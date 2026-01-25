using HwpLib.Object;
using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Control.CtrlHeader.Gso;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent.ShadowInfo;
using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Object.BodyText.Paragraph.Text;
using HwpLib.Object.DocInfo.BinData;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Reader;
using HwpLib.Tool.BlankFileMaker;
using HwpLib.Writer;
using System.Drawing;
using System.IO;
using Section = HwpLib.Object.BodyText.Section;

namespace HwpLibSharp.Test
{
    /// <summary>
    /// 최종 단계: 타이틀 섹션 + 이미지 섹션들 생성 테스트 (Robust Implementation)
    /// </summary>
    [TestClass]
    public class ReportGeneratorTest
    {
        private readonly string _imageFilePath = TestHelper.GetImagePath("sample.jpg");
        private const string ImageFileExt = "jpg";
        private const BinDataCompress CompressMethod = BinDataCompress.ByStorageDefault;

        private int _instanceId = 0x5bb840e1;
        private HWPFile? _hwpFile;

        // 상태값 (매번 갱신됨)
        private int _streamIndex;
        private int _binDataId;
        private ControlRectangle? _rectangle;
        private Rectangle _shapePosition = new Rectangle(50, 50, 100, 100);

        [TestMethod]
        public void GenerateFullReport_ShouldSucceed()
        {
            // Arrange
            var filePath = TestHelper.GetSamplePath("blank.hwp");
            var hwpFile = HWPReader.FromFile(filePath);
            _hwpFile = hwpFile;

            Assert.IsNotNull(hwpFile);

            // Act 1: 첫 번째 섹션 (타이틀)
            var section0 = hwpFile.BodyText.SectionList[0];
            SetTitleToSection(section0, "상세 보고서 (2025-01-25)");

            // Act 2: 두 번째 섹션 (이미지 1)
            var section1 = hwpFile.BodyText.AddNewSection();
            EmptyParagraphAdder.Add(section1);

            // Local File -> MemoryStream 변환 후 API 호출
            string imagePath1 = TestHelper.GetImagePath("sample.jpg");
            byte[] fileBytes1 = File.ReadAllBytes(imagePath1);
            using (var stream1 = new MemoryStream(fileBytes1))
            {
                InsertImageToSection(section1, stream1, "jpg");
            }
            AppendTextToSection(section1, "이것은 이미지에 대한 설명입니다1.");
            AppendTextToSection(section1, "이것은 이미지에 대한 설명입니다1\n이것은 이미지에 대한 설명입니다3.\t이것은 이미지에 대한 설명입니다4");

            // Act 3: 세 번째 섹션 (이미지 2)
            var section2 = hwpFile.BodyText.AddNewSection();
            EmptyParagraphAdder.Add(section2);

            // Local File -> MemoryStream 변환 후 API 호출
            string imagePath2 = TestHelper.GetImagePath("sample.jpg");
            byte[] fileBytes2 = File.ReadAllBytes(imagePath2);
            using (var stream2 = new MemoryStream(fileBytes2))
            {
                InsertImageToSection(section2, stream2, "jpg", autoSize: false);
            }
            AppendTextToSection(section2, "이것은 이미지에 대한 설명입니다2.");

            // [중요 Fix] 섹션 개수를 DocInfo에 반영해야 함
            hwpFile.DocInfo.DocumentProperties.SectionCount = hwpFile.BodyText.SectionList.Count;

            // 파일 잠금 방지를 위해 유니크한 파일명 사용
            string uniqueId = System.Guid.NewGuid().ToString().Substring(0, 8);
            var writePath = TestHelper.GetResultPath($"result-report-generator-{uniqueId}.hwp");
            HWPWriter.ToFile(hwpFile, writePath);

            // Assert
            Assert.IsTrue(File.Exists(writePath), "파일 생성 성공");
            Assert.AreEqual(3, hwpFile.BodyText.SectionList.Count, "섹션 개수 확인");
        }

        [TestMethod]
        public void TestSimpleHwpReport_DreamCode()
        {
            // 사용자가 꿈꾸던 바로 그 코드!
            using var report = new SimpleHwpReport();

            // 1. 제목 설정
            report.SetTitle("AI Model Training Report 2026 (Simple API)");

            // 2. 내용 추가 (이미지 스트림 + 캡션)
            string imagePath1 = TestHelper.GetImagePath("sample.jpg");
            byte[] bytes1 = File.ReadAllBytes(imagePath1);
            using (var stream1 = new MemoryStream(bytes1))
            {
                report.AddContent(stream1, "Loss Landscape Visualization");
            }

            string imagePath2 = TestHelper.GetImagePath("sample.jpg");
            byte[] bytes2 = File.ReadAllBytes(imagePath2);
            using (var stream2 = new MemoryStream(bytes2))
            {
                // AutoSize는 기본 true
                report.AddContent(stream2, "Gradient Descent Optimization Steps", autoSize:false);
            }

            // 3. 저장
            string uniqueId = System.Guid.NewGuid().ToString().Substring(0, 8);
            var writePath = TestHelper.GetResultPath($"result-simple-api-{uniqueId}.hwp");

            report.Save(writePath);

            Assert.IsTrue(File.Exists(writePath));
        }

        private void SetTitleToSection(Section section, string titleText)
        {
            // InsertingHyperLinkTest 참고: 이미 존재하는 문단의 Text에 AddString만 수행
            var paragraph = section.GetParagraph(0);
            if (paragraph?.Text == null) return;

            paragraph.Text.AddString(titleText);
            paragraph.Header.CharacterCount = paragraph.Text.CharList.Count;
        }

        private void AppendTextToSection(Section section, string text)
        {
            // [중요 Fix] 문단을 추가하기 전에, 기존 마지막 문단의 'LastInList' 플래그를 꺼야 함.
            var prevLastPara = section.GetLastParagraph();
            if (prevLastPara != null)
            {
                prevLastPara.Header.LastInList = false;
            }

            // 새 문단 추가 (Caption용)
            // [중요 Fix] EmptyParagraphAdder.Add(section)은 SectionDefine(구역 정의)을 포함하므로 
            // 같은 섹션 내에 일반 문단을 추가하려면 수동으로 Plain Paragraph를 추가해야 함.
            AddPlainParagraph(section);

            // 방금 추가된 마지막 문단 가져오기
            var paragraph = section.GetLastParagraph();
            if (paragraph?.Text == null) return;

            // 텍스트 추가 (InsertingHyperLinkTest 패턴)
            paragraph.Text.AddString(text);
            paragraph.Header.CharacterCount = paragraph.Text.CharList.Count;
        }

        private void AddPlainParagraph(Section section)
        {
            var paragraph = section.AddNewParagraph();

            // Header 설청 (EmptyParagraphAdder.Header2 로직 복사)
            // SectionDefine(ControlMask 4)이 없어야 같은 섹션으로 유지됨
            var header = paragraph.Header;
            header.LastInList = true;
            header.CharacterCount = 0;
            header.ControlMask.Value = 0;
            header.ParaShapeId = 1;
            header.StyleId = 1;
            header.DivideSort.Value = 0;
            header.CharShapeCount = 1;
            header.RangeTagCount = 0;
            header.LineAlignCount = 1;
            header.InstanceID = 0;
            header.IsMergedByTrack = 0;

            // CharShape 생성 (EmptyParagraphAdder.CharShapeInfo 로직)
            paragraph.CreateCharShape();
            paragraph.CharShape!.AddParaCharShape(0, 0);

            // Text 생성
            paragraph.CreateText();
            // Note: LineSeg는 텍스트가 있으면 필요할 수 있으나, 뷰어가 자동 계산하기도 함. 
            // 안전을 위해 EmptyParagraphAdder.LineSeg 로직 일부 차용
            paragraph.CreateLineSeg();
            var item = paragraph.LineSeg!.AddNewLineSegItem();
            item.TextStartPosition = 0;
            item.LineVerticalPosition = 0;
            item.LineHeight = 1000;
            item.TextPartHeight = 1000;
            item.DistanceBaseLineToLineVerticalPosition = 850;
            item.LineSpace = 600;
            item.StartPositionFromColumn = 0;
            item.SegmentWidth = 42520;
            item.Tag.Value = 393216;
        }

        private void InsertImageToSection(Section section, string imagePath, int widthMm = 100, int heightMm = 100, bool autoSize = true)
        {
            if (File.Exists(imagePath))
            {
                // 로컬 파일을 읽어서 MemoryStream으로 변환 (사용자 요청 시나리오)
                byte[] fileBytes = File.ReadAllBytes(imagePath);
                using (var stream = new MemoryStream(fileBytes))
                {
                    // Stream 버전 호출
                    // 확장자는 점 제외 ("jpg")
                    string ext = Path.GetExtension(imagePath).TrimStart('.');
                    InsertImageToSection(section, stream, ext, widthMm, heightMm, autoSize);
                }
            }
        }

        private void InsertImageToSection(Section section, Stream imageStream, string extension, int widthMm = 100, int heightMm = 100, bool autoSize = true)
        {
            // Stream 위치 초기화
            if (imageStream.CanSeek) imageStream.Seek(0, SeekOrigin.Begin);

            if (autoSize)
            {
                try
                {
                    // Stream을 닫지 않도록 주의 (필요 시 복사본 사용)
                    // SKBitmap.Decode는 내부적으로 스트림을 읽음
                    using (var bitmap = SkiaSharp.SKBitmap.Decode(imageStream))
                    {
                        if (bitmap != null)
                        {
                            // 96 DPI 기준: 1 px = 25.4 / 96 mm
                            double scale = 25.4 / 96.0;
                            widthMm = (int)(bitmap.Width * scale);
                            heightMm = (int)(bitmap.Height * scale);
                        }
                    }
                }
                catch { /* Ignore */ }

                // Decode 후 스트림 위치가 끝에 있을 수 있으므로 다시 초기화
                if (imageStream.CanSeek) imageStream.Seek(0, SeekOrigin.Begin);
            }

            // Stream을 byte[]로 변환
            byte[] imageBytes;
            if (imageStream is MemoryStream ms)
            {
                imageBytes = ms.ToArray();
            }
            else
            {
                using (var tempMs = new MemoryStream())
                {
                    imageStream.CopyTo(tempMs);
                    imageBytes = tempMs.ToArray();
                }
            }

            AddBinData(imageBytes, extension);
            _binDataId = AddBinDataInDocInfo(_streamIndex, extension);
            AddGsoControl(section.GetParagraph(0), widthMm, heightMm);
        }

        private void AddBinData(byte[] imageBytes, string extension)
        {
            _streamIndex = _hwpFile!.BinData.EmbeddedBinaryDataList.Count + 1;
            var streamName = GetStreamName(extension);
            _hwpFile.BinData.AddNewEmbeddedBinaryData(streamName, imageBytes, CompressMethod);
        }

        private string GetStreamName(string extension)
        {
            return $"Bin{_streamIndex:X4}.{extension}";
        }

        private int AddBinDataInDocInfo(int streamIndex, string extension)
        {
            var bd = _hwpFile!.DocInfo.AddNewBinData();
            bd.Property.Type = BinDataType.Embedding;
            bd.Property.Compress = CompressMethod;
            bd.Property.State = BinDataState.NotAccess;
            bd.BinDataId = streamIndex;
            bd.ExtensionForEmbedding = extension;
            return _hwpFile.DocInfo.BinDataList.Count;
        }

        private void AddGsoControl(Paragraph targetParagraph, int widthMm, int heightMm)
        {
            _shapePosition = new Rectangle(0, 0, widthMm, heightMm);
            CreateRectangleControl(targetParagraph);
            SetCtrlHeaderGso();
            SetShapeComponent();
            SetShapeComponentRectangle();
        }

        private void CreateRectangleControl(Paragraph paragraph)
        {
            if (paragraph.Text == null) paragraph.CreateText();
            paragraph.Text!.AddExtendCharForGSO();
            _rectangle = (ControlRectangle?)paragraph.AddNewGsoControl(GsoControlType.Rectangle);
        }

        private void SetCtrlHeaderGso()
        {
            var hdr = _rectangle!.GetHeader()!;
            var prop = hdr.Property;
            prop.SetLikeWord(false);
            prop.SetApplyLineSpace(false);
            prop.SetVertRelTo(VertRelTo.Para);
            prop.SetVertRelativeArrange(RelativeArrange.TopOrLeft);
            prop.SetHorzRelTo(HorzRelTo.Para);
            prop.SetHorzRelativeArrange(RelativeArrange.TopOrLeft);
            prop.SetVertRelToParaLimit(true);
            prop.SetAllowOverlap(true);
            prop.SetWidthCriterion(WidthCriterion.Absolute);
            prop.SetHeightCriterion(HeightCriterion.Absolute);
            prop.SetProtectSize(false);
            // [중요 Fix] 이미지가 줄(Line) 전체를 차지하도록 설정하여, 설명글이 자연스럽게 다음 줄로 밀리도록 함.
            prop.SetTextFlowMethod(TextFlowMethod.TakePlace);
            prop.SetTextHorzArrange(TextHorzArrange.BothSides);
            prop.SetObjectNumberSort(ObjectNumberSort.Figure);

            hdr.YOffset = (uint)FromMm(_shapePosition.Y);
            hdr.XOffset = (uint)FromMm(_shapePosition.X);
            hdr.Width = (uint)FromMm(_shapePosition.Width);
            hdr.Height = (uint)FromMm(_shapePosition.Height);
            hdr.ZOrder = 0;
            hdr.OutterMarginLeft = 0;
            hdr.OutterMarginRight = 0;
            hdr.OutterMarginTop = 0;
            hdr.OutterMarginBottom = 0;
            hdr.InstanceId = (uint)_instanceId;
            hdr.PreventPageDivide = false;
            hdr.Explanation.Bytes = null;
        }

        private static int FromMm(int mm)
        {
            if (mm == 0) return 1;
            return (int)((double)mm * 72000.0f / 254.0f + 0.5f);
        }

        private void SetShapeComponent()
        {
            var sc = (ShapeComponentNormal)_rectangle!.ShapeComponent;
            sc.Property.IsRotateWithImage = true;
            sc.OffsetX = 0;
            sc.OffsetY = 0;
            sc.GroupingCount = 0;
            sc.LocalFileVersion = 1;
            sc.WidthAtCreate = FromMm(_shapePosition.Width);
            sc.HeightAtCreate = FromMm(_shapePosition.Height);
            sc.WidthAtCurrent = FromMm(_shapePosition.Width);
            sc.HeightAtCurrent = FromMm(_shapePosition.Height);
            sc.RotateAngle = 0;
            sc.RotateXCenter = FromMm(_shapePosition.Width / 2);
            sc.RotateYCenter = FromMm(_shapePosition.Height / 2);

            sc.CreateLineInfo();
            var li = sc.LineInfo!;
            li.Property.LineEndShape = LineEndShape.Flat;
            li.Property.StartArrowShape = LineArrowShape.None;
            li.Property.StartArrowSize = LineArrowSize.MiddleMiddle;
            li.Property.EndArrowShape = LineArrowShape.None;
            li.Property.EndArrowSize = LineArrowSize.MiddleMiddle;
            li.Property.IsFillStartArrow = true;
            li.Property.IsFillEndArrow = true;
            li.Property.LineType = LineType.None;
            li.OutlineStyle = OutlineStyle.Normal;
            li.Thickness = 0;
            li.Color.Value = 0;

            sc.CreateFillInfo();
            var fi = sc.FillInfo!;
            fi.Type.HasPatternFill = false;
            fi.Type.HasImageFill = true;
            fi.Type.HasGradientFill = false;
            fi.CreateImageFill();
            var imgF = fi.ImageFill!;
            imgF.ImageFillType = ImageFillType.FitSize;
            imgF.PictureInfo.Brightness = 0;
            imgF.PictureInfo.Contrast = 0;
            imgF.PictureInfo.Effect = PictureEffect.RealPicture;
            imgF.PictureInfo.BinItemID = _binDataId;

            sc.CreateShadowInfo();
            var si = sc.ShadowInfo!;
            si.Type = ShadowType.None;
            si.Color.Value = 0xc4c4c4;
            si.OffsetX = 283;
            si.OffsetY = 283;
            si.Transparent = 0;

            sc.SetMatrixsNormal();
        }

        private void SetShapeComponentRectangle()
        {
            var scr = _rectangle!.ShapeComponentRectangle;
            scr.RoundRate = 0;
            scr.X1 = 0;
            scr.Y1 = 0;
            scr.X2 = FromMm(_shapePosition.Width);
            scr.Y2 = 0;
            scr.X3 = FromMm(_shapePosition.Width);
            scr.Y3 = FromMm(_shapePosition.Height);
            scr.X4 = 0;
            scr.Y4 = FromMm(_shapePosition.Height);
        }
    }
}

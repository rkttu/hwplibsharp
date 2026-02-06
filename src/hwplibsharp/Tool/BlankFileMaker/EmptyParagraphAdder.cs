// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/EmptyParagraphAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Object.BodyText.Paragraph.Header;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 빈 문단을 추가하는 클래스
    /// </summary>
    public static class EmptyParagraphAdder
    {
        /// <summary>
        /// 구역에 빈 문단을 추가한다.
        /// </summary>
        /// <param name="section">구역</param>
        public static void Add(Section section)
        {
            var paragraph = section.AddNewParagraph();
            Header(paragraph.Header);
            Text(paragraph);
            CharShapeInfo(paragraph);
            LineSeg(paragraph);
            SectionDefineAdder.Add(paragraph);
            ColumnDefineAdder.Add(paragraph);
        }

        private static void Header(ParaHeader header)
        {
            header.LastInList = true;
            header.CharacterCount = 17;
            header.ControlMask.Value = 4;
            header.ParaShapeId = 3;
            header.StyleId = 0;
            header.DivideSort.Value = 3;
            header.CharShapeCount = 1;
            header.RangeTagCount = 0;
            header.LineAlignCount = 1;
            header.InstanceID = 0;
            header.IsMergedByTrack = 0;
        }

        /// <summary>
        /// 문단 리스트에 빈 문단을 추가한다.
        /// </summary>
        /// <param name="paragraphList">문단 리스트</param>
        public static void Add(ParagraphList paragraphList)
        {
            var paragraph = paragraphList.AddNewParagraph();
            Header2(paragraph.Header);
            CharShapeInfo(paragraph);
        }

        private static void Header2(ParaHeader header)
        {
            header.LastInList = true;
            header.CharacterCount = 17;
            header.ControlMask.Value = 4;
            header.ParaShapeId = 3;
            header.StyleId = 0;
            header.DivideSort.Value = 0;
            header.CharShapeCount = 1;
            header.RangeTagCount = 0;
            header.LineAlignCount = 1;
            header.InstanceID = 0;
            header.IsMergedByTrack = 0;
        }

        private static void Text(Paragraph paragraph)
        {
            paragraph.CreateText();
            var paraText = paragraph.Text!;

            paraText.AddExtendCharForSectionDefine();
            paraText.AddExtendCharForColumnDefine();
        }

        private static void CharShapeInfo(Paragraph paragraph)
        {
            paragraph.CreateCharShape();
            var charShape = paragraph.CharShape!;
            charShape.AddParaCharShape(0, 0);
        }

        private static void LineSeg(Paragraph paragraph)
        {
            paragraph.CreateLineSeg();
            var lineSeg = paragraph.LineSeg!;
            var item = lineSeg.AddNewLineSegItem();
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
    }
}

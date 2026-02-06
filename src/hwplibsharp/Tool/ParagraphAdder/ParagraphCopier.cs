// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/ParagraphCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Tool.ParagraphAdder.Control;
using HwpLib.Tool.ParagraphAdder.DocInfo;
using System;
using Paragraph = HwpLib.Object.BodyText.Paragraph.Paragraph;

namespace HwpLib.Tool.ParagraphAdder
{
    /// <summary>
    /// Paragraph 객체를 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class ParagraphCopier
    {
        private readonly DocInfoAdder? _docInfoAdder;
        private Paragraph? _source;
        private Paragraph? _target;
        private bool _includingSectionInfo;
        private bool _excludedSectionDefine;

        /// <summary>
        /// <see cref="ParagraphCopier"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">문서 정보 추가기 인스턴스입니다. null일 수 있습니다.</param>
        public ParagraphCopier(DocInfoAdder? docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
        }

        /// <summary>
        /// 문단 리스트를 복사한다.
        /// </summary>
        public static void ListCopy(ParagraphList source, ParagraphList target, DocInfoAdder? docInfoAdder)
        {
            var copier = new ParagraphCopier(docInfoAdder);
            foreach (var p in source)
            {
                try
                {
                    copier.Copy(p, target.AddNewParagraph());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// 문단을 복사한다.
        /// </summary>
        public void Copy(Paragraph source, Paragraph target)
        {
            _source = source;
            _target = target;
            _includingSectionInfo = false;

            CopyHeader();
            CopyText();
            CopyCharShapeInfo();
            CopyLineSeg();
            CopyRangeTag();
            CopyControlList();
            CopyMemoList();
        }

        /// <summary>
        /// 구역 정보를 포함하여 문단을 복사한다.
        /// </summary>
        public void CopyIncludingSectionInfo(Paragraph source, Paragraph target)
        {
            _source = source;
            _target = target;
            _includingSectionInfo = true;

            CopyHeader();
            CopyText();
            CopyCharShapeInfo();
            CopyLineSeg();
            CopyRangeTag();
            CopyControlList();
            CopyMemoList();
        }

        private void CopyHeader()
        {
            if (_source?.Header == null || _target == null) return;

            var sourceH = _source.Header;
            var targetH = _target.Header;

            if (sourceH == null || targetH == null) return;

            targetH.LastInList = sourceH.LastInList;
            targetH.CharacterCount = sourceH.CharacterCount;
            targetH.ControlMask.Value = sourceH.ControlMask.Value;
            targetH.ParaShapeId = _docInfoAdder == null ? sourceH.ParaShapeId : _docInfoAdder.ForParaShapeInfo().ProcessById(sourceH.ParaShapeId);
            targetH.StyleId = (short)(_docInfoAdder == null ? sourceH.StyleId : _docInfoAdder.ForStyle().ProcessById(sourceH.StyleId));
            targetH.DivideSort.Value = sourceH.DivideSort.Value;
            targetH.CharShapeCount = sourceH.CharShapeCount;
            targetH.RangeTagCount = sourceH.RangeTagCount;
            targetH.LineAlignCount = sourceH.LineAlignCount;
            targetH.InstanceID = 0;
            targetH.IsMergedByTrack = sourceH.IsMergedByTrack;
        }

        private void CopyText()
        {
            if (_source?.Text == null || _target == null) return;

            _target.CreateText();
            _excludedSectionDefine = ParaTextCopier.Copy(_source.Text!, _target.Text!, _includingSectionInfo);
        }

        private void CopyCharShapeInfo()
        {
            if (_source?.CharShape == null || _target == null) return;

            _target.CreateCharShape();

            foreach (var cpsp in _source.CharShape!.PositionShapeIdPairList)
            {
                if (_excludedSectionDefine && cpsp.Position > 0)
                {
                    _target.CharShape!.AddParaCharShape(
                        cpsp.Position - 8,
                        _docInfoAdder == null ? cpsp.ShapeId : _docInfoAdder.ForCharShapeInfo().ProcessById((int)cpsp.ShapeId));
                }
                else
                {
                    _target.CharShape!.AddParaCharShape(
                        cpsp.Position,
                        _docInfoAdder == null ? cpsp.ShapeId : _docInfoAdder.ForCharShapeInfo().ProcessById((int)cpsp.ShapeId));
                }
            }
        }

        private void CopyLineSeg()
        {
            if (_source?.LineSeg == null || _target == null) return;

            _target.CreateLineSeg();
            foreach (var lsi in _source.LineSeg!.LineSegItemList)
            {
                _target.LineSeg!.AddLineSegItem(lsi.Clone());
            }
        }

        private void CopyRangeTag()
        {
            if (_source?.RangeTag == null || _target == null) return;

            _target.CreateRangeTag();
            foreach (var rti in _source.RangeTag!.RangeTagItemList)
            {
                _target.RangeTag!.AddRangeTagItem(rti.Clone());
            }
        }

        private void CopyControlList()
        {
            if (_source?.ControlList == null || _target == null) return;

            foreach (var c in _source.ControlList!)
            {
                switch (c.Type)
                {
                    case ControlType.Table:
                        {
                            if (_target.AddNewControl(ControlType.Table) is ControlTable targetControl)
                                TableCopier.Copy((ControlTable)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Gso:
                        {
                            var targetControl = _target.AddNewGsoControl(((GsoControl)c).GsoType);
                            if (targetControl != null)
                                GsoCopier.Copy((GsoControl)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Equation:
                        {
                            if (_target.AddNewControl(ControlType.Equation) is ControlEquation targetControl)
                                EquationCopier.Copy((ControlEquation)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.SectionDefine:
                        if (_includingSectionInfo)
                        {
                            if (_target.AddNewControl(ControlType.SectionDefine) is ControlSectionDefine targetControl)
                                SectionDefineCopier.Copy((ControlSectionDefine)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.ColumnDefine:
                        {
                            if (_target.AddNewControl(ControlType.ColumnDefine) is ControlColumnDefine targetControl)
                                ETCControlCopier.CopyColumnDefine((ControlColumnDefine)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Header:
                        if (_includingSectionInfo)
                        {
                            if (_target.AddNewControl(ControlType.Header) is ControlHeader targetControl)
                                ETCControlCopier.CopyHeader((ControlHeader)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Footer:
                        if (_includingSectionInfo)
                        {
                            if (_target.AddNewControl(ControlType.Footer) is ControlFooter targetControl)
                                ETCControlCopier.CopyFooter((ControlFooter)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Footnote:
                        {
                            if (_target.AddNewControl(ControlType.Footnote) is ControlFootnote targetControl)
                                ETCControlCopier.CopyFootnote((ControlFootnote)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Endnote:
                        {
                            if (_target.AddNewControl(ControlType.Endnote) is ControlEndnote targetControl)
                                ETCControlCopier.CopyEndnote((ControlEndnote)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.AutoNumber:
                        {
                            if (_target.AddNewControl(ControlType.AutoNumber) is ControlAutoNumber targetControl)
                                ETCControlCopier.CopyAutoNumber((ControlAutoNumber)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.NewNumber:
                        {
                            if (_target.AddNewControl(ControlType.NewNumber) is ControlNewNumber targetControl)
                                ETCControlCopier.CopyNewNumber((ControlNewNumber)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.PageHide:
                        {
                            if (_target.AddNewControl(ControlType.PageHide) is ControlPageHide targetControl)
                                ETCControlCopier.CopyPageHide((ControlPageHide)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.PageOddEvenAdjust:
                        {
                            if (_target.AddNewControl(ControlType.PageOddEvenAdjust) is ControlPageOddEvenAdjust targetControl)
                                ETCControlCopier.CopyPageOddEvenAdjust((ControlPageOddEvenAdjust)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.PageNumberPosition:
                        {
                            if (_target.AddNewControl(ControlType.PageNumberPosition) is ControlPageNumberPosition targetControl)
                                ETCControlCopier.CopyPageNumberPosition((ControlPageNumberPosition)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.IndexMark:
                        {
                            if (_target.AddNewControl(ControlType.IndexMark) is ControlIndexMark targetControl)
                                ETCControlCopier.CopyIndexMark((ControlIndexMark)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Bookmark:
                        {
                            if (_target.AddNewControl(ControlType.Bookmark) is ControlBookmark targetControl)
                                ETCControlCopier.CopyBookmark((ControlBookmark)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.OverlappingLetter:
                        {
                            if (_target.AddNewControl(ControlType.OverlappingLetter) is ControlOverlappingLetter targetControl)
                                OverlappingLetterCopier.Copy((ControlOverlappingLetter)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.AdditionalText:
                        {
                            if (_target.AddNewControl(ControlType.AdditionalText) is ControlAdditionalText targetControl)
                                AdditionalTextCopier.Copy((ControlAdditionalText)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.HiddenComment:
                        {
                            if (_target.AddNewControl(ControlType.HiddenComment) is ControlHiddenComment targetControl)
                                ETCControlCopier.CopyHiddenComment((ControlHiddenComment)c, targetControl, _docInfoAdder);
                        }
                        break;
                    case ControlType.Form:
                        {
                            if (_target.AddNewControl(ControlType.Form) is ControlForm targetControl)
                                ETCControlCopier.CopyForm((ControlForm)c, targetControl, _docInfoAdder);
                        }
                        break;
                    default:
                        // Field 컨트롤 처리
                        if (c.Type.IsField())
                        {
                            var sourceField = (ControlField)c;
                            if (_target.AddNewControl(sourceField.GetHeader()?.CtrlId ?? 0) is ControlField targetControl)
                                ETCControlCopier.CopyField(sourceField, targetControl, _docInfoAdder);
                        }
                        break;
                }
            }
        }

        private void CopyMemoList()
        {
            CopyMemoList(_source, _target, _docInfoAdder);
        }

        /// <summary>
        /// 소스 문단의 메모 리스트를 대상 문단으로 복사합니다.
        /// </summary>
        /// <remarks>
        /// 현재는 구현되어 있지 않습니다.
        /// </remarks>
        /// <param name="source">복사할 소스 문단</param>
        /// <param name="target">복사 대상 문단</param>
        /// <param name="docInfoAdder">문서 정보 추가기</param>
        public static void CopyMemoList(Paragraph? source, Paragraph? target, DocInfoAdder? docInfoAdder)
        {
            // 메모 리스트 복사 - 추후 구현
            _ = source;
            _ = target;
            _ = docInfoAdder;
        }
    }
}

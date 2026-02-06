// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/ParagraphMerger.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Object.BodyText.Paragraph.Text;
using HwpLib.Tool.ParagraphAdder.Control;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder
{
    /// <summary>
    /// 문단을 병합하는 기능을 포함하는 클래스
    /// </summary>
    public class ParagraphMerger
    {
        private readonly DocInfoAdder? _docInfoAdder;
        private Paragraph? _source;
        private Paragraph? _target;
        private int _targetCharPosition;
        private int _sourceCharPosition;
        private int _sourceCharShapeIndex;
        private int _sourceControlIndex;

        /// <summary>
        /// <see cref="ParagraphMerger"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public ParagraphMerger()
        {
            _docInfoAdder = null;
        }

        /// <summary>
        /// <see cref="ParagraphMerger"/> 클래스의 새 인스턴스를 지정된 <see cref="DocInfoAdder"/>와 함께 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">문서 정보 병합을 위한 <see cref="DocInfoAdder"/> 인스턴스</param>
        public ParagraphMerger(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
        }

        /// <summary>
        /// source 문단을 target 문단에 병합한다.
        /// </summary>
        public void Merge(Paragraph source, Paragraph target)
        {
            _source = source;
            _target = target;

            RemoveLastParaBreakCharFromTarget();
            MoveTextAndCharShapeInfoAndControl();

            DeleteLineSeg();
            DeleteRangeTag();
            CopyMemoList();
        }

        private void RemoveLastParaBreakCharFromTarget()
        {
            if (_target?.Text == null) return;

            var charList = _target.Text!.CharList;
            if (charList.Count > 0)
            {
                var lastChar = charList[charList.Count - 1];
                if (lastChar.Type == HWPCharType.ControlChar && lastChar.Code == 13)
                {
                    _target.Text!.RemoveCharAt(charList.Count - 1);
                }
            }
        }

        private void MoveTextAndCharShapeInfoAndControl()
        {
            if (_target?.Text == null)
            {
                _target?.CreateText();
            }

            if (_source?.Text == null || _target?.Text == null) return;

            _targetCharPosition = _target.Text!.GetCharSize();
            _sourceCharPosition = 0;
            _sourceCharShapeIndex = 0;
            _sourceControlIndex = 0;

            foreach (var hwpChar in _source.Text!.CharList)
            {
                switch (hwpChar.Type)
                {
                    case HWPCharType.Normal:
                        MoveCharAndCharShapeInfo(hwpChar);
                        break;
                    case HWPCharType.ControlChar:
                        MoveCharAndCharShapeInfo(hwpChar);
                        break;
                    case HWPCharType.ControlInline:
                        MoveCharAndCharShapeInfo(hwpChar);
                        break;
                    case HWPCharType.ControlExtend:
                        MoveExtendChar((HWPCharControlExtend)hwpChar);
                        break;
                }

                _sourceCharPosition += hwpChar.CharSize;
            }
        }

        private void MoveCharAndCharShapeInfo(HWPChar hwpChar)
        {
            _target?.Text?.AddChar(hwpChar);
            MoveCharSpace();
            _targetCharPosition += hwpChar.CharSize;
        }

        private void MoveCharSpace()
        {
            if (_source?.CharShape == null || _target?.CharShape == null) return;

            var pairList = _source.CharShape!.PositionShapeIdPairList;
            if (_sourceCharShapeIndex < pairList.Count)
            {
                var cpsip = pairList[_sourceCharShapeIndex];
                if (cpsip.Position <= _sourceCharPosition)
                {
                    _target.CharShape!.AddParaCharShape(
                        _targetCharPosition,
                        _docInfoAdder == null ? cpsip.ShapeId : _docInfoAdder.ForCharShapeInfo().ProcessById((int)cpsip.ShapeId));
                    _sourceCharShapeIndex++;
                }
            }
        }

        private void MoveExtendChar(HWPCharControlExtend hwpChar)
        {
            if (CanMoveExtendChar(hwpChar))
            {
                _target?.Text?.AddChar(hwpChar);
                MoveCharSpace();
                _targetCharPosition += hwpChar.CharSize;

                var controlList = _source?.ControlList;
                if (controlList != null && _sourceControlIndex < controlList.Count)
                {
                    MoveControl(controlList[_sourceControlIndex]);
                }
            }
            _sourceControlIndex++;
        }

        private static bool CanMoveExtendChar(HWPCharControlExtend hwpChar)
        {
            int code = hwpChar.Code;
            return code == 3       // 필드 시작
                || code == 11      // 그리기 개체/표/수식/양식 개체
                || code == 15      // 숨은 설명
                || code == 16      // 머리말/꼬리말
                || code == 17      // 각주/미주
                || code == 18      // 자동번호
                || code == 21      // 페이지 컨트롤
                || code == 22      // 책갈피/찾아보기 표식
                || code == 23;     // 덧말/글자 겹침
        }

        private void MoveControl(HwpLib.Object.BodyText.Control.Control sourceControl)
        {
            if (_target?.ControlList == null)
            {
                _target?.CreateControlList();
            }

            if (_target == null) return;

            switch (sourceControl.Type)
            {
                case ControlType.Table:
                    {
                        if (_target.AddNewControl(ControlType.Table) is ControlTable targetControl)
                            TableCopier.Copy((ControlTable)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Gso:
                    {
                        var targetControl = _target.AddNewGsoControl(((GsoControl)sourceControl).GsoType);
                        if (targetControl != null)
                            GsoCopier.Copy((GsoControl)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Equation:
                    {
                        if (_target.AddNewControl(ControlType.Equation) is ControlEquation targetControl)
                            EquationCopier.Copy((ControlEquation)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Header:
                    {
                        if (_target.AddNewControl(ControlType.Header) is ControlHeader targetControl)
                            ETCControlCopier.CopyHeader((ControlHeader)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Footer:
                    {
                        if (_target.AddNewControl(ControlType.Footer) is ControlFooter targetControl)
                            ETCControlCopier.CopyFooter((ControlFooter)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Footnote:
                    {
                        if (_target.AddNewControl(ControlType.Footnote) is ControlFootnote targetControl)
                            ETCControlCopier.CopyFootnote((ControlFootnote)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Endnote:
                    {
                        if (_target.AddNewControl(ControlType.Endnote) is ControlEndnote targetControl)
                            ETCControlCopier.CopyEndnote((ControlEndnote)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.AutoNumber:
                    {
                        if (_target.AddNewControl(ControlType.AutoNumber) is ControlAutoNumber targetControl)
                            ETCControlCopier.CopyAutoNumber((ControlAutoNumber)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.NewNumber:
                    {
                        if (_target.AddNewControl(ControlType.NewNumber) is ControlNewNumber targetControl)
                            ETCControlCopier.CopyNewNumber((ControlNewNumber)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.PageHide:
                    {
                        if (_target.AddNewControl(ControlType.PageHide) is ControlPageHide targetControl)
                            ETCControlCopier.CopyPageHide((ControlPageHide)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.PageOddEvenAdjust:
                    {
                        if (_target.AddNewControl(ControlType.PageOddEvenAdjust) is ControlPageOddEvenAdjust targetControl)
                            ETCControlCopier.CopyPageOddEvenAdjust((ControlPageOddEvenAdjust)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.PageNumberPosition:
                    {
                        if (_target.AddNewControl(ControlType.PageNumberPosition) is ControlPageNumberPosition targetControl)
                            ETCControlCopier.CopyPageNumberPosition((ControlPageNumberPosition)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.IndexMark:
                    {
                        if (_target.AddNewControl(ControlType.IndexMark) is ControlIndexMark targetControl)
                            ETCControlCopier.CopyIndexMark((ControlIndexMark)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Bookmark:
                    {
                        if (_target.AddNewControl(ControlType.Bookmark) is ControlBookmark targetControl)
                            ETCControlCopier.CopyBookmark((ControlBookmark)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.OverlappingLetter:
                    {
                        if (_target.AddNewControl(ControlType.OverlappingLetter) is ControlOverlappingLetter targetControl)
                            OverlappingLetterCopier.Copy((ControlOverlappingLetter)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.AdditionalText:
                    {
                        if (_target.AddNewControl(ControlType.AdditionalText) is ControlAdditionalText targetControl)
                            AdditionalTextCopier.Copy((ControlAdditionalText)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.HiddenComment:
                    {
                        if (_target.AddNewControl(ControlType.HiddenComment) is ControlHiddenComment targetControl)
                            ETCControlCopier.CopyHiddenComment((ControlHiddenComment)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                case ControlType.Form:
                    {
                        if (_target.AddNewControl(ControlType.Form) is ControlForm targetControl)
                            ETCControlCopier.CopyForm((ControlForm)sourceControl, targetControl, _docInfoAdder);
                    }
                    break;
                default:
                    if (sourceControl.IsField)
                    {
                        var sourceField = (ControlField)sourceControl;
                        if (_target.AddNewControl(sourceField.GetHeader()?.CtrlId ?? 0) is ControlField targetControl)
                            ETCControlCopier.CopyField(sourceField, targetControl, _docInfoAdder);
                    }
                    break;
            }
        }

        private void DeleteLineSeg()
        {
            _target?.DeleteLineSeg();
        }

        private void DeleteRangeTag()
        {
            _target?.DeleteRangeTag();
        }

        private void CopyMemoList()
        {
            ParagraphCopier.CopyMemoList(_source, _target, _docInfoAdder);
        }
    }
}

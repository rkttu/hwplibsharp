// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Writer.BodyText.Control.Form;
using HwpLib.Writer.BodyText.Control.Gso;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControl
    {
        /// <summary>
        /// 컨트롤을 쓴다.
        /// </summary>
        /// <param name="c">컨트롤</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(Object.BodyText.Control.Control c, CompoundStreamWriter sw)
        {
            if (c.Type.IsField())
            {
                ForControlField.Write((ControlField)c, sw);
                return;
            }

            switch (c.Type)
            {
                case ControlType.Table:
                    ForControlTable.Write((ControlTable)c, sw);
                    break;
                case ControlType.Equation:
                    ForControlEquation.Write((ControlEquation)c, sw);
                    break;
                case ControlType.SectionDefine:
                    ForControlSectionDefine.Write((ControlSectionDefine)c, sw);
                    break;
                case ControlType.ColumnDefine:
                    ForControlColumnDefine.Write((ControlColumnDefine)c, sw);
                    break;
                case ControlType.Header:
                    ForControlHeader.Write((ControlHeader)c, sw);
                    break;
                case ControlType.Footer:
                    ForControlFooter.Write((ControlFooter)c, sw);
                    break;
                case ControlType.Footnote:
                    ForControlFootnote.Write((ControlFootnote)c, sw);
                    break;
                case ControlType.Endnote:
                    ForControlEndnote.Write((ControlEndnote)c, sw);
                    break;
                case ControlType.AutoNumber:
                    ForControlAutoNumber.Write((ControlAutoNumber)c, sw);
                    break;
                case ControlType.NewNumber:
                    ForControlNewNumber.Write((ControlNewNumber)c, sw);
                    break;
                case ControlType.PageHide:
                    ForControlPageHide.Write((ControlPageHide)c, sw);
                    break;
                case ControlType.PageOddEvenAdjust:
                    ForControlPageOddEvenAdjust.Write((ControlPageOddEvenAdjust)c, sw);
                    break;
                case ControlType.PageNumberPosition:
                    ForControlPageNumberPosition.Write((ControlPageNumberPosition)c, sw);
                    break;
                case ControlType.IndexMark:
                    ForControlIndexMark.Write((ControlIndexMark)c, sw);
                    break;
                case ControlType.Bookmark:
                    ForControlBookmark.Write((ControlBookmark)c, sw);
                    break;
                case ControlType.OverlappingLetter:
                    ForControlOverlappingLetter.Write((ControlOverlappingLetter)c, sw);
                    break;
                case ControlType.AdditionalText:
                    ForControlAdditionalText.Write((ControlAdditionalText)c, sw);
                    break;
                case ControlType.HiddenComment:
                    ForControlHiddenComment.Write((ControlHiddenComment)c, sw);
                    break;
                case ControlType.Form:
                    ForControlForm.Write((ControlForm)c, sw);
                    break;
                case ControlType.Gso:
                    ForGsoControl.Write((GsoControl)c, sw);
                    break;
                default:
                    break;
            }
        }
    }
}

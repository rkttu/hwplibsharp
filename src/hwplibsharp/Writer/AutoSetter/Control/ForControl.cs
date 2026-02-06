// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Writer.AutoSetter.Control.Gso;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 각각의 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControl
    {
        /// <summary>
        /// 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="c">컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(Object.BodyText.Control.Control c, InstanceID iid)
        {
            if (c.Type.IsField())
            {
                ForControlField.AutoSet((ControlField)c, iid);
            }
            else
            {
                switch (c.Type)
                {
                    case ControlType.AdditionalText:
                        break;
                    case ControlType.AutoNumber:
                        break;
                    case ControlType.Bookmark:
                        break;
                    case ControlType.ColumnDefine:
                        ForControlColumnDefine.AutoSet((ControlColumnDefine)c);
                        break;
                    case ControlType.Endnote:
                        ForControlEndNote.AutoSet((ControlEndnote)c, iid);
                        break;
                    case ControlType.Equation:
                        ForControlEquation.AutoSet((ControlEquation)c, iid);
                        break;
                    case ControlType.Footer:
                        ForControlFooter.AutoSet((ControlFooter)c, iid);
                        break;
                    case ControlType.Footnote:
                        ForControlFootnote.AutoSet((ControlFootnote)c, iid);
                        break;
                    case ControlType.Gso:
                        ForGsoControl.AutoSet((GsoControl)c, iid);
                        break;
                    case ControlType.Header:
                        ForControlHeader.AutoSet((ControlHeader)c, iid);
                        break;
                    case ControlType.HiddenComment:
                        ForControlHiddenComment.AutoSet((ControlHiddenComment)c, iid);
                        break;
                    case ControlType.IndexMark:
                        break;
                    case ControlType.NewNumber:
                        break;
                    case ControlType.OverlappingLetter:
                        break;
                    case ControlType.PageHide:
                        break;
                    case ControlType.PageNumberPosition:
                        break;
                    case ControlType.PageOddEvenAdjust:
                        break;
                    case ControlType.SectionDefine:
                        ForControlSectionDefine.AutoSet((ControlSectionDefine)c, iid);
                        break;
                    case ControlType.Table:
                        ForControlTable.AutoSet((ControlTable)c, iid);
                        break;
                    case ControlType.Form:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

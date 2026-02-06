// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/forfield/gettext/ForControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using System.Collections.Generic;
using System.Text;

namespace HwpLib.Tool.ObjectFinder.ForField.GetText
{
    /// <summary>
    /// 컨트롤에 포함된 필드의 텍스트를 가져오는 기능을 포함한 클래스
    /// </summary>
    public class ForControlGetText
    {
        /// <summary>
        /// 컨트롤 리스트에서 필드 텍스트를 가져온다.
        /// </summary>
        /// <param name="controls">컨트롤 리스트</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="sb">문자열 버퍼</param>
        public static void GetFieldText(IList<Control>? controls, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            if (controls == null)
                return;

            foreach (var control in controls)
            {
                GetFieldText(control, fieldType, fieldName, sb);
            }
        }

        /// <summary>
        /// 컨트롤에서 필드 텍스트를 가져온다.
        /// </summary>
        /// <param name="c">컨트롤</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="sb">문자열 버퍼</param>
        public static void GetFieldText(Control c, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            if (c.IsField)
                return;

            switch (c.Type)
            {
                case ControlType.Table:
                    Table((ControlTable)c, fieldType, fieldName, sb);
                    break;
                case ControlType.Gso:
                    ForGsoGetText.GetFieldText((GsoControl)c, fieldType, fieldName, sb);
                    break;
                case ControlType.Header:
                    Header((ControlHeader)c, fieldType, fieldName, sb);
                    break;
                case ControlType.Footer:
                    Footer((ControlFooter)c, fieldType, fieldName, sb);
                    break;
                case ControlType.Footnote:
                    Footnote((ControlFootnote)c, fieldType, fieldName, sb);
                    break;
                case ControlType.Endnote:
                    Endnote((ControlEndnote)c, fieldType, fieldName, sb);
                    break;
                case ControlType.HiddenComment:
                    HiddenComment((ControlHiddenComment)c, fieldType, fieldName, sb);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 표 컨트롤에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Table(ControlTable table, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            foreach (var row in table.RowList)
            {
                foreach (var cell in row.CellList)
                {
                    string? text = ForParagraphList.GetFieldText(cell.ParagraphList, fieldType, fieldName);
                    if (text != null)
                    {
                        sb.Append(text);
                    }
                }
            }
        }

        /// <summary>
        /// 머리말 컨트롤에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Header(ControlHeader header, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            string? text = ForParagraphList.GetFieldText(header.ParagraphList, fieldType, fieldName);
            if (text != null)
            {
                sb.Append(text);
            }
        }

        /// <summary>
        /// 꼬리말 컨트롤에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Footer(ControlFooter footer, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            string? text = ForParagraphList.GetFieldText(footer.ParagraphList, fieldType, fieldName);
            if (text != null)
            {
                sb.Append(text);
            }
        }

        /// <summary>
        /// 각주 컨트롤에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Footnote(ControlFootnote footnote, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            string? text = ForParagraphList.GetFieldText(footnote.ParagraphList, fieldType, fieldName);
            if (text != null)
            {
                sb.Append(text);
            }
        }

        /// <summary>
        /// 미주 컨트롤에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Endnote(ControlEndnote endnote, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            string? text = ForParagraphList.GetFieldText(endnote.ParagraphList, fieldType, fieldName);
            if (text != null)
            {
                sb.Append(text);
            }
        }

        /// <summary>
        /// 숨은 설명 컨트롤에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void HiddenComment(ControlHiddenComment hiddenComment, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            string? text = ForParagraphList.GetFieldText(hiddenComment.ParagraphList, fieldType, fieldName);
            if (text != null)
            {
                sb.Append(text);
            }
        }
    }
}

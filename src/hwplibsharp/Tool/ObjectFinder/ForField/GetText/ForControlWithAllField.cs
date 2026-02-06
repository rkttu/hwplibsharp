// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/forfield/gettext/ForControlWithAllField.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using System.Collections.Generic;

namespace HwpLib.Tool.ObjectFinder.ForField.GetText
{
    /// <summary>
    /// 컨트롤에 포함된 모든 필드의 텍스트를 가져오는 기능을 포함한 클래스
    /// </summary>
    public class ForControlWithAllField
    {
        /// <summary>
        /// 컨트롤 리스트에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        /// <param name="controls">컨트롤 리스트</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="results">결과 리스트</param>
        public static void GetFieldText(IList<Control>? controls, ControlType fieldType, string fieldName, List<string> results)
        {
            if (controls == null)
                return;

            foreach (var control in controls)
            {
                GetFieldText(control, fieldType, fieldName, results);
            }
        }

        /// <summary>
        /// 컨트롤에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        /// <param name="c">컨트롤</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="results">결과 리스트</param>
        public static void GetFieldText(Control c, ControlType fieldType, string fieldName, List<string> results)
        {
            if (c.IsField)
                return;

            switch (c.Type)
            {
                case ControlType.Table:
                    Table((ControlTable)c, fieldType, fieldName, results);
                    break;
                case ControlType.Gso:
                    ForGsoWithAllField.GetFieldText((GsoControl)c, fieldType, fieldName, results);
                    break;
                case ControlType.Header:
                    Header((ControlHeader)c, fieldType, fieldName, results);
                    break;
                case ControlType.Footer:
                    Footer((ControlFooter)c, fieldType, fieldName, results);
                    break;
                case ControlType.Footnote:
                    Footnote((ControlFootnote)c, fieldType, fieldName, results);
                    break;
                case ControlType.Endnote:
                    Endnote((ControlEndnote)c, fieldType, fieldName, results);
                    break;
                case ControlType.HiddenComment:
                    HiddenComment((ControlHiddenComment)c, fieldType, fieldName, results);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 표 컨트롤에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Table(ControlTable table, ControlType fieldType, string fieldName, List<string> results)
        {
            foreach (var row in table.RowList)
            {
                foreach (var cell in row.CellList)
                {
                    ForParagraphList.GetAllFieldText(cell.ParagraphList, fieldType, fieldName, results);
                }
            }
        }

        /// <summary>
        /// 머리말 컨트롤에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Header(ControlHeader header, ControlType fieldType, string fieldName, List<string> results)
        {
            ForParagraphList.GetAllFieldText(header.ParagraphList, fieldType, fieldName, results);
        }

        /// <summary>
        /// 꼬리말 컨트롤에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Footer(ControlFooter footer, ControlType fieldType, string fieldName, List<string> results)
        {
            ForParagraphList.GetAllFieldText(footer.ParagraphList, fieldType, fieldName, results);
        }

        /// <summary>
        /// 각주 컨트롤에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Footnote(ControlFootnote footnote, ControlType fieldType, string fieldName, List<string> results)
        {
            ForParagraphList.GetAllFieldText(footnote.ParagraphList, fieldType, fieldName, results);
        }

        /// <summary>
        /// 미주 컨트롤에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Endnote(ControlEndnote endnote, ControlType fieldType, string fieldName, List<string> results)
        {
            ForParagraphList.GetAllFieldText(endnote.ParagraphList, fieldType, fieldName, results);
        }

        /// <summary>
        /// 숨은 설명 컨트롤에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void HiddenComment(ControlHiddenComment hiddenComment, ControlType fieldType, string fieldName, List<string> results)
        {
            ForParagraphList.GetAllFieldText(hiddenComment.ParagraphList, fieldType, fieldName, results);
        }
    }
}

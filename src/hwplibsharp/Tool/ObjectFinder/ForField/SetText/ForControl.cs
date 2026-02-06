// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/forfield/settext/ForControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using System.Collections.Generic;

namespace HwpLib.Tool.ObjectFinder.ForField.SetText
{
    /// <summary>
    /// 컨트롤에 포함된 필드의 텍스트를 설정하는 기능을 포함한 클래스
    /// </summary>
    public class ForControlSetText
    {
        /// <summary>
        /// 컨트롤 리스트에서 필드 텍스트를 설정한다.
        /// </summary>
        /// <param name="controls">컨트롤 리스트</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="textBuffer">텍스트 버퍼</param>
        /// <returns>필드 설정 결과값</returns>
        public static SetFieldResult SetFieldText(IList<Control>? controls, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            if (controls == null)
                return SetFieldResult.InProcess;

            foreach (var control in controls)
            {
                SetFieldResult result = SetFieldText(control, fieldType, fieldName, textBuffer);
                if (result == SetFieldResult.NotEnoughText)
                {
                    return SetFieldResult.NotEnoughText;
                }
            }

            return SetFieldResult.InProcess;
        }

        /// <summary>
        /// 컨트롤에서 필드 텍스트를 설정한다.
        /// </summary>
        /// <param name="c">컨트롤</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="textBuffer">텍스트 버퍼</param>
        /// <returns>필드 설정 결과값</returns>
        public static SetFieldResult SetFieldText(Control c, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            if (c.IsField)
                return SetFieldResult.InProcess;

            return c.Type switch
            {
                ControlType.Table => Table((ControlTable)c, fieldType, fieldName, textBuffer),
                ControlType.Gso => ForGsoSetText.SetFieldText((GsoControl)c, fieldType, fieldName, textBuffer),
                ControlType.Header => Header((ControlHeader)c, fieldType, fieldName, textBuffer),
                ControlType.Footer => Footer((ControlFooter)c, fieldType, fieldName, textBuffer),
                ControlType.Footnote => Footnote((ControlFootnote)c, fieldType, fieldName, textBuffer),
                ControlType.Endnote => Endnote((ControlEndnote)c, fieldType, fieldName, textBuffer),
                ControlType.HiddenComment => HiddenComment((ControlHiddenComment)c, fieldType, fieldName, textBuffer),
                _ => SetFieldResult.InProcess,
            };
        }

        /// <summary>
        /// 표 컨트롤에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Table(ControlTable table, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            foreach (var row in table.RowList)
            {
                foreach (var cell in row.CellList)
                {
                    SetFieldResult result = ForParagraphList.SetFieldText(cell.ParagraphList, fieldType, fieldName, textBuffer);
                    if (result == SetFieldResult.NotEnoughText)
                    {
                        return SetFieldResult.NotEnoughText;
                    }
                }
            }
            return SetFieldResult.InProcess;
        }

        /// <summary>
        /// 머리말 컨트롤에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Header(ControlHeader header, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return ForParagraphList.SetFieldText(header.ParagraphList, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 꼬리말 컨트롤에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Footer(ControlFooter footer, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return ForParagraphList.SetFieldText(footer.ParagraphList, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 각주 컨트롤에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Footnote(ControlFootnote footnote, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return ForParagraphList.SetFieldText(footnote.ParagraphList, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 미주 컨트롤에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Endnote(ControlEndnote endnote, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return ForParagraphList.SetFieldText(endnote.ParagraphList, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 숨은 설명 컨트롤에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult HiddenComment(ControlHiddenComment hiddenComment, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return ForParagraphList.SetFieldText(hiddenComment.ParagraphList, fieldType, fieldName, textBuffer);
        }
    }
}

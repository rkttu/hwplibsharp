// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/FieldFinder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object;
using HwpLib.Object.BodyText.Control;
using HwpLib.Tool.TextExtractor;
using System.Collections.Generic;
using ForParagraphListField = HwpLib.Tool.ObjectFinder.ForField.ForParagraphList;

namespace HwpLib.Tool.ObjectFinder
{
    /// <summary>
    /// 필드 객체를 찾는 기능을 포함하는 클래스
    /// </summary>
    public static class FieldFinder
    {
        /// <summary>
        /// 누름틀 컨트롤(ClickHere 필드)을 찾아 텍스트를 반환한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="fieldName">필드 이름</param>
        /// <returns>필드 텍스트</returns>
        public static string? GetClickHereText(HWPFile hwpFile, string fieldName/*, TextExtractMethod temInField*/)
        {
            string? strText = null;
            foreach (var s in hwpFile.BodyText.SectionList)
            {
                strText = ForParagraphListField.GetFieldText(s, ControlType.FIELD_CLICKHERE, fieldName);
                if (strText != null)
                {
                    break;
                }
            }
            return strText;
        }

        /// <summary>
        /// 파일 안에 이름이 같은 모든 누름틀 컨트롤(ClickHere 필드)을 찾아 텍스트를 리스트에 추가한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="fieldName">필드 이름</param>
        /// <returns>필드 텍스트 리스트</returns>
        public static List<string> GetAllClickHereText(HWPFile hwpFile, string fieldName/*, TextExtractMethod temInField*/)
        {
            var textList = new List<string>();
            foreach (var s in hwpFile.BodyText.SectionList)
            {
                ForParagraphListField.GetAllFieldText(s, ControlType.FIELD_CLICKHERE, fieldName, textList);
            }

            return textList;
        }

        /// <summary>
        /// 누름틀 컨트롤(ClickHere 필드)를 찾아 텍스트를 설정한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="textList">텍스트 리스트</param>
        /// <returns>필드 설정 결과값</returns>
        public static SetFieldResult SetClickHereText(HWPFile hwpFile, string fieldName, List<string> textList)
        {
            if (textList.Count == 0)
            {
                return SetFieldResult.ETCError;
            }
            var textBuffer = new TextBuffer(textList);
            foreach (var s in hwpFile.BodyText.SectionList)
            {
                if (ForParagraphListField.SetFieldText(s, ControlType.FIELD_CLICKHERE, fieldName, textBuffer) == SetFieldResult.NotEnoughText)
                {
                    return SetFieldResult.NotEnoughText;
                }
            }
            if (textBuffer.UsedAll())
            {
                return SetFieldResult.SetAllText;
            }
            else if (textBuffer.NotUsed())
            {
                return SetFieldResult.NotFound;
            }
            return SetFieldResult.TextRemains;
        }

        /// <summary>
        /// 필드 컨트롤을 찾아 텍스트를 반환한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <returns>필드 텍스트</returns>
        public static string? GetFieldText(HWPFile hwpFile, ControlType fieldType, string fieldName/*, TextExtractMethod temInField*/)
        {
            string? strText = null;
            foreach (var s in hwpFile.BodyText.SectionList)
            {
                strText = ForParagraphListField.GetFieldText(s, fieldType, fieldName);
                if (strText != null)
                {
                    break;
                }
            }
            return strText;
        }

        /// <summary>
        /// 파일 안에 이름이 같은 모든 필드를 찾아 텍스트를 리스트에 추가한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <returns>필드 텍스트 리스트</returns>
        public static List<string> GetAllFieldText(HWPFile hwpFile, ControlType fieldType, string fieldName/*, TextExtractMethod temInField*/)
        {
            var textList = new List<string>();
            foreach (var s in hwpFile.BodyText.SectionList)
            {
                ForParagraphListField.GetAllFieldText(s, fieldType, fieldName, textList);
            }
            return textList;
        }

        /// <summary>
        /// 필드를 찾아 텍스트를 설정한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="textList">텍스트 리스트</param>
        /// <returns>필드 설정 결과값</returns>
        public static SetFieldResult SetFieldText(HWPFile hwpFile, ControlType fieldType, string fieldName, List<string> textList)
        {
            if (!fieldType.IsField() || textList.Count == 0)
            {
                return SetFieldResult.ETCError;
            }

            var textBuffer = new TextBuffer(textList);
            foreach (var s in hwpFile.BodyText.SectionList)
            {
                if (ForParagraphListField.SetFieldText(s, fieldType, fieldName, textBuffer) == SetFieldResult.NotEnoughText)
                {
                    return SetFieldResult.NotEnoughText;
                }
            }
            if (textBuffer.UsedAll())
            {
                return SetFieldResult.SetAllText;
            }
            else if (textBuffer.NotUsed())
            {
                return SetFieldResult.NotFound;
            }
            return SetFieldResult.TextRemains;
        }
    }
}

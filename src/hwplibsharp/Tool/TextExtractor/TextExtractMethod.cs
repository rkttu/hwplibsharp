// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/TextExtractMethod.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 텍스트 추출 방법
    /// </summary>
    public enum TextExtractMethod
    {
        /// <summary>
        /// 메인 문단에 포함된 텍스트만 추출함
        /// </summary>
        OnlyMainParagraph,

        /// <summary>
        /// 컨트롤의 텍스트를 문단 텍스트 사이에 삽입하여 추출함
        /// </summary>
        InsertControlTextBetweenParagraphText,

        /// <summary>
        /// 컨트롤의 텍스트를 문단 텍스트 뒤에 추가하여 추출함
        /// </summary>
        AppendControlTextAfterParagraphText
    }
}

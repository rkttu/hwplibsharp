// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/TextExtractorListener.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 텍스트 추출 리스너 인터페이스
    /// </summary>
    public interface ITextExtractorListener
    {
        /// <summary>
        /// 단락의 텍스트를 처리합니다.
        /// </summary>
        /// <param name="text">단락에서 추출된 텍스트입니다.</param>
        void ParagraphText(string text);
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/TextExtractor.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object;
using HwpLib.Tool.TextExtractor.ParaHead;
using System.Text;

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 한글 파일에서 텍스트를 추출하는 객체
    /// </summary>
    public static class TextExtractor
    {
        /// <summary>
        /// 텍스트를 추출한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="tem">추출 방법</param>
        /// <returns>추출된 문자열</returns>
        public static string Extract(HWPFile hwpFile, TextExtractMethod tem)
        {
            return Extract(hwpFile, new TextExtractOption(tem));
        }

        /// <summary>
        /// 텍스트를 추출한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="option">추출 옵션</param>
        /// <returns>추출된 문자열</returns>
        public static string Extract(HWPFile hwpFile, TextExtractOption option)
        {
            var sb = new StringBuilder();
            var paraHeadMaker = new ParaHeadMaker(hwpFile);

            var sectionList = hwpFile.BodyText?.SectionList;
            if (sectionList != null)
            {
                foreach (var s in sectionList)
                {
                    paraHeadMaker.StartSection(s);
                    ForParagraphList.Extract(s, option, paraHeadMaker, sb);
                    paraHeadMaker.EndSection();
                }
            }
            return sb.ToString();
        }
    }
}

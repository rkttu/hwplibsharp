// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForParagraphList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText;

namespace HwpLib.Writer.BodyText.Paragraph
{
    /// <summary>
    /// 문단 리스트를 쓰기 위한 객체
    /// </summary>
    public static class ForParagraphList
    {
        /// <summary>
        /// 문단 리스트를 쓴다.
        /// </summary>
        /// <param name="pl">문단 리스트</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(IParagraphList pl, CompoundStreamWriter sw)
        {
            foreach (var p in pl)
            {
                ForParagraph.Write(p, sw);
            }
        }
    }
}

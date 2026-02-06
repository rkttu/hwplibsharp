// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForSection.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText;
using HwpLib.Writer.BodyText.Control.SectionDefine;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText
{
    /// <summary>
    /// 구역을 쓰기 위한 객체
    /// </summary>
    public static class ForSection
    {
        /// <summary>
        /// 구역을 쓴다.
        /// </summary>
        /// <param name="s">구역</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(Section s, CompoundStreamWriter sw)
        {
            ForParagraphList.Write(s, sw);

            if (s.LastBatangPageInfo != null)
            {
                sw.UpRecordLevel();
                ForBatangPageInfo.Write(s.LastBatangPageInfo, sw);
                sw.DownRecordLevel();
            }
        }
    }
}

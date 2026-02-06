// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForParagraph.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Writer.BodyText.Control;

namespace HwpLib.Writer.BodyText.Paragraph
{
    /// <summary>
    /// 문단을 쓰기 위한 객체
    /// </summary>
    public static class ForParagraph
    {
        /// <summary>
        /// 문단을 쓴다.
        /// </summary>
        /// <param name="p">문단</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(Object.BodyText.Paragraph.Paragraph p, CompoundStreamWriter sw)
        {
            ForParaHeader.Write(p.Header, sw);
            sw.UpRecordLevel();

            ForParaText.Write(p, sw);
            ForParaCharShape.Write(p.CharShape, sw);
            ForParaLineSeg.Write(p.LineSeg, sw);
            ForParaRangeTag.Write(p.RangeTag, sw);
            Controls(p, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 문단에 포함된 컨트롤들을 쓴다.
        /// </summary>
        /// <param name="p">문단</param>
        /// <param name="sw">스트림 라이터</param>
        private static void Controls(Object.BodyText.Paragraph.Paragraph p, CompoundStreamWriter sw)
        {
            if (p.ControlList == null)
            {
                return;
            }

            foreach (var c in p.ControlList)
            {
                ForControl.Write(c, sw);
            }
        }
    }
}

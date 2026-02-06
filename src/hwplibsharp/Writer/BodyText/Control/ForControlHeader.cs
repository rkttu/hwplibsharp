// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.HeaderFooter;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 머리말 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlHeader
    {
        /// <summary>
        /// 머리말 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlHeader h, CompoundStreamWriter sw)
        {
            CtrlHeader(h.Header, sw);

            sw.UpRecordLevel();

            ForListHeaderForHeaderFooter.Write(h.ListHeader, sw);
            ForParagraphList.Write(h.ParagraphList, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 머리말 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderHeader h, CompoundStreamWriter sw)
        {
            RecordHeader(sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteUInt4((uint)h.ApplyPage);
            sw.WriteSInt4(h.CreateIndex);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, 12);
        }
    }
}

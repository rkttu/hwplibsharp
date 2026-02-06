// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlFooter.java
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
    /// 꼬리말 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlFooter
    {
        /// <summary>
        /// 꼬리말 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlFooter f, CompoundStreamWriter sw)
        {
            CtrlHeader(f.Header, sw);

            sw.UpRecordLevel();

            ForListHeaderForHeaderFooter.Write(f.ListHeader, sw);
            ForParagraphList.Write(f.ParagraphList, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 꼬리말 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderFooter h, CompoundStreamWriter sw)
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

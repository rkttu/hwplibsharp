// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlEndnote.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Endnote;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 미주 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlEndnote
    {
        /// <summary>
        /// 미주 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlEndnote en, CompoundStreamWriter sw)
        {
            CtrlHeader(en.Header, sw);

            sw.UpRecordLevel();

            ForListHeaderForFootnoteEndnote.Write(en.ListHeader, sw);
            ForParagraphList.Write(en.ParagraphList, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 미주 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderEndnote h, CompoundStreamWriter sw)
        {
            RecordHeader(sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteUInt4(h.Number);
            sw.WriteWChar(h.BeforeDecorationLetter.Bytes ?? new byte[2]);
            sw.WriteWChar(h.AfterDecorationLetter.Bytes ?? new byte[2]);
            sw.WriteUInt4((uint)h.NumberShape);
            sw.WriteUInt4(h.InstanceId);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, 20);
        }
    }
}

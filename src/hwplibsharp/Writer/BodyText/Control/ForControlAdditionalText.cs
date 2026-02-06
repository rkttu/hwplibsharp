// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlAdditionalText.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 덧말 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlAdditionalText
    {
        /// <summary>
        /// 덧말 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlAdditionalText at, CompoundStreamWriter sw)
        {
            CtrlHeader(at.GetHeader()!, sw);
        }

        /// <summary>
        /// 덧말 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderAdditionalText h, CompoundStreamWriter sw)
        {
            RecordHeader(h, sw);
            sw.WriteUInt4(h.CtrlId);
            sw.WriteHWPString(h.MainText);
            sw.WriteHWPString(h.SubText);
            sw.WriteUInt4((uint)h.Position);
            sw.WriteUInt4(h.Fsizeratio);
            sw.WriteUInt4(h.Option);
            sw.WriteUInt4(h.StyleId);
            sw.WriteUInt4((uint)h.Alignment);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CtrlHeaderAdditionalText h, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, GetSize(h));
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(CtrlHeaderAdditionalText h)
        {
            int size = 4;
            size += h.MainText.GetWCharsSize();
            size += h.SubText.GetWCharsSize();
            size += 20;
            return size;
        }
    }
}

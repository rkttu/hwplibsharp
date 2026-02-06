// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlIndexMark.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 찾아보기 표식 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlIndexMark
    {
        /// <summary>
        /// 찾아보기 표식 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlIndexMark im, CompoundStreamWriter sw)
        {
            CtrlHeader(im.GetHeader()!, sw);
        }

        /// <summary>
        /// 찾아보기 표식 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderIndexMark h, CompoundStreamWriter sw)
        {
            RecordHeader(h, sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteHWPString(h.Keyword1);
            sw.WriteHWPString(h.Keyword2);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CtrlHeaderIndexMark h, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, GetSize(h));
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(CtrlHeaderIndexMark h)
        {
            int size = 4;
            size += h.Keyword1.GetWCharsSize();
            size += h.Keyword2.GetWCharsSize();
            return size;
        }
    }
}

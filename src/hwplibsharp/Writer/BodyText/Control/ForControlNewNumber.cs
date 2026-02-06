// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlNewNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 새 번호 지정 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlNewNumber
    {
        /// <summary>
        /// 새 번호 지정 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlNewNumber nn, CompoundStreamWriter sw)
        {
            CtrlHeader(nn.GetHeader()!, sw);
        }

        /// <summary>
        /// 새 번호 지정 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderNewNumber h, CompoundStreamWriter sw)
        {
            RecordHeader(sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteUInt4(h.Property.Value);
            sw.WriteUInt2(h.Number);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, 10);
        }
    }
}

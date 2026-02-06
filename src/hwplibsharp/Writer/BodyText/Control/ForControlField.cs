// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlField.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Bookmark;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 필드 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlField
    {
        /// <summary>
        /// 필드 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlField f, CompoundStreamWriter sw)
        {
            CtrlHeader(f.GetHeader()!, sw);

            sw.UpRecordLevel();

            ForCtrlData.Write(f.GetCtrlData(), sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 필드 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderField h, CompoundStreamWriter sw)
        {
            RecordHeader(h, sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteUInt4(h.Property.Value);
            sw.WriteUInt1(h.EtcProperty);
            sw.WriteHWPString(h.Command);
            sw.WriteUInt4(h.InstanceId);

            if (h.CtrlId == ControlType.FIELD_UNKNOWN.GetCtrlId())
            {
                sw.WriteSInt4(h.MemoIndex);
            }
            else
            {
                sw.WriteZero(4);
            }
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CtrlHeaderField h, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, GetSize(h));
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(CtrlHeaderField h)
        {
            int size = 9;
            size += h.Command.GetWCharsSize();
            size += 8;
            return size;
        }
    }
}

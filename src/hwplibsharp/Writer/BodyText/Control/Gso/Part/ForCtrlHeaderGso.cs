// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/part/ForCtrlHeaderGso.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;
using HwpLib.Util.Binary;

namespace HwpLib.Writer.BodyText.Control.Gso.Part
{
    /// <summary>
    /// 그리기 개체의 컨트롤 헤더 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForCtrlHeaderGso
    {
        /// <summary>
        /// 그리기 개체의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        public static void Write(CtrlHeaderGso h, CompoundStreamWriter sw)
        {
            RecordHeader(h, sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteUInt4(h.Property.Value);
            sw.WriteUInt4(h.YOffset);
            sw.WriteUInt4(h.XOffset);
            sw.WriteUInt4(h.Width);
            sw.WriteUInt4(h.Height);
            sw.WriteSInt4(h.ZOrder);
            sw.WriteUInt2(h.OutterMarginLeft);
            sw.WriteUInt2(h.OutterMarginRight);
            sw.WriteUInt2(h.OutterMarginTop);
            sw.WriteUInt2(h.OutterMarginBottom);
            sw.WriteUInt4(h.InstanceId);
            int temp = 0;
            temp = BitFlag.Set(temp, 0, h.PreventPageDivide);
            sw.WriteSInt4(temp);
            sw.WriteHWPString(h.Explanation);
            if (h.Unknown != null)
            {
                sw.WriteBytes(h.Unknown);
            }
        }

        /// <summary>
        /// 그리기 개체의 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CtrlHeaderGso h, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, GetSize(h));
        }

        /// <summary>
        /// 그리기 개체의 컨트롤 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(CtrlHeaderGso h)
        {
            int size = 0;
            size += 44;
            size += h.Explanation.GetWCharsSize();
            if (h.Unknown != null)
            {
                size += h.Unknown.Length;
            }
            return size;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/secd/ForPageBorderFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.SectionDefine;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Secd
{
    /// <summary>
    /// 쪽 테두리/배경 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForPageBorderFill
    {
        /// <summary>
        /// 쪽 테두리/배경 레코드를 쓴다.
        /// </summary>
        public static void Write(PageBorderFill pbf, CompoundStreamWriter sw)
        {
            if (pbf == null)
            {
                return;
            }

            RecordHeader(sw);

            sw.WriteUInt4(pbf.Property.Value);
            sw.WriteUInt2((ushort)pbf.LeftGap);
            sw.WriteUInt2((ushort)pbf.RightGap);
            sw.WriteUInt2((ushort)pbf.TopGap);
            sw.WriteUInt2((ushort)pbf.BottomGap);
            sw.WriteUInt2(pbf.BorderFillId);
        }

        /// <summary>
        /// 쪽 테두리/배경 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.PageBorderFill, 14);
        }
    }
}

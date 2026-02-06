// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/headerfooter/ForListHeaderForHeaderFooter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.HeaderFooter;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.HeaderFooter
{
    /// <summary>
    /// 머리말/꼬리말 컨트롤의 리스트 헤더 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForListHeaderForHeaderFooter
    {
        /// <summary>
        /// 머리말/꼬리말 컨트롤의 리스트 헤더 레코드를 쓴다.
        /// </summary>
        public static void Write(ListHeaderForHeaderFooter lh, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt4(lh.ParaCount);
            sw.WriteUInt4(lh.Property.Value);
            sw.WriteUInt4(lh.TextWidth);
            sw.WriteUInt4(lh.TextHeight);
            sw.WriteZero(18);
        }

        /// <summary>
        /// 머리말/꼬리말 컨트롤의 리스트 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ListHeader, 34);
        }
    }
}

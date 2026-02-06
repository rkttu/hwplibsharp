// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/secd/ForBatangPageInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.SectionDefine;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText.Control.Secd
{
    /// <summary>
    /// 바탕쪽 정보를 쓰기 위한 객체
    /// </summary>
    public static class ForBatangPageInfo
    {
        /// <summary>
        /// 바탕쪽 정보를 쓴다.
        /// </summary>
        public static void Write(BatangPageInfo bpi, CompoundStreamWriter sw)
        {
            ListHeader(bpi.ListHeader, sw);
            ForParagraphList.Write(bpi.ParagraphList, sw);
        }

        /// <summary>
        /// 바탕쪽 정보의 리스트 헤더 레코드를 쓴다.
        /// </summary>
        private static void ListHeader(ListHeaderForBatangPage lh, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt4(lh.ParaCount);
            sw.WriteUInt4(lh.Property.Value);
            sw.WriteUInt4(lh.TextWidth);
            sw.WriteUInt4(lh.TextHeight);
            sw.WriteZero(18);
        }

        /// <summary>
        /// 바탕쪽 정보의 리스트 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ListHeader, 34);
        }
    }
}

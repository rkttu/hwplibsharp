// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForParaRangeTag.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.RangeTag;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Paragraph
{
    /// <summary>
    /// 문서의 영역 테그 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForParaRangeTag
    {
        /// <summary>
        /// 문서의 영역 테그 레코드를 쓴다.
        /// </summary>
        /// <param name="prt">문서의 영역 테그 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(ParaRangeTag? prt, CompoundStreamWriter sw)
        {
            if (prt == null)
            {
                return;
            }

            RecordHeader(prt, sw);

            foreach (var rti in prt.RangeTagItemList)
            {
                RangeTagItem(rti, sw);
            }
        }

        /// <summary>
        /// 문서의 영역 테그 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ParaRangeTag prt, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ParaRangeTag, GetSize(prt));
        }

        /// <summary>
        /// 문서의 영역 테그 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ParaRangeTag prt)
        {
            return prt.RangeTagItemList.Count * 12;
        }

        /// <summary>
        /// 영역 태그 정보을 쓴다.
        /// </summary>
        private static void RangeTagItem(RangeTagItem rti, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(rti.RangeStart);
            sw.WriteUInt4(rti.RangeEnd);
            sw.WriteBytes(rti.Data ?? new byte[3], 3);
            sw.WriteUInt1(rti.Sort);
        }
    }
}

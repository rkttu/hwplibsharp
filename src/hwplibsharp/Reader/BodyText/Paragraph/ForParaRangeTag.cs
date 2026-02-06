// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/ForParaRangeTag.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;

namespace HwpLib.Reader.BodyText.Paragraph
{
    /// <summary>
    /// 문서의 영역 테그 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForParaRangeTag
    {
        /// <summary>
        /// 문서의 영역 태그 레코드를 읽는다.
        /// </summary>
        /// <param name="prt">문단 객체</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(HwpLib.Object.BodyText.Paragraph.RangeTag.ParaRangeTag prt, CompoundStreamReader sr)
        {
            // 레코드 크기 / 12 = 항목 수 (RangeStart 4바이트 + RangeEnd 4바이트 + Data 3바이트 + Sort 1바이트 = 12바이트)
            // Writer의 기준: RangeStart 4바이트, RangeEnd 4바이트, Data 3바이트, Sort 1바이트 = 총 12바이트
            int count = (int)(sr.CurrentRecordHeader!.Size / 12);

            for (int i = 0; i < count; i++)
            {
                var item = prt.AddNewRangeTagItem();

                item.RangeStart = sr.ReadUInt4();
                item.RangeEnd = sr.ReadUInt4();
                byte[] data = sr.ReadBytes(3);
                item.SetData(data);
                item.Sort = sr.ReadSInt1();
            }
        }
    }
}

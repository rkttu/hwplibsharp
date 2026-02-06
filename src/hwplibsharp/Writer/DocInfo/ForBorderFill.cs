// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForBorderFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo.BorderFill;
using HwpLib.Object.Etc;
using HwpLib.Writer.DocInfo.BorderFill;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 테두리/배경 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForBorderFill
    {
        /// <summary>
        /// 테두리/배경 레코드를 쓴다.
        /// </summary>
        /// <param name="bf">테두리/배경 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(Object.DocInfo.BorderFillInfo bf, CompoundStreamWriter sw)
        {
            RecordHeader(bf, sw);

            sw.WriteUInt2(bf.Property.Value);

            EachBorder(bf.LeftBorder, sw);
            EachBorder(bf.RightBorder, sw);
            EachBorder(bf.TopBorder, sw);
            EachBorder(bf.BottomBorder, sw);
            EachBorder(bf.DiagonalBorder, sw);

            ForFillInfo.Write(bf.FillInfo, sw);
        }

        /// <summary>
        /// 테두리/배경 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="bf">테두리/배경 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(Object.DocInfo.BorderFillInfo bf, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.BorderFill, GetSize(bf));
        }

        /// <summary>
        /// 테두리/배경 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="bf">테두리/배경 레코드</param>
        /// <returns>테두리/배경 레코드의 크기</returns>
        private static int GetSize(Object.DocInfo.BorderFillInfo bf)
        {
            int size = 0;
            size += 2;
            size += (1 + 1 + 4) * 5;
            size += ForFillInfo.GetSize(bf.FillInfo);
            return size;
        }

        /// <summary>
        /// 4방향의 테두리를 표현하는 각각의 선을 쓴다.
        /// </summary>
        /// <param name="eb">4방향의 테두리를 표현하는 각각의 선</param>
        /// <param name="sw">스트림 라이터</param>
        private static void EachBorder(EachBorder eb, CompoundStreamWriter sw)
        {
            sw.WriteUInt1((byte)eb.Type);
            sw.WriteUInt1((byte)eb.Thickness);
            sw.WriteUInt4(eb.Color.Value);
        }
    }
}

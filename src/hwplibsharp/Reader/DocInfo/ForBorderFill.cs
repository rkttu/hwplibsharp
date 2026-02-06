// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForBorderFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.BorderFill;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Reader.DocInfo.BorderFill;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 테두리/배경 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForBorderFill
    {
        /// <summary>
        /// 테두리/배경 레코드를 읽는다.
        /// </summary>
        /// <param name="bf">테두리/배경 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(BorderFillInfo bf, CompoundStreamReader sr)
        {
            ReadProperty(bf.Property, sr);
            ReadEachBorder(bf.LeftBorder, sr);
            ReadEachBorder(bf.RightBorder, sr);
            ReadEachBorder(bf.TopBorder, sr);
            ReadEachBorder(bf.BottomBorder, sr);
            ReadEachBorder(bf.DiagonalBorder, sr);
            ReadFillInfo(bf.FillInfo, sr);
        }

        /// <summary>
        /// 속성 부분을 읽는다.
        /// </summary>
        /// <param name="p">테두리/배경 속성 부분 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadProperty(BorderFillProperty p, CompoundStreamReader sr)
        {
            p.Value = sr.ReadUInt2();
        }

        /// <summary>
        /// 4방향의 테두리/대각선를 표현하는 각각의 선를 읽는다.
        /// </summary>
        /// <param name="eb">4방향의 테두리/대각선를 표현하는 각각 선 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadEachBorder(EachBorder eb, CompoundStreamReader sr)
        {
            eb.Type = BorderTypeExtensions.FromValue(sr.ReadUInt1());
            eb.Thickness = BorderThicknessExtensions.FromValue(sr.ReadUInt1());
            eb.Color.Value = sr.ReadUInt4();
        }

        /// <summary>
        /// 배경 정보을 읽는다.
        /// </summary>
        /// <param name="fi">배경 정보 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadFillInfo(FillInfo fi, CompoundStreamReader sr)
        {
            ForFillInfo.Read(fi, sr);
        }
    }
}

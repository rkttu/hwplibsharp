// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/BorderFillAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.BorderFill;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 테두리/배경 정보를 추가하는 클래스
    /// </summary>
    public static class BorderFillInfoAdder
    {
        /// <summary>
        /// 테두리/배경 정보를 추가한다.
        /// </summary>
        /// <param name="docInfo">문서 정보</param>
        public static void Add(DocInfo docInfo)
        {
            BorderFillInfo1(docInfo.AddNewBorderFill());
            BorderFillInfo2(docInfo.AddNewBorderFill());
        }

        private static void BorderFillInfo1(BorderFillInfo bf)
        {
            bf.Property.Value = 0;
            Border(bf.LeftBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.RightBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.LeftBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.TopBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.BottomBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.DiagonalBorder, BorderType.Solid, BorderThickness.MM0_1, 0);
            bf.FillInfo.Type.Value = 0;
        }

        private static void Border(EachBorder border, BorderType type, BorderThickness thickness, uint color)
        {
            border.Type = type;
            border.Thickness = thickness;
            border.Color.Value = color;
        }

        private static void BorderFillInfo2(BorderFillInfo bf)
        {
            bf.Property.Value = 0;
            Border(bf.LeftBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.RightBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.LeftBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.TopBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.BottomBorder, BorderType.None, BorderThickness.MM0_1, 0);
            Border(bf.DiagonalBorder, BorderType.Solid, BorderThickness.MM0_1, 0);
            bf.FillInfo.Type.HasPatternFill = true;
            bf.FillInfo.CreatePatternFill();
            var pf = bf.FillInfo.PatternFill!;
            pf.BackColor.Value = 0xFFFFFFFF; // -1 in unsigned
            pf.PatternColor.Value = 0xFF000000; // -16777216 in unsigned
            pf.PatternType = PatternType.None;
        }
    }
}

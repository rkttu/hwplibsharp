using System;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{

    /// <summary>
    /// 색상 효과 종류
    /// </summary>
    public enum ColorEffectSort : int
    {
        Alpha = 0,
        AlphaMod = 1,
        AlphaOff = 2,
        Red = 3,
        RedMod = 4,
        RedOff = 5,
        Green = 6,
        GreenMod = 7,
        GreenOff = 8,
        Blue = 9,
        BlueMod = 10,
        BlueOff = 11,
        Hue = 12,
        HueMod = 13,
        HueOff = 14,
        Sat = 15,
        SatMod = 16,
        SatOff = 17,
        Lum = 18,
        LumMod = 19,
        LumOff = 20,
        Shade = 21,
        Tint = 22,
        Gray = 23,
        Comp = 24,
        Gamma = 25,
        InvGamma = 26,
        Inv = 27,
    }

    /// <summary>
    /// ColorEffectSort 확장 메서드
    /// </summary>
    public static class ColorEffectSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static int GetValue(this ColorEffectSort sort)
            => (int)sort + 500;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ColorEffectSort FromValue(int value)
        {
#if NET5_0_OR_GREATER
            // .NET 5+ uses AOT-compatible Enum.GetValues<T>
            foreach (ColorEffectSort ces in System.Enum.GetValues<ColorEffectSort>())
#else
            // .NET Framework / .NET Standard uses reflection-based approach (AOT not applicable)
            foreach (ColorEffectSort ces in (ColorEffectSort[])System.Enum.GetValues(typeof(ColorEffectSort)))
#endif
            {
                if ((int)ces == value || (int)ces + 500 == value)
                {
                    return ces;
                }
            }
            return ColorEffectSort.Alpha;
        }
    }

}
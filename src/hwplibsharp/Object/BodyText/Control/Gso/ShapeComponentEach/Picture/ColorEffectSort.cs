// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/ColorEffectSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 색상 효과 종류
    /// </summary>
    public enum ColorEffectSort : int
    {
        /// <summary>
        /// 투명도(Alpha) 효과
        /// </summary>
        Alpha = 0,
        /// <summary>
        /// 투명도(Alpha) 조정 효과
        /// </summary>
        AlphaMod = 1,
        /// <summary>
        /// 투명도(Alpha) 오프셋 효과
        /// </summary>
        AlphaOff = 2,
        /// <summary>
        /// 빨간색(Red) 효과
        /// </summary>
        Red = 3,
        /// <summary>
        /// 빨간색(Red) 조정 효과
        /// </summary>
        RedMod = 4,
        /// <summary>
        /// 빨간색(Red) 오프셋 효과
        /// </summary>
        RedOff = 5,
        /// <summary>
        /// 초록색(Green) 효과
        /// </summary>
        Green = 6,
        /// <summary>
        /// 초록색(Green) 조정 효과
        /// </summary>
        GreenMod = 7,
        /// <summary>
        /// 초록색(Green) 오프셋 효과
        /// </summary>
        GreenOff = 8,
        /// <summary>
        /// 파란색(Blue) 효과
        /// </summary>
        Blue = 9,
        /// <summary>
        /// 파란색(Blue) 조정 효과
        /// </summary>
        BlueMod = 10,
        /// <summary>
        /// 파란색(Blue) 오프셋 효과
        /// </summary>
        BlueOff = 11,
        /// <summary>
        /// 색상(Hue) 효과
        /// </summary>
        Hue = 12,
        /// <summary>
        /// 색상(Hue) 조정 효과
        /// </summary>
        HueMod = 13,
        /// <summary>
        /// 색상(Hue) 오프셋 효과
        /// </summary>
        HueOff = 14,
        /// <summary>
        /// 채도(Saturation) 효과
        /// </summary>
        Sat = 15,
        /// <summary>
        /// 채도(Saturation) 조정 효과
        /// </summary>
        SatMod = 16,
        /// <summary>
        /// 채도(Saturation) 오프셋 효과
        /// </summary>
        SatOff = 17,
        /// <summary>
        /// 명도(Luminance) 효과
        /// </summary>
        Lum = 18,
        /// <summary>
        /// 명도(Luminance) 조정 효과
        /// </summary>
        LumMod = 19,
        /// <summary>
        /// 명도(Luminance) 오프셋 효과
        /// </summary>
        LumOff = 20,
        /// <summary>
        /// 음영(Shade) 효과
        /// </summary>
        Shade = 21,
        /// <summary>
        /// 색조(Tint) 효과
        /// </summary>
        Tint = 22,
        /// <summary>
        /// 회색조(Gray) 효과
        /// </summary>
        Gray = 23,
        /// <summary>
        /// 보색(Complement) 효과
        /// </summary>
        Comp = 24,
        /// <summary>
        /// 감마(Gamma) 효과
        /// </summary>
        Gamma = 25,
        /// <summary>
        /// 역감마(Inverse Gamma) 효과
        /// </summary>
        InvGamma = 26,
        /// <summary>
        /// 반전(Invert) 효과
        /// </summary>
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

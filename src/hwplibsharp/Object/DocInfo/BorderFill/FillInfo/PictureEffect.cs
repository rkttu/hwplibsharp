// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/PictureEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 그림 효과
    /// </summary>
    public enum PictureEffect : byte
    {
        /// <summary>
        /// 실제이미지(REAL_PIC)
        /// </summary>
        RealPicture = 0,

        /// <summary>
        /// 회색톤 (GRAY_SCALE)
        /// </summary>
        GrayScale = 1,

        /// <summary>
        /// 흑백 (BLACK_WHITE)
        /// </summary>
        BlackWhite = 2,

        /// <summary>
        /// PATTERN8x8
        /// </summary>
        Pattern8x8 = 3,
    }

    /// <summary>
    /// PictureEffect 확장 메서드
    /// </summary>
    public static class PictureEffectExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this PictureEffect effect)
            => (byte)effect;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static PictureEffect FromValue(byte value)
            => value switch
            {
                0 => PictureEffect.RealPicture,
                1 => PictureEffect.GrayScale,
                2 => PictureEffect.BlackWhite,
                3 => PictureEffect.Pattern8x8,
                _ => PictureEffect.RealPicture,
            };
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/GradientType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 그러데이션 유형
    /// </summary>
    public enum GradientType : byte
    {
        /// <summary>
        /// 줄무늬형
        /// </summary>
        Stripe = 1,

        /// <summary>
        /// 원형
        /// </summary>
        Circle = 2,

        /// <summary>
        /// 원뿔형
        /// </summary>
        Cone = 3,

        /// <summary>
        /// 사각형
        /// </summary>
        Square = 4,
    }

    /// <summary>
    /// GradientType 확장 메서드
    /// </summary>
    public static class GradientTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this GradientType type)
            => (byte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static GradientType FromValue(byte value)
            => value switch
            {
                1 => GradientType.Stripe,
                2 => GradientType.Circle,
                3 => GradientType.Cone,
                4 => GradientType.Square,
                _ => GradientType.Stripe,
            };
    }
}

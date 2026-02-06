// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/ShadowSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 그림자 종류
    /// </summary>
    public enum ShadowSort : byte
    {
        /// <summary>없음</summary>
        None = 0,
        /// <summary>비연속</summary>
        Discontinuous = 1,
        /// <summary>연속</summary>
        Continuous = 2
    }

    /// <summary>
    /// 그림자 종류에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class ShadowSortExtensions
    {
        /// <summary>
        /// <see cref="ShadowSort"/> 열거형 값을 byte 값으로 반환합니다.
        /// </summary>
        /// <param name="sort">변환할 <see cref="ShadowSort"/> 값입니다.</param>
        /// <returns>byte 값으로 변환된 그림자 종류입니다.</returns>
        public static byte GetValue(this ShadowSort sort) => (byte)sort;

        /// <summary>
        /// byte 값을 <see cref="ShadowSort"/> 열거형 값으로 변환합니다.
        /// </summary>
        /// <param name="value">변환할 byte 값입니다.</param>
        /// <returns>변환된 <see cref="ShadowSort"/> 값입니다.</returns>
        public static ShadowSort FromValue(byte value) => value switch
        {
            0 => ShadowSort.None,
            1 => ShadowSort.Discontinuous,
            2 => ShadowSort.Continuous,
            _ => ShadowSort.None
        };
    }
}

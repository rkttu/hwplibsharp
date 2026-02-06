// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/OutterLineSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 외곽선 종류
    /// </summary>
    public enum OutterLineSort : byte
    {
        /// <summary>없음</summary>
        None = 0,
        /// <summary>실선</summary>
        Solid = 1,
        /// <summary>점선</summary>
        Dot = 2,
        /// <summary>굵은 실선(두꺼운 선)</summary>
        BoldSolid = 3,
        /// <summary>쇄선(긴 점선)</summary>
        Dash = 4,
        /// <summary>일점쇄선 (-.-.-.-.)</summary>
        DashDot = 5,
        /// <summary>이점쇄선 (-..-..-..)</summary>
        DashDotDot = 6
    }

    /// <summary>
    /// <c>OutterLineSort</c> 열거형에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class OutterLineSortExtensions
    {
        /// <summary>
        /// <see cref="OutterLineSort"/> 값을 byte로 반환합니다.
        /// </summary>
        /// <param name="sort">변환할 <see cref="OutterLineSort"/> 값입니다.</param>
        /// <returns>byte 값으로 변환된 <see cref="OutterLineSort"/> 값입니다.</returns>
        public static byte GetValue(this OutterLineSort sort) => (byte)sort;

        /// <summary>
        /// byte 값을 <see cref="OutterLineSort"/> 열거형 값으로 변환합니다.
        /// </summary>
        /// <param name="value">변환할 byte 값입니다.</param>
        /// <returns>변환된 <see cref="OutterLineSort"/> 값입니다. 유효하지 않은 값인 경우 <see cref="OutterLineSort.None"/>을 반환합니다.</returns>
        public static OutterLineSort FromValue(byte value) => value switch
        {
            0 => OutterLineSort.None,
            1 => OutterLineSort.Solid,
            2 => OutterLineSort.Dot,
            3 => OutterLineSort.BoldSolid,
            4 => OutterLineSort.Dash,
            5 => OutterLineSort.DashDot,
            6 => OutterLineSort.DashDotDot,
            _ => OutterLineSort.None
        };
    }
}

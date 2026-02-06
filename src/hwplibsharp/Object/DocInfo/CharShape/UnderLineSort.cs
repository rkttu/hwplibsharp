// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/UnderLineSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 밑줄 종류
    /// </summary>
    public enum UnderLineSort : byte
    {
        /// <summary>없음</summary>
        None = 0,
        /// <summary>글자 아래</summary>
        Bottom = 1,
        /// <summary>글자 가운데</summary>
        Middle = 2,
        /// <summary>글자 위</summary>
        Top = 3
    }

    /// <summary>
    /// <c>UnderLineSort</c> 열거형에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class UnderLineSortExtensions
    {
        /// <summary>
        /// <see cref="UnderLineSort"/> 값을 byte로 반환합니다.
        /// </summary>
        /// <param name="sort">변환할 <see cref="UnderLineSort"/> 값입니다.</param>
        /// <returns>byte로 변환된 값입니다.</returns>
        public static byte GetValue(this UnderLineSort sort) => (byte)sort;

        /// <summary>
        /// byte 값을 <see cref="UnderLineSort"/> 열거형 값으로 변환합니다.
        /// </summary>
        /// <param name="value">변환할 byte 값입니다.</param>
        /// <returns>변환된 <see cref="UnderLineSort"/> 값입니다.</returns>
        public static UnderLineSort FromValue(byte value) => value switch
        {
            0 => UnderLineSort.None,
            1 => UnderLineSort.Bottom,
            2 => UnderLineSort.Middle,
            3 => UnderLineSort.Top,
            _ => UnderLineSort.None
        };
    }
}

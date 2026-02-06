// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/EmphasisSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 강조점 종류
    /// </summary>
    public enum EmphasisSort : byte
    {
        /// <summary>없음</summary>
        None = 0,
        /// <summary>위에 점</summary>
        DotAbove = 1,
        /// <summary>위에 고리</summary>
        RingAbove = 2,
        /// <summary>물결표</summary>
        Tilde = 3,
        /// <summary>캐런(ˇ)</summary>
        Caron = 4,
        /// <summary>옆에 점</summary>
        Side = 5,
        /// <summary>쌍점(:)</summary>
        Colon = 6,
        /// <summary>Grave 악센트(`)</summary>
        GraveAccent = 7,
        /// <summary>Acute 악센트(´)</summary>
        AcuteAccent = 8,
        /// <summary>곡절 부호(^)</summary>
        Circumflex = 9,
        /// <summary>마크론(¯)</summary>
        Macron = 10,
        /// <summary>위에 갈고리</summary>
        HookAbove = 11,
        /// <summary>아래에 점</summary>
        DotBelow = 12
    }

    /// <summary>
    /// <c>EmphasisSort</c> 열거형에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class EmphasisSortExtensions
    {
        /// <summary>
        /// <see cref="EmphasisSort"/> 값을 byte로 반환합니다.
        /// </summary>
        /// <param name="sort">변환할 <see cref="EmphasisSort"/> 값입니다.</param>
        /// <returns>해당 <see cref="EmphasisSort"/> 값의 byte 표현입니다.</returns>
        public static byte GetValue(this EmphasisSort sort) => (byte)sort;

        /// <summary>
        /// byte 값을 <see cref="EmphasisSort"/> 열거형 값으로 변환합니다.
        /// </summary>
        /// <param name="value">변환할 byte 값입니다.</param>
        /// <returns>해당 byte 값에 대응하는 <see cref="EmphasisSort"/> 값입니다. 범위를 벗어나면 <see cref="EmphasisSort.None"/>을 반환합니다.</returns>
        public static EmphasisSort FromValue(byte value) => value switch
        {
            0 => EmphasisSort.None,
            1 => EmphasisSort.DotAbove,
            2 => EmphasisSort.RingAbove,
            3 => EmphasisSort.Tilde,
            4 => EmphasisSort.Caron,
            5 => EmphasisSort.Side,
            6 => EmphasisSort.Colon,
            7 => EmphasisSort.GraveAccent,
            8 => EmphasisSort.AcuteAccent,
            9 => EmphasisSort.Circumflex,
            10 => EmphasisSort.Macron,
            11 => EmphasisSort.HookAbove,
            12 => EmphasisSort.DotBelow,
            _ => EmphasisSort.None
        };
    }
}

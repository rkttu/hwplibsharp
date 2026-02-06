// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/LineSpaceSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 줄 간격 종류 (한글 2007 이하 버전에서만 사용)
    /// </summary>
    public enum LineSpaceSort : byte
    {
        /// <summary>
        /// 글자에 따라(%)
        /// </summary>
        RatioForLetter = 0,

        /// <summary>
        /// 고정값
        /// </summary>
        FixedValue = 1,

        /// <summary>
        /// 여백만 지정
        /// </summary>
        OnlyMargin = 2,

        /// <summary>
        /// 최소
        /// </summary>
        AtLeast = 3
    }

    /// <summary>
    /// LineSpaceSort 확장 메서드
    /// </summary>
    public static class LineSpaceSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this LineSpaceSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static LineSpaceSort FromValue(byte value)
        {
            return value switch
            {
                0 => LineSpaceSort.RatioForLetter,
                1 => LineSpaceSort.FixedValue,
                2 => LineSpaceSort.OnlyMargin,
                3 => LineSpaceSort.AtLeast,
                _ => LineSpaceSort.RatioForLetter
            };
        }
    }
}

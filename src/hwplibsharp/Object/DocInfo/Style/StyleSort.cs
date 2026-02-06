// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/style/StyleSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.Style
{
    /// <summary>
    /// 스타일 종류
    /// </summary>
    public enum StyleSort : byte
    {
        /// <summary>
        /// 문단 스타일
        /// </summary>
        ParaStyle = 0,

        /// <summary>
        /// 글자 스타일
        /// </summary>
        CharStyle = 1
    }

    /// <summary>
    /// StyleSort 확장 메서드
    /// </summary>
    public static class StyleSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this StyleSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static StyleSort FromValue(byte value)
        {
            return value switch
            {
                0 => StyleSort.ParaStyle,
                1 => StyleSort.CharStyle,
                _ => StyleSort.ParaStyle
            };
        }
    }
}

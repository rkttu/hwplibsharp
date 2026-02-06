// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/DiagonalSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// 대각선 종류
    /// </summary>
    public enum DiagonalSort : byte
    {
        /// <summary>
        /// Slash
        /// </summary>
        Slash = 0,

        /// <summary>
        /// BackSlash
        /// </summary>
        BackSlash = 1,

        /// <summary>
        /// CrookedSlash
        /// </summary>
        CrookedSlash = 2
    }

    /// <summary>
    /// DiagonalSort 확장 메서드
    /// </summary>
    public static class DiagonalSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="sort">DiagonalSort 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this DiagonalSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static DiagonalSort FromValue(byte value)
        {
            return value switch
            {
                0 => DiagonalSort.Slash,
                1 => DiagonalSort.BackSlash,
                2 => DiagonalSort.CrookedSlash,
                _ => DiagonalSort.Slash
            };
        }
    }
}

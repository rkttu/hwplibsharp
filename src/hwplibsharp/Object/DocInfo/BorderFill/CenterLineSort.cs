// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/CenterLineSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// 중심선 종류
    /// </summary>
    public enum CenterLineSort : byte
    {
        /// <summary>
        /// 선없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 수평선
        /// </summary>
        Horizontal = 1,

        /// <summary>
        /// 수직선
        /// </summary>
        Vertical = 2,

        /// <summary>
        /// 교차
        /// </summary>
        Cross = 3
    }

    /// <summary>
    /// CenterLineSort 확장 메서드
    /// </summary>
    public static class CenterLineSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="sort">CenterLineSort 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this CenterLineSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static CenterLineSort FromValue(byte value)
        {
            return value switch
            {
                0 => CenterLineSort.None,
                1 => CenterLineSort.Horizontal,
                2 => CenterLineSort.Vertical,
                3 => CenterLineSort.Cross,
                _ => CenterLineSort.None
            };
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/columndefine/ColumnSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.ColumnDefine
{
    /// <summary>
    /// 단 종류
    /// </summary>
    public enum ColumnSort : byte
    {
        /// <summary>
        /// 일반 다단
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 배분 다단
        /// </summary>
        Distribution = 1,

        /// <summary>
        /// 평행 다단
        /// </summary>
        Parallel = 2
    }

    /// <summary>
    /// ColumnSort 확장 메서드
    /// </summary>
    public static class ColumnSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="sort">ColumnSort 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this ColumnSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static ColumnSort FromValue(byte value)
        {
            return value switch
            {
                0 => ColumnSort.Normal,
                1 => ColumnSort.Distribution,
                2 => ColumnSort.Parallel,
                _ => ColumnSort.Normal
            };
        }
    }
}

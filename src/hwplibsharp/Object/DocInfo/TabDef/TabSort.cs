// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/tabdef/TabSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.TabDef
{
    /// <summary>
    /// 탭의 종류
    /// </summary>
    public enum TabSort : byte
    {
        /// <summary>
        /// 왼쪽
        /// </summary>
        Left = 0,

        /// <summary>
        /// 오른쪽
        /// </summary>
        Right = 1,

        /// <summary>
        /// 가운데
        /// </summary>
        Center = 2,

        /// <summary>
        /// 소수점
        /// </summary>
        DecimalPoint = 3
    }

    /// <summary>
    /// TabSort 확장 메서드
    /// </summary>
    public static class TabSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this TabSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static TabSort FromValue(byte value)
        {
            return value switch
            {
                0 => TabSort.Left,
                1 => TabSort.Right,
                2 => TabSort.Center,
                3 => TabSort.DecimalPoint,
                _ => TabSort.Left
            };
        }
    }
}

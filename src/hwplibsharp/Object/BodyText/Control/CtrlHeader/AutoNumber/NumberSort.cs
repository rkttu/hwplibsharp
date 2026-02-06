// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/autonumber/NumberSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.AutoNumber
{
    /// <summary>
    /// 번호 종류
    /// </summary>
    public enum NumberSort : byte
    {
        /// <summary>
        /// 쪽 번호
        /// </summary>
        Page = 0,

        /// <summary>
        /// 각주 번호
        /// </summary>
        FootNote = 1,

        /// <summary>
        /// 미주 번호
        /// </summary>
        EndNote = 2,

        /// <summary>
        /// 그림 번호
        /// </summary>
        Picture = 3,

        /// <summary>
        /// 표 번호
        /// </summary>
        Table = 4,

        /// <summary>
        /// 수식 번호
        /// </summary>
        Equation = 5
    }

    /// <summary>
    /// NumberSort 확장 메서드
    /// </summary>
    public static class NumberSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="sort">NumberSort 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this NumberSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static NumberSort FromValue(byte value)
        {
            return value switch
            {
                0 => NumberSort.Page,
                1 => NumberSort.FootNote,
                2 => NumberSort.EndNote,
                3 => NumberSort.Picture,
                4 => NumberSort.Table,
                5 => NumberSort.Equation,
                _ => NumberSort.Page
            };
        }
    }
}

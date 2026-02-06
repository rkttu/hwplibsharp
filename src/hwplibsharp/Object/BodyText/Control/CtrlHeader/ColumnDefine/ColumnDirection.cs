// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/columndefine/ColumnDirection.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.ColumnDefine
{
    /// <summary>
    /// 단 방향
    /// </summary>
    public enum ColumnDirection : byte
    {
        /// <summary>
        /// 왼쪽부터
        /// </summary>
        FromLeft = 0,

        /// <summary>
        /// 오른쪽부터
        /// </summary>
        FromRight = 1,

        /// <summary>
        /// 맞쪽
        /// </summary>
        Both = 2
    }

    /// <summary>
    /// ColumnDirection 확장 메서드
    /// </summary>
    public static class ColumnDirectionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="direction">ColumnDirection 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this ColumnDirection direction)
        {
            return (byte)direction;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static ColumnDirection FromValue(byte value)
        {
            return value switch
            {
                0 => ColumnDirection.FromLeft,
                1 => ColumnDirection.FromRight,
                2 => ColumnDirection.Both,
                _ => ColumnDirection.FromLeft
            };
        }
    }
}

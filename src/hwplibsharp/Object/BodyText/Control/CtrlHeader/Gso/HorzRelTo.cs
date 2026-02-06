// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/HorzRelTo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 가로 위치의 기준
    /// </summary>
    public enum HorzRelTo : byte
    {
        /// <summary>
        /// 종이
        /// </summary>
        Paper = 0,

        /// <summary>
        /// 쪽
        /// </summary>
        Page = 1,

        /// <summary>
        /// 단
        /// </summary>
        Column = 2,

        /// <summary>
        /// 문단
        /// </summary>
        Para = 3
    }

    /// <summary>
    /// HorzRelTo 확장 메서드
    /// </summary>
    public static class HorzRelToExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this HorzRelTo horzRelTo) => (byte)horzRelTo;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static HorzRelTo FromValue(byte value) => value switch
        {
            0 => HorzRelTo.Paper,
            1 => HorzRelTo.Page,
            2 => HorzRelTo.Column,
            3 => HorzRelTo.Para,
            _ => HorzRelTo.Paper
        };
    }
}

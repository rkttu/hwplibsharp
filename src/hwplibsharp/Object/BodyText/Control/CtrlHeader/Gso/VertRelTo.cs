// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/VertRelTo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 세로 위치의 기준
    /// </summary>
    public enum VertRelTo : byte
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
        /// 문단
        /// </summary>
        Para = 2
    }

    /// <summary>
    /// VertRelTo 확장 메서드
    /// </summary>
    public static class VertRelToExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this VertRelTo vertRelTo) => (byte)vertRelTo;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static VertRelTo FromValue(byte value) => value switch
        {
            0 => VertRelTo.Paper,
            1 => VertRelTo.Page,
            2 => VertRelTo.Para,
            _ => VertRelTo.Paper
        };
    }
}

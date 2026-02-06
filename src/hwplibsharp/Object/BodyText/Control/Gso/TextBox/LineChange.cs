// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/textbox/LineChange.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.TextBox
{
    /// <summary>
    /// 문단의 줄바꿈 방법
    /// </summary>
    public enum LineChange : byte
    {
        /// <summary>
        /// 일반적인 줄바꿈
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 자간을 조종하여 한 줄을 유지
        /// </summary>
        KeepOneLineByAdjustWordSpace = 1,

        /// <summary>
        /// 내용에 따라 폭이 늘어남
        /// </summary>
        IncreaseWidthByContent = 2,
    }

    /// <summary>
    /// LineChange 열거형에 대한 확장 메서드
    /// </summary>
    public static class LineChangeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="lineChange">LineChange 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this LineChange lineChange) => (byte)lineChange;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static LineChange FromValue(byte value) => value switch
        {
            0 => LineChange.Normal,
            1 => LineChange.KeepOneLineByAdjustWordSpace,
            2 => LineChange.IncreaseWidthByContent,
            _ => LineChange.Normal,
        };
    }
}

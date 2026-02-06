// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/NumberingMethod.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 번호매김 방법
    /// </summary>
    public enum NumberingMethod : byte
    {
        /// <summary>
        /// 앞 구역에 이어서
        /// </summary>
        Continue = 0,

        /// <summary>
        /// 현재 구역부터 새로 시작
        /// </summary>
        Restart = 1,

        /// <summary>
        /// 쪽마다 새로 시작(각주 전용)
        /// </summary>
        RestartAtEachPage = 2
    }

    /// <summary>
    /// NumberingMethod enum에 대한 확장 메서드
    /// </summary>
    public static class NumberingMethodExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="method">NumberingMethod 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this NumberingMethod method)
        {
            return (byte)method;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static NumberingMethod FromValue(byte value)
        {
            return value switch
            {
                0 => NumberingMethod.Continue,
                1 => NumberingMethod.Restart,
                2 => NumberingMethod.RestartAtEachPage,
                _ => NumberingMethod.Continue
            };
        }
    }
}

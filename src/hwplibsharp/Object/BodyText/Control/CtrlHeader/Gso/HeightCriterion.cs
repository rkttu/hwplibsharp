// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/HeightCriterion.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 오브젝트 높이의 기준
    /// </summary>
    public enum HeightCriterion : byte
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
        /// 절대값
        /// </summary>
        Absolute = 2
    }

    /// <summary>
    /// HeightCriterion 확장 메서드
    /// </summary>
    public static class HeightCriterionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this HeightCriterion heightCriterion) => (byte)heightCriterion;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static HeightCriterion FromValue(byte value) => value switch
        {
            0 => HeightCriterion.Paper,
            1 => HeightCriterion.Page,
            2 => HeightCriterion.Absolute,
            _ => HeightCriterion.Paper
        };
    }
}

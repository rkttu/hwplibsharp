// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/WidthCriterion.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 오브젝트 폭의 기준
    /// </summary>
    public enum WidthCriterion : byte
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
        Para = 3,

        /// <summary>
        /// 절대값
        /// </summary>
        Absolute = 4
    }

    /// <summary>
    /// WidthCriterion 확장 메서드
    /// </summary>
    public static class WidthCriterionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this WidthCriterion widthCriterion) => (byte)widthCriterion;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static WidthCriterion FromValue(byte value) => value switch
        {
            0 => WidthCriterion.Paper,
            1 => WidthCriterion.Page,
            2 => WidthCriterion.Column,
            3 => WidthCriterion.Para,
            4 => WidthCriterion.Absolute,
            _ => WidthCriterion.Paper
        };
    }
}

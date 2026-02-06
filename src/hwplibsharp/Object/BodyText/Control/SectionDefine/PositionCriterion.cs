// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/PositionCriterion.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 위치 기준
    /// </summary>
    public enum PositionCriterion : byte
    {
        /// <summary>
        /// 본문 기준
        /// </summary>
        MainText = 0,

        /// <summary>
        /// 종이 기준
        /// </summary>
        Paper = 1
    }

    /// <summary>
    /// PositionCriterion enum에 대한 확장 메서드
    /// </summary>
    public static class PositionCriterionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="criterion">PositionCriterion 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this PositionCriterion criterion)
        {
            return (byte)criterion;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static PositionCriterion FromValue(byte value)
        {
            return value switch
            {
                0 => PositionCriterion.MainText,
                1 => PositionCriterion.Paper,
                _ => PositionCriterion.MainText
            };
        }
    }
}

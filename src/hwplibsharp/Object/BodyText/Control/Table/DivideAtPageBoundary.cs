// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/table/DivideAtPageBoundary.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Table
{
    /// <summary>
    /// 쪽 경계에서 나눔 방법
    /// </summary>
    public enum DivideAtPageBoundary : byte
    {
        /// <summary>
        /// 나누지 않음
        /// </summary>
        NoDivide = 0,

        /// <summary>
        /// 셀 단위로 나눔
        /// </summary>
        DivideByCell = 1,

        /// <summary>
        /// 나눔
        /// </summary>
        Divide = 2
    }

    /// <summary>
    /// DivideAtPageBoundary enum에 대한 확장 메서드
    /// </summary>
    public static class DivideAtPageBoundaryExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="divideAtPageBoundary">DivideAtPageBoundary 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this DivideAtPageBoundary divideAtPageBoundary)
        {
            return (byte)divideAtPageBoundary;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static DivideAtPageBoundary FromValue(byte value)
        {
            return value switch
            {
                0 => DivideAtPageBoundary.NoDivide,
                1 => DivideAtPageBoundary.DivideByCell,
                2 => DivideAtPageBoundary.Divide,
                _ => DivideAtPageBoundary.NoDivide
            };
        }
    }
}

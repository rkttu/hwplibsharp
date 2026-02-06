// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/PatternType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 채우기 무늬 종류
    /// </summary>
    public enum PatternType : sbyte
    {
        /// <summary>
        /// 단색 (solid)
        /// </summary>
        None = -1,

        /// <summary>
        /// 수평선 (- - - -)
        /// </summary>
        HorizontalLine = 0,

        /// <summary>
        /// 수직선 (|||||)
        /// </summary>
        VerticalLine = 1,

        /// <summary>
        /// 하향 대각선 (\\\\\)
        /// </summary>
        BackDiagonalLine = 2,

        /// <summary>
        /// 상향 대각선 (/////)
        /// </summary>
        FrontDiagonalLine = 3,

        /// <summary>
        /// 십자선 (+++++)
        /// </summary>
        CrossLine = 4,

        /// <summary>
        /// 체크 (xxxxx)
        /// </summary>
        CrossDiagonalLine = 5,
    }

    /// <summary>
    /// PatternType 확장 메서드
    /// </summary>
    public static class PatternTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static sbyte GetValue(this PatternType type)
            => (sbyte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static PatternType FromValue(sbyte value)
            => value switch
            {
                -1 => PatternType.None,
                0 => PatternType.HorizontalLine,
                1 => PatternType.VerticalLine,
                2 => PatternType.BackDiagonalLine,
                3 => PatternType.FrontDiagonalLine,
                4 => PatternType.CrossLine,
                5 => PatternType.CrossDiagonalLine,
                _ => PatternType.None,
            };
    }
}

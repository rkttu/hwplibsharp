// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/lineinfo/LineType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo
{
    /// <summary>
    /// 선 종류
    /// </summary>
    public enum LineType : byte
    {
        /// <summary>
        /// 없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 실선
        /// </summary>
        Solid = 1,

        /// <summary>
        /// 파선(쇄선)
        /// </summary>
        Dash = 2,

        /// <summary>
        /// 점선
        /// </summary>
        Dot = 3,

        /// <summary>
        /// 일점쇄선
        /// </summary>
        DashDot = 4,

        /// <summary>
        /// 이점쇄선
        /// </summary>
        DashDotDot = 5,

        /// <summary>
        /// 긴 파선
        /// </summary>
        LongDash = 6,

        /// <summary>
        /// 원형 점선
        /// </summary>
        CircleDot = 7,

        /// <summary>
        /// 이중선
        /// </summary>
        Double = 8,

        /// <summary>
        /// 얇고 굵은 이중선
        /// </summary>
        ThinBold = 9,

        /// <summary>
        /// 굵고 얇은 이중선
        /// </summary>
        BoldThin = 10,

        /// <summary>
        /// 얇고 굵고 얇은 삼중선
        /// </summary>
        ThinBoldThin = 11,
    }

    /// <summary>
    /// LineType 확장 메서드
    /// </summary>
    public static class LineTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="type">선 종류</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this LineType type)
            => (byte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static LineType FromValue(byte value)
            => value switch
            {
                0 => LineType.None,
                1 => LineType.Solid,
                2 => LineType.Dash,
                3 => LineType.Dot,
                4 => LineType.DashDot,
                5 => LineType.DashDotDot,
                6 => LineType.LongDash,
                7 => LineType.CircleDot,
                8 => LineType.Double,
                9 => LineType.ThinBold,
                10 => LineType.BoldThin,
                11 => LineType.ThinBoldThin,
                _ => LineType.None,
            };
    }
}

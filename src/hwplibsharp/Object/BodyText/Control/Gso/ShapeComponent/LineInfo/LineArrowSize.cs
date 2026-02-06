// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/lineinfo/LineArrowSize.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo
{
    /// <summary>
    /// 화살표 크기 (가로크기-세로크기)
    /// </summary>
    public enum LineArrowSize : byte
    {
        /// <summary>
        /// 작은-작은
        /// </summary>
        SmallSmall = 0,

        /// <summary>
        /// 작은-중간
        /// </summary>
        SmallMiddle = 1,

        /// <summary>
        /// 작은-큰
        /// </summary>
        SmallBig = 2,

        /// <summary>
        /// 중간-작은
        /// </summary>
        MiddleSmall = 3,

        /// <summary>
        /// 중간-중간
        /// </summary>
        MiddleMiddle = 4,

        /// <summary>
        /// 중간-큰
        /// </summary>
        MiddleBig = 5,

        /// <summary>
        /// 큰-작은
        /// </summary>
        BigSmall = 6,

        /// <summary>
        /// 큰-중간
        /// </summary>
        BigMiddle = 7,

        /// <summary>
        /// 큰-큰
        /// </summary>
        BigBig = 8,
    }

    /// <summary>
    /// LineArrowSize 확장 메서드
    /// </summary>
    public static class LineArrowSizeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="size">화살표 크기</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this LineArrowSize size)
            => (byte)size;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static LineArrowSize FromValue(byte value)
            => value switch
            {
                0 => LineArrowSize.SmallSmall,
                1 => LineArrowSize.SmallMiddle,
                2 => LineArrowSize.SmallBig,
                3 => LineArrowSize.MiddleSmall,
                4 => LineArrowSize.MiddleMiddle,
                5 => LineArrowSize.MiddleBig,
                6 => LineArrowSize.BigSmall,
                7 => LineArrowSize.BigMiddle,
                8 => LineArrowSize.BigBig,
                _ => LineArrowSize.SmallSmall,
            };
    }
}

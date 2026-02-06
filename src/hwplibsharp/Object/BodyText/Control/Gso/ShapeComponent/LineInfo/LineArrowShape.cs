// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/lineinfo/LineArrowShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo
{
    /// <summary>
    /// 선 끝에 화살표 모양
    /// </summary>
    public enum LineArrowShape : byte
    {
        /// <summary>
        /// 모양 없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 화살표
        /// </summary>
        Arrow = 1,

        /// <summary>
        /// 선형 화살표
        /// </summary>
        LinedArrow = 2,

        /// <summary>
        /// 오목한 화살표
        /// </summary>
        ConcaveArrow = 3,

        /// <summary>
        /// 속이 빈 다이아몬드 모양
        /// </summary>
        Diamond = 4,

        /// <summary>
        /// 속이 빈 원 모양
        /// </summary>
        Circle = 5,

        /// <summary>
        /// 속이 빈 사각형 모양
        /// </summary>
        Rectangle = 6,
    }

    /// <summary>
    /// LineArrowShape 확장 메서드
    /// </summary>
    public static class LineArrowShapeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="shape">화살표 모양</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this LineArrowShape shape)
            => (byte)shape;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static LineArrowShape FromValue(byte value)
            => value switch
            {
                0 => LineArrowShape.None,
                1 => LineArrowShape.Arrow,
                2 => LineArrowShape.LinedArrow,
                3 => LineArrowShape.ConcaveArrow,
                4 => LineArrowShape.Diamond,
                5 => LineArrowShape.Circle,
                6 => LineArrowShape.Rectangle,
                _ => LineArrowShape.None,
            };
    }
}

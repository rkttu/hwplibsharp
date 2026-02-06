// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/objectlinkline/LinkLineType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.ObjectLinkLine
{
    /// <summary>
    /// 연결선 타입
    /// </summary>
    public enum LinkLineType : byte
    {
        /// <summary>
        /// 직선 - 화살표 없음
        /// </summary>
        StraightNoArrow = 0,

        /// <summary>
        /// 직선 - 한쪽 화살표
        /// </summary>
        StraightOneWay = 1,

        /// <summary>
        /// 직선 - 양쪽 화살표
        /// </summary>
        StraightBoth = 2,

        /// <summary>
        /// 꺾은선 - 화살표 없음
        /// </summary>
        StrokeNoArrow = 3,

        /// <summary>
        /// 꺾은선 - 한쪽 화살표
        /// </summary>
        StrokeOneWay = 4,

        /// <summary>
        /// 꺾은선 - 양쪽 화살표
        /// </summary>
        StrokeBoth = 5,

        /// <summary>
        /// 호 - 화살표 없음
        /// </summary>
        ArcNoArrow = 6,

        /// <summary>
        /// 호 - 한쪽 화살표
        /// </summary>
        ArcOneWay = 7,

        /// <summary>
        /// 호 - 양쪽 화살표
        /// </summary>
        ArcBoth = 8,
    }

    /// <summary>
    /// LinkLineType 확장 메서드
    /// </summary>
    public static class LinkLineTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this LinkLineType type)
            => (byte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static LinkLineType FromValue(byte value)
            => value switch
            {
                0 => LinkLineType.StraightNoArrow,
                1 => LinkLineType.StraightOneWay,
                2 => LinkLineType.StraightBoth,
                3 => LinkLineType.StrokeNoArrow,
                4 => LinkLineType.StrokeOneWay,
                5 => LinkLineType.StrokeBoth,
                6 => LinkLineType.ArcNoArrow,
                7 => LinkLineType.ArcOneWay,
                8 => LinkLineType.ArcBoth,
                _ => LinkLineType.StraightNoArrow,
            };
    }
}

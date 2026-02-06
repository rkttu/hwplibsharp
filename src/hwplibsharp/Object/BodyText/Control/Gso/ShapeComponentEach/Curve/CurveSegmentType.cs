// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/curve/CurveSegmentType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Curve
{
    /// <summary>
    /// 곡선의 Segment Type
    /// </summary>
    public enum CurveSegmentType : byte
    {
        /// <summary>
        /// line
        /// </summary>
        Line = 0,

        /// <summary>
        /// curve
        /// </summary>
        Curve = 1,
    }

    /// <summary>
    /// CurveSegmentType 확장 메서드
    /// </summary>
    public static class CurveSegmentTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this CurveSegmentType type)
            => (byte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static CurveSegmentType FromValue(byte value)
            => value switch
            {
                0 => CurveSegmentType.Line,
                1 => CurveSegmentType.Curve,
                _ => CurveSegmentType.Line,
            };
    }
}

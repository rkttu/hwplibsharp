// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/lineinfo/LineEndShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo
{
    /// <summary>
    /// 선 끝 모양
    /// </summary>
    public enum LineEndShape : byte
    {
        /// <summary>
        /// 둥근 선 끝
        /// </summary>
        Round = 0,

        /// <summary>
        /// 각진 선 끝
        /// </summary>
        Flat = 1,
    }

    /// <summary>
    /// LineEndShape 확장 메서드
    /// </summary>
    public static class LineEndShapeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="shape">선 끝 모양</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this LineEndShape shape)
            => (byte)shape;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static LineEndShape FromValue(byte value)
            => value switch
            {
                0 => LineEndShape.Round,
                1 => LineEndShape.Flat,
                _ => LineEndShape.Round,
            };
    }
}

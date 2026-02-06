// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/arc/ArcType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Arc
{
    /// <summary>
    /// 호 테두리
    /// </summary>
    public enum ArcType : byte
    {
        /// <summary>
        /// 호
        /// </summary>
        Arc = 0,

        /// <summary>
        /// 부채꼴
        /// </summary>
        CircularSector = 1,

        /// <summary>
        /// 활
        /// </summary>
        Bow = 2,
    }

    /// <summary>
    /// ArcType 확장 메서드
    /// </summary>
    public static class ArcTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ArcType type)
            => (byte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ArcType FromValue(byte value)
            => value switch
            {
                0 => ArcType.Arc,
                1 => ArcType.CircularSector,
                2 => ArcType.Bow,
                _ => ArcType.Arc,
            };
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ole/ObjectSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Ole
{
    /// <summary>
    /// OLE 객체 종류
    /// </summary>
    public enum ObjectSort : byte
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Embedded
        /// </summary>
        Embedded = 1,

        /// <summary>
        /// Link
        /// </summary>
        Link = 2,

        /// <summary>
        /// Static
        /// </summary>
        Static = 3,

        /// <summary>
        /// Equation
        /// </summary>
        Equation = 4,
    }

    /// <summary>
    /// ObjectSort 확장 메서드
    /// </summary>
    public static class ObjectSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ObjectSort sort)
            => (byte)sort;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ObjectSort FromValue(byte value)
            => value switch
            {
                0 => ObjectSort.Unknown,
                1 => ObjectSort.Embedded,
                2 => ObjectSort.Link,
                3 => ObjectSort.Static,
                4 => ObjectSort.Equation,
                _ => ObjectSort.Unknown,
            };
    }
}

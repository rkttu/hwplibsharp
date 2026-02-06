// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/lineinfo/OutlineStyle.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo
{
    /// <summary>
    /// Outline style
    /// </summary>
    public enum OutlineStyle : byte
    {
        /// <summary>
        /// 일반
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 외부
        /// </summary>
        Outter = 1,

        /// <summary>
        /// 내부
        /// </summary>
        Inner = 2,
    }

    /// <summary>
    /// OutlineStyle 확장 메서드
    /// </summary>
    public static class OutlineStyleExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="style">Outline style</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this OutlineStyle style)
            => (byte)style;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static OutlineStyle FromValue(byte value)
            => value switch
            {
                0 => OutlineStyle.Normal,
                1 => OutlineStyle.Outter,
                2 => OutlineStyle.Inner,
                _ => OutlineStyle.Normal,
            };
    }
}

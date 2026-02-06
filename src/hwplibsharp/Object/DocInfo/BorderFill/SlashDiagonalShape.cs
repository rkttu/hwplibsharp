// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/SlashDiagonalShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// Slash 대각선 모양
    /// </summary>
    public enum SlashDiagonalShape : byte
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,

        /// <summary>
        /// slash (RightTop --> leftBottom) "/"
        /// </summary>
        Slash = 2,

        /// <summary>
        /// RightTop --> Bottom Edge
        /// </summary>
        RightTopToBottomEdge = 3,

        /// <summary>
        /// RightTop --> Left Edge
        /// </summary>
        RightTopToLeftEdge = 6,

        /// <summary>
        /// RightTop --> Bottom &amp; Left Edge
        /// </summary>
        RightTopToBottomLeftEdge = 7
    }

    /// <summary>
    /// SlashDiagonalShape 확장 메서드
    /// </summary>
    public static class SlashDiagonalShapeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="shape">SlashDiagonalShape 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this SlashDiagonalShape shape)
        {
            return (byte)shape;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static SlashDiagonalShape FromValue(byte value)
        {
            return value switch
            {
                0 => SlashDiagonalShape.None,
                2 => SlashDiagonalShape.Slash,
                3 => SlashDiagonalShape.RightTopToBottomEdge,
                6 => SlashDiagonalShape.RightTopToLeftEdge,
                7 => SlashDiagonalShape.RightTopToBottomLeftEdge,
                _ => SlashDiagonalShape.None
            };
        }
    }
}

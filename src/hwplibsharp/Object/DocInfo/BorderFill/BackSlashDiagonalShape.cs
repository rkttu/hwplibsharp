// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/BackSlashDiagonalShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// BackSlash의 대각선 모양
    /// </summary>
    public enum BackSlashDiagonalShape : byte
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,

        /// <summary>
        /// back slash(leftTop --> rightBottom) "\"
        /// </summary>
        BackSlash = 2,

        /// <summary>
        /// LeftTop --> Bottom Edge
        /// </summary>
        LeftTopToBottomEdge = 3,

        /// <summary>
        /// LeftTop --> Right Edge
        /// </summary>
        LeftTopToRightEdge = 6,

        /// <summary>
        /// LeftTop --> Bottom &amp; Right Edge
        /// </summary>
        LeftTopToBottomRightEdge = 7
    }

    /// <summary>
    /// BackSlashDiagonalShape 확장 메서드
    /// </summary>
    public static class BackSlashDiagonalShapeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="shape">BackSlashDiagonalShape 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this BackSlashDiagonalShape shape)
        {
            return (byte)shape;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static BackSlashDiagonalShape FromValue(byte value)
        {
            return value switch
            {
                0 => BackSlashDiagonalShape.None,
                2 => BackSlashDiagonalShape.BackSlash,
                3 => BackSlashDiagonalShape.LeftTopToBottomEdge,
                6 => BackSlashDiagonalShape.LeftTopToRightEdge,
                7 => BackSlashDiagonalShape.LeftTopToBottomRightEdge,
                _ => BackSlashDiagonalShape.None
            };
        }
    }
}

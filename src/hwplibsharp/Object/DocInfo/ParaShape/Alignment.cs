// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/Alignment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 정렬 방식
    /// </summary>
    public enum Alignment : byte
    {
        /// <summary>
        /// 양쪽 정렬
        /// </summary>
        Justify = 0,

        /// <summary>
        /// 왼쪽 정렬
        /// </summary>
        Left = 1,

        /// <summary>
        /// 오른쪽 정렬
        /// </summary>
        Right = 2,

        /// <summary>
        /// 가운데 정렬
        /// </summary>
        Center = 3,

        /// <summary>
        /// 배분 정렬
        /// </summary>
        Distribute = 4,

        /// <summary>
        /// 나눔 정렬
        /// </summary>
        Divide = 5,
    }

    /// <summary>
    /// Alignment enum 확장 메서드
    /// </summary>
    public static class AlignmentExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="alignment">enum 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this Alignment alignment)
        {
            return (byte)alignment;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static Alignment FromValue(byte value)
        {
            return value switch
            {
                0 => Alignment.Justify,
                1 => Alignment.Left,
                2 => Alignment.Right,
                3 => Alignment.Center,
                4 => Alignment.Distribute,
                5 => Alignment.Divide,
                _ => Alignment.Justify,
            };
        }
    }
}

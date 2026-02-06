// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/numbering/ParagraphAlignment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.Numbering
{
    /// <summary>
    /// 문단의 정렬 종류
    /// </summary>
    public enum ParagraphAlignment : byte
    {
        /// <summary>
        /// 왼쪽
        /// </summary>
        Left = 0,

        /// <summary>
        /// 가운데
        /// </summary>
        Center = 1,

        /// <summary>
        /// 오른쪽
        /// </summary>
        Right = 2
    }

    /// <summary>
    /// ParagraphAlignment 확장 메서드
    /// </summary>
    public static class ParagraphAlignmentExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ParagraphAlignment alignment)
        {
            return (byte)alignment;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ParagraphAlignment FromValue(byte value)
        {
            return value switch
            {
                0 => ParagraphAlignment.Left,
                1 => ParagraphAlignment.Center,
                2 => ParagraphAlignment.Right,
                _ => ParagraphAlignment.Left
            };
        }
    }
}

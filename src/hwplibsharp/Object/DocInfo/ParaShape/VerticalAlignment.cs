// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/VerticalAlignment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 세로 정렬
    /// </summary>
    public enum VerticalAlignment : byte
    {
        /// <summary>
        /// 글꼴기준
        /// </summary>
        ByFont = 0,

        /// <summary>
        /// 위쪽
        /// </summary>
        Top = 1,

        /// <summary>
        /// 가운데
        /// </summary>
        Center = 2,

        /// <summary>
        /// 아래
        /// </summary>
        Bottom = 3
    }

    /// <summary>
    /// VerticalAlignment 확장 메서드
    /// </summary>
    public static class VerticalAlignmentExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this VerticalAlignment alignment)
        {
            return (byte)alignment;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static VerticalAlignment FromValue(byte value)
        {
            return value switch
            {
                0 => VerticalAlignment.ByFont,
                1 => VerticalAlignment.Top,
                2 => VerticalAlignment.Center,
                3 => VerticalAlignment.Bottom,
                _ => VerticalAlignment.ByFont
            };
        }
    }
}

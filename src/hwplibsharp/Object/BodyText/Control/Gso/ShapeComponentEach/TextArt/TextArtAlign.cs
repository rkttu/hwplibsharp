// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/textart/TextArtAlign.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.TextArt
{
    /// <summary>
    /// 글맵시 정렬
    /// </summary>
    public enum TextArtAlign : byte
    {
        /// <summary>
        /// 왼쪽
        /// </summary>
        Left = 0,

        /// <summary>
        /// 오른쪽
        /// </summary>
        Right = 1,

        /// <summary>
        /// 가운데
        /// </summary>
        Center = 2,

        /// <summary>
        /// 전체
        /// </summary>
        Full = 3,

        /// <summary>
        /// 표
        /// </summary>
        Table = 4,
    }

    /// <summary>
    /// TextArtAlign 확장 메서드
    /// </summary>
    public static class TextArtAlignExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this TextArtAlign align)
            => (byte)align;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static TextArtAlign FromValue(byte value)
            => value switch
            {
                0 => TextArtAlign.Left,
                1 => TextArtAlign.Right,
                2 => TextArtAlign.Center,
                3 => TextArtAlign.Full,
                4 => TextArtAlign.Table,
                _ => TextArtAlign.Left,
            };
    }
}

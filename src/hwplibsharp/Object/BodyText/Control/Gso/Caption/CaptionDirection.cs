// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/caption/CaptionDirection.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.Caption
{
    /// <summary>
    /// 캡션 방향
    /// </summary>
    public enum CaptionDirection : byte
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
        /// 위쪽
        /// </summary>
        Top = 2,

        /// <summary>
        /// 아래쪽
        /// </summary>
        Bottom = 3,
    }

    /// <summary>
    /// CaptionDirection 확장 메서드
    /// </summary>
    public static class CaptionDirectionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="direction">캡션 방향</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this CaptionDirection direction)
            => (byte)direction;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static CaptionDirection FromValue(byte value)
            => value switch
            {
                0 => CaptionDirection.Left,
                1 => CaptionDirection.Right,
                2 => CaptionDirection.Top,
                3 => CaptionDirection.Bottom,
                _ => CaptionDirection.Left,
            };
    }
}

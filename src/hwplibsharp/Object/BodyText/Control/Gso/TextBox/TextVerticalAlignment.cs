// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/textbox/TextVerticalAlignment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.TextBox
{
    /// <summary>
    /// 텍스트 세로 정렬 방법
    /// </summary>
    public enum TextVerticalAlignment : byte
    {
        /// <summary>
        /// 위쪽
        /// </summary>
        Top = 0,

        /// <summary>
        /// 가운데
        /// </summary>
        Center = 1,

        /// <summary>
        /// 아래쪽
        /// </summary>
        Bottom = 2,
    }

    /// <summary>
    /// TextVerticalAlignment 열거형에 대한 확장 메서드
    /// </summary>
    public static class TextVerticalAlignmentExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="alignment">TextVerticalAlignment 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this TextVerticalAlignment alignment) => (byte)alignment;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static TextVerticalAlignment FromValue(byte value) => value switch
        {
            0 => TextVerticalAlignment.Top,
            1 => TextVerticalAlignment.Center,
            2 => TextVerticalAlignment.Bottom,
            _ => TextVerticalAlignment.Top,
        };
    }
}

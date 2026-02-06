// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/TextHorzArrange.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 오브젝트의 좌/우 어느 쪽에 글을 배치할지 지정하는 옵션
    /// </summary>
    public enum TextHorzArrange : byte
    {
        /// <summary>
        /// 양쪽
        /// </summary>
        BothSides = 0,

        /// <summary>
        /// 왼쪽
        /// </summary>
        LeftOnly = 1,

        /// <summary>
        /// 오른쪽
        /// </summary>
        RightOnly = 2,

        /// <summary>
        /// 큰 쪽
        /// </summary>
        LargestOnly = 3
    }

    /// <summary>
    /// TextHorzArrange 확장 메서드
    /// </summary>
    public static class TextHorzArrangeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this TextHorzArrange textHorzArrange) => (byte)textHorzArrange;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static TextHorzArrange FromValue(byte value) => value switch
        {
            0 => TextHorzArrange.BothSides,
            1 => TextHorzArrange.LeftOnly,
            2 => TextHorzArrange.RightOnly,
            3 => TextHorzArrange.LargestOnly,
            _ => TextHorzArrange.BothSides
        };
    }
}

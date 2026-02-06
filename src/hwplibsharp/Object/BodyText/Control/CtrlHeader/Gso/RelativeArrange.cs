// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/RelativeArrange.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 상대적인 배열 방식
    /// </summary>
    public enum RelativeArrange : byte
    {
        /// <summary>
        /// VerRelTo이 'paper'나 'page' 이면 top, 그렇지 않으면 left
        /// </summary>
        TopOrLeft = 0,

        /// <summary>
        /// VerRelTo이 'paper'나 'page' 이면 center
        /// </summary>
        Center = 1,

        /// <summary>
        /// VerRelTo이 'paper'나 'page' 이면 bottom, 그렇지 않으면 right
        /// </summary>
        BottomOrRight = 2,

        /// <summary>
        /// VerRelTo이 'paper'나 'page' 이면 inside
        /// </summary>
        Inside = 3,

        /// <summary>
        /// VerRelTo이 'paper'나 'page' 이면 outside
        /// </summary>
        Outside = 4
    }

    /// <summary>
    /// RelativeArrange 확장 메서드
    /// </summary>
    public static class RelativeArrangeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this RelativeArrange relativeArrange) => (byte)relativeArrange;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static RelativeArrange FromValue(byte value) => value switch
        {
            0 => RelativeArrange.TopOrLeft,
            1 => RelativeArrange.Center,
            2 => RelativeArrange.BottomOrRight,
            3 => RelativeArrange.Inside,
            4 => RelativeArrange.Outside,
            _ => RelativeArrange.TopOrLeft
        };
    }
}

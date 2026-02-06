// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/additionaltext/AdditionalTextPosition.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.AdditionalText
{
    /// <summary>
    /// 덧말의 위치
    /// </summary>
    public enum AdditionalTextPosition : byte
    {
        /// <summary>
        /// 위
        /// </summary>
        Top = 0,

        /// <summary>
        /// 아래
        /// </summary>
        Bottom = 1,

        /// <summary>
        /// 가운데
        /// </summary>
        Center = 2
    }

    /// <summary>
    /// AdditionalTextPosition 확장 메서드
    /// </summary>
    public static class AdditionalTextPositionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="position">AdditionalTextPosition 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this AdditionalTextPosition position)
        {
            return (byte)position;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static AdditionalTextPosition FromValue(byte value)
        {
            return value switch
            {
                0 => AdditionalTextPosition.Top,
                1 => AdditionalTextPosition.Bottom,
                2 => AdditionalTextPosition.Center,
                _ => AdditionalTextPosition.Top
            };
        }
    }
}
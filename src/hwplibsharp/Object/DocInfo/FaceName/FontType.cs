// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/facename/FontType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.FaceName
{
    /// <summary>
    /// 대체 글꼴 유형
    /// </summary>
    public enum FontType : byte
    {
        /// <summary>
        /// 원래 종류를 알 수 없을 때
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 트루타입 글꼴(TTF)
        /// </summary>
        TTF = 1,

        /// <summary>
        /// 한글 전용 글꼴(HFT)
        /// </summary>
        HFT = 2
    }

    /// <summary>
    /// FontType enum에 대한 확장 메서드
    /// </summary>
    public static class FontTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="fontType">FontType 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this FontType fontType)
        {
            return (byte)fontType;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static FontType FromValue(byte value)
        {
            return value switch
            {
                0 => FontType.Unknown,
                1 => FontType.TTF,
                2 => FontType.HFT,
                _ => FontType.Unknown
            };
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/sectiondefine/TextDirection.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.SectionDefine
{
    /// <summary>
    /// 텍스트 진행방향
    /// </summary>
    public enum TextDirection : byte
    {
        /// <summary>
        /// 가로
        /// </summary>
        Horizontal = 0,

        /// <summary>
        /// 세로(영어 눕힘)
        /// </summary>
        VerticalWithEnglishLayDown = 1,

        /// <summary>
        /// 세로(영어 세움)
        /// </summary>
        VerticalWithEnglishStanding = 2,
    }

    /// <summary>
    /// TextDirection enum 확장 메서드
    /// </summary>
    public static class TextDirectionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="textDirection">enum 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this TextDirection textDirection)
        {
            return (byte)textDirection;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static TextDirection FromValue(byte value)
        {
            return value switch
            {
                0 => TextDirection.Horizontal,
                1 => TextDirection.VerticalWithEnglishLayDown,
                2 => TextDirection.VerticalWithEnglishStanding,
                _ => TextDirection.Horizontal,
            };
        }
    }
}

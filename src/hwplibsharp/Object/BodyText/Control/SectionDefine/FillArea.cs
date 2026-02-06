// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/FillArea.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 채워질 영역의 종류
    /// </summary>
    public enum FillArea : byte
    {
        /// <summary>
        /// 종이
        /// </summary>
        Paper = 0,

        /// <summary>
        /// 쪽
        /// </summary>
        Page = 1,

        /// <summary>
        /// 테두리
        /// </summary>
        Border = 2
    }

    /// <summary>
    /// FillArea enum에 대한 확장 메서드
    /// </summary>
    public static class FillAreaExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="fillArea">FillArea 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this FillArea fillArea)
        {
            return (byte)fillArea;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static FillArea FromValue(byte value)
        {
            return value switch
            {
                0 => FillArea.Paper,
                1 => FillArea.Page,
                2 => FillArea.Border,
                _ => FillArea.Paper
            };
        }
    }
}

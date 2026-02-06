// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/EndNoteDisplayMethod.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 미주를 위치시킬 방법
    /// </summary>
    public enum EndNoteDisplayMethod : byte
    {
        /// <summary>
        /// 문서의 마지막
        /// </summary>
        DocumentEnd = 0,

        /// <summary>
        /// 구역의 마지막
        /// </summary>
        SectionEnd = 1
    }

    /// <summary>
    /// EndNoteDisplayMethod enum에 대한 확장 메서드
    /// </summary>
    public static class EndNoteDisplayMethodExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="method">EndNoteDisplayMethod 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this EndNoteDisplayMethod method)
        {
            return (byte)method;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static EndNoteDisplayMethod FromValue(byte value)
        {
            return value switch
            {
                0 => EndNoteDisplayMethod.DocumentEnd,
                1 => EndNoteDisplayMethod.SectionEnd,
                _ => EndNoteDisplayMethod.DocumentEnd
            };
        }
    }
}

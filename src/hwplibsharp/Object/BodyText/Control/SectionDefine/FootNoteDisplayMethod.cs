// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/FootNoteDisplayMethod.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 한 페이지 내에서 각주를 다단에 위치시킬 방법
    /// </summary>
    public enum FootNoteDisplayMethod : byte
    {
        /// <summary>
        /// 각 단마다 따로 배열
        /// </summary>
        EachColumn = 0,

        /// <summary>
        /// 통단으로 배열
        /// </summary>
        AllColumn = 1,

        /// <summary>
        /// 가장 오른쪽 단에 배열
        /// </summary>
        RightColumn = 2
    }

    /// <summary>
    /// FootNoteDisplayMethod enum에 대한 확장 메서드
    /// </summary>
    public static class FootNoteDisplayMethodExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="method">FootNoteDisplayMethod 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this FootNoteDisplayMethod method)
        {
            return (byte)method;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static FootNoteDisplayMethod FromValue(byte value)
        {
            return value switch
            {
                0 => FootNoteDisplayMethod.EachColumn,
                1 => FootNoteDisplayMethod.AllColumn,
                2 => FootNoteDisplayMethod.RightColumn,
                _ => FootNoteDisplayMethod.EachColumn
            };
        }
    }
}

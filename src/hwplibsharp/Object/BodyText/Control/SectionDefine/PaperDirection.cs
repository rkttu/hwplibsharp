// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/PaperDirection.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 용지 방향
    /// </summary>
    public enum PaperDirection : byte
    {
        /// <summary>
        /// 좁게 (세로)
        /// </summary>
        Portrait = 0,

        /// <summary>
        /// 넓게 (가로)
        /// </summary>
        Landscape = 1
    }

    /// <summary>
    /// PaperDirection enum에 대한 확장 메서드
    /// </summary>
    public static class PaperDirectionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="direction">PaperDirection 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this PaperDirection direction)
        {
            return (byte)direction;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static PaperDirection FromValue(byte value)
        {
            return value switch
            {
                0 => PaperDirection.Portrait,
                1 => PaperDirection.Landscape,
                _ => PaperDirection.Portrait
            };
        }
    }
}

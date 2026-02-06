// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/sectiondefine/StartPageNumberType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.SectionDefine
{
    /// <summary>
    /// 시작 쪽번호 타입
    /// </summary>
    public enum StartPageNumberType : byte
    {
        /// <summary>
        /// 이어서
        /// </summary>
        Continue = 0,

        /// <summary>
        /// 짝수
        /// </summary>
        Even = 1,

        /// <summary>
        /// 홀수
        /// </summary>
        Odd = 2,

        /// <summary>
        /// 사용자 정의
        /// </summary>
        Custom = 3,
    }

    /// <summary>
    /// StartPageNumberType enum 확장 메서드
    /// </summary>
    public static class StartPageNumberTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="startPageNumberType">enum 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this StartPageNumberType startPageNumberType)
        {
            return (byte)startPageNumberType;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static StartPageNumberType FromValue(byte value)
        {
            return value switch
            {
                0 => StartPageNumberType.Continue,
                1 => StartPageNumberType.Even,
                2 => StartPageNumberType.Odd,
                3 => StartPageNumberType.Custom,
                _ => StartPageNumberType.Continue,
            };
        }
    }
}

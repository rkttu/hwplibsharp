// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/MakingBookMethod.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 제책 방법
    /// </summary>
    public enum MakingBookMethod : byte
    {
        /// <summary>
        /// 한쪽 편집
        /// </summary>
        OneSideEditing = 0,

        /// <summary>
        /// 맞쪽 편집
        /// </summary>
        BothSideEditing = 1,

        /// <summary>
        /// 위로 넘기기
        /// </summary>
        BackFlip = 2
    }

    /// <summary>
    /// MakingBookMethod enum에 대한 확장 메서드
    /// </summary>
    public static class MakingBookMethodExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="method">MakingBookMethod 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this MakingBookMethod method)
        {
            return (byte)method;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static MakingBookMethod FromValue(byte value)
        {
            return value switch
            {
                0 => MakingBookMethod.OneSideEditing,
                1 => MakingBookMethod.BothSideEditing,
                2 => MakingBookMethod.BackFlip,
                _ => MakingBookMethod.OneSideEditing
            };
        }
    }
}

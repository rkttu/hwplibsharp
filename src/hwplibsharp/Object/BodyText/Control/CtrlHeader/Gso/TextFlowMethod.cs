// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/TextFlowMethod.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 오브젝트 주위를 텍스트가 어떻게 흘러갈지 지정하는 옵션
    /// </summary>
    public enum TextFlowMethod : byte
    {
        /// <summary>
        /// 어울림
        /// </summary>
        FitWithText = 0,

        /// <summary>
        /// 자리 차지
        /// </summary>
        TakePlace = 1,

        /// <summary>
        /// 글 뒤로
        /// </summary>
        BehindText = 2,

        /// <summary>
        /// 글 앞으로
        /// </summary>
        InFrontOfText = 3
    }

    /// <summary>
    /// TextFlowMethod 확장 메서드
    /// </summary>
    public static class TextFlowMethodExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this TextFlowMethod textFlowMethod) => (byte)textFlowMethod;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static TextFlowMethod FromValue(byte value) => value switch
        {
            0 => TextFlowMethod.FitWithText,
            1 => TextFlowMethod.TakePlace,
            2 => TextFlowMethod.BehindText,
            3 => TextFlowMethod.InFrontOfText,
            _ => TextFlowMethod.FitWithText
        };
    }
}

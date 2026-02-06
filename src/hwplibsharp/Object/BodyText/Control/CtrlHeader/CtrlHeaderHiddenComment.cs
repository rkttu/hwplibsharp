// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderHiddenComment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 숨은 설명 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderHiddenComment : CtrlHeader
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderHiddenComment()
            : base(ControlTypeExtensions.GetCtrlId(ControlType.HiddenComment))
        {
        }

        /// <summary>
        /// 다른 CtrlHeader에서 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본</param>
        public override void Copy(CtrlHeader from)
        {
            // 특별한 속성 없음
        }
    }
}

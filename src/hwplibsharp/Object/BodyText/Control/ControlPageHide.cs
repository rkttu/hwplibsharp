// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlPageHide.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 감추기 컨트롤
    /// </summary>
    public class ControlPageHide : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlPageHide()
            : base(new CtrlHeaderPageHide())
        {
        }

        /// <summary>
        /// 감추기 컨트롤용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>감추기 컨트롤용 컨트롤 헤더</returns>
        public new CtrlHeaderPageHide? GetHeader() => Header as CtrlHeaderPageHide;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlPageHide cloned = new ControlPageHide();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlAdditionalText.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 덧말 컨트롤
    /// </summary>
    public class ControlAdditionalText : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlAdditionalText()
            : base(new CtrlHeaderAdditionalText())
        {
        }

        /// <summary>
        /// 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>컨트롤 헤더</returns>
        public new CtrlHeaderAdditionalText? GetHeader() => Header as CtrlHeaderAdditionalText;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlAdditionalText cloned = new ControlAdditionalText();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

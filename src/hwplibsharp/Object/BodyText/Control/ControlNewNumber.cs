// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlNewNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 새 번호 지정 컨트롤
    /// </summary>
    public class ControlNewNumber : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlNewNumber()
            : base(new CtrlHeaderNewNumber())
        {
        }

        /// <summary>
        /// 새 번호 지정용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>새 번호 지정용 컨트롤 헤더</returns>
        public new CtrlHeaderNewNumber? GetHeader() => Header as CtrlHeaderNewNumber;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlNewNumber cloned = new ControlNewNumber();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

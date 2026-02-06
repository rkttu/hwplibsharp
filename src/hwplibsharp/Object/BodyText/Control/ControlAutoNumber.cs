// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlAutoNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 자동번호 컨트롤에 대한 객체
    /// </summary>
    public class ControlAutoNumber : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlAutoNumber()
            : base(new CtrlHeaderAutoNumber())
        {
        }

        /// <summary>
        /// 자동번호 컨트롤용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>자동번호 컨트롤용 컨트롤 헤더</returns>
        public new CtrlHeaderAutoNumber? GetHeader() => Header as CtrlHeaderAutoNumber;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlAutoNumber cloned = new ControlAutoNumber();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

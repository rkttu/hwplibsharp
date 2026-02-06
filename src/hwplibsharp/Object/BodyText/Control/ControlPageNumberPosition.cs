// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlPageNumberPosition.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 쪽 번호 위치 컨트롤
    /// </summary>
    public class ControlPageNumberPosition : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlPageNumberPosition()
            : base(new CtrlHeaderPageNumberPosition())
        {
        }

        /// <summary>
        /// 쪽 번호 위치 컨트롤용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>쪽 번호 위치 컨트롤용 컨트롤 헤더</returns>
        public new CtrlHeaderPageNumberPosition? GetHeader() => Header as CtrlHeaderPageNumberPosition;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlPageNumberPosition cloned = new ControlPageNumberPosition();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

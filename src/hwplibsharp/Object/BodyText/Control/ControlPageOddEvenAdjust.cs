// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlPageOddEvenAdjust.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 홀/짝수 조정(페이지 번호 제어) 컨트롤
    /// </summary>
    public class ControlPageOddEvenAdjust : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlPageOddEvenAdjust()
            : base(new CtrlHeaderPageOddEvenAdjust())
        {
        }

        /// <summary>
        /// 홀/짝수 조정(페이지 번호 제어) 컨트롤용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>홀/짝수 조정(페이지 번호 제어) 컨트롤 헤더</returns>
        public new CtrlHeaderPageOddEvenAdjust? GetHeader() => Header as CtrlHeaderPageOddEvenAdjust;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlPageOddEvenAdjust cloned = new ControlPageOddEvenAdjust();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

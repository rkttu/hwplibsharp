// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderPageOddEvenAdjust.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.PageOddEvenAdjust;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 홀/짝수 조정(페이지 번호 제어) 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderPageOddEvenAdjust : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly PageOddEvenAdjustHeaderProperty property;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderPageOddEvenAdjust()
            : base(ControlType.PageOddEvenAdjust.GetCtrlId())
        {
            property = new PageOddEvenAdjustHeaderProperty();
        }

        /// <summary>
        /// 홀/짝수 조정(페이지 번호 제어) 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public PageOddEvenAdjustHeaderProperty Property => property;

        /// <summary>
        /// 다른 <see cref="CtrlHeaderPageOddEvenAdjust"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeaderPageOddEvenAdjust"/> 인스턴스입니다.</param>
        public void Copy(CtrlHeaderPageOddEvenAdjust from)
        {
            property.Copy(from.property);
        }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderPageOddEvenAdjust from2 = (CtrlHeaderPageOddEvenAdjust)from;
            property.Copy(from2.property);
        }
    }
}

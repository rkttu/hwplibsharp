// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderPageHide.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.PageHide;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 감추기 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderPageHide : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly PageHideHeaderProperty property;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderPageHide()
            : base(ControlType.PageHide.GetCtrlId())
        {
            property = new PageHideHeaderProperty();
        }

        /// <summary>
        /// 감추기 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public PageHideHeaderProperty Property => property;

        /// <summary>
        /// 다른 <see cref="CtrlHeaderPageHide"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeaderPageHide"/> 인스턴스입니다.</param>
        public void Copy(CtrlHeaderPageHide from)
        {
            property.Copy(from.property);
        }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderPageHide from2 = (CtrlHeaderPageHide)from;
            property.Copy(from2.property);
        }
    }
}

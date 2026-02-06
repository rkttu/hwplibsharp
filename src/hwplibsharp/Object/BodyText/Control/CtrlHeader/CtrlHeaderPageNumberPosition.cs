// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderPageNumberPosition.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.PageNumberPosition;
using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 쪽 번호 위치 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderPageNumberPosition : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly PageNumberPositionHeaderProperty property;

        /// <summary>
        /// 사용자 기호
        /// </summary>
        private readonly HWPString userSymbol;

        /// <summary>
        /// 앞 장식 문자
        /// </summary>
        private readonly HWPString beforeDecorationLetter;

        /// <summary>
        /// 뒤 장식 문자
        /// </summary>
        private readonly HWPString afterDecorationLetter;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderPageNumberPosition()
            : base(ControlType.PageNumberPosition.GetCtrlId())
        {
            property = new PageNumberPositionHeaderProperty();
            userSymbol = new HWPString();
            beforeDecorationLetter = new HWPString();
            afterDecorationLetter = new HWPString();
        }

        /// <summary>
        /// 쪽 번호 위치 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public PageNumberPositionHeaderProperty Property => property;

        /// <summary>
        /// 번호
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 사용자 기호를 반환한다.
        /// </summary>
        public HWPString UserSymbol => userSymbol;

        /// <summary>
        /// 앞 장식 문자를 반환한다.
        /// </summary>
        public HWPString BeforeDecorationLetter => beforeDecorationLetter;

        /// <summary>
        /// 뒤 장식 문자를 반환한다.
        /// </summary>
        public HWPString AfterDecorationLetter => afterDecorationLetter;

        /// <summary>
        /// 다른 <see cref="CtrlHeaderPageNumberPosition"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeaderPageNumberPosition"/> 인스턴스입니다.</param>
        public void Copy(CtrlHeaderPageNumberPosition from)
        {
            property.Copy(from.property);
            Number = from.Number;
            userSymbol.Copy(from.userSymbol);
            beforeDecorationLetter.Copy(from.beforeDecorationLetter);
            afterDecorationLetter.Copy(from.afterDecorationLetter);
        }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderPageNumberPosition from2 = (CtrlHeaderPageNumberPosition)from;
            property.Copy(from2.property);
            Number = from2.Number;
            userSymbol.Copy(from2.userSymbol);
            beforeDecorationLetter.Copy(from2.beforeDecorationLetter);
            afterDecorationLetter.Copy(from2.afterDecorationLetter);
        }
    }
}

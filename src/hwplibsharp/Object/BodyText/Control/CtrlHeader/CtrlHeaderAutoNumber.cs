// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderAutoNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.AutoNumber;
using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 자동번호 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderAutoNumber : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly AutoNumberHeaderProperty property;

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
        public CtrlHeaderAutoNumber()
            : base(ControlType.AutoNumber.GetCtrlId())
        {
            property = new AutoNumberHeaderProperty();
            userSymbol = new HWPString();
            beforeDecorationLetter = new HWPString();
            afterDecorationLetter = new HWPString();
        }

        /// <summary>
        /// 자동번호 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public AutoNumberHeaderProperty Property => property;

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
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderAutoNumber from2 = (CtrlHeaderAutoNumber)from;
            property.Copy(from2.property);
            Number = from2.Number;
            userSymbol.Copy(from2.userSymbol);
            beforeDecorationLetter.Copy(from2.beforeDecorationLetter);
            afterDecorationLetter.Copy(from2.afterDecorationLetter);
        }
    }
}

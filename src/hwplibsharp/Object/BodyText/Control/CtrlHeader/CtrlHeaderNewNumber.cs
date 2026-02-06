// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderNewNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.NewNumber;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 새 번호 지정 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderNewNumber : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly NewNumberHeaderProperty property;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderNewNumber()
            : base(ControlType.NewNumber.GetCtrlId())
        {
            property = new NewNumberHeaderProperty();
        }

        /// <summary>
        /// 새 번호 지정 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public NewNumberHeaderProperty Property => property;

        /// <summary>
        /// 번호
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderNewNumber from2 = (CtrlHeaderNewNumber)from;
            property.Copy(from2.property);
            Number = from2.Number;
        }
    }
}

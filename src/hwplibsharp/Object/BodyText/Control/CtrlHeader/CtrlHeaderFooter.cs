// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderFooter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.Header;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 꼬리말 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderFooter : CtrlHeader
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderFooter()
            : base(ControlType.Footer.GetCtrlId())
        {
        }

        /// <summary>
        /// 꼬리말이 적용될 범위(페이지 종류)
        /// </summary>
        public HeaderFooterApplyPage ApplyPage { get; set; }

        /// <summary>
        /// 생성 순서 (??)
        /// </summary>
        public int CreateIndex { get; set; }

        /// <summary>
        /// 다른 <see cref="CtrlHeaderFooter"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeaderFooter"/> 인스턴스입니다.</param>
        public void Copy(CtrlHeaderFooter from)
        {
            ApplyPage = from.ApplyPage;
            CreateIndex = from.CreateIndex;
        }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderFooter from2 = (CtrlHeaderFooter)from;
            ApplyPage = from2.ApplyPage;
            CreateIndex = from2.CreateIndex;
        }
    }
}

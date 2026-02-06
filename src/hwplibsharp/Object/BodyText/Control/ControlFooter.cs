// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlFooter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.HeaderFooter;
using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 꼬리말 컨트롤
    /// </summary>
    public class ControlFooter : Control
    {
        /// <summary>
        /// 머리말/꼬리말용 리스트 헤더
        /// </summary>
        private readonly ListHeaderForHeaderFooter _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlFooter()
            : base(new CtrlHeaderFooter())
        {
            _listHeader = new ListHeaderForHeaderFooter();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 꼬리말용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>꼬리말용 컨트롤 헤더</returns>
        public new CtrlHeaderFooter Header => (CtrlHeaderFooter)base.Header!;

        /// <summary>
        /// 머리말/꼬리말용 리스트 헤더를 반환한다.
        /// </summary>
        public ListHeaderForHeaderFooter ListHeader => _listHeader;

        /// <summary>
        /// 문단 리스트를 반환한다.
        /// </summary>
        public ParagraphList ParagraphList => _paragraphList;

        /// <summary>
        /// 컨트롤을 복제한다.
        /// </summary>
        /// <returns>복제된 컨트롤</returns>
        public override Control Clone()
        {
            var cloned = new ControlFooter();
            cloned.CopyControlPart(this);
            cloned._listHeader.Copy(_listHeader);
            cloned._paragraphList.Copy(_paragraphList);
            return cloned;
        }
    }
}

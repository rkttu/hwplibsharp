// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlEndnote.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.FootnoteEndnote;
using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 미주(Endnote) 컨트롤
    /// </summary>
    public class ControlEndnote : Control
    {
        /// <summary>
        /// 각주/미주용 리스트 헤더
        /// </summary>
        private readonly ListHeaderForFootnoteEndnote _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlEndnote()
            : base(new CtrlHeaderEndnote())
        {
            _listHeader = new ListHeaderForFootnoteEndnote();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 미주 컨트롤용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>미주 컨트롤용 컨트롤 헤더</returns>
        public new CtrlHeaderEndnote Header => (CtrlHeaderEndnote)base.Header!;

        /// <summary>
        /// 각주/미주용 리스트 헤더를 반환한다.
        /// </summary>
        public ListHeaderForFootnoteEndnote ListHeader => _listHeader;

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
            var cloned = new ControlEndnote();
            cloned.CopyControlPart(this);
            cloned._listHeader.Copy(_listHeader);
            cloned._paragraphList.Copy(_paragraphList);
            return cloned;
        }
    }
}

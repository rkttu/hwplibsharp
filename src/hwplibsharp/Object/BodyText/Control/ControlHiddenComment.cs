// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlHiddenComment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.HiddenComment;
using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 숨은 설명 컨트롤
    /// </summary>
    public class ControlHiddenComment : Control
    {
        /// <summary>
        /// 숨은 설명 용 리스트 헤더
        /// </summary>
        private readonly ListHeaderForHiddenComment _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlHiddenComment()
            : base(new CtrlHeader.CtrlHeaderHiddenComment())
        {
            _listHeader = new ListHeaderForHiddenComment();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>컨트롤 헤더</returns>
        public new CtrlHeader.CtrlHeaderHiddenComment Header => (CtrlHeader.CtrlHeaderHiddenComment)base.Header!;

        /// <summary>
        /// 숨은 설명 용 리스트 헤더를 반환한다.
        /// </summary>
        public ListHeaderForHiddenComment ListHeader => _listHeader;

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
            var cloned = new ControlHiddenComment();
            cloned.CopyControlPart(this);
            cloned._listHeader.Copy(_listHeader);
            cloned._paragraphList.Copy(_paragraphList);
            return cloned;
        }
    }
}

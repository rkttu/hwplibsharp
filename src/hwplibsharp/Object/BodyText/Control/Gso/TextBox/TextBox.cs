// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/textbox/TextBox.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Object.BodyText.Control.Gso.TextBox
{
    /// <summary>
    /// 글상자를 나타내는 객체
    /// </summary>
    public class TextBox
    {
        /// <summary>
        /// 문단 리스트 헤더
        /// </summary>
        private readonly ListHeaderForTextBox _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public TextBox()
        {
            _listHeader = new ListHeaderForTextBox();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 문단 리스트 헤더 객체를 반환한다.
        /// </summary>
        public ListHeaderForTextBox ListHeader => _listHeader;

        /// <summary>
        /// 문단 리스트 객체를 반환한다.
        /// </summary>
        public ParagraphList ParagraphList => _paragraphList;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(TextBox from)
        {
            _listHeader.Copy(from._listHeader);
            _paragraphList.Copy(from._paragraphList);
        }
    }
}

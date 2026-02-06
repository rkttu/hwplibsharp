// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/caption/Caption.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================
using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Object.BodyText.Control.Gso.Caption
{
    /// <summary>
    /// 캡션 정보를 나타내는 객체
    /// </summary>
    public class Caption
    {
        /// <summary>
        /// 문단 리스트 헤더
        /// </summary>
        private readonly ListHeaderForCaption _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public Caption()
        {
            _listHeader = new ListHeaderForCaption();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 문단 리스트 헤더를 반환한다.
        /// </summary>
        public ListHeaderForCaption ListHeader => _listHeader;

        /// <summary>
        /// 문단 리스트를 반환한다.
        /// </summary>
        public ParagraphList ParagraphList => _paragraphList;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(Caption from)
        {
            _listHeader.Copy(from._listHeader);
            _paragraphList.Copy(from._paragraphList);
        }
    }
}

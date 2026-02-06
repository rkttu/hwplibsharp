// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/table/Cell.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Object.BodyText.Control.Table
{
    /// <summary>
    /// 표의 셀을 나타내는 객체
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// 문단 리스트 헤더
        /// </summary>
        private readonly ListHeaderForCell _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public Cell()
        {
            _listHeader = new ListHeaderForCell();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 문단 리스트 헤더를 반환한다.
        /// </summary>
        public ListHeaderForCell ListHeader => _listHeader;

        /// <summary>
        /// 문단 리스트를 반환한다.
        /// </summary>
        public ParagraphList ParagraphList => _paragraphList;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public Cell Clone()
        {
            var cloned = new Cell();
            cloned._listHeader.Copy(_listHeader);
            cloned._paragraphList.Copy(_paragraphList);
            return cloned;
        }
    }
}

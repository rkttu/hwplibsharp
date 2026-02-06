// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/memo/Memo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Paragraph.Memo
{
    /// <summary>
    /// 메모 정보를 나타내는 객체
    /// </summary>
    public class Memo
    {
        /// <summary>
        /// 메모 리스트 레코드
        /// </summary>
        private readonly MemoList _memoList;

        /// <summary>
        /// 메모를 위한 리스트 헤더 레코드
        /// </summary>
        private readonly ListHeaderForMemo _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public Memo()
        {
            _memoList = new MemoList();
            _listHeader = new ListHeaderForMemo();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 메모 리스트 레코드를 반환한다.
        /// </summary>
        public MemoList MemoList => _memoList;

        /// <summary>
        /// 메모를 위한 리스트 헤더 레코드를 반환한다.
        /// </summary>
        public ListHeaderForMemo ListHeader => _listHeader;

        /// <summary>
        /// 문단 리스트를 반환한다.
        /// </summary>
        public ParagraphList ParagraphList => _paragraphList;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public Memo Clone()
        {
            var cloned = new Memo();
            cloned._memoList.Copy(_memoList);
            cloned._listHeader.Copy(_listHeader);
            cloned._paragraphList.Copy(_paragraphList);
            return cloned;
        }
    }
}

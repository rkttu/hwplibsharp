// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/memo/MemoList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Paragraph.Memo
{
    /// <summary>
    /// 메모 리스트 레코드
    /// </summary>
    public class MemoList
    {
        /// <summary>
        /// 메모 인덱스
        /// </summary>
        public long MemoIndex { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public MemoList()
        {
            MemoIndex = 0;
        }

        /// <summary>
        /// 다른 MemoList 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(MemoList from)
        {
            MemoIndex = from.MemoIndex;
        }
    }
}

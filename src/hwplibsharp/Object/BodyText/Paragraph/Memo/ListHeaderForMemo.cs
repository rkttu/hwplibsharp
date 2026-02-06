// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/memo/ListHeaderForMemo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.TextBox;

namespace HwpLib.Object.BodyText.Paragraph.Memo
{
    /// <summary>
    /// 메모를 위한 문단 리스트 헤더 레코드
    /// </summary>
    public class ListHeaderForMemo
    {
        /// <summary>
        /// 문단 개수
        /// </summary>
        public int ParaCount { get; set; }

        /// <summary>
        /// 속성
        /// </summary>
        public ListHeaderProperty Property { get; }

        /// <summary>
        /// 텍스트 영역의 폭
        /// </summary>
        public long TextWidth { get; set; }

        /// <summary>
        /// 텍스트 영역의 높이
        /// </summary>
        public long TextHeight { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderForMemo()
        {
            Property = new ListHeaderProperty();
        }

        /// <summary>
        /// 다른 ListHeaderForMemo 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ListHeaderForMemo from)
        {
            ParaCount = from.ParaCount;
            Property.Copy(from.Property);
            TextWidth = from.TextWidth;
            TextHeight = from.TextHeight;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/footnoteendnote/ListHeaderForFootnoteEndnote.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.TextBox;

namespace HwpLib.Object.BodyText.Control.FootnoteEndnote
{
    /// <summary>
    /// 미주/각주을 위한 문단 리스트 헤더 레코드
    /// </summary>
    public class ListHeaderForFootnoteEndnote
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
        /// 생성자
        /// </summary>
        public ListHeaderForFootnoteEndnote()
        {
            Property = new ListHeaderProperty();
        }

        /// <summary>
        /// 다른 객체에서 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본</param>
        public void Copy(ListHeaderForFootnoteEndnote from)
        {
            ParaCount = from.ParaCount;
            Property.Copy(from.Property);
        }
    }
}

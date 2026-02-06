// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/hiddencomment/ListHeaderForHiddenComment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.TextBox;

namespace HwpLib.Object.BodyText.Control.HiddenComment
{
    /// <summary>
    /// 숨은 설명을 위한 문단 리스트 헤더
    /// </summary>
    public class ListHeaderForHiddenComment
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
        public ListHeaderForHiddenComment()
        {
            Property = new ListHeaderProperty();
        }

        /// <summary>
        /// 다른 객체에서 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본</param>
        public void Copy(ListHeaderForHiddenComment from)
        {
            ParaCount = from.ParaCount;
            Property.Copy(from.Property);
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/ListHeaderForBatangPage.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.TextBox;

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 바탕쪽을 위한 문단 리스트 헤더 레코드
    /// </summary>
    public class ListHeaderForBatangPage
    {
        /// <summary>
        /// 문단 개수
        /// </summary>
        private int _paraCount;

        /// <summary>
        /// 속성
        /// </summary>
        private readonly ListHeaderProperty _property;

        /// <summary>
        /// 텍스트 영역의 폭
        /// </summary>
        private long _textWidth;

        /// <summary>
        /// 텍스트 영역의 높이
        /// </summary>
        private long _textHeight;

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderForBatangPage()
        {
            _property = new ListHeaderProperty();
        }

        /// <summary>
        /// 문단 개수를 반환하거나 설정한다.
        /// </summary>
        public int ParaCount
        {
            get => _paraCount;
            set => _paraCount = value;
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public ListHeaderProperty Property => _property;

        /// <summary>
        /// 텍스트 영역의 폭을 반환하거나 설정한다.
        /// </summary>
        public long TextWidth
        {
            get => _textWidth;
            set => _textWidth = value;
        }

        /// <summary>
        /// 텍스트 영역의 높이를 반환하거나 설정한다.
        /// </summary>
        public long TextHeight
        {
            get => _textHeight;
            set => _textHeight = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ListHeaderForBatangPage from)
        {
            _paraCount = from._paraCount;
            _property.Copy(from._property);
            _textWidth = from._textWidth;
            _textHeight = from._textHeight;
        }
    }
}

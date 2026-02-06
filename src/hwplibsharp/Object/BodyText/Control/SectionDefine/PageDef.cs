// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/PageDef.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 용지 설정에 대한 레코드
    /// </summary>
    public class PageDef
    {
        /// <summary>
        /// 용지 가로 크기
        /// </summary>
        private long _paperWidth;

        /// <summary>
        /// 용지 세로 크기
        /// </summary>
        private long _paperHeight;

        /// <summary>
        /// 용지 왼쪽 여백
        /// </summary>
        private long _leftMargin;

        /// <summary>
        /// 용지 오른쪽 여백
        /// </summary>
        private long _rightMargin;

        /// <summary>
        /// 용지 위쪽 여백
        /// </summary>
        private long _topMargin;

        /// <summary>
        /// 용지 아래쪽 여백
        /// </summary>
        private long _bottomMargin;

        /// <summary>
        /// 머리말 여백
        /// </summary>
        private long _headerMargin;

        /// <summary>
        /// 꼬리말 여백
        /// </summary>
        private long _footerMargin;

        /// <summary>
        /// 제본 여백
        /// </summary>
        private long _gutterMargin;

        /// <summary>
        /// 속성
        /// </summary>
        private readonly PageDefProperty _property;

        /// <summary>
        /// 생성자
        /// </summary>
        public PageDef()
        {
            _property = new PageDefProperty();
        }

        /// <summary>
        /// 용지 가로 크기를 반환하거나 설정한다.
        /// </summary>
        public long PaperWidth
        {
            get => _paperWidth;
            set => _paperWidth = value;
        }

        /// <summary>
        /// 용지 세로 크기를 반환하거나 설정한다.
        /// </summary>
        public long PaperHeight
        {
            get => _paperHeight;
            set => _paperHeight = value;
        }

        /// <summary>
        /// 용지 왼쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public long LeftMargin
        {
            get => _leftMargin;
            set => _leftMargin = value;
        }

        /// <summary>
        /// 용지 오른쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public long RightMargin
        {
            get => _rightMargin;
            set => _rightMargin = value;
        }

        /// <summary>
        /// 용지 위쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public long TopMargin
        {
            get => _topMargin;
            set => _topMargin = value;
        }

        /// <summary>
        /// 용지 아래쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public long BottomMargin
        {
            get => _bottomMargin;
            set => _bottomMargin = value;
        }

        /// <summary>
        /// 머리말 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public long HeaderMargin
        {
            get => _headerMargin;
            set => _headerMargin = value;
        }

        /// <summary>
        /// 꼬리말 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public long FooterMargin
        {
            get => _footerMargin;
            set => _footerMargin = value;
        }

        /// <summary>
        /// 제본 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public long GutterMargin
        {
            get => _gutterMargin;
            set => _gutterMargin = value;
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public PageDefProperty Property => _property;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PageDef from)
        {
            _paperWidth = from._paperWidth;
            _paperHeight = from._paperHeight;
            _leftMargin = from._leftMargin;
            _rightMargin = from._rightMargin;
            _topMargin = from._topMargin;
            _bottomMargin = from._bottomMargin;
            _headerMargin = from._headerMargin;
            _footerMargin = from._footerMargin;
            _gutterMargin = from._gutterMargin;
            _property.Copy(from._property);
        }
    }
}

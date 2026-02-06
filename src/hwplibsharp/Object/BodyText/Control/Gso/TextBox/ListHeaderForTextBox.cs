// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/textbox/ListHeaderForTextBox.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.TextBox
{
    /// <summary>
    /// 글상자를 위한 문단 리스트 헤더 레코드
    /// </summary>
    public class ListHeaderForTextBox
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
        /// 글상자 텍스트 왼쪽 여백
        /// </summary>
        private int _leftMargin;

        /// <summary>
        /// 글상자 텍스트 오른쪽 여백
        /// </summary>
        private int _rightMargin;

        /// <summary>
        /// 글상자 텍스트 위쪽 여백
        /// </summary>
        private int _topMargin;

        /// <summary>
        /// 글상자 텍스트 아래쪽 여백
        /// </summary>
        private int _bottomMargin;

        /// <summary>
        /// 텍스트 문자열의 최대 폭
        /// </summary>
        private long _textWidth;

        /// <summary>
        /// 양식 모드에서 편집 가능
        /// </summary>
        private bool _editableAtFormMode;

        /// <summary>
        /// 필드 이름
        /// </summary>
        private string? _fieldName;

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderForTextBox()
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
        /// 글상자 텍스트 왼쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int LeftMargin
        {
            get => _leftMargin;
            set => _leftMargin = value;
        }

        /// <summary>
        /// 글상자 텍스트 오른쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int RightMargin
        {
            get => _rightMargin;
            set => _rightMargin = value;
        }

        /// <summary>
        /// 글상자 텍스트 위쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int TopMargin
        {
            get => _topMargin;
            set => _topMargin = value;
        }

        /// <summary>
        /// 글상자 텍스트 아래쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int BottomMargin
        {
            get => _bottomMargin;
            set => _bottomMargin = value;
        }

        /// <summary>
        /// 텍스트 문자열의 최대 폭을 반환하거나 설정한다.
        /// </summary>
        public long TextWidth
        {
            get => _textWidth;
            set => _textWidth = value;
        }

        /// <summary>
        /// 양식 모드에서 편집 가능 여부를 반환하거나 설정한다.
        /// </summary>
        public bool EditableAtFormMode
        {
            get => _editableAtFormMode;
            set => _editableAtFormMode = value;
        }

        /// <summary>
        /// 필드 이름을 반환하거나 설정한다.
        /// </summary>
        public string? FieldName
        {
            get => _fieldName;
            set => _fieldName = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ListHeaderForTextBox from)
        {
            _paraCount = from._paraCount;
            _property.Copy(from._property);
            _leftMargin = from._leftMargin;
            _rightMargin = from._rightMargin;
            _topMargin = from._topMargin;
            _bottomMargin = from._bottomMargin;
            _textWidth = from._textWidth;
            _editableAtFormMode = from._editableAtFormMode;
            _fieldName = from._fieldName;
        }
    }
}

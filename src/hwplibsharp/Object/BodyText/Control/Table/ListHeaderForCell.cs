// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/table/ListHeaderForCell.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Table
{
    /// <summary>
    /// 셀의 문단 리스트 헤더 레코드
    /// </summary>
    public class ListHeaderForCell
    {
        /// <summary>
        /// 문단 개수
        /// </summary>
        private int _paraCount;

        /// <summary>
        /// 속성
        /// </summary>
        private readonly ListHeaderPropertyForCell _property;

        /// <summary>
        /// 셀 주소(Column)
        /// </summary>
        private int _colIndex;

        /// <summary>
        /// 셀 주소(Row)
        /// </summary>
        private int _rowIndex;

        /// <summary>
        /// 열의 병합 개수
        /// </summary>
        private int _colSpan;

        /// <summary>
        /// 행의 병합 개수
        /// </summary>
        private int _rowSpan;

        /// <summary>
        /// 셀의 폭
        /// </summary>
        private long _width;

        /// <summary>
        /// 셀의 높이
        /// </summary>
        private long _height;

        /// <summary>
        /// 왼쪽 여백
        /// </summary>
        private int _leftMargin;

        /// <summary>
        /// 오른쪽 여백
        /// </summary>
        private int _rightMargin;

        /// <summary>
        /// 위쪽 여백
        /// </summary>
        private int _topMargin;

        /// <summary>
        /// 아래쪽 여백
        /// </summary>
        private int _bottomMargin;

        /// <summary>
        /// 참조된 테두리/배경 id
        /// </summary>
        private int _borderFillId;

        /// <summary>
        /// 텍스트 폭
        /// </summary>
        private long _textWidth;

        /// <summary>
        /// 필드 이름
        /// </summary>
        private string? _fieldName;

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderForCell()
        {
            _property = new ListHeaderPropertyForCell();
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
        public ListHeaderPropertyForCell Property => _property;

        /// <summary>
        /// 셀 주소(Column)을 반환하거나 설정한다.
        /// </summary>
        public int ColIndex
        {
            get => _colIndex;
            set => _colIndex = value;
        }

        /// <summary>
        /// 셀 주소(Row)를 반환하거나 설정한다.
        /// </summary>
        public int RowIndex
        {
            get => _rowIndex;
            set => _rowIndex = value;
        }

        /// <summary>
        /// 열의 병합 개수를 반환하거나 설정한다.
        /// </summary>
        public int ColSpan
        {
            get => _colSpan;
            set => _colSpan = value;
        }

        /// <summary>
        /// 행의 병합 개수를 반환하거나 설정한다.
        /// </summary>
        public int RowSpan
        {
            get => _rowSpan;
            set => _rowSpan = value;
        }

        /// <summary>
        /// 셀의 폭을 반환하거나 설정한다.
        /// </summary>
        public long Width
        {
            get => _width;
            set => _width = value;
        }

        /// <summary>
        /// 셀의 높이를 반환하거나 설정한다.
        /// </summary>
        public long Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// 왼쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int LeftMargin
        {
            get => _leftMargin;
            set => _leftMargin = value;
        }

        /// <summary>
        /// 오른쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int RightMargin
        {
            get => _rightMargin;
            set => _rightMargin = value;
        }

        /// <summary>
        /// 위쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int TopMargin
        {
            get => _topMargin;
            set => _topMargin = value;
        }

        /// <summary>
        /// 아래쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int BottomMargin
        {
            get => _bottomMargin;
            set => _bottomMargin = value;
        }

        /// <summary>
        /// 참조된 테두리/배경 id를 반환하거나 설정한다.
        /// </summary>
        public int BorderFillId
        {
            get => _borderFillId;
            set => _borderFillId = value;
        }

        /// <summary>
        /// 텍스트 폭을 반환하거나 설정한다.
        /// </summary>
        public long TextWidth
        {
            get => _textWidth;
            set => _textWidth = value;
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
        public void Copy(ListHeaderForCell from)
        {
            _paraCount = from._paraCount;
            _property.Copy(from._property);
            _colIndex = from._colIndex;
            _rowIndex = from._rowIndex;
            _colSpan = from._colSpan;
            _rowSpan = from._rowSpan;
            _width = from._width;
            _height = from._height;
            _leftMargin = from._leftMargin;
            _rightMargin = from._rightMargin;
            _topMargin = from._topMargin;
            _bottomMargin = from._bottomMargin;
            _borderFillId = from._borderFillId;
            _textWidth = from._textWidth;
            _fieldName = from._fieldName;
        }
    }
}

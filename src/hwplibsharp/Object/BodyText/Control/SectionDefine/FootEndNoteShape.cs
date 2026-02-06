// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/FootEndNoteShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill;
using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 미주/각주 모양 정보에 대한 레코드
    /// </summary>
    public class FootEndNoteShape
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly FootNoteShapeProperty _property;

        /// <summary>
        /// 사용자 기호
        /// </summary>
        private readonly HWPString _userSymbol;

        /// <summary>
        /// 앞 장식 문자
        /// </summary>
        private readonly HWPString _beforeDecorativeLetter;

        /// <summary>
        /// 뒤 장식 문자
        /// </summary>
        private readonly HWPString _afterDecorativeLetter;

        /// <summary>
        /// 시작 번호
        /// </summary>
        private int _startNumber;

        /// <summary>
        /// 구분선 길이
        /// </summary>
        private long _divideLineLength;

        /// <summary>
        /// 구분선 위 여백
        /// </summary>
        private int _divideLineTopMargin;

        /// <summary>
        /// 구분선 아래 여백
        /// </summary>
        private int _divideLineBottomMargin;

        /// <summary>
        /// 주석 사이 여백
        /// </summary>
        private int _betweenNotesMargin;

        /// <summary>
        /// 구분선 정보
        /// </summary>
        private readonly EachBorder _divideLine;

        /// <summary>
        /// 알수 없는 4 byte
        /// </summary>
        private long _unknown;

        /// <summary>
        /// 생성자
        /// </summary>
        public FootEndNoteShape()
        {
            _property = new FootNoteShapeProperty();
            _userSymbol = new HWPString();
            _beforeDecorativeLetter = new HWPString();
            _afterDecorativeLetter = new HWPString();
            _divideLine = new EachBorder();
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public FootNoteShapeProperty Property => _property;

        /// <summary>
        /// 사용자 기호를 반환한다.
        /// </summary>
        public HWPString UserSymbol => _userSymbol;

        /// <summary>
        /// 앞 장식 문자를 반환한다.
        /// </summary>
        public HWPString BeforeDecorativeLetter => _beforeDecorativeLetter;

        /// <summary>
        /// 뒤 장식 문자를 반환한다.
        /// </summary>
        public HWPString AfterDecorativeLetter => _afterDecorativeLetter;

        /// <summary>
        /// 시작 번호를 반환하거나 설정한다.
        /// </summary>
        public int StartNumber
        {
            get => _startNumber;
            set => _startNumber = value;
        }

        /// <summary>
        /// 구분선 길이를 반환하거나 설정한다.
        /// </summary>
        public long DivideLineLength
        {
            get => _divideLineLength;
            set => _divideLineLength = value;
        }

        /// <summary>
        /// 구분선 위 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int DivideLineTopMargin
        {
            get => _divideLineTopMargin;
            set => _divideLineTopMargin = value;
        }

        /// <summary>
        /// 구분선 아래 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int DivideLineBottomMargin
        {
            get => _divideLineBottomMargin;
            set => _divideLineBottomMargin = value;
        }

        /// <summary>
        /// 주석 사이 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int BetweenNotesMargin
        {
            get => _betweenNotesMargin;
            set => _betweenNotesMargin = value;
        }

        /// <summary>
        /// 구분선 정보를 반환한다.
        /// </summary>
        public EachBorder DivideLine => _divideLine;

        /// <summary>
        /// 알수 없는 4byte를 반환하거나 설정한다.
        /// </summary>
        public long Unknown
        {
            get => _unknown;
            set => _unknown = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FootEndNoteShape from)
        {
            _property.Copy(from._property);
            _userSymbol.Copy(from._userSymbol);
            _beforeDecorativeLetter.Copy(from._beforeDecorativeLetter);
            _afterDecorativeLetter.Copy(from._afterDecorativeLetter);
            _startNumber = from._startNumber;
            _divideLineLength = from._divideLineLength;
            _divideLineTopMargin = from._divideLineTopMargin;
            _divideLineBottomMargin = from._divideLineBottomMargin;
            _betweenNotesMargin = from._betweenNotesMargin;
            _divideLine.Copy(from._divideLine);
            _unknown = from._unknown;
        }
    }
}

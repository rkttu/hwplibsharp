// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/IDMappings.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 아이디 매핑 헤더를 나타내는 레코드. "DocInfo" stream 안에 있는 다른 객체들의 개수를 저장한다.
    /// </summary>
    public class IDMappings
    {
        private int _binDataCount;
        private int _hangulFaceNameCount;
        private int _englishFaceNameCount;
        private int _hanjaFaceNameCount;
        private int _japaneseFaceNameCount;
        private int _etcFaceNameCount;
        private int _symbolFaceNameCount;
        private int _userFaceNameCount;
        private int _borderFillCount;
        private int _charShapeCount;
        private int _tabDefCount;
        private int _numberingCount;
        private int _bulletCount;
        private int _paraShapeCount;
        private int _styleCount;
        private int _memoShapeCount;
        private int _trackChangeCount;
        private int _trackChangeAuthorCount;

        /// <summary>
        /// <see cref="IDMappings"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public IDMappings()
        {
        }

        /// <summary>
        /// BinData 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int BinDataCount
        {
            get => _binDataCount;
            set => _binDataCount = value;
        }

        /// <summary>
        /// 한글 글꼴 이름 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int HangulFaceNameCount
        {
            get => _hangulFaceNameCount;
            set => _hangulFaceNameCount = value;
        }

        /// <summary>
        /// 영문 글꼴 이름 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int EnglishFaceNameCount
        {
            get => _englishFaceNameCount;
            set => _englishFaceNameCount = value;
        }

        /// <summary>
        /// 한자 글꼴 이름 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int HanjaFaceNameCount
        {
            get => _hanjaFaceNameCount;
            set => _hanjaFaceNameCount = value;
        }

        /// <summary>
        /// 일본어 글꼴 이름 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int JapaneseFaceNameCount
        {
            get => _japaneseFaceNameCount;
            set => _japaneseFaceNameCount = value;
        }

        /// <summary>
        /// 기타 글꼴 이름 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int EtcFaceNameCount
        {
            get => _etcFaceNameCount;
            set => _etcFaceNameCount = value;
        }

        /// <summary>
        /// 기호 글꼴 이름 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int SymbolFaceNameCount
        {
            get => _symbolFaceNameCount;
            set => _symbolFaceNameCount = value;
        }

        /// <summary>
        /// 사용자 글꼴 이름 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int UserFaceNameCount
        {
            get => _userFaceNameCount;
            set => _userFaceNameCount = value;
        }

        /// <summary>
        /// 테두리/배경 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int BorderFillCount
        {
            get => _borderFillCount;
            set => _borderFillCount = value;
        }

        /// <summary>
        /// 글자 모양 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int CharShapeCount
        {
            get => _charShapeCount;
            set => _charShapeCount = value;
        }

        /// <summary>
        /// 탭 정의 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int TabDefCount
        {
            get => _tabDefCount;
            set => _tabDefCount = value;
        }

        /// <summary>
        /// 번호 매기기 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int NumberingCount
        {
            get => _numberingCount;
            set => _numberingCount = value;
        }

        /// <summary>
        /// 글머리표 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int BulletCount
        {
            get => _bulletCount;
            set => _bulletCount = value;
        }

        /// <summary>
        /// 문단 모양 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int ParaShapeCount
        {
            get => _paraShapeCount;
            set => _paraShapeCount = value;
        }

        /// <summary>
        /// 스타일 객체의 개수를 가져오거나 설정합니다.
        /// </summary>
        public int StyleCount
        {
            get => _styleCount;
            set => _styleCount = value;
        }

        /// <summary>
        /// 메모 모양 객체의 개수 (5.0.2.1 이상)
        /// </summary>
        public int MemoShapeCount
        {
            get => _memoShapeCount;
            set => _memoShapeCount = value;
        }

        /// <summary>
        /// 변경 추적 객체의 개수 (5.0.3.2 이상)
        /// </summary>
        public int TrackChangeCount
        {
            get => _trackChangeCount;
            set => _trackChangeCount = value;
        }

        /// <summary>
        /// 변경추적 사용자 객체의 개수 (5.0.3.2 이상)
        /// </summary>
        public int TrackChangeAuthorCount
        {
            get => _trackChangeAuthorCount;
            set => _trackChangeAuthorCount = value;
        }

        /// <summary>
        /// <paramref name="from"/>의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="IDMappings"/> 인스턴스입니다.</param>
        public void Copy(IDMappings from)
        {
            _binDataCount = from._binDataCount;
            _hangulFaceNameCount = from._hangulFaceNameCount;
            _englishFaceNameCount = from._englishFaceNameCount;
            _hanjaFaceNameCount = from._hanjaFaceNameCount;
            _japaneseFaceNameCount = from._japaneseFaceNameCount;
            _etcFaceNameCount = from._etcFaceNameCount;
            _symbolFaceNameCount = from._symbolFaceNameCount;
            _userFaceNameCount = from._userFaceNameCount;
            _borderFillCount = from._borderFillCount;
            _charShapeCount = from._charShapeCount;
            _tabDefCount = from._tabDefCount;
            _numberingCount = from._numberingCount;
            _bulletCount = from._bulletCount;
            _paraShapeCount = from._paraShapeCount;
            _styleCount = from._styleCount;
            _memoShapeCount = from._memoShapeCount;
            _trackChangeCount = from._trackChangeCount;
            _trackChangeAuthorCount = from._trackChangeAuthorCount;
        }
    }
}

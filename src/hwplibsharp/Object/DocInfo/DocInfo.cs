// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/DocInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;
using System.Collections.Generic;
using CfRecordHeader = HwpLib.CompoundFile.RecordHeader;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 문서 정보를 나타내는 객체. HWP파일 내의 "DocInfo" stream에 저장된다.
    /// </summary>
    public class DocInfo
    {
        /// <summary>
        /// 문서 속성
        /// </summary>
        private readonly DocumentPropertiesInfo _documentProperties;

        /// <summary>
        /// 아이디 매핑 헤더
        /// </summary>
        private readonly IDMappings _idMappings;

        /// <summary>
        /// 바이너리 데이터 리스트
        /// </summary>
        private readonly List<BinDataInfo> _binDataList;

        /// <summary>
        /// 한글 글꼴 리스트
        /// </summary>
        private readonly List<FaceNameInfo> _hangulFaceNameList;

        /// <summary>
        /// 영어 글꼴 리스트
        /// </summary>
        private readonly List<FaceNameInfo> _englishFaceNameList;

        /// <summary>
        /// 한자 글꼴 리스트
        /// </summary>
        private readonly List<FaceNameInfo> _hanjaFaceNameList;

        /// <summary>
        /// 일어 글꼴 리스트
        /// </summary>
        private readonly List<FaceNameInfo> _japaneseFaceNameList;

        /// <summary>
        /// 기타 글꼴 리스트
        /// </summary>
        private readonly List<FaceNameInfo> _etcFaceNameList;

        /// <summary>
        /// 기호 글꼴 리스트
        /// </summary>
        private readonly List<FaceNameInfo> _symbolFaceNameList;

        /// <summary>
        /// 사용자 글꼴 리스트
        /// </summary>
        private readonly List<FaceNameInfo> _userFaceNameList;

        /// <summary>
        /// 테두리/배경 리스트
        /// </summary>
        private readonly List<BorderFillInfo> _borderFillList;

        /// <summary>
        /// 글자 모양 리스트
        /// </summary>
        private readonly List<CharShapeInfo> _charShapeList;

        /// <summary>
        /// 탭 정의 리스트
        /// </summary>
        private readonly List<TabDefInfo> _tabDefList;

        /// <summary>
        /// 문단 번호 리스트
        /// </summary>
        private readonly List<NumberingInfo> _numberingList;

        /// <summary>
        /// 글머리표 리스트
        /// </summary>
        private readonly List<Bullet> _bulletList;

        /// <summary>
        /// 문단 모양 리스트
        /// </summary>
        private readonly List<ParaShapeInfo> _paraShapeList;

        /// <summary>
        /// 스타일 리스트
        /// </summary>
        private readonly List<StyleInfo> _styleList;

        /// <summary>
        /// 문서 임의의 데이터
        /// </summary>
        private UnknownRecord? _docData;

        /// <summary>
        /// 배포용 문서 데이터
        /// </summary>
        private UnknownRecord? _distributeDocData;

        /// <summary>
        /// 호환 문서
        /// </summary>
        private CompatibleDocumentInfo? _compatibleDocument;

        /// <summary>
        /// 레이아웃 호환성
        /// </summary>
        private LayoutCompatibility? _layoutCompatibility;

        /// <summary>
        /// 변경 추적 정보
        /// </summary>
        private UnknownRecord? _trackChange;

        /// <summary>
        /// 메모 모양 리스트
        /// </summary>
        private readonly List<MemoShape> _memoShapeList;

        /// <summary>
        /// 금칙처리 문자
        /// </summary>
        private UnknownRecord? _forbiddenChar;

        /// <summary>
        /// 변경 추적 내용 및 모양
        /// </summary>
        private readonly List<UnknownRecord> _trackChange2List;

        /// <summary>
        /// 변경 추적 작성자
        /// </summary>
        private readonly List<UnknownRecord> _trackChangeAuthorList;

        /// <summary>
        /// 생성자
        /// </summary>
        public DocInfo()
        {
            _documentProperties = new DocumentPropertiesInfo();
            _idMappings = new IDMappings();
            _binDataList = new List<BinDataInfo>();
            _hangulFaceNameList = new List<FaceNameInfo>();
            _englishFaceNameList = new List<FaceNameInfo>();
            _hanjaFaceNameList = new List<FaceNameInfo>();
            _japaneseFaceNameList = new List<FaceNameInfo>();
            _etcFaceNameList = new List<FaceNameInfo>();
            _symbolFaceNameList = new List<FaceNameInfo>();
            _userFaceNameList = new List<FaceNameInfo>();
            _borderFillList = new List<BorderFillInfo>();
            _charShapeList = new List<CharShapeInfo>();
            _tabDefList = new List<TabDefInfo>();
            _numberingList = new List<NumberingInfo>();
            _bulletList = new List<Bullet>();
            _paraShapeList = new List<ParaShapeInfo>();
            _styleList = new List<StyleInfo>();
            _memoShapeList = new List<MemoShape>();
            _trackChange2List = new List<UnknownRecord>();
            _trackChangeAuthorList = new List<UnknownRecord>();
        }

        /// <summary>
        /// 문서 속성 객체
        /// </summary>
        public DocumentPropertiesInfo DocumentProperties => _documentProperties;

        /// <summary>
        /// 아이디 매핑 헤더 객체
        /// </summary>
        public IDMappings IdMappings => _idMappings;

        /// <summary>
        /// 새로운 바이너리 데이터 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 바이너리 데이터 객체</returns>
        public BinDataInfo AddNewBinData()
        {
            var bd = new BinDataInfo();
            _binDataList.Add(bd);
            return bd;
        }

        /// <summary>
        /// 바이너리 데이터 객체 리스트
        /// </summary>
        public IReadOnlyList<BinDataInfo> BinDataList => _binDataList;

        /// <summary>
        /// 새로운 한글 글꼴 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 한글 글꼴 객체</returns>
        public FaceNameInfo AddNewHangulFaceName()
        {
            var fn = new FaceNameInfo();
            _hangulFaceNameList.Add(fn);
            return fn;
        }

        /// <summary>
        /// 한글 글꼴 객체 리스트
        /// </summary>
        public IReadOnlyList<FaceNameInfo> HangulFaceNameList => _hangulFaceNameList;

        /// <summary>
        /// 새로운 영어 글꼴 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 영어 글꼴 객체</returns>
        public FaceNameInfo AddNewEnglishFaceName()
        {
            var fn = new FaceNameInfo();
            _englishFaceNameList.Add(fn);
            return fn;
        }

        /// <summary>
        /// 영어 글꼴 객체 리스트
        /// </summary>
        public IReadOnlyList<FaceNameInfo> EnglishFaceNameList => _englishFaceNameList;

        /// <summary>
        /// 새로운 한자 글꼴 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 한자 글꼴 객체</returns>
        public FaceNameInfo AddNewHanjaFaceName()
        {
            var fn = new FaceNameInfo();
            _hanjaFaceNameList.Add(fn);
            return fn;
        }

        /// <summary>
        /// 한자 글꼴 객체 리스트
        /// </summary>
        public IReadOnlyList<FaceNameInfo> HanjaFaceNameList => _hanjaFaceNameList;

        /// <summary>
        /// 새로운 일본어 글꼴 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 일어 글꼴 객체</returns>
        public FaceNameInfo AddNewJapaneseFaceName()
        {
            var fn = new FaceNameInfo();
            _japaneseFaceNameList.Add(fn);
            return fn;
        }

        /// <summary>
        /// 일본어 글꼴 객체 리스트
        /// </summary>
        public IReadOnlyList<FaceNameInfo> JapaneseFaceNameList => _japaneseFaceNameList;

        /// <summary>
        /// 새로운 기타 글꼴 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 기타 글꼴 객체</returns>
        public FaceNameInfo AddNewEtcFaceName()
        {
            var fn = new FaceNameInfo();
            _etcFaceNameList.Add(fn);
            return fn;
        }

        /// <summary>
        /// 기타 글꼴 객체 리스트
        /// </summary>
        public IReadOnlyList<FaceNameInfo> EtcFaceNameList => _etcFaceNameList;

        /// <summary>
        /// 새로운 기호 글꼴 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 기호 글꼴 객체</returns>
        public FaceNameInfo AddNewSymbolFaceName()
        {
            var fn = new FaceNameInfo();
            _symbolFaceNameList.Add(fn);
            return fn;
        }

        /// <summary>
        /// 기호 글꼴 객체 리스트
        /// </summary>
        public IReadOnlyList<FaceNameInfo> SymbolFaceNameList => _symbolFaceNameList;

        /// <summary>
        /// 새로운 사용자 글꼴 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 사용자 글꼴 객체</returns>
        public FaceNameInfo AddNewUserFaceName()
        {
            var fn = new FaceNameInfo();
            _userFaceNameList.Add(fn);
            return fn;
        }

        /// <summary>
        /// 사용자 글꼴 객체 리스트
        /// </summary>
        public IReadOnlyList<FaceNameInfo> UserFaceNameList => _userFaceNameList;

        /// <summary>
        /// 외부에서 생성한 글꼴 정보를 한글 글꼴 리스트에 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 정보 객체</param>
        public void AddFaceNameToHangulList(FaceNameInfo fn) => _hangulFaceNameList.Add(fn);

        /// <summary>
        /// 외부에서 생성한 글꼴 정보를 영어 글꼴 리스트에 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 정보 객체</param>
        public void AddFaceNameToEnglishList(FaceNameInfo fn) => _englishFaceNameList.Add(fn);

        /// <summary>
        /// 외부에서 생성한 글꼴 정보를 한자 글꼴 리스트에 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 정보 객체</param>
        public void AddFaceNameToHanjaList(FaceNameInfo fn) => _hanjaFaceNameList.Add(fn);

        /// <summary>
        /// 외부에서 생성한 글꼴 정보를 일본어 글꼴 리스트에 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 정보 객체</param>
        public void AddFaceNameToJapaneseList(FaceNameInfo fn) => _japaneseFaceNameList.Add(fn);

        /// <summary>
        /// 외부에서 생성한 글꼴 정보를 기타 글꼴 리스트에 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 정보 객체</param>
        public void AddFaceNameToEtcList(FaceNameInfo fn) => _etcFaceNameList.Add(fn);

        /// <summary>
        /// 외부에서 생성한 글꼴 정보를 기호 글꼴 리스트에 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 정보 객체</param>
        public void AddFaceNameToSymbolList(FaceNameInfo fn) => _symbolFaceNameList.Add(fn);

        /// <summary>
        /// 외부에서 생성한 글꼴 정보를 사용자 글꼴 리스트에 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 정보 객체</param>
        public void AddFaceNameToUserList(FaceNameInfo fn) => _userFaceNameList.Add(fn);

        /// <summary>
        /// 새로운 테두리/배경 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 테두리/배경 객체</returns>
        public BorderFillInfo AddNewBorderFill()
        {
            var bf = new BorderFillInfo();
            _borderFillList.Add(bf);
            return bf;
        }

        /// <summary>
        /// 테두리/배경 객체 리스트
        /// </summary>
        public IReadOnlyList<BorderFillInfo> BorderFillList => _borderFillList;

        /// <summary>
        /// 새로운 글자 모양 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 글자 모양 객체</returns>
        public CharShapeInfo AddNewCharShape()
        {
            var cs = new CharShapeInfo();
            _charShapeList.Add(cs);
            return cs;
        }

        /// <summary>
        /// 글자 모양 객체 리스트
        /// </summary>
        public IReadOnlyList<CharShapeInfo> CharShapeList => _charShapeList;

        /// <summary>
        /// 새로운 탭 정의 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 탭 정의 객체</returns>
        public TabDefInfo AddNewTabDef()
        {
            var td = new TabDefInfo();
            _tabDefList.Add(td);
            return td;
        }

        /// <summary>
        /// 탭 정의 객체 리스트
        /// </summary>
        public IReadOnlyList<TabDefInfo> TabDefList => _tabDefList;

        /// <summary>
        /// 새로운 문단 번호 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 문단 번호 객체</returns>
        public NumberingInfo AddNewNumbering()
        {
            var n = new NumberingInfo();
            _numberingList.Add(n);
            return n;
        }

        /// <summary>
        /// 문단 번호 객체 리스트
        /// </summary>
        public IReadOnlyList<NumberingInfo> NumberingList => _numberingList;

        /// <summary>
        /// 새로운 글머리표 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 글머리표 객체</returns>
        public Bullet AddNewBullet()
        {
            var b = new Bullet();
            _bulletList.Add(b);
            return b;
        }

        /// <summary>
        /// 글머리표 객체 리스트
        /// </summary>
        public IReadOnlyList<Bullet> BulletList => _bulletList;

        /// <summary>
        /// 새로운 문단 모양 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 문단 모양 객체</returns>
        public ParaShapeInfo AddNewParaShape()
        {
            var ps = new ParaShapeInfo();
            _paraShapeList.Add(ps);
            return ps;
        }

        /// <summary>
        /// 문단 모양 객체 리스트
        /// </summary>
        public IReadOnlyList<ParaShapeInfo> ParaShapeList => _paraShapeList;

        /// <summary>
        /// 새로운 스타일 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 스타일 객체</returns>
        public StyleInfo AddNewStyle()
        {
            var s = new StyleInfo();
            _styleList.Add(s);
            return s;
        }

        /// <summary>
        /// 스타일 객체 리스트
        /// </summary>
        public IReadOnlyList<StyleInfo> StyleList => _styleList;

        /// <summary>
        /// 문서 임의의 데이터 객체를 생성한다.
        /// </summary>
        /// <param name="rh">레코드 헤더</param>
        public void CreateDocData(RecordHeader rh)
        {
            _docData = new UnknownRecord(rh);
        }

        /// <summary>
        /// 문서 임의의 데이터 객체를 생성한다. (CompoundFile.RecordHeader로부터)
        /// </summary>
        /// <param name="rh">CompoundFile 레코드 헤더</param>
        public void CreateDocData(CfRecordHeader rh)
        {
            _docData = new UnknownRecord(rh);
        }

        /// <summary>
        /// 문서 임의의 데이터 객체를 삭제한다.
        /// </summary>
        public void DeleteDocData()
        {
            _docData = null;
        }

        /// <summary>
        /// 문서 임의의 데이터 객체
        /// </summary>
        public UnknownRecord? DocData => _docData;

        /// <summary>
        /// 배포용 문서 데이터 객체를 생성한다.
        /// </summary>
        /// <param name="rh">레코드 헤더</param>
        public void CreateDistributeDocData(RecordHeader rh)
        {
            _distributeDocData = new UnknownRecord(rh);
        }

        /// <summary>
        /// 배포용 문서 데이터 객체를 생성한다. (CompoundFile.RecordHeader로부터)
        /// </summary>
        /// <param name="rh">CompoundFile 레코드 헤더</param>
        public void CreateDistributeDocData(CfRecordHeader rh)
        {
            _distributeDocData = new UnknownRecord(rh);
        }

        /// <summary>
        /// 배포용 문서 데이터 객체를 삭제한다.
        /// </summary>
        public void DeleteDistributeDocData()
        {
            _distributeDocData = null;
        }

        /// <summary>
        /// 배포용 문서 데이터 객체
        /// </summary>
        public UnknownRecord? DistributeDocData => _distributeDocData;

        /// <summary>
        /// 호환 문서 객체를 생성한다.
        /// </summary>
        public void CreateCompatibleDocument()
        {
            _compatibleDocument = new CompatibleDocumentInfo();
        }

        /// <summary>
        /// 호환 문서 객체를 삭제한다.
        /// </summary>
        public void DeleteCompatibleDocument()
        {
            _compatibleDocument = null;
        }

        /// <summary>
        /// 호환 문서 객체
        /// </summary>
        public CompatibleDocumentInfo? CompatibleDocument => _compatibleDocument;

        /// <summary>
        /// 레이아웃 호환성 객체를 생성한다.
        /// </summary>
        public void CreateLayoutCompatibility()
        {
            _layoutCompatibility = new LayoutCompatibility();
        }

        /// <summary>
        /// 레이아웃 호환성 객체를 삭제한다.
        /// </summary>
        public void DeleteLayoutCompatibility()
        {
            _layoutCompatibility = null;
        }

        /// <summary>
        /// 레이아웃 호환성 객체
        /// </summary>
        public LayoutCompatibility? LayoutCompatibility => _layoutCompatibility;

        /// <summary>
        /// 변경 추적 정보 객체를 생성한다.
        /// </summary>
        /// <param name="rh">레코드 헤더</param>
        public void CreateTrackChange(RecordHeader rh)
        {
            _trackChange = new UnknownRecord(rh);
        }

        /// <summary>
        /// 변경 추적 정보 객체를 생성한다. (CompoundFile.RecordHeader로부터)
        /// </summary>
        /// <param name="rh">CompoundFile 레코드 헤더</param>
        public void CreateTrackChange(CfRecordHeader rh)
        {
            _trackChange = new UnknownRecord(rh);
        }

        /// <summary>
        /// 변경 추적 정보 객체를 삭제한다.
        /// </summary>
        public void DeleteTrackChange()
        {
            _trackChange = null;
        }

        /// <summary>
        /// 변경 추적 정보 객체
        /// </summary>
        public UnknownRecord? TrackChange => _trackChange;

        /// <summary>
        /// 새로운 메모 모양 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 메모 모양 객체</returns>
        public MemoShape AddNewMemoShape()
        {
            var memoShape = new MemoShape();
            _memoShapeList.Add(memoShape);
            return memoShape;
        }

        /// <summary>
        /// 메모 모양 객체 리스트
        /// </summary>
        public IReadOnlyList<MemoShape> MemoShapeList => _memoShapeList;

        /// <summary>
        /// 금칙처리 문자 객체를 생성한다.
        /// </summary>
        /// <param name="rh">레코드 헤더</param>
        public void CreateForbiddenChar(RecordHeader rh)
        {
            _forbiddenChar = new UnknownRecord(rh);
        }

        /// <summary>
        /// 금칙처리 문자 객체를 생성한다. (CompoundFile.RecordHeader로부터)
        /// </summary>
        /// <param name="rh">CompoundFile 레코드 헤더</param>
        public void CreateForbiddenChar(CfRecordHeader rh)
        {
            _forbiddenChar = new UnknownRecord(rh);
        }

        /// <summary>
        /// 금칙처리 문자 객체를 삭제한다.
        /// </summary>
        public void DeleteForbiddenChar()
        {
            _forbiddenChar = null;
        }

        /// <summary>
        /// 금칙처리 문자 객체
        /// </summary>
        public UnknownRecord? ForbiddenChar => _forbiddenChar;

        /// <summary>
        /// 새로운 [변경 추적 내용 및 모양] 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="rh">레코드 헤더</param>
        /// <returns>새로 생성된 [변경 추적 내용 및 모양] 객체</returns>
        public UnknownRecord AddNewTrackChange2(RecordHeader rh)
        {
            var ur = new UnknownRecord(rh);
            _trackChange2List.Add(ur);
            return ur;
        }

        /// <summary>
        /// 새로운 [변경 추적 내용 및 모양] 객체를 생성하고 리스트에 추가한다. (CompoundFile.RecordHeader로부터)
        /// </summary>
        /// <param name="rh">CompoundFile 레코드 헤더</param>
        /// <returns>새로 생성된 [변경 추적 내용 및 모양] 객체</returns>
        public UnknownRecord AddNewTrackChange2(CfRecordHeader rh)
        {
            var ur = new UnknownRecord(rh);
            _trackChange2List.Add(ur);
            return ur;
        }

        /// <summary>
        /// [변경 추적 내용 및 모양] 객체 리스트
        /// </summary>
        public IReadOnlyList<UnknownRecord> TrackChange2List => _trackChange2List;

        /// <summary>
        /// 새로운 [변경 추적 작성자] 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="rh">레코드 헤더</param>
        /// <returns>새로 생성된 [변경 추적 작성자] 객체</returns>
        public UnknownRecord AddNewTrackChangeAuthor(RecordHeader rh)
        {
            var ur = new UnknownRecord(rh);
            _trackChangeAuthorList.Add(ur);
            return ur;
        }

        /// <summary>
        /// 새로운 [변경 추적 작성자] 객체를 생성하고 리스트에 추가한다. (CompoundFile.RecordHeader로부터)
        /// </summary>
        /// <param name="rh">CompoundFile 레코드 헤더</param>
        /// <returns>새로 생성된 [변경 추적 작성자] 객체</returns>
        public UnknownRecord AddNewTrackChangeAuthor(CfRecordHeader rh)
        {
            var ur = new UnknownRecord(rh);
            _trackChangeAuthorList.Add(ur);
            return ur;
        }

        /// <summary>
        /// [변경 추적 작성자] 객체 리스트
        /// </summary>
        public IReadOnlyList<UnknownRecord> TrackChangeAuthorList => _trackChangeAuthorList;

        /// <summary>
        /// 다른 DocInfo 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">원본 DocInfo 객체</param>
        public void Copy(DocInfo from)
        {
            _documentProperties.Copy(from._documentProperties);
            _idMappings.Copy(from._idMappings);

            _binDataList.Clear();
            foreach (var binData in from._binDataList)
            {
                _binDataList.Add(binData.Clone());
            }

            CopyFaceNameList(from._hangulFaceNameList, _hangulFaceNameList);
            CopyFaceNameList(from._englishFaceNameList, _englishFaceNameList);
            CopyFaceNameList(from._hanjaFaceNameList, _hanjaFaceNameList);
            CopyFaceNameList(from._japaneseFaceNameList, _japaneseFaceNameList);
            CopyFaceNameList(from._etcFaceNameList, _etcFaceNameList);
            CopyFaceNameList(from._symbolFaceNameList, _symbolFaceNameList);
            CopyFaceNameList(from._userFaceNameList, _userFaceNameList);

            _borderFillList.Clear();
            foreach (var borderFill in from._borderFillList)
            {
                _borderFillList.Add(borderFill.Clone());
            }

            _charShapeList.Clear();
            foreach (var charShape in from._charShapeList)
            {
                _charShapeList.Add(charShape.Clone());
            }

            _tabDefList.Clear();
            foreach (var tabDef in from._tabDefList)
            {
                _tabDefList.Add(tabDef.Clone());
            }

            _numberingList.Clear();
            foreach (var numbering in from._numberingList)
            {
                _numberingList.Add(numbering.Clone());
            }

            _bulletList.Clear();
            foreach (var bullet in from._bulletList)
            {
                _bulletList.Add(bullet.Clone());
            }

            _paraShapeList.Clear();
            foreach (var paraShape in from._paraShapeList)
            {
                _paraShapeList.Add(paraShape.Clone());
            }

            _styleList.Clear();
            foreach (var style in from._styleList)
            {
                _styleList.Add(style.Clone());
            }

            _docData = from._docData?.Clone();
            _distributeDocData = from._distributeDocData?.Clone();
            _compatibleDocument = from._compatibleDocument?.Clone();
            _layoutCompatibility = from._layoutCompatibility?.Clone();
            _trackChange = from._trackChange?.Clone();

            _memoShapeList.Clear();
            foreach (var memoShape in from._memoShapeList)
            {
                _memoShapeList.Add(memoShape.Clone());
            }

            _forbiddenChar = from._forbiddenChar?.Clone();

            _trackChange2List.Clear();
            foreach (var unknownRecord in from._trackChange2List)
            {
                _trackChange2List.Add(unknownRecord.Clone());
            }

            _trackChangeAuthorList.Clear();
            foreach (var unknownRecord in from._trackChangeAuthorList)
            {
                _trackChangeAuthorList.Add(unknownRecord.Clone());
            }
        }

        private static void CopyFaceNameList(List<FaceNameInfo> from, List<FaceNameInfo> to)
        {
            to.Clear();
            foreach (var faceName in from)
            {
                to.Add(faceName.Clone());
            }
        }
    }
}

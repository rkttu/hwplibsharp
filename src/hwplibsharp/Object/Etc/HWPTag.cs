// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/etc/HWPTag.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.Etc
{
    /// <summary>
    /// Record의 테그 리스트
    /// </summary>
    public static class HWPTag
    {
        /// <summary>
        /// tag 시작 값
        /// </summary>
        private const short Begin = 0x10;

        // for "DocInfo" stream

        /// <summary>
        /// 문서 속성 tag
        /// </summary>
        public const short DocumentProperties = Begin;

        /// <summary>
        /// 아이디 매핑 헤더 tag
        /// </summary>
        public const short IdMappings = Begin + 1;

        /// <summary>
        /// BinData tag
        /// </summary>
        public const short BinData = Begin + 2;

        /// <summary>
        /// Typeface Name tag
        /// </summary>
        public const short FaceName = Begin + 3;

        /// <summary>
        /// 테두리/배경 tag
        /// </summary>
        public const short BorderFill = Begin + 4;

        /// <summary>
        /// 글자 모양 tag
        /// </summary>
        public const short CharShape = Begin + 5;

        /// <summary>
        /// 탭 정의 tag
        /// </summary>
        public const short TabDef = Begin + 6;

        /// <summary>
        /// 번호 정의 tag
        /// </summary>
        public const short Numbering = Begin + 7;

        /// <summary>
        /// 글머리표 tag
        /// </summary>
        public const short Bullet = Begin + 8;

        /// <summary>
        /// 문단 모양 tag
        /// </summary>
        public const short ParaShape = Begin + 9;

        /// <summary>
        /// 스타일 tag
        /// </summary>
        public const short Style = Begin + 10;

        /// <summary>
        /// 문서의 임의의 데이터 tag
        /// </summary>
        public const short DocData = Begin + 11;

        /// <summary>
        /// 배포용 문서 데이터 tag
        /// </summary>
        public const short DistributeDocData = Begin + 12;

        /// <summary>
        /// 호환 문서 tag
        /// </summary>
        public const short CompatibleDocument = Begin + 14;

        /// <summary>
        /// 레이아웃 호환성 tag
        /// </summary>
        public const short LayoutCompatibility = Begin + 15;

        /// <summary>
        /// 변경 추적 정보 tag
        /// </summary>
        public const short TrackChange = Begin + 16;

        /// <summary>
        /// 메모 모양 tag
        /// </summary>
        public const short MemoShape = Begin + 76;

        /// <summary>
        /// 금칙처리 문자 tag
        /// </summary>
        public const short ForbiddenChar = Begin + 78;

        /// <summary>
        /// 변경 추적 내용 및 모양 tag
        /// </summary>
        public const short TrackChange2 = Begin + 80;

        /// <summary>
        /// 변경 추적 작성자 tag
        /// </summary>
        public const short TrackChangeAuthor = Begin + 81;

        // for "BodyText" storages

        /// <summary>
        /// 문단 헤더 tag
        /// </summary>
        public const short ParaHeader = Begin + 50;

        /// <summary>
        /// 문단의 텍스트 tag
        /// </summary>
        public const short ParaText = Begin + 51;

        /// <summary>
        /// 문단의 글자 모양 tag
        /// </summary>
        public const short ParaCharShape = Begin + 52;

        /// <summary>
        /// 문단의 레이아웃 tag
        /// </summary>
        public const short ParaLineSeg = Begin + 53;

        /// <summary>
        /// 문단의 영역 태그 tag
        /// </summary>
        public const short ParaRangeTag = Begin + 54;

        /// <summary>
        /// 컨트롤 헤더 tag
        /// </summary>
        public const short CtrlHeader = Begin + 55;

        /// <summary>
        /// 문단 리스트 헤더 tag
        /// </summary>
        public const short ListHeader = Begin + 56;

        /// <summary>
        /// 용지 설정 tag
        /// </summary>
        public const short PageDef = Begin + 57;

        /// <summary>
        /// 각주/미주 모양 tag
        /// </summary>
        public const short FootnoteShape = Begin + 58;

        /// <summary>
        /// 쪽 테두리/배경 tag
        /// </summary>
        public const short PageBorderFill = Begin + 59;

        /// <summary>
        /// 개체 tag
        /// </summary>
        public const short ShapeComponent = Begin + 60;

        /// <summary>
        /// 표 개체 tag
        /// </summary>
        public const short Table = Begin + 61;

        /// <summary>
        /// 직선 개체 tag
        /// </summary>
        public const short ShapeComponentLine = Begin + 62;

        /// <summary>
        /// 사각형 개체 tag
        /// </summary>
        public const short ShapeComponentRectangle = Begin + 63;

        /// <summary>
        /// 타원 개체 tag
        /// </summary>
        public const short ShapeComponentEllipse = Begin + 64;

        /// <summary>
        /// 호 개체 tag
        /// </summary>
        public const short ShapeComponentArc = Begin + 65;

        /// <summary>
        /// 다각형 개체 tag
        /// </summary>
        public const short ShapeComponentPolygon = Begin + 66;

        /// <summary>
        /// 곡선 개체 tag
        /// </summary>
        public const short ShapeComponentCurve = Begin + 67;

        /// <summary>
        /// OLE 개체 tag
        /// </summary>
        public const short ShapeComponentOle = Begin + 68;

        /// <summary>
        /// 그림 개체 tag
        /// </summary>
        public const short ShapeComponentPicture = Begin + 69;

        /// <summary>
        /// 컨테이너 개체 tag
        /// </summary>
        public const short ShapeComponentContainer = Begin + 70;

        /// <summary>
        /// 컨트롤 임의의 데이터 tag
        /// </summary>
        public const short CtrlData = Begin + 71;

        /// <summary>
        /// 수식 개체 tag
        /// </summary>
        public const short EqEdit = Begin + 72;

        /// <summary>
        /// 글맵시 tag
        /// </summary>
        public const short ShapeComponentTextArt = Begin + 74;

        /// <summary>
        /// 양식 개체 tag
        /// </summary>
        public const short FormObject = Begin + 75;

        /// <summary>
        /// 메모 리스트 헤더 tag
        /// </summary>
        public const short MemoList = Begin + 77;

        /// <summary>
        /// 차트 데이터 tag
        /// </summary>
        public const short ChartData = Begin + 79;

        /// <summary>
        /// 비디오 데이터 tag
        /// </summary>
        public const short VideoData = Begin + 82;

        /// <summary>
        /// Unknown tag
        /// </summary>
        public const short ShapeComponentUnknown = Begin + 99;
    }
}

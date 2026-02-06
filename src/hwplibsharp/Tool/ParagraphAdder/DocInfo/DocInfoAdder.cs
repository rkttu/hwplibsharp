// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/DocInfoAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo를 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class DocInfoAdder
    {
        private readonly HWPFile? _sourceHWPFile;
        private readonly HWPFile? _targetHWPFile;

        private readonly BinDataAdder _binDataAdder;
        private readonly BorderFillInfoAdder _borderFillAdder;
        private readonly BulletAdder _bulletAdder;
        private readonly CharShapeInfoAdder _charShapeAdder;
        private readonly FaceNameInfoAdder _faceNameAdder;
        private readonly NumberingAdder _numberingAdder;
        private readonly ParaShapeInfoAdder _paraShapeAdder;
        private readonly StyleAdder _styleAdder;
        private readonly TabDefInfoAdder _tabDefAdder;

        /// <summary>
        /// DocInfoAdder의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="sourceHWPFile">복사할 원본 HWP 파일</param>
        /// <param name="targetHWPFile">복사 대상 HWP 파일</param>
        public DocInfoAdder(HWPFile? sourceHWPFile, HWPFile? targetHWPFile)
        {
            _sourceHWPFile = sourceHWPFile;
            _targetHWPFile = targetHWPFile;

            _binDataAdder = new BinDataAdder(this);
            _borderFillAdder = new BorderFillInfoAdder(this);
            _bulletAdder = new BulletAdder(this);
            _charShapeAdder = new CharShapeInfoAdder(this);
            _faceNameAdder = new FaceNameInfoAdder(this);
            _numberingAdder = new NumberingAdder(this);
            _paraShapeAdder = new ParaShapeInfoAdder(this);
            _styleAdder = new StyleAdder(this);
            _tabDefAdder = new TabDefInfoAdder(this);
        }

        /// <summary>
        /// 원본 HWP 파일을 반환합니다.
        /// </summary>
        /// <returns>원본 HWP 파일</returns>
        public HWPFile? GetSourceHWPFile() => _sourceHWPFile;

        /// <summary>
        /// 대상 HWP 파일을 반환합니다.
        /// </summary>
        /// <returns>대상 HWP 파일</returns>
        public HWPFile? GetTargetHWPFile() => _targetHWPFile;

        /// <summary>
        /// BinDataAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>BinDataAdder 인스턴스</returns>
        public BinDataAdder ForBinData() => _binDataAdder;

        /// <summary>
        /// BorderFillInfoAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>BorderFillInfoAdder 인스턴스</returns>
        public BorderFillInfoAdder ForBorderFillInfo() => _borderFillAdder;

        /// <summary>
        /// BulletAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>BulletAdder 인스턴스</returns>
        public BulletAdder ForBullet() => _bulletAdder;

        /// <summary>
        /// CharShapeInfoAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>CharShapeInfoAdder 인스턴스</returns>
        public CharShapeInfoAdder ForCharShapeInfo() => _charShapeAdder;

        /// <summary>
        /// FaceNameInfoAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>FaceNameInfoAdder 인스턴스</returns>
        public FaceNameInfoAdder ForFaceNameInfo() => _faceNameAdder;

        /// <summary>
        /// NumberingAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>NumberingAdder 인스턴스</returns>
        public NumberingAdder ForNumbering() => _numberingAdder;

        /// <summary>
        /// ParaShapeInfoAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>ParaShapeInfoAdder 인스턴스</returns>
        public ParaShapeInfoAdder ForParaShapeInfo() => _paraShapeAdder;

        /// <summary>
        /// StyleAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>StyleAdder 인스턴스</returns>
        public StyleAdder ForStyle() => _styleAdder;

        /// <summary>
        /// TabDefInfoAdder 인스턴스를 반환합니다.
        /// </summary>
        /// <returns>TabDefInfoAdder 인스턴스</returns>
        public TabDefInfoAdder ForTabDefInfo() => _tabDefAdder;
    }
}

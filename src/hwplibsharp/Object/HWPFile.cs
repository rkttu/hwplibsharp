// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/HWPFile.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object
{
    /// <summary>
    /// HWP File를 나타내는 객체
    /// </summary>
    public class HWPFile
    {
        /// <summary>
        /// 파일 인식 정보를 나타내는 객체. "FileHeader" stream에 저장된다.
        /// </summary>
        private readonly FileHeader.FileHeader _fileHeader;

        /// <summary>
        /// 문서 정보를 나타내는 객체. "DocInfo" stream에 저장된다.
        /// </summary>
        private readonly DocInfo.DocInfo _docInfo;

        /// <summary>
        /// 본문을 나타내는 객체. "BodyText" storage에 저장된다.
        /// </summary>
        private readonly BodyText.BodyText _bodyText;

        /// <summary>
        /// 바이너리 데이터를 나타내는 객체. "BinData" storage에 저장된다.
        /// </summary>
        private readonly BinData.BinData _binData;

        /// <summary>
        /// 스크립트 정보
        /// </summary>
        private readonly Scripts _scripts;

        /// <summary>
        /// 요약 정보 (OLE 문서 속성)
        /// </summary>
        private byte[]? _summaryInformation;

        /// <summary>
        /// 생성자
        /// </summary>
        public HWPFile()
        {
            _fileHeader = new FileHeader.FileHeader();
            _docInfo = new DocInfo.DocInfo();
            _bodyText = new BodyText.BodyText();
            _binData = new BinData.BinData();
            _scripts = new Scripts();
        }

        /// <summary>
        /// 파일 인식 정보를 나타내는 객체
        /// </summary>
        public FileHeader.FileHeader FileHeader => _fileHeader;

        /// <summary>
        /// 문서 정보를 나타내는 객체
        /// </summary>
        public DocInfo.DocInfo DocInfo => _docInfo;

        /// <summary>
        /// 본문을 나타내는 객체
        /// </summary>
        public BodyText.BodyText BodyText => _bodyText;

        /// <summary>
        /// 바이너리 데이터를 나타내는 객체
        /// </summary>
        public BinData.BinData BinData => _binData;

        /// <summary>
        /// 스크립트 정보
        /// </summary>
        public Scripts Scripts => _scripts;

        /// <summary>
        /// 요약 정보 (OLE 문서 속성)
        /// </summary>
        public byte[]? SummaryInformation
        {
            get => _summaryInformation;
            set => _summaryInformation = value;
        }

        /// <summary>
        /// HWP 파일을 복제한다.
        /// </summary>
        /// <param name="deepCopyImage">이미지 데이터를 깊은 복사할지 여부</param>
        /// <returns>복제된 HWP 파일 객체</returns>
        public HWPFile Clone(bool deepCopyImage)
        {
            var cloned = new HWPFile();
            cloned.Copy(this, deepCopyImage);
            return cloned;
        }

        /// <summary>
        /// 다른 HWP 파일 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">원본 HWP 파일 객체</param>
        /// <param name="deepCopyImage">이미지 데이터를 깊은 복사할지 여부</param>
        public void Copy(HWPFile from, bool deepCopyImage)
        {
            _fileHeader.Copy(from._fileHeader);
            _docInfo.Copy(from._docInfo);
            _bodyText.Copy(from._bodyText);
            _binData.Copy(from._binData, deepCopyImage);
            _scripts.Copy(from._scripts);

            if (from._summaryInformation != null)
            {
                _summaryInformation = (byte[])from._summaryInformation.Clone();
            }
            else
            {
                _summaryInformation = null;
            }
        }
    }
}

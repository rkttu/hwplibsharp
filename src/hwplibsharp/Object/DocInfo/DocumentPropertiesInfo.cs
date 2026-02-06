// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/DocumentProperties.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.DocumentProperties;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 문서 속성를 나타내는 레코드
    /// </summary>
    public class DocumentPropertiesInfo
    {
        private int _sectionCount;
        private readonly StartNumber _startNumber;
        private readonly CaretPosition _caretPosition;

        /// <summary>
        /// <see cref="DocumentPropertiesInfo"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public DocumentPropertiesInfo()
        {
            _startNumber = new StartNumber();
            _caretPosition = new CaretPosition();
        }

        /// <summary>
        /// 문서의 섹션 개수를 가져오거나 설정합니다.
        /// </summary>
        public int SectionCount
        {
            get => _sectionCount;
            set => _sectionCount = value;
        }

        /// <summary>
        /// 문서의 시작 번호 정보를 가져옵니다.
        /// </summary>
        public StartNumber StartNumber => _startNumber;

        /// <summary>
        /// 문서의 캐럿 위치 정보를 가져옵니다.
        /// </summary>
        public CaretPosition CaretPosition => _caretPosition;

        /// <summary>
        /// 다른 DocumentPropertiesInfo 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(DocumentPropertiesInfo from)
        {
            _sectionCount = from._sectionCount;
            _startNumber.Copy(from._startNumber);
            _caretPosition.Copy(from._caretPosition);
        }
    }
}

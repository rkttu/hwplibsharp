// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/TextExtractOption.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 텍스트 추출 옵션
    /// </summary>
    public class TextExtractOption
    {
        private TextExtractMethod _method;
        private bool _withControlChar;
        private bool _appendEndingLF;
        private bool _insertParaHead;

        /// <summary>
        /// <see cref="TextExtractOption"/>의 기본 생성자입니다.
        /// 기본 텍스트 추출 방법과 옵션을 사용하여 인스턴스를 초기화합니다.
        /// </summary>
        public TextExtractOption()
        {
            _method = TextExtractMethod.InsertControlTextBetweenParagraphText;
            _withControlChar = false;
            _appendEndingLF = true;
            _insertParaHead = true;
        }

        /// <summary>
        /// 지정한 텍스트 추출 방법을 사용하여 <see cref="TextExtractOption"/>의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="method">텍스트 추출 방법</param>
        public TextExtractOption(TextExtractMethod method)
        {
            _method = method;
            _withControlChar = false;
            _appendEndingLF = true;
            _insertParaHead = true;
        }

        /// <summary>
        /// 지정한 텍스트 추출 방법과 줄바꿈 옵션을 사용하여 <see cref="TextExtractOption"/>의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="method">텍스트 추출 방법</param>
        /// <param name="appendEndingLF">문서 끝에 줄바꿈 추가 여부</param>
        public TextExtractOption(TextExtractMethod method, bool appendEndingLF)
        {
            _method = method;
            _withControlChar = false;
            _appendEndingLF = appendEndingLF;
            _insertParaHead = true;
        }

        /// <summary>
        /// 다른 <see cref="TextExtractOption"/>의 값을 복사하여 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="that">복사할 옵션 인스턴스</param>
        public TextExtractOption(TextExtractOption that)
        {
            _method = that._method;
            _withControlChar = that._withControlChar;
            _appendEndingLF = that._appendEndingLF;
            _insertParaHead = that._insertParaHead;
        }

        /// <summary>
        /// 텍스트 추출 방법을 반환합니다.
        /// </summary>
        /// <returns>텍스트 추출 방법</returns>
        public TextExtractMethod GetMethod() => _method;

        /// <summary>
        /// 텍스트 추출 방법을 설정합니다.
        /// </summary>
        /// <param name="method">설정할 텍스트 추출 방법</param>
        public void SetMethod(TextExtractMethod method) => _method = method;

        /// <summary>
        /// 제어 문자를 포함할지 여부를 반환합니다.
        /// </summary>
        /// <returns>제어 문자 포함 여부</returns>
        public bool IsWithControlChar() => _withControlChar;

        /// <summary>
        /// 제어 문자 포함 여부를 설정합니다.
        /// </summary>
        /// <param name="withControlChar">제어 문자 포함 여부</param>
        public void SetWithControlChar(bool withControlChar) => _withControlChar = withControlChar;

        /// <summary>
        /// 문서 끝에 줄바꿈을 추가할지 여부를 반환합니다.
        /// </summary>
        /// <returns>줄바꿈 추가 여부</returns>
        public bool IsAppendEndingLF() => _appendEndingLF;

        /// <summary>
        /// 문서 끝에 줄바꿈 추가 여부를 설정합니다.
        /// </summary>
        /// <param name="appendEndingLF">줄바꿈 추가 여부</param>
        public void SetAppendEndingLF(bool appendEndingLF) => _appendEndingLF = appendEndingLF;

        /// <summary>
        /// 문단 시작에 헤더를 삽입할지 여부를 반환합니다.
        /// </summary>
        /// <returns>문단 시작 헤더 삽입 여부</returns>
        public bool IsInsertParaHead() => _insertParaHead;

        /// <summary>
        /// 문단 시작 헤더 삽입 여부를 설정합니다.
        /// </summary>
        /// <param name="insertParaHead">문단 시작 헤더 삽입 여부</param>
        public void SetInsertParaHead(bool insertParaHead) => _insertParaHead = insertParaHead;
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/Style.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.Style;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 스타일에 대한 레코드
    /// </summary>
    public class StyleInfo
    {
        private string? _hangulName;
        private string? _englishName;
        private readonly StyleProperty _property;
        private short _nextStyleId;
        private short _languageId;
        private int _paraShapeId;
        private int _charShapeId;

        /// <summary>
        /// <see cref="StyleInfo"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public StyleInfo()
        {
            _property = new StyleProperty();
        }

        /// <summary>
        /// 스타일의 한글 이름을 가져오거나 설정합니다.
        /// </summary>
        public string? HangulName
        {
            get => _hangulName;
            set => _hangulName = value;
        }

        /// <summary>
        /// 스타일의 영문 이름을 가져오거나 설정합니다.
        /// </summary>
        public string? EnglishName
        {
            get => _englishName;
            set => _englishName = value;
        }

        /// <summary>
        /// 스타일의 속성 정보를 가져옵니다.
        /// </summary>
        public StyleProperty Property => _property;

        /// <summary>
        /// 다음 스타일의 ID를 가져오거나 설정합니다.
        /// </summary>
        public short NextStyleId
        {
            get => _nextStyleId;
            set => _nextStyleId = value;
        }

        /// <summary>
        /// 스타일의 언어 ID를 가져오거나 설정합니다.
        /// </summary>
        public short LanguageId
        {
            get => _languageId;
            set => _languageId = value;
        }

        /// <summary>
        /// 스타일에 적용된 문단 모양 ID를 가져오거나 설정합니다.
        /// </summary>
        public int ParaShapeId
        {
            get => _paraShapeId;
            set => _paraShapeId = value;
        }

        /// <summary>
        /// 스타일에 적용된 글자 모양 ID를 가져오거나 설정합니다.
        /// </summary>
        public int CharShapeId
        {
            get => _charShapeId;
            set => _charShapeId = value;
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="StyleInfo"/>의 새 인스턴스입니다.</returns>
        public StyleInfo Clone()
        {
            var cloned = new StyleInfo
            {
                _hangulName = _hangulName,
                _englishName = _englishName
            };
            cloned._property.Copy(_property);
            cloned._nextStyleId = _nextStyleId;
            cloned._languageId = _languageId;
            cloned._paraShapeId = _paraShapeId;
            cloned._charShapeId = _charShapeId;
            return cloned;
        }
    }
}

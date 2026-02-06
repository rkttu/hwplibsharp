// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/LayoutCompatibility.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 레이아웃 호환성에 대한 레코드
    /// </summary>
    public class LayoutCompatibility
    {
        private uint _letterLevelFormat;
        private uint _paragraphLevelFormat;
        private uint _sectionLevelFormat;
        private uint _objectLevelFormat;
        private uint _fieldLevelFormat;

        /// <summary>
        /// <see cref="LayoutCompatibility"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public LayoutCompatibility()
        {
        }

        /// <summary>
        /// 글자 단위 레이아웃 호환성 포맷 값을 가져오거나 설정합니다.
        /// </summary>
        public uint LetterLevelFormat
        {
            get => _letterLevelFormat;
            set => _letterLevelFormat = value;
        }

        /// <summary>
        /// 문단 단위 레이아웃 호환성 포맷 값을 가져오거나 설정합니다.
        /// </summary>
        public uint ParagraphLevelFormat
        {
            get => _paragraphLevelFormat;
            set => _paragraphLevelFormat = value;
        }

        /// <summary>
        /// 구역 단위 레이아웃 호환성 포맷 값을 가져오거나 설정합니다.
        /// </summary>
        public uint SectionLevelFormat
        {
            get => _sectionLevelFormat;
            set => _sectionLevelFormat = value;
        }

        /// <summary>
        /// 객체 단위 레이아웃 호환성 포맷 값을 가져오거나 설정합니다.
        /// </summary>
        public uint ObjectLevelFormat
        {
            get => _objectLevelFormat;
            set => _objectLevelFormat = value;
        }

        /// <summary>
        /// 필드 단위 레이아웃 호환성 포맷 값을 가져오거나 설정합니다.
        /// </summary>
        public uint FieldLevelFormat
        {
            get => _fieldLevelFormat;
            set => _fieldLevelFormat = value;
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="LayoutCompatibility"/>의 새 인스턴스입니다.</returns>
        public LayoutCompatibility Clone()
        {
            var cloned = new LayoutCompatibility
            {
                _letterLevelFormat = _letterLevelFormat,
                _paragraphLevelFormat = _paragraphLevelFormat,
                _sectionLevelFormat = _sectionLevelFormat,
                _objectLevelFormat = _objectLevelFormat,
                _fieldLevelFormat = _fieldLevelFormat
            };
            return cloned;
        }
    }
}

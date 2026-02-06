// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/FaceName.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.FaceName;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 글꼴 레코드
    /// </summary>
    public class FaceNameInfo
    {
        private readonly FaceNameProperty _property;
        private string? _name;
        private FontType _substituteFontType;
        private string? _substituteFontName;
        private readonly FontTypeInfo _fontTypeInfo;
        private string? _baseFontName;

        /// <summary>
        /// <see cref="FaceNameInfo"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public FaceNameInfo()
        {
            _property = new FaceNameProperty();
            _fontTypeInfo = new FontTypeInfo();
        }

        /// <summary>
        /// 글꼴 속성 정보를 가져옵니다.
        /// </summary>
        public FaceNameProperty Property => _property;

        /// <summary>
        /// 글꼴 이름을 가져오거나 설정합니다.
        /// </summary>
        public string? Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// 대체 글꼴의 종류를 가져오거나 설정합니다.
        /// </summary>
        public FontType SubstituteFontType
        {
            get => _substituteFontType;
            set => _substituteFontType = value;
        }

        /// <summary>
        /// 대체 글꼴의 이름을 가져오거나 설정합니다.
        /// </summary>
        public string? SubstituteFontName
        {
            get => _substituteFontName;
            set => _substituteFontName = value;
        }

        /// <summary>
        /// 글꼴 유형 정보를 가져옵니다.
        /// </summary>
        public FontTypeInfo FontTypeInfo => _fontTypeInfo;

        /// <summary>
        /// 기본 글꼴 이름을 가져오거나 설정합니다.
        /// </summary>
        public string? BaseFontName
        {
            get => _baseFontName;
            set => _baseFontName = value;
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="FaceNameInfo"/>의 새 인스턴스입니다.</returns>
        public FaceNameInfo Clone()
        {
            var cloned = new FaceNameInfo();
            cloned._property.Copy(_property);
            cloned._name = _name;
            cloned._substituteFontType = _substituteFontType;
            cloned._substituteFontName = _substituteFontName;
            cloned._fontTypeInfo.Copy(_fontTypeInfo);
            cloned._baseFontName = _baseFontName;
            return cloned;
        }
    }
}

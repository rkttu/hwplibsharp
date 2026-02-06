// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/CharShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.CharShape;
using HwpLib.Object.Etc;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 글자 모양을 나타내는 레코드
    /// </summary>
    public class CharShapeInfo
    {
        private readonly FaceNameIds _faceNameIds;
        private readonly Ratios _ratios;
        private readonly CharSpaces _charSpaces;
        private readonly RelativeSizes _relativeSizes;
        private readonly CharOffsets _charOffsets;
        private int _baseSize;
        private readonly CharShapeProperty _property;
        private sbyte _shadowGap1;
        private sbyte _shadowGap2;
        private readonly Color4Byte _charColor;
        private readonly Color4Byte _underLineColor;
        private readonly Color4Byte _shadeColor;
        private readonly Color4Byte _shadowColor;
        private int _borderFillId;
        private readonly Color4Byte _strikeLineColor;

        /// <summary>
        /// CharShapeInfo 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public CharShapeInfo()
        {
            _faceNameIds = new FaceNameIds();
            _ratios = new Ratios();
            _charSpaces = new CharSpaces();
            _relativeSizes = new RelativeSizes();
            _charOffsets = new CharOffsets();
            _property = new CharShapeProperty();
            _charColor = new Color4Byte();
            _underLineColor = new Color4Byte();
            _shadeColor = new Color4Byte();
            _shadowColor = new Color4Byte();
            _strikeLineColor = new Color4Byte();
        }

        /// <summary>
        /// 글꼴 이름 ID 정보를 가져옵니다.
        /// </summary>
        public FaceNameIds FaceNameIds => _faceNameIds;

        /// <summary>
        /// 각 문자 종류별 비율 정보를 가져옵니다.
        /// </summary>
        public Ratios Ratios => _ratios;

        /// <summary>
        /// 각 문자 종류별 자간 정보를 가져옵니다.
        /// </summary>
        public CharSpaces CharSpaces => _charSpaces;

        /// <summary>
        /// 각 문자 종류별 상대 크기 정보를 가져옵니다.
        /// </summary>
        public RelativeSizes RelativeSizes => _relativeSizes;

        /// <summary>
        /// 각 문자 종류별 오프셋 정보를 가져옵니다.
        /// </summary>
        public CharOffsets CharOffsets => _charOffsets;

        /// <summary>
        /// 기본 글자 크기를 가져오거나 설정합니다.
        /// </summary>
        public int BaseSize
        {
            get => _baseSize;
            set => _baseSize = value;
        }

        /// <summary>
        /// 글자 모양 속성 정보를 가져옵니다.
        /// </summary>
        public CharShapeProperty Property => _property;

        /// <summary>
        /// 그림자 간격 1을 가져오거나 설정합니다.
        /// </summary>
        public sbyte ShadowGap1
        {
            get => _shadowGap1;
            set => _shadowGap1 = value;
        }

        /// <summary>
        /// 그림자 간격 2를 가져오거나 설정합니다.
        /// </summary>
        public sbyte ShadowGap2
        {
            get => _shadowGap2;
            set => _shadowGap2 = value;
        }

        /// <summary>
        /// 글자 색상을 가져옵니다.
        /// </summary>
        public Color4Byte CharColor => _charColor;

        /// <summary>
        /// 밑줄 색상을 가져옵니다.
        /// </summary>
        public Color4Byte UnderLineColor => _underLineColor;

        /// <summary>
        /// 음영 색상을 가져옵니다.
        /// </summary>
        public Color4Byte ShadeColor => _shadeColor;

        /// <summary>
        /// 그림자 색상을 가져옵니다.
        /// </summary>
        public Color4Byte ShadowColor => _shadowColor;

        /// <summary>
        /// 테두리 채우기 ID를 가져오거나 설정합니다.
        /// </summary>
        public int BorderFillId
        {
            get => _borderFillId;
            set => _borderFillId = value;
        }

        /// <summary>
        /// 취소선 색 (5.0.3.0 이상)
        /// </summary>
        public Color4Byte StrikeLineColor => _strikeLineColor;

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="CharShapeInfo"/>의 새 인스턴스입니다.</returns>
        public CharShapeInfo Clone()
        {
            var cloned = new CharShapeInfo();
            cloned._faceNameIds.Copy(_faceNameIds);
            cloned._ratios.Copy(_ratios);
            cloned._charSpaces.Copy(_charSpaces);
            cloned._relativeSizes.Copy(_relativeSizes);
            cloned._charOffsets.Copy(_charOffsets);
            cloned._baseSize = _baseSize;
            cloned._property.Copy(_property);
            cloned._shadowGap1 = _shadowGap1;
            cloned._shadowGap2 = _shadowGap2;
            cloned._charColor.Copy(_charColor);
            cloned._underLineColor.Copy(_underLineColor);
            cloned._shadeColor.Copy(_shadeColor);
            cloned._shadowColor.Copy(_shadowColor);
            cloned._borderFillId = _borderFillId;
            cloned._strikeLineColor.Copy(_strikeLineColor);
            return cloned;
        }
    }
}

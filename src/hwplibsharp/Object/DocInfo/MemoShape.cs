// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/MemoShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill;
using HwpLib.Object.Etc;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 메모 모양
    /// </summary>
    public class MemoShape
    {
        private uint _width;
        private BorderType _lineType;
        private BorderThickness _lineWidth;
        private readonly Color4Byte _lineColor;
        private readonly Color4Byte _fillColor;
        private readonly Color4Byte _activeColor;
        private uint _unknown;

        /// <summary>
        /// <see cref="MemoShape"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public MemoShape()
        {
            _lineType = BorderType.None;
            _lineWidth = BorderThickness.MM0_1;
            _lineColor = new Color4Byte();
            _fillColor = new Color4Byte();
            _activeColor = new Color4Byte();
            _unknown = 0;
        }

        /// <summary>
        /// 메모의 너비(단위: 0.1mm)를 가져오거나 설정합니다.
        /// </summary>
        public uint Width
        {
            get => _width;
            set => _width = value;
        }

        /// <summary>
        /// 메모 테두리의 선 종류를 가져오거나 설정합니다.
        /// </summary>
        public BorderType LineType
        {
            get => _lineType;
            set => _lineType = value;
        }

        /// <summary>
        /// 메모 테두리의 선 두께를 가져오거나 설정합니다.
        /// </summary>
        public BorderThickness LineWidth
        {
            get => _lineWidth;
            set => _lineWidth = value;
        }

        /// <summary>
        /// 메모 테두리의 색상을 가져옵니다.
        /// </summary>
        public Color4Byte LineColor => _lineColor;

        /// <summary>
        /// 메모의 채우기 색상을 가져옵니다.
        /// </summary>
        public Color4Byte FillColor => _fillColor;

        /// <summary>
        /// 메모가 활성화되었을 때의 색상을 가져옵니다.
        /// </summary>
        public Color4Byte ActiveColor => _activeColor;

        /// <summary>
        /// 알 수 없는 값을 가져오거나 설정합니다.
        /// </summary>
        public uint Unknown
        {
            get => _unknown;
            set => _unknown = value;
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>복제된 <see cref="MemoShape"/> 인스턴스입니다.</returns>
        public MemoShape Clone()
        {
            var cloned = new MemoShape
            {
                _width = _width,
                _lineType = _lineType,
                _lineWidth = _lineWidth
            };
            cloned._lineColor.Copy(_lineColor);
            cloned._fillColor.Copy(_fillColor);
            cloned._activeColor.Copy(_activeColor);
            cloned._unknown = _unknown;
            return cloned;
        }
    }
}

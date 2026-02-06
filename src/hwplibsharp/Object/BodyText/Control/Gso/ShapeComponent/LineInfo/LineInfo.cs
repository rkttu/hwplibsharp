// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/lineinfo/LineInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo
{
    /// <summary>
    /// 테두리 선 정보
    /// </summary>
    public class LineInfo
    {
        /// <summary>
        /// 선 색상
        /// </summary>
        private readonly Color4Byte _color;

        /// <summary>
        /// 선 굵기
        /// </summary>
        private int _thickness;

        /// <summary>
        /// 속성
        /// </summary>
        private readonly LineInfoProperty _property;

        /// <summary>
        /// outline style
        /// </summary>
        private OutlineStyle _outlineStyle;

        /// <summary>
        /// 생성자
        /// </summary>
        public LineInfo()
        {
            _color = new Color4Byte();
            _property = new LineInfoProperty();
        }

        /// <summary>
        /// 선 색상 객체를 반환한다.
        /// </summary>
        public Color4Byte Color => _color;

        /// <summary>
        /// 선 굵기를 반환하거나 설정한다.
        /// </summary>
        public int Thickness
        {
            get => _thickness;
            set => _thickness = value;
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public LineInfoProperty Property => _property;

        /// <summary>
        /// outline style를 반환하거나 설정한다.
        /// </summary>
        public OutlineStyle OutlineStyle
        {
            get => _outlineStyle;
            set => _outlineStyle = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(LineInfo from)
        {
            _color.Copy(from._color);
            _thickness = from._thickness;
            _property.Copy(from._property);
            _outlineStyle = from._outlineStyle;
        }
    }
}

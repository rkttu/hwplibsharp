// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentTextArt.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Polygon;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.TextArt;
using HwpLib.Object.DocInfo.FaceName;
using HwpLib.Object.Etc;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 글맵시(TextArt) 개체 속성 레코드
    /// </summary>
    public class ShapeComponentTextArt
    {
        /// <summary>
        /// x1
        /// </summary>
        private int _x1;

        /// <summary>
        /// y1
        /// </summary>
        private int _y1;

        /// <summary>
        /// x2
        /// </summary>
        private int _x2;

        /// <summary>
        /// y2
        /// </summary>
        private int _y2;

        /// <summary>
        /// x3
        /// </summary>
        private int _x3;

        /// <summary>
        /// y3
        /// </summary>
        private int _y3;

        /// <summary>
        /// x4
        /// </summary>
        private int _x4;

        /// <summary>
        /// y4
        /// </summary>
        private int _y4;

        /// <summary>
        /// 내용
        /// </summary>
        private readonly HWPString _content;

        /// <summary>
        /// 글꼴이름
        /// </summary>
        private readonly HWPString _fontName;

        /// <summary>
        /// 글꼴스타일
        /// </summary>
        private readonly HWPString _fontStyle;

        /// <summary>
        /// 글꼴 타입
        /// </summary>
        private FontType _fontType;

        /// <summary>
        /// 글맵시 모양
        /// </summary>
        private TextArtShape _textArtShape;

        /// <summary>
        /// 줄 간격
        /// </summary>
        private int _lineSpace;

        /// <summary>
        /// 글자 간격
        /// </summary>
        private int _charSpace;

        /// <summary>
        /// 문단 정렬
        /// </summary>
        private TextArtAlign _paraAlignment;

        /// <summary>
        /// 그림자 타입 = 0: 없음, 1:비연속
        /// </summary>
        private int _shadowType;

        /// <summary>
        /// 그림자 x offset
        /// </summary>
        private int _shadowOffsetX;

        /// <summary>
        /// 그림자 y offset
        /// </summary>
        private int _shadowOffsetY;

        /// <summary>
        /// 그림자 색상
        /// </summary>
        private readonly Color4Byte _shadowColor;

        /// <summary>
        /// outline list ??
        /// </summary>
        private readonly List<PositionXY> _outlinePointList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentTextArt()
        {
            _content = new HWPString();
            _fontName = new HWPString();
            _fontStyle = new HWPString();
            _shadowColor = new Color4Byte();
            _outlinePointList = new List<PositionXY>();
        }

        /// <summary>
        /// x1 값을 반환하거나 설정한다.
        /// </summary>
        public int X1
        {
            get => _x1;
            set => _x1 = value;
        }

        /// <summary>
        /// y1 값을 반환하거나 설정한다.
        /// </summary>
        public int Y1
        {
            get => _y1;
            set => _y1 = value;
        }

        /// <summary>
        /// x2 값을 반환하거나 설정한다.
        /// </summary>
        public int X2
        {
            get => _x2;
            set => _x2 = value;
        }

        /// <summary>
        /// y2 값을 반환하거나 설정한다.
        /// </summary>
        public int Y2
        {
            get => _y2;
            set => _y2 = value;
        }

        /// <summary>
        /// x3 값을 반환하거나 설정한다.
        /// </summary>
        public int X3
        {
            get => _x3;
            set => _x3 = value;
        }

        /// <summary>
        /// y3 값을 반환하거나 설정한다.
        /// </summary>
        public int Y3
        {
            get => _y3;
            set => _y3 = value;
        }

        /// <summary>
        /// x4 값을 반환하거나 설정한다.
        /// </summary>
        public int X4
        {
            get => _x4;
            set => _x4 = value;
        }

        /// <summary>
        /// y4 값을 반환하거나 설정한다.
        /// </summary>
        public int Y4
        {
            get => _y4;
            set => _y4 = value;
        }

        /// <summary>
        /// 내용을 반환한다.
        /// </summary>
        public HWPString Content => _content;

        /// <summary>
        /// 글꼴 이름을 반환한다.
        /// </summary>
        public HWPString FontName => _fontName;

        /// <summary>
        /// 글꼴 스타일을 반환한다.
        /// </summary>
        public HWPString FontStyle => _fontStyle;

        /// <summary>
        /// 글꼴 타입을 반환하거나 설정한다.
        /// </summary>
        public FontType FontType
        {
            get => _fontType;
            set => _fontType = value;
        }

        /// <summary>
        /// 글맵시 모양을 반환하거나 설정한다.
        /// </summary>
        public TextArtShape TextArtShape
        {
            get => _textArtShape;
            set => _textArtShape = value;
        }

        /// <summary>
        /// 줄 간격을 반환하거나 설정한다.
        /// </summary>
        public int LineSpace
        {
            get => _lineSpace;
            set => _lineSpace = value;
        }

        /// <summary>
        /// 글자 간격을 반환하거나 설정한다.
        /// </summary>
        public int CharSpace
        {
            get => _charSpace;
            set => _charSpace = value;
        }

        /// <summary>
        /// 문단 정렬을 반환하거나 설정한다.
        /// 0:왼쪽, 1:오른쪽, 2:중앙, 3:양끝, 4:양끝(끝줄 포함)
        /// </summary>
        public TextArtAlign ParaAlignment
        {
            get => _paraAlignment;
            set => _paraAlignment = value;
        }

        /// <summary>
        /// 그림자 타입을 반환하거나 설정한다.
        /// 0: 없음, 1:비연속
        /// </summary>
        public int ShadowType
        {
            get => _shadowType;
            set => _shadowType = value;
        }

        /// <summary>
        /// 그림자 x 오프셋을 반환하거나 설정한다.
        /// </summary>
        public int ShadowOffsetX
        {
            get => _shadowOffsetX;
            set => _shadowOffsetX = value;
        }

        /// <summary>
        /// 그림자 y 오프셋을 반환하거나 설정한다.
        /// </summary>
        public int ShadowOffsetY
        {
            get => _shadowOffsetY;
            set => _shadowOffsetY = value;
        }

        /// <summary>
        /// 그림자 색상을 반환한다.
        /// </summary>
        public Color4Byte ShadowColor => _shadowColor;

        /// <summary>
        /// outline list를 반환한다.
        /// </summary>
        public IReadOnlyList<PositionXY> OutlinePointList => _outlinePointList;

        /// <summary>
        /// 새로운 outline point를 추가한다.
        /// </summary>
        /// <returns>새로 생성된 PositionXY 객체</returns>
        public PositionXY AddNewOutlinePoint()
        {
            PositionXY p = new PositionXY();
            _outlinePointList.Add(p);
            return p;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentTextArt from)
        {
            _x1 = from._x1;
            _y1 = from._y1;
            _x2 = from._x2;
            _y2 = from._y2;
            _x3 = from._x3;
            _y3 = from._y3;
            _x4 = from._x4;
            _y4 = from._y4;
            _content.Copy(from._content);
            _fontName.Copy(from._fontName);
            _fontStyle.Copy(from._fontStyle);
            _fontType = from._fontType;
            _textArtShape = from._textArtShape;
            _lineSpace = from._lineSpace;
            _charSpace = from._charSpace;
            _paraAlignment = from._paraAlignment;
            _shadowType = from._shadowType;
            _shadowOffsetX = from._shadowOffsetX;
            _shadowOffsetY = from._shadowOffsetY;
            _shadowColor.Copy(from._shadowColor);

            _outlinePointList.Clear();
            foreach (var positionXY in from._outlinePointList)
            {
                PositionXY clonedPositionXY = new PositionXY();
                clonedPositionXY.Copy(positionXY);
                _outlinePointList.Add(clonedPositionXY);
            }
        }
    }
}

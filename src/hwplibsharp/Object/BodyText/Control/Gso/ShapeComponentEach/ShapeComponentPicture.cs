// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentPicture.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Polygon;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 그림 개체 속성 레코드
    /// </summary>
    public class ShapeComponentPicture
    {
        /// <summary>
        /// 테두리 색
        /// </summary>
        private readonly Color4Byte _borderColor;

        /// <summary>
        /// 테두리 두께
        /// </summary>
        private int _borderThickness;

        /// <summary>
        /// 테두리 속성
        /// </summary>
        private readonly LineInfoProperty _borderProperty;

        /// <summary>
        /// left,top 좌표
        /// </summary>
        private readonly PositionXY _leftTop;

        /// <summary>
        /// right,top 좌표
        /// </summary>
        private readonly PositionXY _rightTop;

        /// <summary>
        /// left, bottom 좌표
        /// </summary>
        private readonly PositionXY _leftBottom;

        /// <summary>
        /// right, bottom 좌표
        /// </summary>
        private readonly PositionXY _rightBottom;

        /// <summary>
        /// 자르기 한 후 사각형의 left좌표
        /// </summary>
        private int _leftAfterCutting;

        /// <summary>
        /// 자르기 한 후 사각형의 top좌표
        /// </summary>
        private int _topAfterCutting;

        /// <summary>
        /// 자르기 한 후 사각형의 right좌표
        /// </summary>
        private int _rightAfterCutting;

        /// <summary>
        /// 자르기 한 후 사각형의 bottom좌표
        /// </summary>
        private int _bottomAfterCutting;

        /// <summary>
        /// 안쪽 여백 정보
        /// </summary>
        private readonly InnerMargin _innerMargin;

        /// <summary>
        /// 그림 정보
        /// </summary>
        private readonly PictureInfo _pictureInfo;

        /// <summary>
        /// 테두리 투명도
        /// </summary>
        private short _borderTransparency;

        /// <summary>
        /// 문서 내 각 개체에 대한 고유 아이디
        /// </summary>
        private long _instanceId;

        /// <summary>
        /// 그림 효과 정보
        /// </summary>
        private readonly Picture.PictureEffect _pictureEffect;

        /// <summary>
        /// 이미지 너비 (??)
        /// </summary>
        private long _imageWidth;

        /// <summary>
        /// 이미지 높이 (??)
        /// </summary>
        private long _imageHeight;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentPicture()
        {
            _borderColor = new Color4Byte();
            _borderProperty = new LineInfoProperty();
            _leftTop = new PositionXY();
            _rightTop = new PositionXY();
            _leftBottom = new PositionXY();
            _rightBottom = new PositionXY();
            _innerMargin = new InnerMargin();
            _pictureInfo = new PictureInfo();
            _pictureEffect = new Picture.PictureEffect();
        }

        /// <summary>
        /// 테두리 색상 객체를 반환한다.
        /// </summary>
        public Color4Byte BorderColor => _borderColor;

        /// <summary>
        /// 테두리 두께를 반환하거나 설정한다.
        /// </summary>
        public int BorderThickness
        {
            get => _borderThickness;
            set => _borderThickness = value;
        }

        /// <summary>
        /// 테두리 선의 속성 객체를 반환한다.
        /// </summary>
        public LineInfoProperty BorderProperty => _borderProperty;

        /// <summary>
        /// left,top 좌표 객체를 반환한다.
        /// </summary>
        public PositionXY LeftTop => _leftTop;

        /// <summary>
        /// right,top 좌표 객체를 반환한다.
        /// </summary>
        public PositionXY RightTop => _rightTop;

        /// <summary>
        /// left, bottom 좌표 객체를 반환한다.
        /// </summary>
        public PositionXY LeftBottom => _leftBottom;

        /// <summary>
        /// right, bottom 좌표 객체를 반환한다.
        /// </summary>
        public PositionXY RightBottom => _rightBottom;

        /// <summary>
        /// 자르기 한 후 사각형의 left좌표를 반환하거나 설정한다.
        /// </summary>
        public int LeftAfterCutting
        {
            get => _leftAfterCutting;
            set => _leftAfterCutting = value;
        }

        /// <summary>
        /// 자르기 한 후 사각형의 top좌표를 반환하거나 설정한다.
        /// </summary>
        public int TopAfterCutting
        {
            get => _topAfterCutting;
            set => _topAfterCutting = value;
        }

        /// <summary>
        /// 자르기 한 후 사각형의 right좌표를 반환하거나 설정한다.
        /// </summary>
        public int RightAfterCutting
        {
            get => _rightAfterCutting;
            set => _rightAfterCutting = value;
        }

        /// <summary>
        /// 자르기 한 후 사각형의 bottom좌표를 반환하거나 설정한다.
        /// </summary>
        public int BottomAfterCutting
        {
            get => _bottomAfterCutting;
            set => _bottomAfterCutting = value;
        }

        /// <summary>
        /// 안쪽 여백 정보 객체를 반환한다.
        /// </summary>
        public InnerMargin InnerMargin => _innerMargin;

        /// <summary>
        /// 그림 정보 객체를 반환한다.
        /// </summary>
        public PictureInfo PictureInfo => _pictureInfo;

        /// <summary>
        /// 테두리 투명도를 반환하거나 설정한다.
        /// </summary>
        public short BorderTransparency
        {
            get => _borderTransparency;
            set => _borderTransparency = value;
        }

        /// <summary>
        /// 문서 내 각 개체에 대한 고유 아이디를 반환하거나 설정한다.
        /// </summary>
        public long InstanceId
        {
            get => _instanceId;
            set => _instanceId = value;
        }

        /// <summary>
        /// 그림 효과 정보 객체를 반환한다.
        /// </summary>
        public Picture.PictureEffect PictureEffect => _pictureEffect;

        /// <summary>
        /// 이미지 폭을 반환하거나 설정한다. (??)
        /// </summary>
        public long ImageWidth
        {
            get => _imageWidth;
            set => _imageWidth = value;
        }

        /// <summary>
        /// 이미지 높이를 반환하거나 설정한다. (??)
        /// </summary>
        public long ImageHeight
        {
            get => _imageHeight;
            set => _imageHeight = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentPicture from)
        {
            _borderColor.Copy(from._borderColor);
            _borderThickness = from._borderThickness;
            _borderProperty.Copy(from._borderProperty);
            _leftTop.Copy(from._leftTop);
            _rightTop.Copy(from._rightTop);
            _leftBottom.Copy(from._leftBottom);
            _rightBottom.Copy(from._rightBottom);
            _leftAfterCutting = from._leftAfterCutting;
            _topAfterCutting = from._topAfterCutting;
            _rightAfterCutting = from._rightAfterCutting;
            _bottomAfterCutting = from._bottomAfterCutting;
            _innerMargin.Copy(from._innerMargin);
            _pictureInfo.Copy(from._pictureInfo);
            _borderTransparency = from._borderTransparency;
            _instanceId = from._instanceId;
            _pictureEffect.Copy(from._pictureEffect);
            _imageWidth = from._imageWidth;
            _imageHeight = from._imageHeight;
        }
    }
}

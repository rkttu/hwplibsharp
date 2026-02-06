// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/ShapeComponent.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent
{
    /// <summary>
    /// 객체 공통 속성
    /// </summary>
    public abstract class ShapeComponent
    {
        /// <summary>
        /// 개체 컨트롤 Id
        /// </summary>
        private uint _gsoId;

        /// <summary>
        /// 개체가 속한 그룹 내에서의 X offset
        /// </summary>
        private int _offsetX;

        /// <summary>
        /// 개체가 속한 그룹 내에서의 Y offset
        /// </summary>
        private int _offsetY;

        /// <summary>
        /// 그룹핑 횟수
        /// </summary>
        private int _groupingCount;

        /// <summary>
        /// 개체 요소의 local file version
        /// </summary>
        private int _localFileVersion;

        /// <summary>
        /// 생성시 폭
        /// </summary>
        private int _widthAtCreate;

        /// <summary>
        /// 생성시 높이
        /// </summary>
        private int _heightAtCreate;

        /// <summary>
        /// 현재 폭
        /// </summary>
        private int _widthAtCurrent;

        /// <summary>
        /// 현재 높이
        /// </summary>
        private int _heightAtCurrent;

        /// <summary>
        /// 속성(정보 없음)
        /// </summary>
        private readonly ShapeComponentProperty _property;

        /// <summary>
        /// 회전각
        /// </summary>
        private int _rotateAngle;

        /// <summary>
        /// 회전 중심의 x 좌표(개체 좌표계)
        /// </summary>
        private int _rotateXCenter;

        /// <summary>
        /// 회전 중심의 y 좌표(개체 좌표계)
        /// </summary>
        private int _rotateYCenter;

        /// <summary>
        /// Rendering 정보
        /// </summary>
        private readonly RenderingInfo.RenderingInfo _renderingInfo;

        /// <summary>
        /// 인스턴스 아이디
        /// </summary>
        private uint _instid;

        /// <summary>
        /// 생성자
        /// </summary>
        protected ShapeComponent()
        {
            _renderingInfo = new RenderingInfo.RenderingInfo();
            _property = new ShapeComponentProperty();
        }

        /// <summary>
        /// 개체 컨트롤 Id를 반환하거나 설정한다.
        /// </summary>
        public uint GsoId
        {
            get => _gsoId;
            set => _gsoId = value;
        }

        /// <summary>
        /// 개체가 속한 그룹 내에서의 X offset을 반환하거나 설정한다.
        /// </summary>
        public int OffsetX
        {
            get => _offsetX;
            set => _offsetX = value;
        }

        /// <summary>
        /// 개체가 속한 그룹 내에서의 Y offset을 반환하거나 설정한다.
        /// </summary>
        public int OffsetY
        {
            get => _offsetY;
            set => _offsetY = value;
        }

        /// <summary>
        /// 그룹핑 횟수를 반환하거나 설정한다.
        /// </summary>
        public int GroupingCount
        {
            get => _groupingCount;
            set => _groupingCount = value;
        }

        /// <summary>
        /// 개체 요소의 local file version을 반환하거나 설정한다.
        /// </summary>
        public int LocalFileVersion
        {
            get => _localFileVersion;
            set => _localFileVersion = value;
        }

        /// <summary>
        /// 생성시 폭을 반환하거나 설정한다.
        /// </summary>
        public int WidthAtCreate
        {
            get => _widthAtCreate;
            set => _widthAtCreate = value;
        }

        /// <summary>
        /// 생성시 높이를 반환하거나 설정한다.
        /// </summary>
        public int HeightAtCreate
        {
            get => _heightAtCreate;
            set => _heightAtCreate = value;
        }

        /// <summary>
        /// 현재 폭을 반환하거나 설정한다.
        /// </summary>
        public int WidthAtCurrent
        {
            get => _widthAtCurrent;
            set => _widthAtCurrent = value;
        }

        /// <summary>
        /// 현재 높이를 반환하거나 설정한다.
        /// </summary>
        public int HeightAtCurrent
        {
            get => _heightAtCurrent;
            set => _heightAtCurrent = value;
        }

        /// <summary>
        /// 속성값을 반환한다.(정보 없음)
        /// </summary>
        public ShapeComponentProperty Property => _property;

        /// <summary>
        /// 회전각을 반환하거나 설정한다.
        /// </summary>
        public int RotateAngle
        {
            get => _rotateAngle;
            set => _rotateAngle = value;
        }

        /// <summary>
        /// 회전 중심의 x 좌표를 반환하거나 설정한다.(개체 좌표계)
        /// </summary>
        public int RotateXCenter
        {
            get => _rotateXCenter;
            set => _rotateXCenter = value;
        }

        /// <summary>
        /// 회전 중심의 y 좌표를 반환하거나 설정한다.(개체 좌표계)
        /// </summary>
        public int RotateYCenter
        {
            get => _rotateYCenter;
            set => _rotateYCenter = value;
        }

        /// <summary>
        /// Rendering 정보 객체를 반환한다.
        /// </summary>
        public RenderingInfo.RenderingInfo RenderingInfo => _renderingInfo;

        /// <summary>
        /// 객체의 인스턴스 아이디를 반환하거나 설정한다.
        /// </summary>
        public uint Instid
        {
            get => _instid;
            set => _instid = value;
        }

        /// <summary>
        /// 메트릭스들을 일반 상태(회전이나 확대되지 않은 상태)로 설정한다.
        /// </summary>
        public void SetMatrixsNormal()
        {
            _renderingInfo.TranslationMatrix.SetValue(0, 1.0);
            _renderingInfo.TranslationMatrix.SetValue(1, 0.0);
            _renderingInfo.TranslationMatrix.SetValue(2, 0.0);
            _renderingInfo.TranslationMatrix.SetValue(3, 0.0);
            _renderingInfo.TranslationMatrix.SetValue(4, 1.0);
            _renderingInfo.TranslationMatrix.SetValue(5, 0.0);

            var pair = _renderingInfo.AddNewScaleRotateMatrixPair();
            pair.ScaleMatrix.SetValue(0, 1.0);
            pair.ScaleMatrix.SetValue(1, 0.0);
            pair.ScaleMatrix.SetValue(2, 0.0);
            pair.ScaleMatrix.SetValue(3, 0.0);
            pair.ScaleMatrix.SetValue(4, 1.0);
            pair.ScaleMatrix.SetValue(5, 0.0);

            pair.RotateMatrix.SetValue(0, 1.0);
            pair.RotateMatrix.SetValue(1, 0.0);
            pair.RotateMatrix.SetValue(2, 0.0);
            pair.RotateMatrix.SetValue(3, 0.0);
            pair.RotateMatrix.SetValue(4, 1.0);
            pair.RotateMatrix.SetValue(5, 0.0);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public abstract void Copy(ShapeComponent from);

        /// <summary>
        /// ShapeComponent 부분만 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void CopyShapeComponent(ShapeComponent from)
        {
            GsoId = from.GsoId;

            _offsetX = from._offsetX;
            _offsetY = from._offsetY;
            _groupingCount = from._groupingCount;
            _localFileVersion = from._localFileVersion;
            _widthAtCreate = from._widthAtCreate;
            _heightAtCreate = from._heightAtCreate;
            _widthAtCurrent = from._widthAtCurrent;
            _heightAtCurrent = from._heightAtCurrent;
            _property.Value = from._property.Value;
            _rotateAngle = from._rotateAngle;
            _rotateXCenter = from._rotateXCenter;
            _rotateYCenter = from._rotateYCenter;
            _renderingInfo.Copy(from._renderingInfo);
            _instid = from._instid;
        }
    }
}

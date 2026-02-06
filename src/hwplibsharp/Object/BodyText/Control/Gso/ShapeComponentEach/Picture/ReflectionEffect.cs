// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/ReflectionEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 반사 효과 속성
    /// </summary>
    public class ReflectionEffect
    {
        /// <summary>
        /// 반사 스타일 (정보 없음)
        /// </summary>
        private int _style;

        /// <summary>
        /// 반경
        /// </summary>
        private float _radius;

        /// <summary>
        /// 방향
        /// </summary>
        private float _direction;

        /// <summary>
        /// 거리
        /// </summary>
        private float _distance;

        /// <summary>
        /// x축 기울기 각도
        /// </summary>
        private float _tiltAngleX;

        /// <summary>
        /// y축 기울기 각도
        /// </summary>
        private float _tiltAngleY;

        /// <summary>
        /// x축 확대 비율
        /// </summary>
        private float _zoomRateX;

        /// <summary>
        /// y축 확대 비율
        /// </summary>
        private float _zoomRateY;

        /// <summary>
        /// 회전 스타일 (정보 없음)
        /// </summary>
        private int _rotationStyle;

        /// <summary>
        /// 시작 투명도
        /// </summary>
        private float _startTransparency;

        /// <summary>
        /// 시작 위치
        /// </summary>
        private float _startPosition;

        /// <summary>
        /// 끝 투명도
        /// </summary>
        private float _endTransparency;

        /// <summary>
        /// 끝 위치
        /// </summary>
        private float _endPosition;

        /// <summary>
        /// 오프셋 방향
        /// </summary>
        private float _offsetDirection;

        /// <summary>
        /// 생성자
        /// </summary>
        public ReflectionEffect()
        {
        }

        /// <summary>
        /// 반사 스타일을 반환하거나 설정한다. (정보 없음)
        /// </summary>
        public int Style
        {
            get => _style;
            set => _style = value;
        }

        /// <summary>
        /// 반경을 반환하거나 설정한다.
        /// </summary>
        public float Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// 방향을 반환하거나 설정한다.
        /// </summary>
        public float Direction
        {
            get => _direction;
            set => _direction = value;
        }

        /// <summary>
        /// 거리를 반환하거나 설정한다.
        /// </summary>
        public float Distance
        {
            get => _distance;
            set => _distance = value;
        }

        /// <summary>
        /// x축 기울기 각도를 반환하거나 설정한다.
        /// </summary>
        public float TiltAngleX
        {
            get => _tiltAngleX;
            set => _tiltAngleX = value;
        }

        /// <summary>
        /// y축 기울기 각도를 반환하거나 설정한다.
        /// </summary>
        public float TiltAngleY
        {
            get => _tiltAngleY;
            set => _tiltAngleY = value;
        }

        /// <summary>
        /// x축 확대 비율을 반환하거나 설정한다.
        /// </summary>
        public float ZoomRateX
        {
            get => _zoomRateX;
            set => _zoomRateX = value;
        }

        /// <summary>
        /// y축 확대 비율을 반환하거나 설정한다.
        /// </summary>
        public float ZoomRateY
        {
            get => _zoomRateY;
            set => _zoomRateY = value;
        }

        /// <summary>
        /// 회전 스타일을 반환하거나 설정한다. (정보 없음)
        /// </summary>
        public int RotationStyle
        {
            get => _rotationStyle;
            set => _rotationStyle = value;
        }

        /// <summary>
        /// 시작 투명도를 반환하거나 설정한다.
        /// </summary>
        public float StartTransparency
        {
            get => _startTransparency;
            set => _startTransparency = value;
        }

        /// <summary>
        /// 시작 위치를 반환하거나 설정한다.
        /// </summary>
        public float StartPosition
        {
            get => _startPosition;
            set => _startPosition = value;
        }

        /// <summary>
        /// 끝 투명도를 반환하거나 설정한다.
        /// </summary>
        public float EndTransparency
        {
            get => _endTransparency;
            set => _endTransparency = value;
        }

        /// <summary>
        /// 끝 위치를 반환하거나 설정한다.
        /// </summary>
        public float EndPosition
        {
            get => _endPosition;
            set => _endPosition = value;
        }

        /// <summary>
        /// 오프셋 방향을 반환하거나 설정한다.
        /// </summary>
        public float OffsetDirection
        {
            get => _offsetDirection;
            set => _offsetDirection = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ReflectionEffect from)
        {
            _style = from._style;
            _radius = from._radius;
            _direction = from._direction;
            _distance = from._distance;
            _tiltAngleX = from._tiltAngleX;
            _tiltAngleY = from._tiltAngleY;
            _zoomRateX = from._zoomRateX;
            _zoomRateY = from._zoomRateY;
            _rotationStyle = from._rotationStyle;
            _startTransparency = from._startTransparency;
            _startPosition = from._startPosition;
            _endTransparency = from._endTransparency;
            _endPosition = from._endPosition;
            _offsetDirection = from._offsetDirection;
        }
    }
}

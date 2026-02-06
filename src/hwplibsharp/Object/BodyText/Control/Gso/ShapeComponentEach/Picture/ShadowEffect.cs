// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/ShadowEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 그림자 효과 속성
    /// </summary>
    public class ShadowEffect
    {
        /// <summary>
        /// 그림자 스타일 (정보 없음)
        /// </summary>
        private int _style;

        /// <summary>
        /// 그림자 투명도
        /// </summary>
        private float _transparency;

        /// <summary>
        /// 그림자 흐릿하게
        /// </summary>
        private float _cloudy;

        /// <summary>
        /// 방향
        /// </summary>
        private float _direction;

        /// <summary>
        /// 거리
        /// </summary>
        private float _distance;

        /// <summary>
        /// 정렬 (정보 없음)
        /// </summary>
        private int _sort;

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
        /// 도형과 함께 그림자 회전
        /// </summary>
        private int _rotateWithShape;

        /// <summary>
        /// 그림자 색상
        /// </summary>
        private readonly ColorWithEffect _color;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShadowEffect()
        {
            _color = new ColorWithEffect();
        }

        /// <summary>
        /// 그림자 스타일을 반환하거나 설정한다. (정보 없음)
        /// </summary>
        public int Style
        {
            get => _style;
            set => _style = value;
        }

        /// <summary>
        /// 그림자 투명도를 반환하거나 설정한다.
        /// </summary>
        public float Transparency
        {
            get => _transparency;
            set => _transparency = value;
        }

        /// <summary>
        /// 그림자 흐릿함 정도를 반환하거나 설정한다.
        /// </summary>
        public float Cloudy
        {
            get => _cloudy;
            set => _cloudy = value;
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
        /// 정렬 방법을 반환하거나 설정한다. (정보 없음)
        /// </summary>
        public int Sort
        {
            get => _sort;
            set => _sort = value;
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
        /// 도형과 함께 그림자 회전 여부를 반환하거나 설정한다.
        /// </summary>
        public int RotateWithShape
        {
            get => _rotateWithShape;
            set => _rotateWithShape = value;
        }

        /// <summary>
        /// 그림자 색상 객체를 반환한다.
        /// </summary>
        public ColorWithEffect Color => _color;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShadowEffect from)
        {
            _style = from._style;
            _transparency = from._transparency;
            _cloudy = from._cloudy;
            _direction = from._direction;
            _distance = from._distance;
            _sort = from._sort;
            _tiltAngleX = from._tiltAngleX;
            _tiltAngleY = from._tiltAngleY;
            _zoomRateX = from._zoomRateX;
            _zoomRateY = from._zoomRateY;
            _rotateWithShape = from._rotateWithShape;
            _color.Copy(from._color);
        }
    }
}

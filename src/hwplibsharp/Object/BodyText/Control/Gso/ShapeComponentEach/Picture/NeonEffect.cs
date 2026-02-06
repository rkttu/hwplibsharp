// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/NeonEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 네온 효과 속성
    /// </summary>
    public class NeonEffect
    {
        /// <summary>
        /// 네온 투명도
        /// </summary>
        private float _transparency;

        /// <summary>
        /// 네온 반경
        /// </summary>
        private float _radius;

        /// <summary>
        /// 네온 색상
        /// </summary>
        private readonly ColorWithEffect _color;

        /// <summary>
        /// 생성자
        /// </summary>
        public NeonEffect()
        {
            _color = new ColorWithEffect();
        }

        /// <summary>
        /// 네온 투명도를 반환하거나 설정한다.
        /// </summary>
        public float Transparency
        {
            get => _transparency;
            set => _transparency = value;
        }

        /// <summary>
        /// 네온 반경을 반환하거나 설정한다.
        /// </summary>
        public float Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// 네온 색상 객체를 반환한다.
        /// </summary>
        public ColorWithEffect Color => _color;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(NeonEffect from)
        {
            _transparency = from._transparency;
            _radius = from._radius;
            _color.Copy(from._color);
        }
    }
}

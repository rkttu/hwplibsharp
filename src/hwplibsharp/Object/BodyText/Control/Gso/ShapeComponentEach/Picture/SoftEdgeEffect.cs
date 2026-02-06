// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/SoftEdgeEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 부드러운 가장자리 효과 속성
    /// </summary>
    public class SoftEdgeEffect
    {
        /// <summary>
        /// 반경
        /// </summary>
        private float _radius;

        /// <summary>
        /// 생성자
        /// </summary>
        public SoftEdgeEffect()
        {
        }

        /// <summary>
        /// 부드러운 가장자리 반경을 반환하거나 설정한다.
        /// </summary>
        public float Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(SoftEdgeEffect from)
        {
            _radius = from._radius;
        }
    }
}

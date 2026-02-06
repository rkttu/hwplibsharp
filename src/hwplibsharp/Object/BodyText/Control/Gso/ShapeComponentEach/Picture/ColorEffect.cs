// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/ColorEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 색상 효과 속성
    /// </summary>
    public class ColorEffect
    {
        /// <summary>
        /// 색상 효과 종류
        /// </summary>
        private ColorEffectSort _sort;

        /// <summary>
        /// 색상 효과 값
        /// </summary>
        private float _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public ColorEffect()
        {
        }

        /// <summary>
        /// 색상 효과 종류를 반환하거나 설정한다.
        /// </summary>
        public ColorEffectSort Sort
        {
            get => _sort;
            set => _sort = value;
        }

        /// <summary>
        /// 색상 효과 값을 반환하거나 설정한다.
        /// </summary>
        public float Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ColorEffect Clone()
        {
            var cloned = new ColorEffect
            {
                _sort = _sort,
                _value = _value
            };
            return cloned;
        }
    }
}

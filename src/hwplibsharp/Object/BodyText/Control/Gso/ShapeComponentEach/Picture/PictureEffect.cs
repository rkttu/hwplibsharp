// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/PictureEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 그림 효과
    /// </summary>
    public class PictureEffect
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly PictureEffectProperty _property;

        /// <summary>
        /// 그림자 효과
        /// </summary>
        private ShadowEffect? _shadowEffect;

        /// <summary>
        /// 네온 효과
        /// </summary>
        private NeonEffect? _neonEffect;

        /// <summary>
        /// 부드러운 가장자리 효과
        /// </summary>
        private SoftEdgeEffect? _softEdgeEffect;

        /// <summary>
        /// 반사 효과
        /// </summary>
        private ReflectionEffect? _reflectionEffect;

        /// <summary>
        /// 생성자
        /// </summary>
        public PictureEffect()
        {
            _property = new PictureEffectProperty();
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public PictureEffectProperty Property => _property;

        /// <summary>
        /// 그림자 효과 객체를 반환한다.
        /// </summary>
        public ShadowEffect? ShadowEffect => _shadowEffect;

        /// <summary>
        /// 네온 효과 객체를 반환한다.
        /// </summary>
        public NeonEffect? NeonEffect => _neonEffect;

        /// <summary>
        /// 부드러운 가장자리 효과 객체를 반환한다.
        /// </summary>
        public SoftEdgeEffect? SoftEdgeEffect => _softEdgeEffect;

        /// <summary>
        /// 반사 효과 객체를 반환한다.
        /// </summary>
        public ReflectionEffect? ReflectionEffect => _reflectionEffect;

        /// <summary>
        /// 그림자 효과 객체를 생성한다.
        /// </summary>
        public void CreateShadowEffect()
        {
            _shadowEffect = new ShadowEffect();
        }

        /// <summary>
        /// 그림자 효과 객체를 삭제한다.
        /// </summary>
        public void DeleteShadowEffect()
        {
            _shadowEffect = null;
        }

        /// <summary>
        /// 네온 효과 객체를 생성한다.
        /// </summary>
        public void CreateNeonEffect()
        {
            _neonEffect = new NeonEffect();
        }

        /// <summary>
        /// 네온 효과 객체를 삭제한다.
        /// </summary>
        public void DeleteNeonEffect()
        {
            _neonEffect = null;
        }

        /// <summary>
        /// 부드러운 가장자리 효과 객체를 생성한다.
        /// </summary>
        public void CreateSoftEdgeEffect()
        {
            _softEdgeEffect = new SoftEdgeEffect();
        }

        /// <summary>
        /// 부드러운 가장자리 효과 객체를 삭제한다.
        /// </summary>
        public void DeleteSoftEdgeEffect()
        {
            _softEdgeEffect = null;
        }

        /// <summary>
        /// 반사 효과 객체를 생성한다.
        /// </summary>
        public void CreateReflectionEffect()
        {
            _reflectionEffect = new ReflectionEffect();
        }

        /// <summary>
        /// 반사 효과 객체를 삭제한다.
        /// </summary>
        public void DeleteReflectionEffect()
        {
            _reflectionEffect = null;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PictureEffect from)
        {
            _property.Copy(from._property);

            if (from._shadowEffect != null)
            {
                CreateShadowEffect();
                _shadowEffect!.Copy(from._shadowEffect);
            }
            else
            {
                _shadowEffect = null;
            }

            if (from._neonEffect != null)
            {
                CreateNeonEffect();
                _neonEffect!.Copy(from._neonEffect);
            }
            else
            {
                _neonEffect = null;
            }

            if (from._softEdgeEffect != null)
            {
                CreateSoftEdgeEffect();
                _softEdgeEffect!.Copy(from._softEdgeEffect);
            }
            else
            {
                _softEdgeEffect = null;
            }

            if (from._reflectionEffect != null)
            {
                CreateReflectionEffect();
                _reflectionEffect!.Copy(from._reflectionEffect);
            }
            else
            {
                _reflectionEffect = null;
            }
        }
    }
}

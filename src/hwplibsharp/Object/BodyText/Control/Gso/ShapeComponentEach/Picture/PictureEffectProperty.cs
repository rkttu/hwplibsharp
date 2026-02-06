// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/PictureEffectProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 그림 효과의 속성을 나타내는 객체
    /// </summary>
    public class PictureEffectProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private uint _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public PictureEffectProperty()
        {
        }

        /// <summary>
        /// 파일에 저장되는 정수값을 반환하거나 설정한다.
        /// </summary>
        public uint Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// 그림자 효과 유무를 반환하거나 설정한다. (0 bit)
        /// </summary>
        public bool HasShadowEffect
        {
            get => BitFlag.Get(_value, 0);
            set => _value = (uint)BitFlag.Set(_value, 0, value);
        }

        /// <summary>
        /// 네온 효과 유무를 반환하거나 설정한다. (1 bit)
        /// </summary>
        public bool HasNeonEffect
        {
            get => BitFlag.Get(_value, 1);
            set => _value = (uint)BitFlag.Set(_value, 1, value);
        }

        /// <summary>
        /// 부드러운 가장자리 효과 유무를 반환하거나 설정한다. (2 bit)
        /// </summary>
        public bool HasSoftBorderEffect
        {
            get => BitFlag.Get(_value, 2);
            set => _value = (uint)BitFlag.Set(_value, 2, value);
        }

        /// <summary>
        /// 반사 효과 유무를 반환하거나 설정한다. (3 bit)
        /// </summary>
        public bool HasReflectionEffect
        {
            get => BitFlag.Get(_value, 3);
            set => _value = (uint)BitFlag.Set(_value, 3, value);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PictureEffectProperty from)
        {
            _value = from._value;
        }
    }
}

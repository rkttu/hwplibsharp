// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/ShapeComponentProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent
{
    /// <summary>
    /// 객체 공통 속성의 속성을 나타내는 객체
    /// </summary>
    public class ShapeComponentProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private uint _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentProperty()
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
        /// 개체가 좌우 대칭인지 여부를 반환하거나 설정한다. (0 bit)
        /// </summary>
        public bool IsFlipHorizontal
        {
            get => BitFlag.Get(_value, 0);
            set => _value = (uint)BitFlag.Set(_value, 0, value);
        }

        /// <summary>
        /// 개체가 상하 대칭인지 여부를 반환하거나 설정한다. (1 bit)
        /// </summary>
        public bool IsFlipVertical
        {
            get => BitFlag.Get(_value, 1);
            set => _value = (uint)BitFlag.Set(_value, 1, value);
        }

        /// <summary>
        /// 개체가 이미지와 함께 회전하는지 여부를 반환하거나 설정한다. (19 bit)
        /// </summary>
        public bool IsRotateWithImage
        {
            get => BitFlag.Get(_value, 19);
            set => _value = (uint)BitFlag.Set(_value, 19, value);
        }

        /// <summary>
        /// 그림 개체의 색 반전 여부를 반환하거나 설정한다. (24 bit)
        /// </summary>
        public bool IsReverseColor
        {
            get => BitFlag.Get(_value, 24);
            set => _value = (uint)BitFlag.Set(_value, 24, value);
        }
    }
}

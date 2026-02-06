// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ellipse/ShapeComponentEllipseProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Arc;
using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Ellipse
{
    /// <summary>
    /// 타원 개체의 속성을 나타내는 객체
    /// </summary>
    public class ShapeComponentEllipseProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private uint _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentEllipseProperty()
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
        /// 호(ARC)로 바뀌었을 때 interval을 다시 계산해야 할 필요가 있는지 여부를 반환하거나 설정한다. (0 bit)
        /// </summary>
        public bool IsRecalculateIntervalWhenChangingArc
        {
            get => BitFlag.Get(_value, 0);
            set => _value = (uint)BitFlag.Set(_value, 0, value);
        }

        /// <summary>
        /// 호(ARC)로 바뀌었는지 여부를 반환하거나 설정한다. (1 bit)
        /// </summary>
        public bool IsChangeArc
        {
            get => BitFlag.Get(_value, 1);
            set => _value = (uint)BitFlag.Set(_value, 1, value);
        }

        /// <summary>
        /// 호(ARC)의 타입를 반환하거나 설정한다. (2~9 bit)
        /// </summary>
        public ArcType ArcType
        {
            get => ArcTypeExtensions.FromValue((byte)BitFlag.Get(_value, 2, 9));
            set => _value = (uint)BitFlag.Set(_value, 2, 9, value.GetValue());
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentEllipseProperty from)
        {
            _value = from._value;
        }
    }
}

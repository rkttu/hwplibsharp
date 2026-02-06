// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/lineinfo/LineInfoProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo
{
    /// <summary>
    /// 테두리 선 정보의 속성을 나타내는 객체
    /// </summary>
    public class LineInfoProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private uint _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public LineInfoProperty()
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
        /// 선 종류를 반환하거나 설정한다. (0~5 bit)
        /// </summary>
        public LineType LineType
        {
            get => LineTypeExtensions.FromValue((byte)BitFlag.Get(_value, 0, 5));
            set => _value = (uint)BitFlag.Set(_value, 0, 5, value.GetValue());
        }

        /// <summary>
        /// 선 끝 모양을 반환하거나 설정한다. (6~9 bit)
        /// </summary>
        public LineEndShape LineEndShape
        {
            get => LineEndShapeExtensions.FromValue((byte)BitFlag.Get(_value, 6, 9));
            set => _value = (uint)BitFlag.Set(_value, 6, 9, value.GetValue());
        }

        /// <summary>
        /// 화살표 시작 모양을 반환하거나 설정한다. (10~15 bit)
        /// </summary>
        public LineArrowShape StartArrowShape
        {
            get => LineArrowShapeExtensions.FromValue((byte)BitFlag.Get(_value, 10, 15));
            set => _value = (uint)BitFlag.Set(_value, 10, 15, value.GetValue());
        }

        /// <summary>
        /// 화살표 끝 모양을 반환하거나 설정한다. (16~21 bit)
        /// </summary>
        public LineArrowShape EndArrowShape
        {
            get => LineArrowShapeExtensions.FromValue((byte)BitFlag.Get(_value, 16, 21));
            set => _value = (uint)BitFlag.Set(_value, 16, 21, value.GetValue());
        }

        /// <summary>
        /// 화살표 시작 크기를 반환하거나 설정한다. (22~25 bit)
        /// </summary>
        public LineArrowSize StartArrowSize
        {
            get => LineArrowSizeExtensions.FromValue((byte)BitFlag.Get(_value, 22, 25));
            set => _value = (uint)BitFlag.Set(_value, 22, 25, value.GetValue());
        }

        /// <summary>
        /// 화살표 끝 크기를 반환하거나 설정한다. (26~29 bit)
        /// </summary>
        public LineArrowSize EndArrowSize
        {
            get => LineArrowSizeExtensions.FromValue((byte)BitFlag.Get(_value, 26, 29));
            set => _value = (uint)BitFlag.Set(_value, 26, 29, value.GetValue());
        }

        /// <summary>
        /// 시작부분 화살표 채움 여부를 반환하거나 설정한다. (30 bit)
        /// </summary>
        public bool IsFillStartArrow
        {
            get => BitFlag.Get(_value, 30);
            set => _value = (uint)BitFlag.Set(_value, 30, value);
        }

        /// <summary>
        /// 끝부분 화살표 채움 여부를 반환하거나 설정한다. (31 bit)
        /// </summary>
        public bool IsFillEndArrow
        {
            get => BitFlag.Get(_value, 31);
            set => _value = (uint)BitFlag.Set(_value, 31, value);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(LineInfoProperty from)
        {
            _value = from._value;
        }
    }
}

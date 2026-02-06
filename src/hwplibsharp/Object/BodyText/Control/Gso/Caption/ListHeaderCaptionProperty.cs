// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/caption/ListHeaderCaptionProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Gso.Caption
{
    /// <summary>
    /// 캡션 정보의 속성을 나타내는 객체
    /// </summary>
    public class ListHeaderCaptionProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private uint _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderCaptionProperty()
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
        /// 캡션 방향을 반환하거나 설정한다. (0~1 bit)
        /// </summary>
        public CaptionDirection Direction
        {
            get => CaptionDirectionExtensions.FromValue((byte)BitFlag.Get(_value, 0, 1));
            set => _value = (uint)BitFlag.Set(_value, 0, 1, value.GetValue());
        }

        /// <summary>
        /// 캡션 폭에 여백을 포함할 것인지 여부를 반환하거나 설정한다. (2 bit)
        /// </summary>
        public bool IsIncludeMargin
        {
            get => BitFlag.Get(_value, 2);
            set => _value = (uint)BitFlag.Set(_value, 2, value);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ListHeaderCaptionProperty from)
        {
            _value = from._value;
        }
    }
}

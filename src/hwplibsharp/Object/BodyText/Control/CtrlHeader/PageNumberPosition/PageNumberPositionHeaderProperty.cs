// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/pagenumberposition/PageNumberPositionHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.SectionDefine;
using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.CtrlHeader.PageNumberPosition
{
    /// <summary>
    /// 쪽 번호 위치 컨트롤의 속성을 나타내는 객체
    /// </summary>
    public class PageNumberPositionHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public PageNumberPositionHeaderProperty()
        {
        }

        /// <summary>
        /// 번호 모양 (0~7 bit)
        /// </summary>
        public NumberShape NumberShape
        {
            get => NumberShapeExtensions.FromValue((short)BitFlag.Get(Value, 0, 7));
            set => Value = (uint)BitFlag.Set(Value, 0, 7, value.GetValue());
        }

        /// <summary>
        /// 번호의 표시 위치 (8~11 bit)
        /// </summary>
        public NumberPosition NumberPosition
        {
            get => NumberPositionExtensions.FromValue((byte)BitFlag.Get(Value, 8, 11));
            set => Value = (uint)BitFlag.Set(Value, 8, 11, value.GetValue());
        }

        /// <summary>
        /// 다른 <see cref="PageNumberPositionHeaderProperty"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="PageNumberPositionHeaderProperty"/> 인스턴스입니다.</param>
        public void Copy(PageNumberPositionHeaderProperty from)
        {
            Value = from.Value;
        }
    }
}

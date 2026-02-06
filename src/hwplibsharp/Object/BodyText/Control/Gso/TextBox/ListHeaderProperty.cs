// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/textbox/ListHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.SectionDefine;
using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Gso.TextBox
{
    /// <summary>
    /// 문단 리스트 헤더의 속성을 나타내는 객체
    /// </summary>
    public class ListHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderProperty()
        {
        }

        /// <summary>
        /// 텍스트 방향을 반환하거나 설정한다. (0~2 bit)
        /// </summary>
        public TextDirection TextDirection
        {
            get => TextDirectionExtensions.FromValue((byte)BitFlag.Get(Value, 0, 2));
            set => Value = (uint)BitFlag.Set(Value, 0, 2, value.GetValue());
        }

        /// <summary>
        /// 문단의 줄바꿈 방법을 반환하거나 설정한다. (3~4 bit)
        /// </summary>
        public LineChange LineChange
        {
            get => LineChangeExtensions.FromValue((byte)BitFlag.Get(Value, 3, 4));
            set => Value = (uint)BitFlag.Set(Value, 3, 4, value.GetValue());
        }

        /// <summary>
        /// 세로 정렬 방법을 반환하거나 설정한다. (5~6 bit)
        /// </summary>
        public TextVerticalAlignment TextVerticalAlignment
        {
            get => TextVerticalAlignmentExtensions.FromValue((byte)BitFlag.Get(Value, 5, 6));
            set => Value = (uint)BitFlag.Set(Value, 5, 6, value.GetValue());
        }

        /// <summary>
        /// 다른 ListHeaderProperty 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ListHeaderProperty from)
        {
            Value = from.Value;
        }
    }
}

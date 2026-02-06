// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/table/ListHeaderPropertyForCell.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.SectionDefine;
using HwpLib.Object.BodyText.Control.Gso.TextBox;
using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Table
{
    /// <summary>
    /// 셀의 문단 리스트 헤더의 속성을 나타내는 객체
    /// </summary>
    public class ListHeaderPropertyForCell
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private long _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderPropertyForCell()
        {
        }

        /// <summary>
        /// 파일에 저장되는 정수값을 반환하거나 설정한다.
        /// </summary>
        public long Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// 텍스트 방향을 반환하거나 설정한다. (0~2 bit)
        /// </summary>
        public TextDirection TextDirection
        {
            get => TextDirectionExtensions.FromValue((byte)BitFlag.Get(_value, 0, 2));
            set => _value = BitFlag.Set(_value, 0, 2, value.GetValue());
        }

        /// <summary>
        /// 문단의 줄바꿈을 반환하거나 설정한다. (3~4 bit)
        /// </summary>
        public LineChange LineChange
        {
            get => LineChangeExtensions.FromValue((byte)BitFlag.Get(_value, 3, 4));
            set => _value = BitFlag.Set(_value, 3, 4, value.GetValue());
        }

        /// <summary>
        /// 세로 정렬을 반환하거나 설정한다. (5~6 bit)
        /// </summary>
        public TextVerticalAlignment TextVerticalAlignment
        {
            get => TextVerticalAlignmentExtensions.FromValue((byte)BitFlag.Get(_value, 5, 6));
            set => _value = BitFlag.Set(_value, 5, 6, value.GetValue());
        }

        /// <summary>
        /// 안 여백 지정 여부를 반환하거나 설정한다. (16 bit)
        /// </summary>
        public bool ApplyInnerMargin
        {
            get => BitFlag.Get(_value, 16);
            set => _value = BitFlag.Set(_value, 16, value);
        }

        /// <summary>
        /// 셀 보호 여부를 반환하거나 설정한다. (17 bit)
        /// </summary>
        public bool ProtectCell
        {
            get => BitFlag.Get(_value, 17);
            set => _value = BitFlag.Set(_value, 17, value);
        }

        /// <summary>
        /// 제목셀 인지 여부를 반환하거나 설정한다. (18 bit)
        /// </summary>
        public bool TitleCell
        {
            get => BitFlag.Get(_value, 18);
            set => _value = BitFlag.Set(_value, 18, value);
        }

        /// <summary>
        /// 양식 모드에서 편집 가능 여부를 반환하거나 설정한다. (19 bit)
        /// </summary>
        public bool EditableAtFormMode
        {
            get => BitFlag.Get(_value, 19);
            set => _value = BitFlag.Set(_value, 19, value);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ListHeaderPropertyForCell from)
        {
            _value = from._value;
        }
    }
}

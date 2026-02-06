// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/PageBorderFillProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 쪽 테두리/배경 정보의 속성에 대한 객체
    /// </summary>
    public class PageBorderFillProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private long _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public PageBorderFillProperty()
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
        /// 위치 기준을 반환하거나 설정한다. (0 bit)
        /// </summary>
        public PositionCriterion PositionCriterion
        {
            get => BitFlag.Get(_value, 0) ? PositionCriterion.Paper : PositionCriterion.MainText;
            set => _value = BitFlag.Set(_value, 0, value == PositionCriterion.Paper);
        }

        /// <summary>
        /// 머리말 포함 여부를 반환하거나 설정한다. (1 bit)
        /// </summary>
        public bool IncludeHeader
        {
            get => BitFlag.Get(_value, 1);
            set => _value = BitFlag.Set(_value, 1, value);
        }

        /// <summary>
        /// 꼬리말 포함 여부를 반환하거나 설정한다. (2 bit)
        /// </summary>
        public bool IncludeFooter
        {
            get => BitFlag.Get(_value, 2);
            set => _value = BitFlag.Set(_value, 2, value);
        }

        /// <summary>
        /// 채워질 영역의 종류를 반환하거나 설정한다. (3~4 bit)
        /// </summary>
        public FillArea FillArea
        {
            get => FillAreaExtensions.FromValue((byte)BitFlag.Get(_value, 3, 4));
            set => _value = BitFlag.Set(_value, 3, 4, value.GetValue());
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PageBorderFillProperty from)
        {
            _value = from._value;
        }
    }
}

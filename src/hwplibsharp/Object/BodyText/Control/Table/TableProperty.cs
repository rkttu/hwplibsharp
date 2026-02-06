// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/table/TableProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Table
{
    /// <summary>
    /// 표의 속성을 나타내는 객체
    /// </summary>
    public class TableProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private long _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public TableProperty()
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
        /// 쪽 경계에서 나눔 방법을 반환하거나 설정한다. (0~1 bit)
        /// </summary>
        public DivideAtPageBoundary DivideAtPageBoundary
        {
            get => DivideAtPageBoundaryExtensions.FromValue((byte)BitFlag.Get(_value, 0, 1));
            set => _value = BitFlag.Set(_value, 0, 1, value.GetValue());
        }

        /// <summary>
        /// 제목 줄 자동 반복 여부를 반환하거나 설정한다. (2 bit)
        /// </summary>
        public bool AutoRepeatTitleRow
        {
            get => BitFlag.Get(_value, 2);
            set => _value = BitFlag.Set(_value, 2, value);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(TableProperty from)
        {
            _value = from._value;
        }
    }
}

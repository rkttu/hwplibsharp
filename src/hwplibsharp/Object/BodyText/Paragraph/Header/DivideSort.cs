// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/header/DivideSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Paragraph.Header
{
    /// <summary>
    /// 단 나누기의 종류에 대한 객체
    /// </summary>
    public class DivideSort
    {
        /// <summary>
        /// 파일에 저장되는 값 (unsigned 1 byte)
        /// </summary>
        public byte Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public DivideSort()
        {
        }

        /// <summary>
        /// 구역 나누기가 적용되었는지 여부 (0 bit)
        /// </summary>
        public bool IsDivideSection
        {
            get => BitFlag.Get(Value, 0);
            set => Value = (byte)BitFlag.Set(Value, 0, value);
        }

        /// <summary>
        /// 다단 나누기가 적용되었는지 여부 (1 bit)
        /// </summary>
        public bool IsDivideMultiColumn
        {
            get => BitFlag.Get(Value, 1);
            set => Value = (byte)BitFlag.Set(Value, 1, value);
        }

        /// <summary>
        /// 쪽 나누기가 적용되었는지 여부 (2 bit)
        /// </summary>
        public bool IsDividePage
        {
            get => BitFlag.Get(Value, 2);
            set => Value = (byte)BitFlag.Set(Value, 2, value);
        }

        /// <summary>
        /// 단 나누기가 적용되었는지 여부 (3 bit)
        /// </summary>
        public bool IsDivideColumn
        {
            get => BitFlag.Get(Value, 3);
            set => Value = (byte)BitFlag.Set(Value, 3, value);
        }

        /// <summary>
        /// 다른 DivideSort 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(DivideSort from)
        {
            Value = from.Value;
        }
    }
}

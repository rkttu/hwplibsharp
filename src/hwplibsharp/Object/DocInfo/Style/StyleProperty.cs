// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/style/StyleProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.Style
{
    /// <summary>
    /// 스타일의 속성 객체
    /// </summary>
    public class StyleProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 1 byte)
        /// </summary>
        public byte Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public StyleProperty()
        {
        }

        /// <summary>
        /// 스타일 종류 (0~2 bit)
        /// </summary>
        public StyleSort StyleSort
        {
            get => StyleSortExtensions.FromValue((byte)BitFlag.Get(Value, 0, 2));
            set => Value = (byte)BitFlag.Set(Value, 0, 2, value.GetValue());
        }

        /// <summary>
        /// 다른 StyleProperty 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(StyleProperty from)
        {
            Value = from.Value;
        }
    }
}

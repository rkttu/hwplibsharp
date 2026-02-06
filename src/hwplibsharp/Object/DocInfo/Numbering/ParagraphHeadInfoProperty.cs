// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/numbering/ParagraphHeadInfoProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.Numbering
{
    /// <summary>
    /// 문단 머리 정보의 속성 객체
    /// </summary>
    public class ParagraphHeadInfoProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ParagraphHeadInfoProperty()
        {
        }

        /// <summary>
        /// 문단의 정렬 종류 (0~1 bit)
        /// </summary>
        public ParagraphAlignment ParagraphAlignment
        {
            get => ParagraphAlignmentExtensions.FromValue((byte)BitFlag.Get(Value, 0, 1));
            set => Value = (uint)BitFlag.Set(Value, 0, 1, value.GetValue());
        }

        /// <summary>
        /// 번호 너비를 실제 인스턴스 문자열의 너비에 따를지 여부 (2 bit)
        /// </summary>
        public bool IsFollowStringWidth
        {
            get => BitFlag.Get(Value, 2);
            set => Value = (uint)BitFlag.Set(Value, 2, value);
        }

        /// <summary>
        /// 자동 내어 쓰기 여부 (3 bit)
        /// </summary>
        public bool IsAutoIndent
        {
            get => BitFlag.Get(Value, 3);
            set => Value = (uint)BitFlag.Set(Value, 3, value);
        }

        /// <summary>
        /// 수준별 본문과의 거리 종류 (4 bit)
        /// </summary>
        public ValueType ValueTypeForDistanceFromBody
        {
            get => BitFlag.Get(Value, 4) ? ValueType.Value : ValueType.RatioForLetter;
            set => Value = (uint)BitFlag.Set(Value, 4, value == ValueType.Value);
        }

        /// <summary>
        /// 문단 번호 형식 (5~9 bit)
        /// </summary>
        public ParagraphNumberFormat ParagraphNumberFormat
        {
            get => ParagraphNumberFormatExtensions.FromValue((byte)BitFlag.Get(Value, 5, 9));
            set => Value = (uint)BitFlag.Set(Value, 5, 9, value.GetValue());
        }

        /// <summary>
        /// 다른 ParagraphHeadInfoProperty 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParagraphHeadInfoProperty from)
        {
            Value = from.Value;
        }
    }
}

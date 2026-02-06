// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/lineseg/LineSegItemTag.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Paragraph.LineSeg
{
    /// <summary>
    /// 각 줄의 align 정보의 태그 정보에 대한 객체
    /// </summary>
    public class LineSegItemTag
    {
        /// <summary>
        /// 파일에 저장되는 값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public LineSegItemTag()
        {
        }

        /// <summary>
        /// 페이지의 첫 줄인지 여부 (0 bit)
        /// </summary>
        public bool IsFirstLineAtPage
        {
            get => BitFlag.Get(Value, 0);
            set => Value = (uint)BitFlag.Set(Value, 0, value);
        }

        /// <summary>
        /// 컬럼의 첫 줄인지 여부 (1 bit)
        /// </summary>
        public bool IsFirstLineAtColumn
        {
            get => BitFlag.Get(Value, 1);
            set => Value = (uint)BitFlag.Set(Value, 1, value);
        }

        /// <summary>
        /// 텍스트가 배열되지 않은 빈 세그먼트인지 여부 (16 bit)
        /// </summary>
        public bool IsEmptySegment
        {
            get => BitFlag.Get(Value, 16);
            set => Value = (uint)BitFlag.Set(Value, 16, value);
        }

        /// <summary>
        /// 줄의 첫 세그먼트인지 여부 (17 bit)
        /// </summary>
        public bool IsFirstSegmentAtLine
        {
            get => BitFlag.Get(Value, 17);
            set => Value = (uint)BitFlag.Set(Value, 17, value);
        }

        /// <summary>
        /// 줄의 마지막 세그먼트인지 여부 (18 bit)
        /// </summary>
        public bool IsLastSegmentAtLine
        {
            get => BitFlag.Get(Value, 18);
            set => Value = (uint)BitFlag.Set(Value, 18, value);
        }

        /// <summary>
        /// 줄의 마지막에 auto-hyphenation이 수행되었는지 여부 (19 bit)
        /// </summary>
        public bool IsAutoHyphenation
        {
            get => BitFlag.Get(Value, 19);
            set => Value = (uint)BitFlag.Set(Value, 19, value);
        }

        /// <summary>
        /// indentation 적용 여부 (20 bit)
        /// </summary>
        public bool IsAdjustIndentation
        {
            get => BitFlag.Get(Value, 20);
            set => Value = (uint)BitFlag.Set(Value, 20, value);
        }

        /// <summary>
        /// 문단 머리 모양 적용 여부 (21 bit)
        /// </summary>
        public bool IsAdjustBullet
        {
            get => BitFlag.Get(Value, 21);
            set => Value = (uint)BitFlag.Set(Value, 21, value);
        }

        /// <summary>
        /// 구현상의 편의를 위한 property (31 bit)
        /// </summary>
        public bool Bit31
        {
            get => BitFlag.Get(Value, 31);
            set => Value = (uint)BitFlag.Set(Value, 31, value);
        }

        /// <summary>
        /// 다른 LineSegItemTag 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(LineSegItemTag from)
        {
            Value = from.Value;
        }
    }
}

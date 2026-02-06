// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/CharShapeProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 글자 모양 객체의 속성
    /// </summary>
    public class CharShapeProperty
    {
        private uint _value;

        /// <summary>
        /// CharShapeProperty 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public CharShapeProperty()
        {
        }

        /// <summary>
        /// 글자 모양 속성의 원시 값을 가져오거나 설정합니다.
        /// </summary>
        public uint Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// 글꼴 기울임 여부 (0 bit)
        /// </summary>
        public bool IsItalic
        {
            get => BitFlag.Get(_value, 0);
            set => _value = BitFlag.Set(_value, 0, value);
        }

        /// <summary>
        /// 글꼴 진하게 여부 (1 bit)
        /// </summary>
        public bool IsBold
        {
            get => BitFlag.Get(_value, 1);
            set => _value = BitFlag.Set(_value, 1, value);
        }

        /// <summary>
        /// 밑줄의 종류 (2~3 bit)
        /// </summary>
        public UnderLineSort UnderLineSort
        {
            get => UnderLineSortExtensions.FromValue((byte)BitFlag.Get(_value, 2, 3));
            set => _value = BitFlag.Set(_value, 2, 3, value.GetValue());
        }

        /// <summary>
        /// 밑줄의 모양 (4~7 bit)
        /// </summary>
        public BorderType2 UnderLineShape
        {
            get => BorderType2Extensions.FromValue((byte)BitFlag.Get(_value, 4, 7));
            set => _value = BitFlag.Set(_value, 4, 7, value.GetValue());
        }

        /// <summary>
        /// 외곽선의 종류 (8~10 bit)
        /// </summary>
        public OutterLineSort OutterLineSort
        {
            get => OutterLineSortExtensions.FromValue((byte)BitFlag.Get(_value, 8, 10));
            set => _value = BitFlag.Set(_value, 8, 10, value.GetValue());
        }

        /// <summary>
        /// 그림자의 종류 (11~12 bit)
        /// </summary>
        public ShadowSort ShadowSort
        {
            get => ShadowSortExtensions.FromValue((byte)BitFlag.Get(_value, 11, 12));
            set => _value = BitFlag.Set(_value, 11, 12, value.GetValue());
        }

        /// <summary>
        /// 양각 여부 (13 bit)
        /// </summary>
        public bool IsEmboss
        {
            get => BitFlag.Get(_value, 13);
            set => _value = BitFlag.Set(_value, 13, value);
        }

        /// <summary>
        /// 음각 여부 (14 bit)
        /// </summary>
        public bool IsEngrave
        {
            get => BitFlag.Get(_value, 14);
            set => _value = BitFlag.Set(_value, 14, value);
        }

        /// <summary>
        /// 위 첨자 여부 (15 bit)
        /// </summary>
        public bool IsSuperScript
        {
            get => BitFlag.Get(_value, 15);
            set => _value = BitFlag.Set(_value, 15, value);
        }

        /// <summary>
        /// 아래 첨자 여부 (16 bit)
        /// </summary>
        public bool IsSubScript
        {
            get => BitFlag.Get(_value, 16);
            set => _value = BitFlag.Set(_value, 16, value);
        }

        /// <summary>
        /// 취소선 여부 (18 bit)
        /// </summary>
        public bool IsStrikeLine
        {
            get => BitFlag.Get(_value, 18);
            set => _value = BitFlag.Set(_value, 18, value);
        }

        /// <summary>
        /// 강조점의 종류 (21~24 bit)
        /// </summary>
        public EmphasisSort EmphasisSort
        {
            get => EmphasisSortExtensions.FromValue((byte)BitFlag.Get(_value, 21, 24));
            set => _value = BitFlag.Set(_value, 21, 24, value.GetValue());
        }

        /// <summary>
        /// 글꼴에 어울리는 빈칸 사용 여부 (25 bit)
        /// </summary>
        public bool IsUsingSpaceAppropriateForFont
        {
            get => BitFlag.Get(_value, 25);
            set => _value = BitFlag.Set(_value, 25, value);
        }

        /// <summary>
        /// 취소선의 모양 (26~29 bit)
        /// </summary>
        public BorderType2 StrikeLineShape
        {
            get => BorderType2Extensions.FromValue((byte)BitFlag.Get(_value, 26, 29));
            set => _value = BitFlag.Set(_value, 26, 29, value.GetValue());
        }

        /// <summary>
        /// Kerning 여부 (30 bit)
        /// </summary>
        public bool IsKerning
        {
            get => BitFlag.Get(_value, 30);
            set => _value = BitFlag.Set(_value, 30, value);
        }

        /// <summary>
        /// 다른 CharShapeProperty 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(CharShapeProperty from)
        {
            _value = from._value;
        }

        /// <summary>
        /// 취소선 및 밑줄 모드(StrikeUnderLineMode)를 가져오거나 설정합니다.
        /// 취소선과 밑줄의 조합 상태를 나타냅니다.
        /// </summary>
        public StrikeUnderLineMode StrikeUnderLineMode
        {
            get
            {
                if (!IsStrikeLine && UnderLineSort == UnderLineSort.None)
                    return StrikeUnderLineMode.None;
                if (!IsStrikeLine && UnderLineSort == UnderLineSort.Bottom)
                    return StrikeUnderLineMode.OnlyUnderLine;
                if (IsStrikeLine && UnderLineSort == UnderLineSort.Middle)
                    return StrikeUnderLineMode.OnlyStrike;
                if (IsStrikeLine && UnderLineSort == UnderLineSort.Bottom)
                    return StrikeUnderLineMode.StrikeAndUnderLine;
                return StrikeUnderLineMode.None;
            }
            set
            {
                switch (value)
                {
                    case StrikeUnderLineMode.None:
                        IsStrikeLine = false;
                        UnderLineSort = UnderLineSort.None;
                        break;
                    case StrikeUnderLineMode.OnlyStrike:
                        IsStrikeLine = true;
                        UnderLineSort = UnderLineSort.Middle;
                        break;
                    case StrikeUnderLineMode.OnlyUnderLine:
                        IsStrikeLine = false;
                        UnderLineSort = UnderLineSort.Bottom;
                        break;
                    case StrikeUnderLineMode.StrikeAndUnderLine:
                        IsStrikeLine = true;
                        UnderLineSort = UnderLineSort.Bottom;
                        break;
                }
            }
        }
    }
}

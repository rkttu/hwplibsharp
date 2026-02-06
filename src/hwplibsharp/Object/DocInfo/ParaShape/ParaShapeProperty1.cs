// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/ParaShapeProperty1.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 문단 모양의 속성1 객체
    /// </summary>
    public class ParaShapeProperty1
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaShapeProperty1()
        {
        }

        /// <summary>
        /// 줄 간격의 종류 (0~1 bit, 한글 2007 이하 버전에서 사용)
        /// </summary>
        public LineSpaceSort LineSpaceSort
        {
            get => LineSpaceSortExtensions.FromValue((byte)BitFlag.Get(Value, 0, 1));
            set => Value = (uint)BitFlag.Set(Value, 0, 1, value.GetValue());
        }

        /// <summary>
        /// 정렬 방식 (2~4 bit)
        /// </summary>
        public Alignment Alignment
        {
            get => AlignmentExtensions.FromValue((byte)BitFlag.Get(Value, 2, 4));
            set => Value = (uint)BitFlag.Set(Value, 2, 4, value.GetValue());
        }

        /// <summary>
        /// 줄 나눔 기준 영어 단위 (5~6 bit)
        /// </summary>
        public LineDivideForEnglish LineDivideForEnglish
        {
            get => LineDivideForEnglishExtensions.FromValue((byte)BitFlag.Get(Value, 5, 6));
            set => Value = (uint)BitFlag.Set(Value, 5, 6, value.GetValue());
        }

        /// <summary>
        /// 줄 나눔 기준 한글 단위 (7 bit)
        /// </summary>
        public LineDivideForHangul LineDivideForHangul
        {
            get => BitFlag.Get(Value, 7) ? LineDivideForHangul.ByLetter : LineDivideForHangul.ByWord;
            set => Value = (uint)BitFlag.Set(Value, 7, value == LineDivideForHangul.ByLetter);
        }

        /// <summary>
        /// 편집 용지의 줄 격자 사용 여부 (8 bit)
        /// </summary>
        public bool IsUseGrid
        {
            get => BitFlag.Get(Value, 8);
            set => Value = (uint)BitFlag.Set(Value, 8, value);
        }

        /// <summary>
        /// 공백 최소값 (0%～75%) (9~15 bit)
        /// </summary>
        public byte MinimumSpace
        {
            get => (byte)BitFlag.Get(Value, 9, 15);
            set => Value = (uint)BitFlag.Set(Value, 9, 15, value);
        }

        /// <summary>
        /// 외톨이줄 보호 여부 (16 bit)
        /// </summary>
        public bool IsProtectLoner
        {
            get => BitFlag.Get(Value, 16);
            set => Value = (uint)BitFlag.Set(Value, 16, value);
        }

        /// <summary>
        /// 다음 문단과 함께 여부 (17 bit)
        /// </summary>
        public bool IsTogetherNextPara
        {
            get => BitFlag.Get(Value, 17);
            set => Value = (uint)BitFlag.Set(Value, 17, value);
        }

        /// <summary>
        /// 문단 보호 여부 (18 bit)
        /// </summary>
        public bool IsProtectPara
        {
            get => BitFlag.Get(Value, 18);
            set => Value = (uint)BitFlag.Set(Value, 18, value);
        }

        /// <summary>
        /// 문단 앞에서 항상 쪽 나눔 여부 (19 bit)
        /// </summary>
        public bool IsSplitPageBeforePara
        {
            get => BitFlag.Get(Value, 19);
            set => Value = (uint)BitFlag.Set(Value, 19, value);
        }

        /// <summary>
        /// 세로 정렬 (20~21 bit)
        /// </summary>
        public VerticalAlignment VerticalAlignment
        {
            get => VerticalAlignmentExtensions.FromValue((byte)BitFlag.Get(Value, 20, 21));
            set => Value = (uint)BitFlag.Set(Value, 20, 21, value.GetValue());
        }

        /// <summary>
        /// 글꼴에 어울리는 줄 높이 여부 (22 bit)
        /// </summary>
        public bool IsLineHeightForFont
        {
            get => BitFlag.Get(Value, 22);
            set => Value = (uint)BitFlag.Set(Value, 22, value);
        }

        /// <summary>
        /// 문단 머리의 모양 (23~24 bit)
        /// </summary>
        public ParaHeadShape ParaHeadShape
        {
            get => ParaHeadShapeExtensions.FromValue((byte)BitFlag.Get(Value, 23, 24));
            set => Value = (uint)BitFlag.Set(Value, 23, 24, value.GetValue());
        }

        /// <summary>
        /// 문단 수준 (1수준～7수준) (25~27 bit)
        /// </summary>
        public byte ParaLevel
        {
            get => (byte)BitFlag.Get(Value, 25, 27);
            set => Value = (uint)BitFlag.Set(Value, 25, 27, value);
        }

        /// <summary>
        /// 문단 테두리 연결 여부 (28 bit)
        /// </summary>
        public bool IsLinkBorder
        {
            get => BitFlag.Get(Value, 28);
            set => Value = (uint)BitFlag.Set(Value, 28, value);
        }

        /// <summary>
        /// 문단 여백 무시 여부 (29 bit)
        /// </summary>
        public bool IsIgnoreParaMargin
        {
            get => BitFlag.Get(Value, 29);
            set => Value = (uint)BitFlag.Set(Value, 29, value);
        }

        /// <summary>
        /// 문단 꼬리 모양 (30 bit)
        /// </summary>
        public bool IsParaTailShape
        {
            get => BitFlag.Get(Value, 30);
            set => Value = (uint)BitFlag.Set(Value, 30, value);
        }

        /// <summary>
        /// 다른 ParaShapeProperty1 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParaShapeProperty1 from)
        {
            Value = from.Value;
        }
    }
}

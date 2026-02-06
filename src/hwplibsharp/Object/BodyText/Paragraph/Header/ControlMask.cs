// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/header/ControlMask.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Paragraph.Header
{
    /// <summary>
    /// 문단에 포함된 컨트롤의 종류를 나타내는 객체
    /// </summary>
    public class ControlMask
    {
        /// <summary>
        /// 파일에 저장되는 값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlMask()
        {
        }

        /// <summary>
        /// 문단이 구역/단 정의 컨트롤을 가졌는지 여부 (2 bit)
        /// </summary>
        public bool HasSectColDef
        {
            get => BitFlag.Get(Value, 2);
            set => Value = (uint)BitFlag.Set(Value, 2, value);
        }

        /// <summary>
        /// 필드 시작 컨트롤을 가졌는지 여부 (3 bit)
        /// </summary>
        public bool HasFieldStart
        {
            get => BitFlag.Get(Value, 3);
            set => Value = (uint)BitFlag.Set(Value, 3, value);
        }

        /// <summary>
        /// 필드 끝 컨트롤을 가졌는지 여부 (4 bit)
        /// </summary>
        public bool HasFieldEnd
        {
            get => BitFlag.Get(Value, 4);
            set => Value = (uint)BitFlag.Set(Value, 4, value);
        }

        /// <summary>
        /// Title Mark를 가졌는지 여부 (8 bit)
        /// </summary>
        public bool HasTitleMark
        {
            get => BitFlag.Get(Value, 8);
            set => Value = (uint)BitFlag.Set(Value, 8, value);
        }

        /// <summary>
        /// 탭을 가졌는지 여부 (9 bit)
        /// </summary>
        public bool HasTab
        {
            get => BitFlag.Get(Value, 9);
            set => Value = (uint)BitFlag.Set(Value, 9, value);
        }

        /// <summary>
        /// 강제 줄 나눔을 가졌는지 여부 (10 bit)
        /// </summary>
        public bool HasLineBreak
        {
            get => BitFlag.Get(Value, 10);
            set => Value = (uint)BitFlag.Set(Value, 10, value);
        }

        /// <summary>
        /// 그리기 객체 또는 표 객체를 가졌는지 여부 (11 bit)
        /// </summary>
        public bool HasGsoTable
        {
            get => BitFlag.Get(Value, 11);
            set => Value = (uint)BitFlag.Set(Value, 11, value);
        }

        /// <summary>
        /// 그림 객체를 가졌는지 여부 (12 bit)
        /// </summary>
        public bool HasPicture
        {
            get => BitFlag.Get(Value, 12);
            set => Value = (uint)BitFlag.Set(Value, 12, value);
        }

        /// <summary>
        /// 문단 나누기를 가졌는지 여부 (13 bit)
        /// </summary>
        public bool HasParaBreak
        {
            get => BitFlag.Get(Value, 13);
            set => Value = (uint)BitFlag.Set(Value, 13, value);
        }

        /// <summary>
        /// 숨은 설명을 가졌는지 여부 (15 bit)
        /// </summary>
        public bool HasHiddenComment
        {
            get => BitFlag.Get(Value, 15);
            set => Value = (uint)BitFlag.Set(Value, 15, value);
        }

        /// <summary>
        /// 머리말 또는 꼬리말을 가졌는지 여부 (16 bit)
        /// </summary>
        public bool HasHeaderFooter
        {
            get => BitFlag.Get(Value, 16);
            set => Value = (uint)BitFlag.Set(Value, 16, value);
        }

        /// <summary>
        /// 각주 또는 미주를 가졌는지 여부 (17 bit)
        /// </summary>
        public bool HasFootnoteEndnote
        {
            get => BitFlag.Get(Value, 17);
            set => Value = (uint)BitFlag.Set(Value, 17, value);
        }

        /// <summary>
        /// 자동 번호를 가졌는지 여부 (18 bit)
        /// </summary>
        public bool HasAutoNumber
        {
            get => BitFlag.Get(Value, 18);
            set => Value = (uint)BitFlag.Set(Value, 18, value);
        }

        /// <summary>
        /// 페이지 컨트롤(감추기, 새 번호로 시작 등)을 가졌는지 여부 (21 bit)
        /// </summary>
        public bool HasPageControl
        {
            get => BitFlag.Get(Value, 21);
            set => Value = (uint)BitFlag.Set(Value, 21, value);
        }

        /// <summary>
        /// 책갈피/찾아보기 표시를 가졌는지 여부 (22 bit)
        /// </summary>
        public bool HasBookmark
        {
            get => BitFlag.Get(Value, 22);
            set => Value = (uint)BitFlag.Set(Value, 22, value);
        }

        /// <summary>
        /// 덧말/글자 겹침을 가졌는지 여부 (23 bit)
        /// </summary>
        public bool HasAdditionalTextOverlappingLetter
        {
            get => BitFlag.Get(Value, 23);
            set => Value = (uint)BitFlag.Set(Value, 23, value);
        }

        /// <summary>
        /// 하이픈을 가졌는지 여부 (24 bit)
        /// </summary>
        public bool HasHyphen
        {
            get => BitFlag.Get(Value, 24);
            set => Value = (uint)BitFlag.Set(Value, 24, value);
        }

        /// <summary>
        /// 묶음 빈칸을 가졌는지 여부 (30 bit)
        /// </summary>
        public bool HasBundleBlank
        {
            get => BitFlag.Get(Value, 30);
            set => Value = (uint)BitFlag.Set(Value, 30, value);
        }

        /// <summary>
        /// 고정 폭 빈칸을 가졌는지 여부 (31 bit)
        /// </summary>
        public bool HasFixWidthBlank
        {
            get => BitFlag.Get(Value, 31);
            set => Value = (uint)BitFlag.Set(Value, 31, value);
        }

        /// <summary>
        /// 다른 ControlMask 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ControlMask from)
        {
            Value = from.Value;
        }
    }
}

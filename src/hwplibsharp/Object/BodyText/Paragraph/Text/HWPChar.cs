// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/text/HWPChar.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Paragraph.Text
{
    /// <summary>
    /// ParaText에 저장되는 글자를 나타내는 추상 객체
    /// </summary>
    public abstract class HWPChar
    {
        /// <summary>
        /// 문자 코드
        /// </summary>
        protected int code;

        /// <summary>
        /// 문자 코드를 반환하거나 설정한다.
        /// </summary>
        public int Code
        {
            get => code;
            set => code = value;
        }

        /// <summary>
        /// 글자의 종류를 반환한다.
        /// </summary>
        public abstract HWPCharType Type { get; }

        /// <summary>
        /// 글자 크기를 반환한다.
        /// </summary>
        public abstract int CharSize { get; }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public abstract HWPChar Clone();

        /// <summary>
        /// code에 해당되는 글자의 종류를 반환한다.
        /// </summary>
        /// <param name="code">utf16le 문자열을 구성하는 unsigned 2 byte 한 글자</param>
        /// <returns>code에 해당되는 글자의 종류</returns>
        public static HWPCharType GetCharType(int code)
        {
            if (code > 31)
            {
                return HWPCharType.Normal;
            }

            switch (code)
            {
                // 예약, 구역 정의/단 정의, 필드 시작, 그리기 개체/표/수식/양식 개체,
                // 예약(12, 14), 숨은 설명, 머리말/꼬리말, 각주/미주, 자동번호,
                // 페이지 컨트롤, 책갈피/찾아보기 표식, 덧말/글자 겹침
                case 1:
                case 2:
                case 3:
                case 11:
                case 12:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 21:
                case 22:
                case 23:
                    return HWPCharType.ControlExtend;
                // 필드 끝, 예약(5,6,7), title mark, 탭, 예약(19,20)
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 19:
                case 20:
                    return HWPCharType.ControlInline;
                // unusable, 한 줄 끝, 문단 끝, 하이픈, 예약(25-29), 묶음 빈칸, 고정폭 빈칸
                case 0:
                case 10:
                case 13:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                    return HWPCharType.ControlChar;
                default:
                    return HWPCharType.Normal;
            }
        }

        /// <summary>
        /// 공백 문자인지 여부를 반환한다.
        /// </summary>
        public bool IsSpace => code == 32;

        /// <summary>
        /// 한글인지 여부를 반환한다.
        /// </summary>
        public bool IsHangul => (0xAC00 <= code && code <= 0xD7AF) ||
                                (0x3131 <= code && code <= 0x318E);

        /// <summary>
        /// 줄 바꿈인지 여부를 반환한다.
        /// </summary>
        public bool IsLineBreak => code == 10;

        /// <summary>
        /// 문단 바꿈인지 여부를 반환한다.
        /// </summary>
        public bool IsParaBreak => code == 13;
    }
}

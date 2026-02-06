// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/NumberShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 번호 모양
    /// </summary>
    public enum NumberShape : short
    {
        /// <summary>
        /// 1, 2, 3
        /// </summary>
        Number = 0,

        /// <summary>
        /// 동그라미 쳐진 1, 2, 3
        /// </summary>
        CircledNumber = 1,

        /// <summary>
        /// I, II, III
        /// </summary>
        UppercaseRomanNumber = 2,

        /// <summary>
        /// i, ii, iii
        /// </summary>
        LowercaseRomanNumber = 3,

        /// <summary>
        /// A, B, C
        /// </summary>
        UppercaseAlphabet = 4,

        /// <summary>
        /// a, b, c
        /// </summary>
        LowercaseAlphabet = 5,

        /// <summary>
        /// 동그라미 쳐진 A, B, C
        /// </summary>
        CircledUppercaseAlphabet = 6,

        /// <summary>
        /// 동그라미 쳐진 a, b, c
        /// </summary>
        CircledLowercaseAlphabet = 7,

        /// <summary>
        /// 가, 나, 다
        /// </summary>
        Hangul = 8,

        /// <summary>
        /// 동그라미 쳐진 가, 나, 다
        /// </summary>
        CircledHangul = 9,

        /// <summary>
        /// ㄱ, ㄴ, ㄷ
        /// </summary>
        HangulJamo = 10,

        /// <summary>
        /// 동그라미 쳐진 ㄱ, ㄴ, ㄷ
        /// </summary>
        CircledHangulJamo = 11,

        /// <summary>
        /// 일, 이, 삼
        /// </summary>
        HangulNumber = 12,

        /// <summary>
        /// 一, 二, 三
        /// </summary>
        HanjaNumber = 13,

        /// <summary>
        /// 동그라미 쳐진 一, 二, 三
        /// </summary>
        CircledHanjaNumber = 14,

        /// <summary>
        /// 갑, 을, 병, 정, 무, 기, 경, 신, 임, 계
        /// </summary>
        HangulSibgan = 15,

        /// <summary>
        /// 甲, 乙, 丙, 丁, 戊, 己, 庚, 辛, 壬, 癸
        /// </summary>
        HanjaSibgan = 16,

        /// <summary>
        /// 4가지 문자가 차례로 반복(각주/미주 전용)
        /// </summary>
        Symbol = 0x80,

        /// <summary>
        /// 사용자 지정 문자 반복
        /// </summary>
        UserChar = 0x81
    }

    /// <summary>
    /// NumberShape 확장 메서드
    /// </summary>
    public static class NumberShapeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="shape">NumberShape 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static short GetValue(this NumberShape shape)
        {
            return (short)shape;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static NumberShape FromValue(short value)
        {
            return value switch
            {
                0 => NumberShape.Number,
                1 => NumberShape.CircledNumber,
                2 => NumberShape.UppercaseRomanNumber,
                3 => NumberShape.LowercaseRomanNumber,
                4 => NumberShape.UppercaseAlphabet,
                5 => NumberShape.LowercaseAlphabet,
                6 => NumberShape.CircledUppercaseAlphabet,
                7 => NumberShape.CircledLowercaseAlphabet,
                8 => NumberShape.Hangul,
                9 => NumberShape.CircledHangul,
                10 => NumberShape.HangulJamo,
                11 => NumberShape.CircledHangulJamo,
                12 => NumberShape.HangulNumber,
                13 => NumberShape.HanjaNumber,
                14 => NumberShape.CircledHanjaNumber,
                15 => NumberShape.HangulSibgan,
                16 => NumberShape.HanjaSibgan,
                0x80 => NumberShape.Symbol,
                0x81 => NumberShape.UserChar,
                _ => NumberShape.Number
            };
        }
    }
}

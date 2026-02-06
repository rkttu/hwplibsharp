// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/numbering/ParagraphNumberFormat.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.Numbering
{
    /// <summary>
    /// 문단 번호 형식
    /// </summary>
    public enum ParagraphNumberFormat : byte
    {
        /// <summary>
        /// 1, 2, 3 (무한)
        /// </summary>
        Number = 0,

        /// <summary>
        /// 동그라미 쳐진 1, 2, 3 (1~20 반복)
        /// </summary>
        CircledNumber = 1,

        /// <summary>
        /// I, II, III (무한)
        /// </summary>
        UppercaseRomanNumber = 2,

        /// <summary>
        /// i, ii, iii (무한)
        /// </summary>
        LowercaseRomanNumber = 3,

        /// <summary>
        /// A, B, C (A~Z 반복)
        /// </summary>
        UppercaseAlphabet = 4,

        /// <summary>
        /// a, b, c (a~z 반복)
        /// </summary>
        LowercaseAlphabet = 5,

        /// <summary>
        /// 동그라미 쳐진 A, B, C (A-Z 반복)
        /// </summary>
        CircledUppercaseAlphabet = 6,

        /// <summary>
        /// 동그라미 쳐진 a, b, c (a-z 반복)
        /// </summary>
        CircledLowercaseAlphabet = 7,

        /// <summary>
        /// 가, 나, 다 (가~하,거~허,고~호,구~후,그~흐,기~히 반복)
        /// </summary>
        Hangul = 8,

        /// <summary>
        /// 동그라미 쳐진 가, 나, 다 (가~하 반복)
        /// </summary>
        CircledHangul = 9,

        /// <summary>
        /// ㄱ, ㄴ, ㄷ (ㄱ~ㅎ 반복)
        /// </summary>
        HangulJamo = 10,

        /// <summary>
        /// 동그라미 쳐진 ㄱ, ㄴ, ㄷ (ㄱ~ㅎ 반복)
        /// </summary>
        CircledHangulJamo = 11,

        /// <summary>
        /// 일, 이, 삼 (일~구십구 반복)
        /// </summary>
        HangulNumber = 12,

        /// <summary>
        /// 一, 二, 三 (一~九十九 반복)
        /// </summary>
        HanjaNumber = 13,

        /// <summary>
        /// 동그라미 쳐진 一, 二, 三(一~十 반복)
        /// </summary>
        CircledHanjaNumber = 14,

        /// <summary>
        /// 갑,을,병,정,무,기,경,신,임,계
        /// </summary>
        SibGanHangul = 15,

        /// <summary>
        /// 甲,乙,丙,丁,戊,己,庚,辛,壬,癸
        /// </summary>
        SibGanHanja = 16
    }

    /// <summary>
    /// ParagraphNumberFormat 확장 메서드
    /// </summary>
    public static class ParagraphNumberFormatExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ParagraphNumberFormat format)
        {
            return (byte)format;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ParagraphNumberFormat FromValue(byte value)
        {
            return value switch
            {
                0 => ParagraphNumberFormat.Number,
                1 => ParagraphNumberFormat.CircledNumber,
                2 => ParagraphNumberFormat.UppercaseRomanNumber,
                3 => ParagraphNumberFormat.LowercaseRomanNumber,
                4 => ParagraphNumberFormat.UppercaseAlphabet,
                5 => ParagraphNumberFormat.LowercaseAlphabet,
                6 => ParagraphNumberFormat.CircledUppercaseAlphabet,
                7 => ParagraphNumberFormat.CircledLowercaseAlphabet,
                8 => ParagraphNumberFormat.Hangul,
                9 => ParagraphNumberFormat.CircledHangul,
                10 => ParagraphNumberFormat.HangulJamo,
                11 => ParagraphNumberFormat.CircledHangulJamo,
                12 => ParagraphNumberFormat.HangulNumber,
                13 => ParagraphNumberFormat.HanjaNumber,
                14 => ParagraphNumberFormat.CircledHanjaNumber,
                15 => ParagraphNumberFormat.SibGanHangul,
                16 => ParagraphNumberFormat.SibGanHanja,
                _ => ParagraphNumberFormat.Number
            };
        }
    }
}

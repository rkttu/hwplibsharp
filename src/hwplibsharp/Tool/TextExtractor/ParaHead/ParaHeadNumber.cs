// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/parahead/ParaHeadNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.Numbering;

namespace HwpLib.Tool.TextExtractor.ParaHead
{
    /// <summary>
    /// 문단 머리 번호 변환 클래스
    /// </summary>
    public static class ParaHeadNumber
    {
        private static readonly string[] CircledNumbers;
        private static readonly string[] CircledUppercaseAlphabets;
        private static readonly string[] CircledLowercaseAlphabets;
        private static readonly string[] Hangul;
        private static readonly string[] CircledHangul;
        private static readonly string[] HangulJamo;
        private static readonly string[] CircledHangulJamo;
        private static readonly string[] HangulNumber;
        private static readonly string[] HanjaNumber;
        private static readonly string[] CircledHanjaNumber;
        private static readonly string[] SibGanHangul;
        private static readonly string[] SibGanHanja;

        static ParaHeadNumber()
        {
            CircledNumbers = SetCharsArray("①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳");
            CircledUppercaseAlphabets = SetCharsArray("ⒶⒷⒸⒹⒺⒻⒼⒽⒾⒿⓀⓁⓂⓃⓄⓅⓆⓇⓈⓉⓊⓋⓌⓍⓎⓏ");
            CircledLowercaseAlphabets = SetCharsArray("ⓐⓑⓒⓓⓔⓕⓖⓗⓘⓙⓚⓛⓜⓝⓞⓟⓠⓡⓢⓣⓤⓥⓦⓧⓨⓩ");
            Hangul = SetCharsArray("가나다라마바사아자차카타파하거너더러머버서어저처커터퍼허고노도로모보소오조초코토포호구누두루무부수우주추쿠투푸후그느드르므브스으즈츠크트프흐기니디리미비시이지치키피피히");
            CircledHangul = SetCharsArray("㉮㉯㉰㉱㉲㉳㉴㉵㉶㉷㉸㉹㉺㉻");
            HangulJamo = SetCharsArray("ㄱㄴㄷㄹㅁㅂㅅㅇㅈㅊㅋㅌㅍㅎ");
            CircledHangulJamo = SetCharsArray("㉠㉡㉢㉣㉤㉥㉦㉧㉨㉩㉪㉫㉬㉭");
            HangulNumber = SetCharsArray("일이삼사오육칠팔구십");
            HanjaNumber = SetCharsArray("一二三四五六七八九十");
            CircledHanjaNumber = SetCharsArray("㊀㊁㊂㊃㊄㊅㊆㊇㊈㊉");
            SibGanHangul = SetCharsArray("갑을병정무기경신임계");
            SibGanHanja = SetCharsArray("甲乙丙丁戊己庚辛壬癸");
        }

        private static string[] SetCharsArray(string chars)
        {
            var result = new string[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                result[i] = chars.Substring(i, 1);
            }
            return result;
        }

        /// <summary>
        /// 지정된 값과 문단 번호 형식에 따라 해당하는 문자열을 반환합니다.
        /// </summary>
        /// <param name="value">문단 번호 값(1부터 시작)</param>
        /// <param name="format">문단 번호 형식</param>
        /// <returns>형식에 맞는 번호 문자열</returns>
        public static string ToString(int value, ParagraphNumberFormat format)
        {
            if (value <= 0)
            {
                return "";
            }

            return format switch
            {
                ParagraphNumberFormat.Number => value.ToString(),
                ParagraphNumberFormat.CircledNumber => CircledNumberString(value),
                ParagraphNumberFormat.UppercaseRomanNumber => RomanNumber(value, true),
                ParagraphNumberFormat.LowercaseRomanNumber => RomanNumber(value, false),
                ParagraphNumberFormat.UppercaseAlphabet => UppercaseAlphabetString(value),
                ParagraphNumberFormat.LowercaseAlphabet => LowercaseAlphabetString(value),
                ParagraphNumberFormat.CircledUppercaseAlphabet => CircledUppercaseAlphabetString(value),
                ParagraphNumberFormat.CircledLowercaseAlphabet => CircledLowercaseAlphabetString(value),
                ParagraphNumberFormat.Hangul => HangulString(value),
                ParagraphNumberFormat.CircledHangul => CircledHangulString(value),
                ParagraphNumberFormat.HangulJamo => HangulJamoString(value),
                ParagraphNumberFormat.CircledHangulJamo => CircledHangulJamoString(value),
                ParagraphNumberFormat.HangulNumber => HangulNumberString(value),
                ParagraphNumberFormat.HanjaNumber => HanjaNumberString(value),
                ParagraphNumberFormat.CircledHanjaNumber => CircledHanjaNumberString(value),
                ParagraphNumberFormat.SibGanHangul => SibGanHangulString(value),
                ParagraphNumberFormat.SibGanHanja => SibGanHanjaString(value),
                _ => value.ToString()
            };
        }

        private static string RomanNumber(int value, bool uppercase)
        {
            string[] roman;
            if (uppercase)
            {
                roman = new[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            }
            else
            {
                roman = new[] { "m", "cm", "d", "cd", "c", "xc", "l", "xl", "x", "ix", "v", "iv", "i" };
            }

            int[] decimals = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string romanNumber = "";
            for (int i = 0; i < 13; i++)
            {
                while (value >= decimals[i])
                {
                    romanNumber += roman[i];
                    value -= decimals[i];
                }
            }
            return romanNumber;
        }

        private static string CircledNumberString(int value)
        {
            return CircledNumbers[(value - 1) % 20];
        }

        private static string UppercaseAlphabetString(int value)
        {
            return ((char)('A' + (value - 1) % 26)).ToString();
        }

        private static string LowercaseAlphabetString(int value)
        {
            return ((char)('a' + (value - 1) % 26)).ToString();
        }

        private static string CircledUppercaseAlphabetString(int value)
        {
            return CircledUppercaseAlphabets[(value - 1) % 26];
        }

        private static string CircledLowercaseAlphabetString(int value)
        {
            return CircledLowercaseAlphabets[(value - 1) % 26];
        }

        private static string HangulString(int value)
        {
            if (value > 0)
            {
                return Hangul[(value - 1) % 84];
            }
            return "";
        }

        private static string CircledHangulString(int value)
        {
            return CircledHangul[(value - 1) % 14];
        }

        private static string HangulJamoString(int value)
        {
            return HangulJamo[(value - 1) % 14];
        }

        private static string CircledHangulJamoString(int value)
        {
            return CircledHangulJamo[(value - 1) % 14];
        }

        private static string HangulNumberString(int value)
        {
            int value2 = ((value - 1) % 99 + 1);
            if (value2 <= 10)
            {
                return HangulNumber[value2 - 1];
            }
            else if (value2 <= 19)
            {
                return HangulNumber[9] + HangulNumber[(value2 - 1) % 10];
            }
            else
            {
                if (value2 % 10 == 0)
                {
                    return HangulNumber[value2 / 10 - 1] + HangulNumber[9];
                }
                else
                {
                    return HangulNumber[value2 / 10 - 1] + HangulNumber[9] + HangulNumber[(value2 - 1) % 10];
                }
            }
        }

        private static string HanjaNumberString(int value)
        {
            int value2 = ((value - 1) % 99 + 1);
            if (value2 <= 10)
            {
                return HanjaNumber[value2 - 1];
            }
            else if (value2 <= 19)
            {
                return HanjaNumber[9] + HanjaNumber[(value2 - 1) % 10];
            }
            else
            {
                if (value2 % 10 == 0)
                {
                    return HanjaNumber[value2 / 10 - 1] + HanjaNumber[9];
                }
                else
                {
                    return HanjaNumber[value2 / 10 - 1] + HanjaNumber[9] + HanjaNumber[(value2 - 1) % 10];
                }
            }
        }

        private static string CircledHanjaNumberString(int value)
        {
            return CircledHanjaNumber[(value - 1) % 10];
        }

        private static string SibGanHangulString(int value)
        {
            return SibGanHangul[(value - 1) % 10];
        }

        private static string SibGanHanjaString(int value)
        {
            return SibGanHanja[(value - 1) % 10];
        }
    }
}

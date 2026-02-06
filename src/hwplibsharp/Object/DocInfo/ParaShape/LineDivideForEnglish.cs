// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/LineDivideForEnglish.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 줄 나눔 기준 영어 단위
    /// </summary>
    public enum LineDivideForEnglish : byte
    {
        /// <summary>
        /// 단어
        /// </summary>
        ByWord = 0,

        /// <summary>
        /// 하이픈
        /// </summary>
        ByHyphen = 1,

        /// <summary>
        /// 글자
        /// </summary>
        ByLetter = 2
    }

    /// <summary>
    /// LineDivideForEnglish 확장 메서드
    /// </summary>
    public static class LineDivideForEnglishExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this LineDivideForEnglish value)
        {
            return (byte)value;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static LineDivideForEnglish FromValue(byte value)
        {
            return value switch
            {
                0 => LineDivideForEnglish.ByWord,
                1 => LineDivideForEnglish.ByHyphen,
                2 => LineDivideForEnglish.ByLetter,
                _ => LineDivideForEnglish.ByWord
            };
        }
    }
}

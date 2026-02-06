// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/LineDivideForHangul.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 줄 나눔 기준 한글 단위
    /// </summary>
    public enum LineDivideForHangul : byte
    {
        /// <summary>
        /// 어절
        /// </summary>
        ByWord = 0,

        /// <summary>
        /// 글자
        /// </summary>
        ByLetter = 1
    }

    /// <summary>
    /// LineDivideForHangul 확장 메서드
    /// </summary>
    public static class LineDivideForHangulExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this LineDivideForHangul value)
        {
            return (byte)value;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static LineDivideForHangul FromValue(byte value)
        {
            return value switch
            {
                0 => LineDivideForHangul.ByWord,
                1 => LineDivideForHangul.ByLetter,
                _ => LineDivideForHangul.ByWord
            };
        }
    }
}

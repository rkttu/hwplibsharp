// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/pageoddeven/OddEvenPage.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.PageOddEvenAdjust
{
    /// <summary>
    /// 홀짝수 페이지 구분
    /// </summary>
    public enum OddEvenPage : byte
    {
        /// <summary>
        /// 양쪽
        /// </summary>
        Both = 0,

        /// <summary>
        /// 짝수
        /// </summary>
        Even = 1,

        /// <summary>
        /// 홀수
        /// </summary>
        Odd = 2,
    }

    /// <summary>
    /// OddEvenPage enum 확장 메서드
    /// </summary>
    public static class OddEvenPageExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="oddEvenPage">enum 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this OddEvenPage oddEvenPage)
        {
            return (byte)oddEvenPage;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static OddEvenPage FromValue(byte value)
        {
            return value switch
            {
                0 => OddEvenPage.Both,
                1 => OddEvenPage.Even,
                2 => OddEvenPage.Odd,
                _ => OddEvenPage.Both,
            };
        }
    }
}

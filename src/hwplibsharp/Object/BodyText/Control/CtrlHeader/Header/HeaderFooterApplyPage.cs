// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/header/HeaderFooterApplyPage.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Header
{
    /// <summary>
    /// 머리글/꼬리글 적용 페이지 종류
    /// </summary>
    public enum HeaderFooterApplyPage : byte
    {
        /// <summary>
        /// 양 쪽
        /// </summary>
        BothPage = 0,

        /// <summary>
        /// 짝수 쪽만
        /// </summary>
        EvenPage = 1,

        /// <summary>
        /// 홀수 쪽만
        /// </summary>
        OddPage = 2
    }

    /// <summary>
    /// HeaderFooterApplyPage 확장 메서드
    /// </summary>
    public static class HeaderFooterApplyPageExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this HeaderFooterApplyPage applyPage) => (byte)applyPage;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static HeaderFooterApplyPage FromValue(byte value) => value switch
        {
            0 => HeaderFooterApplyPage.BothPage,
            1 => HeaderFooterApplyPage.EvenPage,
            2 => HeaderFooterApplyPage.OddPage,
            _ => HeaderFooterApplyPage.BothPage
        };
    }
}

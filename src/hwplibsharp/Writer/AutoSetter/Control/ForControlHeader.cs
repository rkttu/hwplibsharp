// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControlHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 머리말 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlHeader
    {
        /// <summary>
        /// 머리말 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="h">머리말 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlHeader h, InstanceID iid)
        {
            ListHeader(h);
            ForParagraphList.AutoSet(h.ParagraphList, iid);
        }

        /// <summary>
        /// 리스트 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="h">머리말 컨트롤</param>
        private static void ListHeader(ControlHeader h)
        {
            h.ListHeader.ParaCount = h.ParagraphList.ParagraphCount;
        }
    }
}

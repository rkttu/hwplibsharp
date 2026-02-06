// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControlEndNote.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 미주 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlEndNote
    {
        /// <summary>
        /// 미주 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="en">미주 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlEndnote en, InstanceID iid)
        {
            ListHeader(en);
            ForParagraphList.AutoSet(en.ParagraphList, iid);
        }

        /// <summary>
        /// 리스트 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="en">미주 컨트롤</param>
        private static void ListHeader(ControlEndnote en)
        {
            en.ListHeader.ParaCount = en.ParagraphList.ParagraphCount;
        }
    }
}

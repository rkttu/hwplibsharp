// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControlFootnote.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 각주 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlFootnote
    {
        /// <summary>
        /// 각주 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="fn">각주 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlFootnote fn, InstanceID iid)
        {
            CtrlHeader(fn.Header!, iid);
            ListHeader(fn);
            ForParagraphList.AutoSet(fn.ParagraphList, iid);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="h">컨트롤 헤더 레코드</param>
        /// <param name="iid">인스턴스 id</param>
        private static void CtrlHeader(CtrlHeaderFootnote h, InstanceID iid)
        {
            h.InstanceId = (uint)iid.Get();
        }

        /// <summary>
        /// 리스트 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="fn">각주 컨트롤</param>
        private static void ListHeader(ControlFootnote fn)
        {
            fn.ListHeader.ParaCount = fn.ParagraphList.ParagraphCount;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/gso/part/ForCaption.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.Caption;

namespace HwpLib.Writer.AutoSetter.Control.Gso.Part
{
    /// <summary>
    /// 캡션 정보를 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForCaption
    {
        /// <summary>
        /// 캡션 정보를 자동 설정한다.
        /// </summary>
        /// <param name="c">캡션 정보 객체</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(Caption? c, InstanceID iid)
        {
            if (c == null)
            {
                return;
            }
            ListHeader(c);
            ForParagraphList.AutoSet(c.ParagraphList, iid);
        }

        /// <summary>
        /// 리스트 헤더 레코드를 자동설정한다.
        /// </summary>
        /// <param name="c">캡션 정보 객체</param>
        private static void ListHeader(Caption c)
        {
            c.ListHeader.ParaCount = c.ParagraphList.ParagraphCount;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/ForParagraphList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText;

namespace HwpLib.Writer.AutoSetter
{
    /// <summary>
    /// 문단 리스트 객체를 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForParagraphList
    {
        /// <summary>
        /// 문단 리스트를 자동 설정한다.
        /// </summary>
        /// <param name="pli">문단 리스트 객체</param>
        /// <param name="iid">인스턴스 ID</param>
        public static void AutoSet(IParagraphList pli, InstanceID iid)
        {
            int count = pli.ParagraphCount;
            for (int index = 0; index < count; index++)
            {
                var p = pli.GetParagraph(index);
                if (index == count - 1)
                {
                    ForParagraph.AutoSet(p, true, iid);
                }
                else
                {
                    ForParagraph.AutoSet(p, false, iid);
                }
            }
        }
    }
}

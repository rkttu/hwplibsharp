// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControlSectionDefine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.SectionDefine;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 구역 정의 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlSectionDefine
    {
        /// <summary>
        /// 구역 정의 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="sd">구역 정의 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlSectionDefine sd, InstanceID iid)
        {
            BatangPageInfos(sd, iid);
        }

        /// <summary>
        /// 바탕 페이지 정보들을 자동 설정한다.
        /// </summary>
        /// <param name="sd">구역 정의 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void BatangPageInfos(ControlSectionDefine sd, InstanceID iid)
        {
            foreach (var bpi in sd.BatangPageInfoList)
            {
                ListHeader(bpi);
                ForParagraphList.AutoSet(bpi.ParagraphList, iid);
            }
        }

        /// <summary>
        /// 바탕 페이지 정보의 리스트 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="bpi">바탕 페이지 정보 객체</param>
        private static void ListHeader(BatangPageInfo bpi)
        {
            bpi.ListHeader.ParaCount = bpi.ParagraphList.ParagraphCount;
        }
    }
}

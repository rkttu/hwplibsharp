// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/BatangPageInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 바탕 페이지 정보를 나타내는 객체
    /// </summary>
    public class BatangPageInfo
    {
        /// <summary>
        /// 문단 리스트 헤더
        /// </summary>
        private readonly ListHeaderForBatangPage _listHeader;

        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly ParagraphList _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public BatangPageInfo()
        {
            _listHeader = new ListHeaderForBatangPage();
            _paragraphList = new ParagraphList();
        }

        /// <summary>
        /// 문단 리스트 헤더를 반환한다.
        /// </summary>
        public ListHeaderForBatangPage ListHeader => _listHeader;

        /// <summary>
        /// 문단 리스트를 반환한다.
        /// </summary>
        public ParagraphList ParagraphList => _paragraphList;

        /// <summary>
        /// BatangPageInfo를 복제한다.
        /// </summary>
        /// <returns>복제된 BatangPageInfo</returns>
        public BatangPageInfo Clone()
        {
            var cloned = new BatangPageInfo();
            cloned._listHeader.Copy(_listHeader);
            cloned._paragraphList.Copy(_paragraphList);
            return cloned;
        }
    }
}

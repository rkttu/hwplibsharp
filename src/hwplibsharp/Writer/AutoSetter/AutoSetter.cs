// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/AutoSetter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object;

namespace HwpLib.Writer.AutoSetter
{
    /// <summary>
    /// 한글 파일을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class AutoSetter
    {
        /// <summary>
        /// 한글 파일을 자동 설정한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="iid">인스턴스 ID</param>
        public static void AutoSet(HWPFile hwpFile, InstanceID iid)
        {
            DocInfo(hwpFile);
            BodyText(hwpFile.BodyText, iid);
        }

        /// <summary>
        /// DocInfo 스트림을 자동설정한다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        private static void DocInfo(HWPFile hwpFile)
        {
            ForDocInfo.AutoSet(hwpFile.DocInfo, hwpFile.BodyText);
        }

        /// <summary>
        /// BodyText 스토리지를 자동 설정한다.
        /// </summary>
        /// <param name="bodyText">BodyText 스토리지 객체</param>
        /// <param name="iid">인스턴스 ID</param>
        private static void BodyText(Object.BodyText.BodyText bodyText, InstanceID iid)
        {
            foreach (var section in bodyText.SectionList)
            {
                ForParagraphList.AutoSet(section, iid);
            }

            if (bodyText.MemoList != null)
            {
                foreach (var memo in bodyText.MemoList)
                {
                    ForParagraphList.AutoSet(memo.ParagraphList, iid);
                }
            }
        }
    }
}

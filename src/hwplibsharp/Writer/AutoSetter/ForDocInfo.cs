// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/ForDocInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Writer.AutoSetter
{
    /// <summary>
    /// DocInfo 스트림을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForDocInfo
    {
        /// <summary>
        /// DocInfo 스트림을 자동 설정한다.
        /// </summary>
        /// <param name="di">DocInfo 스트림 객체</param>
        /// <param name="bt">BodyText 스토리지 객체</param>
        public static void AutoSet(HwpLib.Object.DocInfo.DocInfo di, HwpLib.Object.BodyText.BodyText bt)
        {
            DocumentProperties(di.DocumentProperties, bt);
            IdMappings(di.IdMappings, di);
        }

        /// <summary>
        /// 문서 속성 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="dp">문서 속성 레코드</param>
        /// <param name="bt">BodyText 스토리지 객체</param>
        private static void DocumentProperties(HwpLib.Object.DocInfo.DocumentPropertiesInfo dp, HwpLib.Object.BodyText.BodyText bt)
        {
            dp.SectionCount = bt.SectionList.Count;
        }

        /// <summary>
        /// 아이디 매핑 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="im">아이디 매핑 레코드</param>
        /// <param name="di">DocInfo 스트림 객체</param>
        private static void IdMappings(HwpLib.Object.DocInfo.IDMappings im, HwpLib.Object.DocInfo.DocInfo di)
        {
            im.BinDataCount = di.BinDataList.Count;
            im.HangulFaceNameCount = di.HangulFaceNameList.Count;
            im.EnglishFaceNameCount = di.EnglishFaceNameList.Count;
            im.HanjaFaceNameCount = di.HanjaFaceNameList.Count;
            im.JapaneseFaceNameCount = di.JapaneseFaceNameList.Count;
            im.EtcFaceNameCount = di.EtcFaceNameList.Count;
            im.SymbolFaceNameCount = di.SymbolFaceNameList.Count;
            im.UserFaceNameCount = di.UserFaceNameList.Count;
            im.BorderFillCount = di.BorderFillList.Count;
            im.CharShapeCount = di.CharShapeList.Count;
            im.TabDefCount = di.TabDefList.Count;
            im.NumberingCount = di.NumberingList.Count;
            im.BulletCount = di.BulletList.Count;
            im.ParaShapeCount = di.ParaShapeList.Count;
            im.StyleCount = di.StyleList.Count;
            im.MemoShapeCount = di.MemoShapeList.Count;
            im.TrackChangeCount = di.TrackChange2List.Count;
            im.TrackChangeAuthorCount = di.TrackChangeAuthorList.Count;
        }
    }
}

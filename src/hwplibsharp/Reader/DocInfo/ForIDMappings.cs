// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForIDMappings.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 아이디 매핑 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForIDMappings
    {
        /// <summary>
        /// 아이디 매핑 레코드를 읽는다.
        /// </summary>
        /// <param name="idm">아이디 매핑 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(IDMappings idm, CompoundStreamReader sr)
        {
            idm.BinDataCount = sr.ReadSInt4();              // 0
            idm.HangulFaceNameCount = sr.ReadSInt4();       // 1
            idm.EnglishFaceNameCount = sr.ReadSInt4();      // 2
            idm.HanjaFaceNameCount = sr.ReadSInt4();        // 3
            idm.JapaneseFaceNameCount = sr.ReadSInt4();     // 4
            idm.EtcFaceNameCount = sr.ReadSInt4();          // 5
            idm.SymbolFaceNameCount = sr.ReadSInt4();       // 6
            idm.UserFaceNameCount = sr.ReadSInt4();         // 7
            idm.BorderFillCount = sr.ReadSInt4();           // 8
            idm.CharShapeCount = sr.ReadSInt4();            // 9
            idm.TabDefCount = sr.ReadSInt4();               // 10
            idm.NumberingCount = sr.ReadSInt4();            // 11
            idm.BulletCount = sr.ReadSInt4();               // 12
            idm.ParaShapeCount = sr.ReadSInt4();            // 13
            idm.StyleCount = sr.ReadSInt4();                // 14

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 2, 1))
            {
                idm.MemoShapeCount = sr.ReadSInt4();        // 15
            }

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 3, 2))
            {
                idm.TrackChangeCount = sr.ReadSInt4();          // 16
                idm.TrackChangeAuthorCount = sr.ReadSInt4();    // 17
            }
        }
    }
}

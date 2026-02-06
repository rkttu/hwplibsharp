// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForLayoutCompatibility.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 레이아웃 호환 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForLayoutCompatibility
    {
        /// <summary>
        /// 호환 문서 레코드를 읽는다.
        /// </summary>
        /// <param name="lc">레이아웃 호환 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(LayoutCompatibility lc, CompoundStreamReader sr)
        {
            lc.LetterLevelFormat = sr.ReadUInt4();
            lc.ParagraphLevelFormat = sr.ReadUInt4();
            lc.SectionLevelFormat = sr.ReadUInt4();
            lc.ObjectLevelFormat = sr.ReadUInt4();
            lc.FieldLevelFormat = sr.ReadUInt4();
        }
    }
}

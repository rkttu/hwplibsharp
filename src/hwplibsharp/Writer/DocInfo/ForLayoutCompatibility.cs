// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForLayoutCompatibility.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 레이아웃 호환 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForLayoutCompatibility
    {
        /// <summary>
        /// 레이아웃 호환 레코드를 쓴다.
        /// </summary>
        /// <param name="lc">레이아웃 호환 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(LayoutCompatibility lc, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteUInt4(lc.LetterLevelFormat);
            sw.WriteUInt4(lc.ParagraphLevelFormat);
            sw.WriteUInt4(lc.SectionLevelFormat);
            sw.WriteUInt4(lc.ObjectLevelFormat);
            sw.WriteUInt4(lc.FieldLevelFormat);
        }

        /// <summary>
        /// 레이아웃 호환 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.LayoutCompatibility, 20);
        }
    }
}

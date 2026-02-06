// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/endnote/ForListHeaderForFootnoteEndnote.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.FootnoteEndnote;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Endnote
{
    /// <summary>
    /// 미주/각주 컨트롤의 리스트 헤더 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForListHeaderForFootnoteEndnote
    {
        /// <summary>
        /// 미주/각주 컨트롤의 리스트 헤더 레코드를 쓴다.
        /// </summary>
        public static void Write(ListHeaderForFootnoteEndnote lh, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt4(lh.ParaCount);
            sw.WriteUInt4(lh.Property.Value);
            sw.WriteZero(8);
        }

        /// <summary>
        /// 리스트 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ListHeader, 16);
        }
    }
}

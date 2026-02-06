// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/secd/ForPageDef.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.SectionDefine;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Secd
{
    /// <summary>
    /// 용지 설정 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForPageDef
    {
        /// <summary>
        /// 용지 설정 레코드를 쓴다.
        /// </summary>
        public static void Write(PageDef pd, CompoundStreamWriter sw)
        {
            if (pd == null)
            {
                return;
            }

            RecordHeader(sw);

            sw.WriteUInt4(pd.PaperWidth);
            sw.WriteUInt4(pd.PaperHeight);
            sw.WriteUInt4(pd.LeftMargin);
            sw.WriteUInt4(pd.RightMargin);
            sw.WriteUInt4(pd.TopMargin);
            sw.WriteUInt4(pd.BottomMargin);
            sw.WriteUInt4(pd.HeaderMargin);
            sw.WriteUInt4(pd.FooterMargin);
            sw.WriteUInt4(pd.GutterMargin);
            sw.WriteUInt4(pd.Property.Value);
        }

        /// <summary>
        /// 용지 설정 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.PageDef, 40);
        }
    }
}

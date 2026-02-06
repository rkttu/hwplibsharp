// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/part/ForCaption.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso.Caption;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText.Control.Gso.Part
{
    /// <summary>
    /// 캡션 정보를 쓰기 위한 객체
    /// </summary>
    public static class ForCaption
    {
        /// <summary>
        /// 캡션 정보를 쓴다.
        /// </summary>
        public static void Write(Caption? c, CompoundStreamWriter sw)
        {
            if (c == null)
            {
                return;
            }

            ListHeader(c.ListHeader, sw);
            ForParagraphList.Write(c.ParagraphList, sw);
        }

        /// <summary>
        /// 캡션 정보의 리스트 헤더 레코드를 쓴다.
        /// </summary>
        private static void ListHeader(ListHeaderForCaption lh, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt4(lh.ParaCount);
            sw.WriteUInt4(lh.Property.Value);
            sw.WriteUInt4(lh.CaptionProperty.Value);
            sw.WriteUInt4(lh.CaptionWidth);
            sw.WriteUInt2(lh.SpaceBetweenCaptionAndFrame);
            sw.WriteUInt4(lh.TextWidth);
            sw.WriteZero(8);
        }

        /// <summary>
        /// 리스트 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ListHeader, 30);
        }
    }
}

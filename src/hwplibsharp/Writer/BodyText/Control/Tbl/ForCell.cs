// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/tbl/ForCell.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Bookmark;
using HwpLib.Object.BodyText.Control.Table;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Bookmark;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText.Control.Tbl
{
    /// <summary>
    /// 표 컨트롤의 셀을 쓰기 위한 객체
    /// </summary>
    public static class ForCell
    {
        /// <summary>
        /// 표 컨트롤의 셀을 쓴다.
        /// </summary>
        public static void Write(Cell c, CompoundStreamWriter sw)
        {
            ListHeader(c.ListHeader, sw);
            ForParagraphList.Write(c.ParagraphList, sw);
        }

        /// <summary>
        /// 셀의 리스트 헤더 레코드를 쓴다.
        /// </summary>
        private static void ListHeader(ListHeaderForCell lh, CompoundStreamWriter sw)
        {
            var psFieldName = ParameterSet.CreateForFieldName(lh.FieldName);
            RecordHeader(psFieldName, sw);

            sw.WriteSInt4(lh.ParaCount);
            sw.WriteUInt4(lh.Property.Value);
            sw.WriteUInt2(lh.ColIndex);
            sw.WriteUInt2(lh.RowIndex);
            sw.WriteUInt2(lh.ColSpan);
            sw.WriteUInt2(lh.RowSpan);
            sw.WriteUInt4(lh.Width);
            sw.WriteUInt4(lh.Height);
            sw.WriteUInt2(lh.LeftMargin);
            sw.WriteUInt2(lh.RightMargin);
            sw.WriteUInt2(lh.TopMargin);
            sw.WriteUInt2(lh.BottomMargin);
            sw.WriteUInt2(lh.BorderFillId);
            sw.WriteUInt4(lh.TextWidth);
            if (psFieldName != null)
            {
                byte flag = 0xff;
                sw.WriteUInt1(flag);

                ForParameterSet.Write(psFieldName, sw);
            }
            else
            {
                byte flag = 0x0;
                sw.WriteUInt1(flag);
            }
            sw.WriteZero(8);
        }

        /// <summary>
        /// 셀의 리스트 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ParameterSet? psFieldName, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ListHeader, GetSize(psFieldName));
        }

        /// <summary>
        /// 셀의 리스트 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ParameterSet? psFieldName)
        {
            int size = 0;
            size += 38;

            if (psFieldName != null)
            {
                size += 1;
                size += ForParameterSet.GetSize(psFieldName);
            }
            else
            {
                size += 1;
            }
            size += 8;
            return size;
        }
    }
}

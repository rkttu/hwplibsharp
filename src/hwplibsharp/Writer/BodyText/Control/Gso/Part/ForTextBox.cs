// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/part/ForTextBox.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Bookmark;
using HwpLib.Object.BodyText.Control.Gso.TextBox;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Bookmark;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText.Control.Gso.Part
{
    /// <summary>
    /// 글상자를 쓰기 위한 객체
    /// </summary>
    public static class ForTextBox
    {
        /// <summary>
        /// 글상자를 쓴다.
        /// </summary>
        public static void Write(TextBox? tb, CompoundStreamWriter sw)
        {
            if (tb == null)
            {
                return;
            }

            ListHeader(tb.ListHeader, sw);
            ForParagraphList.Write(tb.ParagraphList, sw);
        }

        /// <summary>
        /// 글상자의 리스트 헤더 레코드를 쓴다.
        /// </summary>
        private static void ListHeader(ListHeaderForTextBox lh, CompoundStreamWriter sw)
        {
            var psFieldName = ParameterSet.CreateForFieldName(lh.FieldName);

            RecordHeader(psFieldName, sw);

            sw.WriteSInt4(lh.ParaCount);
            sw.WriteUInt4(lh.Property.Value);
            sw.WriteUInt2(lh.LeftMargin);
            sw.WriteUInt2(lh.RightMargin);
            sw.WriteUInt2(lh.TopMargin);
            sw.WriteUInt2(lh.BottomMargin);
            sw.WriteUInt4(lh.TextWidth);
            sw.WriteZero(8);
            if (lh.EditableAtFormMode)
            {
                sw.WriteSInt4(1);
            }
            else
            {
                sw.WriteSInt4(0);
            }

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
        }

        /// <summary>
        /// 글상자의 리스트 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ParameterSet? psFieldName, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ListHeader, GetSize(psFieldName));
        }

        /// <summary>
        /// 글상자의 리스트 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ParameterSet? psFieldName)
        {
            int size = 0;
            size += 32;
            if (psFieldName != null)
            {
                size += 1;
                size += ForParameterSet.GetSize(psFieldName);
            }
            else
            {
                size += 1;
            }
            return size;
        }
    }
}

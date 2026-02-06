// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/memo/ForMemo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.Memo;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Paragraph.Memo
{
    /// <summary>
    /// 메모를 쓰기 위한 객체
    /// </summary>
    public static class ForMemo
    {
        /// <summary>
        /// 메모를 쓴다.
        /// </summary>
        /// <param name="m">메모</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(Object.BodyText.Paragraph.Memo.Memo m, CompoundStreamWriter sw)
        {
            ForMemoList.Write(m.MemoList, sw);
            ListHeader(m.ListHeader, sw);
            ForParagraphList.Write(m.ParagraphList, sw);
        }

        /// <summary>
        /// 메모의 리스트 헤더 레코드를 쓴다.
        /// </summary>
        /// <param name="li">메모의 리스트 헤더 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void ListHeader(ListHeaderForMemo li, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt4(li.ParaCount);
            sw.WriteUInt4(li.Property.Value);
            sw.WriteUInt4(li.TextWidth);
            sw.WriteUInt4(li.TextHeight);
        }

        /// <summary>
        /// 메모의 리스트 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ListHeader, 16);
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/memo/ForMemo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.Memo;
using HwpLib.Reader.BodyText.Control;

namespace HwpLib.Reader.BodyText.Memo
{
    /// <summary>
    /// 메모를 읽기 위한 객체
    /// </summary>
    public static class ForMemo
    {
        /// <summary>
        /// 메모를 읽는다.
        /// </summary>
        /// <param name="m">메모 객체</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(Object.BodyText.Paragraph.Memo.Memo m, CompoundStreamReader sr)
        {
            ForMemoList.Read(m.MemoList, sr);
            ListHeader(m.ListHeader, sr);
            ForParagraphList.Read(m.ParagraphList, sr);
        }

        /// <summary>
        /// 메모의 문단 리스트 헤더 레코드를 읽는다.
        /// </summary>
        /// <param name="listHeaderForMemo">메모의 문단 리스트 헤더 레코드</param>
        /// <param name="sr">스트림 리더</param>
        private static void ListHeader(ListHeaderForMemo listHeaderForMemo, CompoundStreamReader sr)
        {
            sr.ReadRecordHeader();

            listHeaderForMemo.ParaCount = sr.ReadSInt4();
            listHeaderForMemo.Property.Value = sr.ReadUInt4();
            listHeaderForMemo.TextWidth = sr.ReadUInt4();
            listHeaderForMemo.TextHeight = sr.ReadUInt4();
            sr.SkipToEndRecord();
        }
    }
}

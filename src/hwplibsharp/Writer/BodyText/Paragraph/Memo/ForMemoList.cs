// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/memo/ForMemoList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.Memo;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Paragraph.Memo
{
    /// <summary>
    /// 메모 리스트 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForMemoList
    {
        /// <summary>
        /// 메모 리스트 레코드를 쓴다.
        /// </summary>
        /// <param name="ml">메모 리스트 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(MemoList? ml, CompoundStreamWriter sw)
        {
            if (ml == null)
            {
                return;
            }

            RecordHeader(/*ml, */sw);
            sw.WriteUInt4(ml.MemoIndex);
        }

        /// <summary>
        /// 메모 리스트 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(/*MemoList ml, */CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.MemoList, 4);
        }
    }
}

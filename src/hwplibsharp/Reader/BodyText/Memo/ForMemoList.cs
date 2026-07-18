// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/memo/ForMemoList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;

namespace HwpLib.Reader.BodyText.Memo
{
    /// <summary>
    /// 메모 리스트 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForMemoList
    {
        /// <summary>
        /// 메모 리스트 레코드를 읽는다.
        /// </summary>
        /// <param name="ml">메모 리스트 레코드 객체</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(Object.BodyText.Paragraph.Memo.MemoList ml, CompoundStreamReader sr)
        {
            ml.MemoIndex = sr.ReadUInt4();
        }
    }
}

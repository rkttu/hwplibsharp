// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForMemoShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 메모 모양 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForMemoShape
    {
        /// <summary>
        /// 메모 모양 레코드를 쓴다.
        /// </summary>
        /// <param name="ms">메모 모양 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(MemoShape ms, CompoundStreamWriter sw)
        {
            RecordHeader(/*ms, */sw);

            sw.WriteUInt4(ms.Width);
            sw.WriteSInt1((sbyte)(byte)ms.LineType);
            sw.WriteSInt1((sbyte)(byte)ms.LineWidth);
            sw.WriteUInt4(ms.LineColor.Value);
            sw.WriteUInt4(ms.FillColor.Value);
            sw.WriteUInt4(ms.ActiveColor.Value);
            sw.WriteUInt4(ms.Unknown);
        }

        /// <summary>
        /// 메모 모양 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(/*MemoShape ms, */CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.MemoShape, 22);
        }
    }
}

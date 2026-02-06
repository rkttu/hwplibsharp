// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForCompatibleDocument.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 호환 문서 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForCompatibleDocument
    {
        /// <summary>
        /// 호환 문서 레코드를 쓴다.
        /// </summary>
        /// <param name="cd">호환 문서 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(CompatibleDocumentInfo cd, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteUInt4((uint)cd.TargetProgram);
        }

        /// <summary>
        /// 호환 문서 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CompatibleDocument, 4);
        }
    }
}

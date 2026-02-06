// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForCompatibleDocument.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.CompatibleDocument;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 호환 문서 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForCompatibleDocument
    {
        /// <summary>
        /// 호환 문서 정보를 읽는다.
        /// </summary>
        /// <param name="cd">호환 문서 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(CompatibleDocumentInfo cd, CompoundStreamReader sr)
        {
            cd.TargetProgram = CompatibleDocumentSortExtensions.FromValue((byte)sr.ReadUInt4());
        }
    }
}

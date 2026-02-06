// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForDocumentProperties.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.DocumentProperties;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 문서 속성 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForDocumentProperties
    {
        /// <summary>
        /// 문서 속성 레코드를 쓴다.
        /// </summary>
        /// <param name="dp">문서 속성 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(DocumentPropertiesInfo dp, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteUInt2(dp.SectionCount);
            StartNumber(dp.StartNumber, sw);
            CaretPosition(dp.CaretPosition, sw);
        }

        /// <summary>
        /// 문서 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.DocumentProperties, 26);
        }

        /// <summary>
        /// 시작 번호 부분을 쓴다.
        /// </summary>
        /// <param name="sn">시작 번호 객체</param>
        /// <param name="sw">스트림 라이터</param>
        private static void StartNumber(StartNumber sn, CompoundStreamWriter sw)
        {
            sw.WriteUInt2(sn.Page);
            sw.WriteUInt2(sn.Footnote);
            sw.WriteUInt2(sn.Endnote);
            sw.WriteUInt2(sn.Picture);
            sw.WriteUInt2(sn.Table);
            sw.WriteUInt2(sn.Equation);
        }

        /// <summary>
        /// 캐릿 위치 부분을 쓴다.
        /// </summary>
        /// <param name="cp">캐릿 위치 객체</param>
        /// <param name="sw">스트림 라이터</param>
        private static void CaretPosition(CaretPosition cp, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(cp.ListID);
            sw.WriteUInt4(cp.ParagraphID);
            sw.WriteUInt4(cp.PositionInParagraph);
        }
    }
}

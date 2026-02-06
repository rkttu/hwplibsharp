// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForDocumentProperties.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.DocumentProperties;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 문서 속성 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForDocumentProperties
    {
        /// <summary>
        /// 문서 속성 레코드를 읽는다.
        /// </summary>
        /// <param name="dp">문서 속성 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(DocumentPropertiesInfo dp, CompoundStreamReader sr)
        {
            Property(dp, sr);
            StartNumberRead(dp.StartNumber, sr);
            CaretPositionRead(dp.CaretPosition, sr);
        }

        /// <summary>
        /// 속성 부분을 읽는다.
        /// </summary>
        /// <param name="dp">문서 속성 레코드</param>
        /// <param name="sr">스트림 리더</param>
        private static void Property(DocumentPropertiesInfo dp, CompoundStreamReader sr)
        {
            dp.SectionCount = sr.ReadUInt2();
        }

        /// <summary>
        /// 시작 번호 부분을 읽는다.
        /// </summary>
        /// <param name="sn">시작 번호 부분 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void StartNumberRead(StartNumber sn, CompoundStreamReader sr)
        {
            sn.Page = sr.ReadUInt2();
            sn.Footnote = sr.ReadUInt2();
            sn.Endnote = sr.ReadUInt2();
            sn.Picture = sr.ReadUInt2();
            sn.Table = sr.ReadUInt2();
            sn.Equation = sr.ReadUInt2();
        }

        /// <summary>
        /// 캐릿 위치 부분을 읽는다.
        /// </summary>
        /// <param name="cp">캐릿 위치 부분을 나태내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void CaretPositionRead(CaretPosition cp, CompoundStreamReader sr)
        {
            cp.ListID = sr.ReadUInt4();
            cp.ParagraphID = sr.ReadUInt4();
            cp.PositionInParagraph = sr.ReadUInt4();
        }
    }
}

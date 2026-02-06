// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForStyle.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 스타일 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForStyle
    {
        /// <summary>
        /// 스타일 레코드를 읽는다.
        /// </summary>
        /// <param name="s">스타일 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(StyleInfo s, CompoundStreamReader sr)
        {
            s.HangulName = sr.ReadUTF16LEString();
            s.EnglishName = sr.ReadUTF16LEString();
            s.Property.Value = sr.ReadUInt1();
            s.NextStyleId = (short)sr.ReadUInt1();
            s.LanguageId = sr.ReadSInt2();
            s.ParaShapeId = sr.CorrectParaShapeId(sr.ReadUInt2());
            s.CharShapeId = sr.ReadUInt2();
            ReadUnknown2Bytes(sr);
        }

        /// <summary>
        /// 알려지지 않은 2 바이트를 처리한다.
        /// </summary>
        /// <param name="sr">스트림 리더</param>
        private static void ReadUnknown2Bytes(CompoundStreamReader sr)
        {
            sr.Skip(2);
        }
    }
}

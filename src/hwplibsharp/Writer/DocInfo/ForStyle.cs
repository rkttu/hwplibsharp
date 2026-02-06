// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForStyle.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;
using HwpLib.Util;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 스타일 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForStyle
    {
        /// <summary>
        /// 스타일 레코드를 쓴다.
        /// </summary>
        /// <param name="s">스타일 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(StyleInfo s, CompoundStreamWriter sw)
        {
            RecordHeader(s, sw);

            sw.WriteUTF16LEString(s.HangulName);
            sw.WriteUTF16LEString(s.EnglishName);
            sw.WriteUInt1(s.Property.Value);
            sw.WriteUInt1((byte)s.NextStyleId);
            sw.WriteUInt2(s.LanguageId);
            sw.WriteUInt2(sw.CorrectParaShapeId(s.ParaShapeId));
            sw.WriteUInt2(s.CharShapeId);
            sw.WriteZero(2);
        }

        /// <summary>
        /// 스타일 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="s">스타일 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(StyleInfo s, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.Style, GetSize(s));
        }

        /// <summary>
        /// 스타일 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="s">스타일 레코드</param>
        /// <returns>스타일 레코드의 크기</returns>
        private static int GetSize(StyleInfo s)
        {
            int size = 0;
            size += StringUtil.GetUTF16LEStringSize(s.HangulName);
            size += StringUtil.GetUTF16LEStringSize(s.EnglishName);
            size += 8 + 2;
            return size;
        }
    }
}

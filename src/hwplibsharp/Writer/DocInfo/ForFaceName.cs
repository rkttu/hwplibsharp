// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForFaceName.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.FaceName;
using HwpLib.Object.Etc;
using HwpLib.Util;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 글꼴 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForFaceName
    {
        /// <summary>
        /// 글꼴 레코드를 쓴다.
        /// </summary>
        /// <param name="fn">글꼴 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(FaceNameInfo fn, CompoundStreamWriter sw)
        {
            RecordHeader(fn, sw);

            sw.WriteUInt1(fn.Property.Value);
            sw.WriteUTF16LEString(fn.Name);

            if (fn.Property.HasSubstituteFont)
            {
                sw.WriteUInt1((byte)fn.SubstituteFontType);
                sw.WriteUTF16LEString(fn.SubstituteFontName);
            }

            if (fn.Property.HasFontInfo)
            {
                FontTypeInfo(fn.FontTypeInfo, sw);
            }

            if (fn.Property.HasBaseFont)
            {
                sw.WriteUTF16LEString(fn.BaseFontName);
            }
        }

        /// <summary>
        /// 글꼴 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="fn">글꼴 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(FaceNameInfo fn, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.FaceName, GetSize(fn));
        }

        /// <summary>
        /// 글꼴 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="fn">글꼴 레코드</param>
        /// <returns>글꼴 레코드의 크기</returns>
        private static int GetSize(FaceNameInfo fn)
        {
            int size = 0;
            size += 1;
            size += StringUtil.GetUTF16LEStringSize(fn.Name);

            if (fn.Property.HasSubstituteFont)
            {
                size += 1;
                size += StringUtil.GetUTF16LEStringSize(fn.SubstituteFontName);
            }

            if (fn.Property.HasFontInfo)
            {
                size += 10;
            }

            if (fn.Property.HasBaseFont)
            {
                size += StringUtil.GetUTF16LEStringSize(fn.BaseFontName);
            }

            return size;
        }

        /// <summary>
        /// 글꼴 유형 정보를 쓴다.
        /// </summary>
        /// <param name="fti">글꼴 유형 정보</param>
        /// <param name="sw">스트림 라이터</param>
        private static void FontTypeInfo(FontTypeInfo fti, CompoundStreamWriter sw)
        {
            sw.WriteUInt1(fti.FontType);
            sw.WriteUInt1(fti.SerifType);
            sw.WriteUInt1(fti.Thickness);
            sw.WriteUInt1(fti.Ratio);
            sw.WriteUInt1(fti.Contrast);
            sw.WriteUInt1(fti.StrokeDeviation);
            sw.WriteUInt1(fti.CharacterStrokeType);
            sw.WriteUInt1(fti.CharacterShape);
            sw.WriteUInt1(fti.MiddleLine);
            sw.WriteUInt1(fti.XHeight);
        }
    }
}

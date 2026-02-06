// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForFaceName.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.FaceName;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 글꼴 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForFaceName
    {
        /// <summary>
        /// 글꼴 레코드를 읽는다.
        /// </summary>
        /// <param name="fn">글꼴 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(FaceNameInfo fn, CompoundStreamReader sr)
        {
            fn.Property.Value = sr.ReadUInt1();
            fn.Name = sr.ReadUTF16LEString();

            if (fn.Property.HasSubstituteFont)
            {
                ReadSubstituteFontInfo(fn, sr);
            }

            if (fn.Property.HasFontInfo)
            {
                ReadFontTypeInfo(fn.FontTypeInfo, sr);
            }

            if (fn.Property.HasBaseFont)
            {
                fn.BaseFontName = sr.ReadUTF16LEString();
            }
        }

        /// <summary>
        /// 대체 글꼴 정보 부분을 읽는다.
        /// </summary>
        /// <param name="fn">대체 글꼴 정보 부분을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadSubstituteFontInfo(FaceNameInfo fn, CompoundStreamReader sr)
        {
            FontType substituteFontType = FontTypeExtensions.FromValue(sr.ReadUInt1());
            fn.SubstituteFontType = substituteFontType;
            fn.SubstituteFontName = sr.ReadUTF16LEString();
        }

        /// <summary>
        /// 글꼴 유형 정보 부분을 읽는다.
        /// </summary>
        /// <param name="fti">글꼴 유형 정보 부분을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadFontTypeInfo(FontTypeInfo fti, CompoundStreamReader sr)
        {
            fti.FontType = sr.ReadUInt1();
            fti.SerifType = sr.ReadUInt1();
            fti.Thickness = sr.ReadUInt1();
            fti.Ratio = sr.ReadUInt1();
            fti.Contrast = sr.ReadUInt1();
            fti.StrokeDeviation = sr.ReadUInt1();
            fti.CharacterStrokeType = sr.ReadUInt1();
            fti.CharacterShape = sr.ReadUInt1();
            fti.MiddleLine = sr.ReadUInt1();
            fti.XHeight = sr.ReadUInt1();
        }
    }
}

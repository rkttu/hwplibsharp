// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/FaceNameAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 글꼴 이름 정보를 추가하는 클래스
    /// </summary>
    public static class FaceNameInfoAdder
    {
        /// <summary>
        /// 글꼴 이름 정보를 추가한다.
        /// </summary>
        /// <param name="docInfo">문서 정보</param>
        public static void Add(DocInfo docInfo)
        {
            HangulFaceNameInfo(docInfo);
            EnglishFaceNameInfo(docInfo);
            HanjaFaceNameInfo(docInfo);
            JapaneseFaceNameInfo(docInfo);
            EtcFaceNameInfo(docInfo);
            SymbolFaceNameInfo(docInfo);
            UserFaceNameInfo(docInfo);
        }

        private static void HangulFaceNameInfo(DocInfo docInfo)
        {
            SetFaceNameInfo1(docInfo.AddNewHangulFaceName());
            SetFaceNameInfo2(docInfo.AddNewHangulFaceName());
        }

        private static void SetFaceNameInfo1(FaceNameInfo faceName)
        {
            faceName.Property.Value = 97;
            faceName.Name = "함초롬돋움";
            faceName.SubstituteFontType = default;
            faceName.SubstituteFontName = null;

            var fontTypeInfo = faceName.FontTypeInfo;
            fontTypeInfo.FontType = 2;
            fontTypeInfo.SerifType = 3;
            fontTypeInfo.Thickness = 5;
            fontTypeInfo.Ratio = 4;
            fontTypeInfo.Contrast = 0;
            fontTypeInfo.StrokeDeviation = 1;
            fontTypeInfo.CharacterStrokeType = 1;
            fontTypeInfo.CharacterShape = 1;
            fontTypeInfo.MiddleLine = 1;
            fontTypeInfo.XHeight = 1;

            faceName.BaseFontName = "HCR Dotum";
        }

        private static void SetFaceNameInfo2(FaceNameInfo faceName)
        {
            faceName.Property.Value = 97;
            faceName.Name = "함초롬바탕";
            faceName.SubstituteFontType = default;
            faceName.SubstituteFontName = null;

            var fontTypeInfo = faceName.FontTypeInfo;
            fontTypeInfo.FontType = 2;
            fontTypeInfo.SerifType = 3;
            fontTypeInfo.Thickness = 5;
            fontTypeInfo.Ratio = 4;
            fontTypeInfo.Contrast = 0;
            fontTypeInfo.StrokeDeviation = 1;
            fontTypeInfo.CharacterStrokeType = 1;
            fontTypeInfo.CharacterShape = 1;
            fontTypeInfo.MiddleLine = 1;
            fontTypeInfo.XHeight = 1;

            faceName.BaseFontName = "HCR Batang";
        }

        private static void EnglishFaceNameInfo(DocInfo docInfo)
        {
            SetFaceNameInfo1(docInfo.AddNewEnglishFaceName());
            SetFaceNameInfo2(docInfo.AddNewEnglishFaceName());
        }

        private static void HanjaFaceNameInfo(DocInfo docInfo)
        {
            SetFaceNameInfo1(docInfo.AddNewHanjaFaceName());
            SetFaceNameInfo2(docInfo.AddNewHanjaFaceName());
        }

        private static void JapaneseFaceNameInfo(DocInfo docInfo)
        {
            SetFaceNameInfo1(docInfo.AddNewJapaneseFaceName());
            SetFaceNameInfo2(docInfo.AddNewJapaneseFaceName());
        }

        private static void EtcFaceNameInfo(DocInfo docInfo)
        {
            SetFaceNameInfo1(docInfo.AddNewEtcFaceName());
            SetFaceNameInfo2(docInfo.AddNewEtcFaceName());
        }

        private static void SymbolFaceNameInfo(DocInfo docInfo)
        {
            SetFaceNameInfo1(docInfo.AddNewSymbolFaceName());
            SetFaceNameInfo2(docInfo.AddNewSymbolFaceName());
        }

        private static void UserFaceNameInfo(DocInfo docInfo)
        {
            SetFaceNameInfo1(docInfo.AddNewUserFaceName());
            SetFaceNameInfo2(docInfo.AddNewUserFaceName());
        }
    }
}

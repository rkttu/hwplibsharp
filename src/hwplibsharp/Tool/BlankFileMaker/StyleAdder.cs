// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/StyleAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 스타일 정보를 추가하는 클래스
    /// </summary>
    public static class StyleAdder
    {
        /// <summary>
        /// 스타일 정보를 추가한다.
        /// </summary>
        /// <param name="docInfo">문서 정보</param>
        public static void Add(DocInfo docInfo)
        {
            Style1(docInfo.AddNewStyle());
            Style2(docInfo.AddNewStyle());
            Style3(docInfo.AddNewStyle());
            Style4(docInfo.AddNewStyle());
            Style5(docInfo.AddNewStyle());
            Style6(docInfo.AddNewStyle());
            Style7(docInfo.AddNewStyle());
            Style8(docInfo.AddNewStyle());
            Style9(docInfo.AddNewStyle());
            Style10(docInfo.AddNewStyle());
            Style11(docInfo.AddNewStyle());
            Style12(docInfo.AddNewStyle());
            Style13(docInfo.AddNewStyle());
            Style14(docInfo.AddNewStyle());
        }

        private static void Style1(StyleInfo style)
        {
            style.HangulName = "바탕글";
            style.EnglishName = "Normal";
            style.Property.Value = 0;
            style.NextStyleId = 0;
            style.LanguageId = 1042;
            style.ParaShapeId = 3;
            style.CharShapeId = 0;
        }

        private static void Style2(StyleInfo style)
        {
            style.HangulName = "본문";
            style.EnglishName = "Body";
            style.Property.Value = 0;
            style.NextStyleId = 1;
            style.LanguageId = 1042;
            style.ParaShapeId = 11;
            style.CharShapeId = 0;
        }

        private static void Style3(StyleInfo style)
        {
            style.HangulName = "개요 1";
            style.EnglishName = "Outline 1";
            style.Property.Value = 0;
            style.NextStyleId = 2;
            style.LanguageId = 1042;
            style.ParaShapeId = 10;
            style.CharShapeId = 0;
        }

        private static void Style4(StyleInfo style)
        {
            style.HangulName = "개요 2";
            style.EnglishName = "Outline 2";
            style.Property.Value = 0;
            style.NextStyleId = 3;
            style.LanguageId = 1042;
            style.ParaShapeId = 9;
            style.CharShapeId = 0;
        }

        private static void Style5(StyleInfo style)
        {
            style.HangulName = "개요 3";
            style.EnglishName = "Outline 3";
            style.Property.Value = 0;
            style.NextStyleId = 4;
            style.LanguageId = 1042;
            style.ParaShapeId = 8;
            style.CharShapeId = 0;
        }

        private static void Style6(StyleInfo style)
        {
            style.HangulName = "개요 4";
            style.EnglishName = "Outline 4";
            style.Property.Value = 0;
            style.NextStyleId = 5;
            style.LanguageId = 1042;
            style.ParaShapeId = 7;
            style.CharShapeId = 0;
        }

        private static void Style7(StyleInfo style)
        {
            style.HangulName = "개요 5";
            style.EnglishName = "Outline 5";
            style.Property.Value = 0;
            style.NextStyleId = 6;
            style.LanguageId = 1042;
            style.ParaShapeId = 6;
            style.CharShapeId = 0;
        }

        private static void Style8(StyleInfo style)
        {
            style.HangulName = "개요 6";
            style.EnglishName = "Outline 6";
            style.Property.Value = 0;
            style.NextStyleId = 7;
            style.LanguageId = 1042;
            style.ParaShapeId = 5;
            style.CharShapeId = 0;
        }

        private static void Style9(StyleInfo style)
        {
            style.HangulName = "개요 7";
            style.EnglishName = "Outline 7";
            style.Property.Value = 0;
            style.NextStyleId = 8;
            style.LanguageId = 1042;
            style.ParaShapeId = 4;
            style.CharShapeId = 0;
        }

        private static void Style10(StyleInfo style)
        {
            style.HangulName = "쪽 번호";
            style.EnglishName = "Page Number";
            style.Property.Value = 0;
            style.NextStyleId = 9;
            style.LanguageId = 1042;
            style.ParaShapeId = 3;
            style.CharShapeId = 1;
        }

        private static void Style11(StyleInfo style)
        {
            style.HangulName = "머리말";
            style.EnglishName = "Header";
            style.Property.Value = 0;
            style.NextStyleId = 10;
            style.LanguageId = 1042;
            style.ParaShapeId = 2;
            style.CharShapeId = 2;
        }

        private static void Style12(StyleInfo style)
        {
            style.HangulName = "각주";
            style.EnglishName = "Footnote";
            style.Property.Value = 0;
            style.NextStyleId = 11;
            style.LanguageId = 1042;
            style.ParaShapeId = 1;
            style.CharShapeId = 3;
        }

        private static void Style13(StyleInfo style)
        {
            style.HangulName = "미주";
            style.EnglishName = "Endnote";
            style.Property.Value = 0;
            style.NextStyleId = 12;
            style.LanguageId = 1042;
            style.ParaShapeId = 1;
            style.CharShapeId = 3;
        }

        private static void Style14(StyleInfo style)
        {
            style.HangulName = "메모";
            style.EnglishName = "Memo";
            style.Property.Value = 0;
            style.NextStyleId = 13;
            style.LanguageId = 1042;
            style.ParaShapeId = 0;
            style.CharShapeId = 4;
        }
    }
}

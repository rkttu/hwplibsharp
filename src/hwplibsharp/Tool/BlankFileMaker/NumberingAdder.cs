// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/NumberingAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 문단 번호 정보를 추가하는 클래스
    /// </summary>
    public static class NumberingAdder
    {
        /// <summary>
        /// 문단 번호 정보를 추가한다.
        /// </summary>
        /// <param name="docInfo">문서 정보</param>
        public static void Add(DocInfo docInfo)
        {
            Numbering1(docInfo.AddNewNumbering());
        }

        private static void Numbering1(NumberingInfo numbering)
        {
            try
            {
                var levelNumbering = numbering.GetLevelNumbering(1);
                levelNumbering.ParagraphHeadInfo.Property.Value = 12;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 50;
                levelNumbering.ParagraphHeadInfo.CharShapeID = uint.MaxValue;
                levelNumbering.NumberFormat.FromUTF16LEString("^1.");
                levelNumbering.StartNumber = 1;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(2);
                levelNumbering.ParagraphHeadInfo.Property.Value = 268;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 50;
                levelNumbering.ParagraphHeadInfo.CharShapeID = uint.MaxValue;
                levelNumbering.NumberFormat.FromUTF16LEString("^2.");
                levelNumbering.StartNumber = 1;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(3);
                levelNumbering.ParagraphHeadInfo.Property.Value = 12;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 50;
                levelNumbering.ParagraphHeadInfo.CharShapeID = uint.MaxValue;
                levelNumbering.NumberFormat.FromUTF16LEString("^3)");
                levelNumbering.StartNumber = 1;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(4);
                levelNumbering.ParagraphHeadInfo.Property.Value = 268;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 50;
                levelNumbering.ParagraphHeadInfo.CharShapeID = uint.MaxValue;
                levelNumbering.NumberFormat.FromUTF16LEString("^4)");
                levelNumbering.StartNumber = 1;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(5);
                levelNumbering.ParagraphHeadInfo.Property.Value = 12;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 50;
                levelNumbering.ParagraphHeadInfo.CharShapeID = uint.MaxValue;
                levelNumbering.NumberFormat.FromUTF16LEString("(^5)");
                levelNumbering.StartNumber = 1;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(6);
                levelNumbering.ParagraphHeadInfo.Property.Value = 268;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 50;
                levelNumbering.ParagraphHeadInfo.CharShapeID = uint.MaxValue;
                levelNumbering.NumberFormat.FromUTF16LEString("(^6)");
                levelNumbering.StartNumber = 1;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(7);
                levelNumbering.ParagraphHeadInfo.Property.Value = 44;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 50;
                levelNumbering.ParagraphHeadInfo.CharShapeID = uint.MaxValue;
                levelNumbering.NumberFormat.FromUTF16LEString("^7");
                levelNumbering.StartNumber = 1;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(8);
                levelNumbering.ParagraphHeadInfo.Property.Value = 0;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 0;
                levelNumbering.ParagraphHeadInfo.CharShapeID = 0;
                levelNumbering.NumberFormat.FromUTF16LEString(null);
                levelNumbering.StartNumber = 0;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(9);
                levelNumbering.ParagraphHeadInfo.Property.Value = 0;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 0;
                levelNumbering.ParagraphHeadInfo.CharShapeID = 0;
                levelNumbering.NumberFormat.FromUTF16LEString(null);
                levelNumbering.StartNumber = 0;
            }
            catch { }

            try
            {
                var levelNumbering = numbering.GetLevelNumbering(10);
                levelNumbering.ParagraphHeadInfo.Property.Value = 0;
                levelNumbering.ParagraphHeadInfo.CorrectionValueForWidth = 0;
                levelNumbering.ParagraphHeadInfo.DistanceFromBody = 0;
                levelNumbering.ParagraphHeadInfo.CharShapeID = 0;
                levelNumbering.NumberFormat.FromUTF16LEString(null);
                levelNumbering.StartNumber = 0;
            }
            catch { }
        }
    }
}

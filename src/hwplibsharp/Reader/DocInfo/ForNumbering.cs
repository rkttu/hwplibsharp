// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForNumbering.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.Numbering;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 문단 번호 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForNumbering
    {
        /// <summary>
        /// 문단 번호 레코드를 읽는다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(NumberingInfo n, CompoundStreamReader sr)
        {
            ReadLevelNumberingsFor1To7(n, sr);
            n.StartNumber = sr.ReadUInt2();

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 2, 5))
            {
                ReadStartNumbersFor1To7(n, sr);
            }

            if (sr.IsEndOfRecord()) return;

            ReadLevelNumberingsFor8To10(n, sr);
            ReadStartNumbersFor8To10(n, sr);
        }

        /// <summary>
        /// 1～7 수준에 해당하는 문단 번호 정보 부분을 읽는다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadLevelNumberingsFor1To7(NumberingInfo n, CompoundStreamReader sr)
        {
            for (int level = 1; level <= 7; level++)
            {
                ReadLevelNumbering(n.GetLevelNumbering(level), sr);
            }
        }

        /// <summary>
        /// 하나의 레벨에 해당하는 문단 번호 정보을 읽는다.
        /// </summary>
        /// <param name="ln">하나의 레벨에 해당하는 문단 번호 정보</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadLevelNumbering(LevelNumbering ln, CompoundStreamReader sr)
        {
            ReadParagraphHeadInfo(ln.ParagraphHeadInfo, sr);
            ln.NumberFormat.Bytes = sr.ReadHWPString();
        }


        /// <summary>
        /// 문단 머리 정보 부분을 읽는다.
        /// </summary>
        /// <param name="phi">문단 머리 정보 부분을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        public static void ReadParagraphHeadInfo(ParagraphHeadInfo phi, CompoundStreamReader sr)
        {
            phi.Property.Value = sr.ReadUInt4();
            phi.CorrectionValueForWidth = sr.ReadUInt2();
            phi.DistanceFromBody = sr.ReadUInt2();
            phi.CharShapeID = sr.ReadUInt4();
        }

        /// <summary>
        /// 1～7 수준의 시작번호 부분을 읽는다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadStartNumbersFor1To7(NumberingInfo n, CompoundStreamReader sr)
        {
            for (int level = 1; level <= 7; level++)
            {
                n.GetLevelNumbering(level).StartNumber = sr.ReadUInt4();
            }
        }

        /// <summary>
        /// 8～10 수준에 해당하는 문단 번호 정보 부분을 읽는다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadLevelNumberingsFor8To10(NumberingInfo n, CompoundStreamReader sr)
        {
            for (int level = 8; level <= 10; level++)
            {
                ReadLevelNumbering(n.GetLevelNumbering(level), sr);
            }
        }

        /// <summary>
        /// 8～10 수준의 시작번호 부분을 읽는다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadStartNumbersFor8To10(NumberingInfo n, CompoundStreamReader sr)
        {
            for (int level = 8; level <= 10; level++)
            {
                n.GetLevelNumbering(level).StartNumber = sr.ReadUInt4();
            }
        }
    }
}

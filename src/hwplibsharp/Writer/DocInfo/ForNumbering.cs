// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForNumbering.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.Numbering;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 문단 번호 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForNumbering
    {
        /// <summary>
        /// 문단 번호 레코드를 쓴다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(NumberingInfo n, CompoundStreamWriter sw)
        {
            RecordHeader(n, sw);

            LevelNumberings1To7(n, sw);
            sw.WriteUInt2(n.StartNumber);

            if (sw.FileVersion.IsOver(5, 0, 2, 5))
            {
                StartNumbersFor1To7(n, sw);
                LevelNumberings8To10(n, sw);
                StartNumbersFor8To10(n, sw);
            }
        }

        /// <summary>
        /// 문단 번호 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(NumberingInfo n, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.Numbering, GetSize(n, sw.FileVersion));
        }

        /// <summary>
        /// 문단 번호 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="version">파일 버전</param>
        /// <returns>문단 번호 레코드의 크기</returns>
        private static int GetSize(NumberingInfo n, FileVersion version)
        {
            int size = 0;
            for (int level = 1; level <= 7; level++)
            {
                var ln = n.GetLevelNumbering(level);
                size += 12 + ln.NumberFormat.GetWCharsSize();
            }
            size += 2;

            if (version.IsOver(5, 0, 2, 5))
            {
                size += 4 * 7;

                for (int level = 8; level <= 10; level++)
                {
                    var ln = n.GetLevelNumbering(level);
                    size += 12 + ln.NumberFormat.GetWCharsSize();
                }
                size += 4 * 3;
            }
            return size;
        }

        /// <summary>
        /// 1-7 수준에 해당하는 문단 번호 정보 부분을 쓴다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void LevelNumberings1To7(NumberingInfo n, CompoundStreamWriter sw)
        {
            for (int level = 1; level <= 7; level++)
            {
                LevelNumbering(n.GetLevelNumbering(level), sw);
            }
        }

        /// <summary>
        /// 하나의 레벨에 해당하는 문단 번호 정보를 쓴다.
        /// </summary>
        /// <param name="ln">하나의 레벨에 해당하는 문단 번호 정보</param>
        /// <param name="sw">스트림 라이터</param>
        private static void LevelNumbering(LevelNumbering ln, CompoundStreamWriter sw)
        {
            ParagraphHeadInfo(ln.ParagraphHeadInfo, sw);
            sw.WriteHWPString(ln.NumberFormat);
        }

        /// <summary>
        /// 문단 머리 정보 부분을 쓴다.
        /// </summary>
        /// <param name="phi">문단 머리 정보</param>
        /// <param name="sw">스트림 라이터</param>
        public static void ParagraphHeadInfo(ParagraphHeadInfo phi, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(phi.Property.Value);
            sw.WriteUInt2(phi.CorrectionValueForWidth);
            sw.WriteUInt2(phi.DistanceFromBody);
            sw.WriteUInt4(phi.CharShapeID);
        }

        /// <summary>
        /// 1-7 수준의 시작번호를 쓴다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void StartNumbersFor1To7(NumberingInfo n, CompoundStreamWriter sw)
        {
            for (int level = 1; level <= 7; level++)
            {
                sw.WriteUInt4(n.GetLevelNumbering(level).StartNumber);
            }
        }

        /// <summary>
        /// 8-10 수준에 해당하는 문단 번호 정보 부분을 쓴다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void LevelNumberings8To10(NumberingInfo n, CompoundStreamWriter sw)
        {
            for (int level = 8; level <= 10; level++)
            {
                LevelNumbering(n.GetLevelNumbering(level), sw);
            }
        }

        /// <summary>
        /// 8-10 수준의 시작번호를 쓴다.
        /// </summary>
        /// <param name="n">문단 번호 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void StartNumbersFor8To10(NumberingInfo n, CompoundStreamWriter sw)
        {
            for (int level = 8; level <= 10; level++)
            {
                sw.WriteUInt4(n.GetLevelNumbering(level).StartNumber);
            }
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/ForParaText.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.Text;

namespace HwpLib.Reader.BodyText.Paragraph
{
    /// <summary>
    /// 문단 텍스트 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForParaText
    {
        /// <summary>
        /// 문단 텍스트 레코드를 읽는다.
        /// </summary>
        /// <param name="p">문단</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(Object.BodyText.Paragraph.Paragraph p, CompoundStreamReader sr)
        {
            p.CreateText();

            var pt = p.Text!;

            long recordSize = sr.CurrentRecordHeader!.Size;
            long read = 0;

            while (read < recordSize)
            {
                read += HwpChar(pt, sr);
            }
        }

        /// <summary>
        /// HWP문자를 종류에 따라 읽는다.
        /// </summary>
        /// <param name="paraText">문단의 텍스트 레코드</param>
        /// <param name="sr">스트림 리더</param>
        /// <returns>읽은 byte 수</returns>
        private static int HwpChar(ParaText paraText, CompoundStreamReader sr)
        {
            int code = sr.ReadUInt2();
            switch (HWPChar.GetCharType(code))
            {
                case HWPCharType.Normal:
                    paraText.AddNewNormalChar().Code = code;
                    return 2;
                case HWPCharType.ControlChar:
                    paraText.AddNewCharControlChar().Code = code;
                    return 2;
                case HWPCharType.ControlExtend:
                    ExtendChar(paraText.AddNewExtendControlChar(), code, sr);
                    return 16;
                case HWPCharType.ControlInline:
                    InlineChar(paraText.AddNewInlineControlChar(), code, sr);
                    return 16;
            }
            return 2;
        }

        /// <summary>
        /// 확장 컨트롤 문자를 읽는다.
        /// </summary>
        private static void ExtendChar(HWPCharControlExtend extendChar, int code, CompoundStreamReader sr)
        {
            extendChar.Code = code;
            byte[] addition = sr.ReadBytes(12);
            extendChar.SetAddition(addition);
            sr.ReadUInt2(); // 종료 코드 읽기
        }

        /// <summary>
        /// 인라인 컨트롤 문자를 읽는다.
        /// </summary>
        private static void InlineChar(HWPCharControlInline inlineChar, int code, CompoundStreamReader sr)
        {
            inlineChar.Code = code;
            byte[] addition = sr.ReadBytes(12);
            inlineChar.SetAddition(addition);
            sr.ReadUInt2(); // 종료 코드 읽기
        }
    }
}

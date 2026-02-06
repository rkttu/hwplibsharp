// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/eqed/ForEQEdit.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Equation;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Eqed
{
    /// <summary>
    /// 수식 정보 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForEQEdit
    {
        /// <summary>
        /// 수식 정보 레코드를 쓴다.
        /// </summary>
        public static void Write(EQEdit ee, CompoundStreamWriter sw)
        {
            RecordHeader(ee, sw);

            sw.WriteUInt4(ee.Property);
            sw.WriteHWPString(ee.Script);
            sw.WriteUInt4(ee.LetterSize);
            sw.WriteUInt4(ee.LetterColor.Value);
            sw.WriteSInt2(ee.BaseLine);
            sw.WriteUInt2(ee.Unknown);
            sw.WriteHWPString(ee.VersionInfo);
            sw.WriteHWPString(ee.FontName);
        }

        /// <summary>
        /// 수식 정보 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(EQEdit ee, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.EqEdit, GetSize(ee));
        }

        /// <summary>
        /// 수식 정보 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(EQEdit ee)
        {
            int size = 0;
            size += 4;
            size += ee.Script.GetWCharsSize();
            size += 12;
            size += ee.VersionInfo.GetWCharsSize();
            size += ee.FontName.GetWCharsSize();
            return size;
        }
    }
}

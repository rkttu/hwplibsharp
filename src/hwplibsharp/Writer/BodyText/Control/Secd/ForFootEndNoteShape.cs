// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/secd/ForFootEndNoteShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.SectionDefine;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Secd
{
    /// <summary>
    /// 각주/미주 모양 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForFootEndNoteShape
    {
        /// <summary>
        /// 각주/미주 모양 레코드를 쓴다.
        /// </summary>
        public static void Write(FootEndNoteShape fens, CompoundStreamWriter sw)
        {
            if (fens == null)
            {
                return;
            }

            RecordHeader(sw);

            sw.WriteUInt4(fens.Property.Value);
            sw.WriteWChar(fens.UserSymbol.Bytes ?? new byte[2]);
            sw.WriteWChar(fens.BeforeDecorativeLetter.Bytes ?? new byte[2]);
            sw.WriteWChar(fens.AfterDecorativeLetter.Bytes ?? new byte[2]);
            sw.WriteUInt2(fens.StartNumber);
            sw.WriteUInt4(fens.DivideLineLength);
            sw.WriteUInt2(fens.DivideLineTopMargin);
            sw.WriteUInt2(fens.DivideLineBottomMargin);
            sw.WriteUInt2(fens.BetweenNotesMargin);
            sw.WriteUInt1((byte)fens.DivideLine.Type);
            sw.WriteUInt1((byte)fens.DivideLine.Thickness);
            sw.WriteUInt4(fens.DivideLine.Color.Value);
        }

        /// <summary>
        /// 각주/미주 모양 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.FootnoteShape, 28);
        }
    }
}

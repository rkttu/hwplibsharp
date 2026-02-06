// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlOverlappingLetter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 글자 겹침 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlOverlappingLetter
    {
        /// <summary>
        /// 글자 겹침 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlOverlappingLetter ol, CompoundStreamWriter sw)
        {
            CtrlHeader((CtrlHeaderOverlappingLetter)ol.GetHeader()!, sw);
        }

        /// <summary>
        /// 글자 겹침 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderOverlappingLetter h, CompoundStreamWriter sw)
        {
            RecordHeader(h, sw);
            sw.WriteUInt4(h.CtrlId);

            OverlappingLetters(h, sw);

            sw.WriteUInt1((byte)h.BorderType);
            sw.WriteSInt1((sbyte)h.InternalFontSize);
            sw.WriteUInt1((byte)h.ExpendInsideLetter);

            CharShapeIds(h, sw);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CtrlHeaderOverlappingLetter h, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, GetSize(h));
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(CtrlHeaderOverlappingLetter h)
        {
            int size = 4;
            size += 2;
            size += h.OverlappingLetterList.Count * 2;
            size += 3;
            size += 1;
            size += h.CharShapeIdList.Count * 4;
            return size;
        }

        /// <summary>
        /// 겹침 글자 부분을 쓴다.
        /// </summary>
        private static void OverlappingLetters(CtrlHeaderOverlappingLetter h, CompoundStreamWriter sw)
        {
            sw.WriteUInt2((ushort)h.OverlappingLetterList.Count);
            foreach (var letter in h.OverlappingLetterList)
            {
                sw.WriteWChar(letter.Bytes ?? new byte[2]);
            }
        }

        /// <summary>
        /// 글자 모양 부분을 쓴다.
        /// </summary>
        private static void CharShapeIds(CtrlHeaderOverlappingLetter h, CompoundStreamWriter sw)
        {
            sw.WriteUInt1((byte)h.CharShapeIdList.Count);
            foreach (var csId in h.CharShapeIdList)
            {
                sw.WriteUInt4(csId);
            }
        }
    }
}

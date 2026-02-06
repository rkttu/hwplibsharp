// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForParaHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.Header;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;

namespace HwpLib.Writer.BodyText.Paragraph
{
    /// <summary>
    /// 문단 헤더 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForParaHeader
    {
        /// <summary>
        /// 문단 헤더 레코드를 쓴다.
        /// </summary>
        /// <param name="ph">문단 헤더 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(ParaHeader ph, CompoundStreamWriter sw)
        {
            RecordHeader(/*ph, */sw);

            LastInListTextCount(ph, sw);
            sw.WriteUInt4(ph.ControlMask.Value);
            sw.WriteUInt2(sw.CorrectParaShapeId(ph.ParaShapeId));
            sw.WriteUInt1(ph.StyleId);
            sw.WriteUInt1(ph.DivideSort.Value);
            sw.WriteUInt2(ph.CharShapeCount);
            sw.WriteUInt2(ph.RangeTagCount);
            sw.WriteUInt2(ph.LineAlignCount);
            sw.WriteUInt4(ph.InstanceID);
            if (sw.FileVersion.IsOver(5, 0, 3, 2))
            {
                sw.WriteUInt2(ph.IsMergedByTrack);
            }
        }

        /// <summary>
        /// 문단 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(/*ParaHeader ph, */CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ParaHeader, GetSize(sw.FileVersion));
        }

        /// <summary>
        /// 문단 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(FileVersion version)
        {
            int size = 22;
            if (version.IsOver(5, 0, 3, 2))
            {
                size += 2;
            }
            return size;
        }

        /// <summary>
        /// 문단 리스트에서 마지막 문단여부와 문자수를 쓴다.
        /// </summary>
        private static void LastInListTextCount(ParaHeader ph, CompoundStreamWriter sw)
        {
            long value = 0;
            if (ph.LastInList)
            {
                value += 0x80000000;
            }
            value += ph.CharacterCount & 0x7fffffff;
            sw.WriteUInt4(value);
        }
    }
}

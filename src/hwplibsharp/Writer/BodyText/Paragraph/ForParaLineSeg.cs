// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForParaLineSeg.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.LineSeg;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Paragraph
{
    /// <summary>
    /// 문단의 레이아웃 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForParaLineSeg
    {
        /// <summary>
        /// 문단의 레이아웃 레코드를 쓴다.
        /// </summary>
        /// <param name="pls">문단의 레이아웃 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(ParaLineSeg? pls, CompoundStreamWriter sw)
        {
            if (pls == null)
            {
                return;
            }

            RecordHeader(pls, sw);

            foreach (var lsi in pls.LineSegItemList)
            {
                LineSegItem(lsi, sw);
            }
        }

        /// <summary>
        /// 문단의 레이아웃 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ParaLineSeg pls, CompoundStreamWriter sw)
        {
            int size = GetSize(pls);
            sw.WriteRecordHeader(HWPTag.ParaLineSeg, size);
        }

        /// <summary>
        /// 문단의 레이아웃 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ParaLineSeg pls)
        {
            return pls.LineSegItemList.Count * 36;
        }

        /// <summary>
        /// 한 라인의 레이아웃 정보를 쓴다.
        /// </summary>
        private static void LineSegItem(LineSegItem lsi, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(lsi.TextStartPosition);
            sw.WriteSInt4(lsi.LineVerticalPosition);
            sw.WriteSInt4(lsi.LineHeight);
            sw.WriteSInt4(lsi.TextPartHeight);
            sw.WriteSInt4(lsi.DistanceBaseLineToLineVerticalPosition);
            sw.WriteSInt4(lsi.LineSpace);
            sw.WriteSInt4(lsi.StartPositionFromColumn);
            sw.WriteSInt4(lsi.SegmentWidth);
            sw.WriteUInt4(lsi.Tag.Value);
        }
    }
}

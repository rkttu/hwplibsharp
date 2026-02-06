// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForParaShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 문단 모양 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForParaShape
    {
        /// <summary>
        /// 문단 모양 레코드를 쓴다.
        /// </summary>
        /// <param name="ps">문단 모양 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(ParaShapeInfo ps, CompoundStreamWriter sw)
        {
            RecordHeader(/*ps, */sw);

            sw.WriteUInt4(ps.Property1.Value);
            sw.WriteSInt4(ps.LeftMargin);
            sw.WriteSInt4(ps.RightMargin);
            sw.WriteSInt4(ps.Indent);
            sw.WriteSInt4(ps.TopParaSpace);
            sw.WriteSInt4(ps.BottomParaSpace);
            sw.WriteSInt4(ps.LineSpace);
            sw.WriteUInt2(ps.TabDefId);
            sw.WriteUInt2(ps.ParaHeadId);
            sw.WriteUInt2(ps.BorderFillId);
            sw.WriteSInt2(ps.LeftBorderSpace);
            sw.WriteSInt2(ps.RightBorderSpace);
            sw.WriteSInt2(ps.TopBorderSpace);
            sw.WriteSInt2(ps.BottomBorderSpace);

            if (sw.FileVersion.IsOver(5, 0, 1, 7))
            {
                sw.WriteUInt4(ps.Property2.Value);
            }

            if (sw.FileVersion.IsOver(5, 0, 2, 5))
            {
                sw.WriteUInt4(ps.Property3.Value);
                sw.WriteUInt4(ps.LineSpace2);
            }

            if (sw.FileVersion.IsOver(5, 0, 255, 255))
            {
                sw.WriteUInt4(ps.ParaLevel);
            }
        }

        /// <summary>
        /// 문단 모양 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(/*ParaShapeInfo ps, */CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ParaShape, GetSize(sw.FileVersion));
        }

        /// <summary>
        /// 문단 모양 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="version">파일 버전</param>
        /// <returns>문단 모양 레코드의 크기</returns>
        private static int GetSize(FileVersion version)
        {
            int size = 0;
            size += 42;

            if (version.IsOver(5, 0, 1, 7))
            {
                size += 4;
            }

            if (version.IsOver(5, 0, 2, 5))
            {
                size += 8;
            }

            if (version.IsOver(5, 0, 255, 255))
            {
                size += 4;
            }

            return size;
        }
    }
}

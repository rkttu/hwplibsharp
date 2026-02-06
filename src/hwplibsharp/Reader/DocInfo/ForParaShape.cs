// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForParaShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 문단 모양 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForParaShape
    {
        /// <summary>
        /// 문단 모양 레코드를 읽는다.
        /// </summary>
        /// <param name="ps">문단 모양 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(ParaShapeInfo ps, CompoundStreamReader sr)
        {
            ps.Property1.Value = sr.ReadUInt4();
            ps.LeftMargin = sr.ReadSInt4();
            ps.RightMargin = sr.ReadSInt4();
            ps.Indent = sr.ReadSInt4();
            ps.TopParaSpace = sr.ReadSInt4();
            ps.BottomParaSpace = sr.ReadSInt4();
            ps.LineSpace = sr.ReadSInt4();
            ps.TabDefId = sr.ReadUInt2();
            ps.ParaHeadId = sr.ReadUInt2();
            ps.BorderFillId = sr.ReadUInt2();
            ps.LeftBorderSpace = sr.ReadSInt2();
            ps.RightBorderSpace = sr.ReadSInt2();
            ps.TopBorderSpace = sr.ReadSInt2();
            ps.BottomBorderSpace = sr.ReadSInt2();

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 1, 7))
            {
                ps.Property2.Value = sr.ReadUInt4();
            }

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 2, 5))
            {
                ps.Property3.Value = sr.ReadUInt4();
                ps.LineSpace2 = sr.ReadUInt4();
            }

            if (sr.IsEndOfRecord()) return;

            ps.ParaLevel = sr.ReadUInt4();
        }
    }
}

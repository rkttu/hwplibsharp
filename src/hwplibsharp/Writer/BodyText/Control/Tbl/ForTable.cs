// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/tbl/ForTable.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Table;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;

namespace HwpLib.Writer.BodyText.Control.Tbl
{
    /// <summary>
    /// 표 정보 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForTable
    {
        /// <summary>
        /// 표 정보 레코드를 쓴다.
        /// </summary>
        public static void Write(Table t, CompoundStreamWriter sw)
        {
            RecordHeader(t, sw);

            sw.WriteUInt4(t.Property.Value);
            sw.WriteUInt2(t.RowCount);
            sw.WriteUInt2(t.ColumnCount);
            sw.WriteUInt2(t.CellSpacing);
            sw.WriteUInt2(t.LeftInnerMargin);
            sw.WriteUInt2(t.RightInnerMargin);
            sw.WriteUInt2(t.TopInnerMargin);
            sw.WriteUInt2(t.BottomInnerMargin);

            for (int index = 0; index < t.RowCount; index++)
            {
                sw.WriteUInt2(t.CellCountOfRowList[index]);
            }
            sw.WriteUInt2(t.BorderFillId);

            if (sw.FileVersion.IsOver(5, 0, 1, 0))
            {
                ZoneInfo(t, sw);
            }
        }

        /// <summary>
        /// 표 정보 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(Table t, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.Table, GetSize(t, sw.FileVersion));
        }

        /// <summary>
        /// 표 정보 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(Table t, FileVersion version)
        {
            int size = 0;

            size += 18;
            size += 2 * t.RowCount;
            size += 2;
            if (version.IsOver(5, 0, 1, 0))
            {
                size += 2;
                size += 10 * t.ZoneInfoList.Count;
            }

            return size;
        }

        /// <summary>
        /// zone info를 쓴다.
        /// </summary>
        private static void ZoneInfo(Table t, CompoundStreamWriter sw)
        {
            var ziList = t.ZoneInfoList;
            int count = ziList.Count;
            sw.WriteUInt2((ushort)count);

            for (int index = 0; index < count; index++)
            {
                var zi = ziList[index];

                sw.WriteUInt2(zi.StartColumn);
                sw.WriteUInt2(zi.StartRow);
                sw.WriteUInt2(zi.EndColumn);
                sw.WriteUInt2(zi.EndRow);
                sw.WriteUInt2(zi.BorderFillId);
            }
        }
    }
}

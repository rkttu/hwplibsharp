using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Table;

namespace HwpLib.Reader.BodyText.Control.Tbl;

/// <summary>
/// 표 정보 레코드를 읽기 위한 객체
/// </summary>
public static class ForTable
{
    /// <summary>
    /// 표 정보 레코드를 읽는다.
    /// </summary>
    /// <param name="table">표 정보 레코드</param>
    /// <param name="sr">스트림 리더</param>
    public static void Read(Table table, CompoundStreamReader sr)
    {
        table.Property.Value = sr.ReadUInt4();

        table.RowCount = sr.ReadUInt2();
        table.ColumnCount = sr.ReadUInt2();
        table.CellSpacing = sr.ReadUInt2();
        table.LeftInnerMargin = sr.ReadUInt2();
        table.RightInnerMargin = sr.ReadUInt2();
        table.TopInnerMargin = sr.ReadUInt2();
        table.BottomInnerMargin = sr.ReadUInt2();

        for (int index = 0; index < table.RowCount; index++)
        {
            table.AddCellCountOfRow(sr.ReadUInt2());
        }

        table.BorderFillId = sr.ReadUInt2();

        if (sr.FileVersion.IsOver(5, 0, 1, 0))
        {
            ZoneInfo(table, sr);
        }
    }

    /// <summary>
    /// zone info를 읽는다.
    /// </summary>
    /// <param name="table">표 정보 레코드</param>
    /// <param name="sr">스트림 리더</param>
    private static void ZoneInfo(Table table, CompoundStreamReader sr)
    {
        int count = sr.ReadUInt2();
        for (int index = 0; index < count; index++)
        {
            var zi = table.AddNewZoneInfo();
            zi.StartColumn = sr.ReadUInt2();
            zi.StartRow = sr.ReadUInt2();
            zi.EndColumn = sr.ReadUInt2();
            zi.EndRow = sr.ReadUInt2();
            zi.BorderFillId = sr.ReadUInt2();
        }
    }
}

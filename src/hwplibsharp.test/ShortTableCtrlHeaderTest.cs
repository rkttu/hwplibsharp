using HwpLib.Object;
using HwpLib.Object.BodyText.Control;
using HwpLib.Reader;
using HwpLib.Writer;

namespace HwpLibSharp.Test;

[TestClass]
public class ShortTableCtrlHeaderTest
{
    // Public, anonymized reproduction from upstream PR #315, pinned at
    // emptinessform/hwplib@5452db19228015ffbe3250c6fbaa6d6526901eb5.
    [TestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public void ReadAndRewriteShortTableHeader_ShouldPreserveTable(bool fillCell)
    {
        var source = TestHelper.GetBasicSamplePath("issue-315-table-ctrl-header.hwp");
        var file = HWPReader.FromFile(source);
        var table = GetTable(file);
        Assert.IsFalse(table.Header.PreventPageDivide);
        Assert.AreEqual("", table.Header.Explanation.ToUTF16LEString());
        Assert.IsNotEmpty(table.RowList);
        var rowCount = table.Table.RowCount;
        var columnCount = table.Table.ColumnCount;
        var cellCount = table.RowList.Sum(row => row.CellList.Count);
        const string text = "이슈 18번 표 읽기 및 저장 검증입니다.";

        if (fillCell)
        {
            var paragraph = table.RowList[0].CellList[0].ParagraphList.GetParagraph(0);
            Assert.IsNotNull(paragraph);
            paragraph.CreateText();
            paragraph.Text!.AddString(text);
            paragraph.Text.AddNewCharControlChar().Code = 13;
            paragraph.DeleteLineSeg();
        }

        var name = fillCell ? "filled" : "rewrite";
        var output = TestHelper.GetResultPath($"result-issue18-short-table-{name}.hwp");
        HWPWriter.ToFile(file, output);

        var reloaded = HWPReader.FromFile(output);
        var reloadedTable = GetTable(reloaded);
        Assert.AreEqual(rowCount, reloadedTable.Table.RowCount);
        Assert.AreEqual(columnCount, reloadedTable.Table.ColumnCount);
        Assert.AreEqual(cellCount, reloadedTable.RowList.Sum(row => row.CellList.Count));
        Assert.AreEqual(table.Header.Width, reloadedTable.Header.Width);
        Assert.AreEqual(table.Header.Height, reloadedTable.Header.Height);
        Assert.IsFalse(reloadedTable.Header.PreventPageDivide);
        Assert.AreEqual("", reloadedTable.Header.Explanation.ToUTF16LEString());
        if (fillCell)
            Assert.AreEqual(text + "\n", reloadedTable.RowList[0].CellList[0].ParagraphList.GetNormalString());
    }

    private static ControlTable GetTable(HWPFile file)
    {
        Assert.HasCount(1, file.BodyText.SectionList);
        var section = file.BodyText.SectionList[0];
        Assert.AreEqual(2, section.ParagraphCount);
        var controls = section.GetParagraph(0)!.ControlList;
        Assert.IsNotNull(controls);
        var tables = controls.OfType<ControlTable>().ToList();
        Assert.HasCount(1, tables);
        return tables[0];
    }
}

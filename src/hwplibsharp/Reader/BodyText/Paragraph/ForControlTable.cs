using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Table;
using HwpLib.Object.Etc;
using HwpLib.Reader.BodyText.Control;
using HwpLib.Reader.BodyText.Control.Gso.Part;
using HwpLib.Reader.BodyText.Control.Tbl;

namespace HwpLib.Reader.BodyText.Paragraph;

/// <summary>
/// 표 컨트롤을 읽기 위한 객체
/// </summary>
public class ForControlTable
{
    /// <summary>
    /// 표 컨트롤
    /// </summary>
    private ControlTable? _table;

    /// <summary>
    /// 스트림 리더
    /// </summary>
    private CompoundStreamReader? _sr;

    /// <summary>
    /// 생성자
    /// </summary>
    public ForControlTable()
    {
    }

    /// <summary>
    /// 표 컨트롤을 읽는다.
    /// </summary>
    /// <param name="table">표 컨트롤 객체</param>
    /// <param name="sr">스트림 리더</param>
    public void Read(ControlTable table, CompoundStreamReader sr)
    {
        _table = table;
        _sr = sr;

        CtrlHeader();
        CtrlData();
        Caption();
        Table();
        Rows();
    }

    /// <summary>
    /// 표 컨트롤의 컨트롤 헤더 레코드를 읽는다.
    /// </summary>
    private void CtrlHeader()
    {
        ForCtrlHeaderGso.Read(_table!.Header, _sr!);
    }

    /// <summary>
    /// 컨트롤 데이터를 읽는다.
    /// </summary>
    private void CtrlData()
    {
        _sr!.ReadRecordHeader();
        if (_sr.CurrentRecordHeader?.TagId == HWPTag.CtrlData)
        {
            _table!.CreateCtrlData();
            var ctrlData = Control.ForCtrlData.Read(_sr);
            _table.SetCtrlData(ctrlData);
        }
    }

    /// <summary>
    /// 캡션 정보를 읽는다.
    /// </summary>
    private void Caption()
    {
        if (!_sr!.IsImmediatelyAfterReadingHeader)
        {
            _sr.ReadRecordHeader();
        }
        if (_sr.CurrentRecordHeader?.TagId == HWPTag.ListHeader)
        {
            _table!.CreateCaption();
            ForCaption.Read(_table.Caption!, _sr);
        }
    }

    /// <summary>
    /// 표 정보 레코드를 읽는다.
    /// </summary>
    private void Table()
    {
        if (!_sr!.IsImmediatelyAfterReadingHeader)
        {
            _sr.ReadRecordHeader();
        }
        if (_sr.CurrentRecordHeader?.TagId == HWPTag.Table)
        {
            ForTable.Read(_table!.Table, _sr);
        }
    }

    /// <summary>
    /// 행들을 읽는다.
    /// </summary>
    private void Rows()
    {
        int rowCount = _table!.Table.RowCount;
        var cellCountOfRowList = _table.Table.CellCountOfRowList;
        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
        {
            var r = _table.AddNewRow();
            Row(r, cellCountOfRowList[rowIndex]);
        }
    }

    /// <summary>
    /// 하나의 행 안에 셀들을 읽는다.
    /// </summary>
    /// <param name="r">행</param>
    /// <param name="cellCount">행에 포함된 셀 개수</param>
    private void Row(Row r, int cellCount)
    {
        for (int cellIndex = 0; cellIndex < cellCount; cellIndex++)
        {
            var c = r.AddNewCell();
            ForCell.Read(c, _sr!);
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/TableCellMerger.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Table;
using System.Collections.Generic;

namespace HwpLib.Tool
{
    /// <summary>
    /// 표의 셀을 병합하는 클래스
    /// </summary>
    public class TableCellMerger
    {
        /// <summary>
        /// 표의 셀을 병합한다.
        /// </summary>
        /// <param name="table">병합할 표</param>
        /// <param name="startRow">행의 시작 인덱스</param>
        /// <param name="startCol">열의 시작 인덱스</param>
        /// <param name="rowSpan">행의 span</param>
        /// <param name="colSpan">열의 span</param>
        /// <returns>병합 성공 여부</returns>
        public static bool MergeCell(ControlTable table, int startRow, int startCol, int rowSpan, int colSpan)
        {
            var merger = new TableCellMerger(table, startRow, startCol, rowSpan, colSpan, true);
            return merger.Merge();
        }

        /// <summary>
        /// 표의 셀을 병합하되, 병합 가능 여부를 검사하지 않고 강제로 병합합니다.
        /// </summary>
        /// <param name="table">병합할 표</param>
        /// <param name="startRow">행의 시작 인덱스</param>
        /// <param name="startCol">열의 시작 인덱스</param>
        /// <param name="rowSpan">행의 span</param>
        /// <param name="colSpan">열의 span</param>
        /// <returns>병합 성공 여부</returns>
        public static bool MergeCellWithoutCheck(ControlTable table, int startRow, int startCol, int rowSpan, int colSpan)
        {
            var merger = new TableCellMerger(table, startRow, startCol, rowSpan, colSpan, false);
            return merger.Merge();
        }

        private readonly ControlTable _table;
        private readonly int _startRow;
        private readonly int _startCol;
        private readonly int _rowSpan;
        private readonly int _colSpan;
        private readonly bool _check;

        private TableCellMerger(ControlTable table, int startRow, int startCol, int rowSpan, int colSpan, bool check)
        {
            _table = table;
            _startRow = startRow;
            _startCol = startCol;
            _rowSpan = rowSpan;
            _colSpan = colSpan;
            _check = check;
        }

        private bool Merge()
        {
            bool possible;
            if (!_check)
            {
                possible = true;
            }
            else
            {
                possible = Possible();
            }

            if (possible)
            {
                ResetMergedCell();
                RemoveRestCell();
                ResetCellCountOfRow();
                return true;
            }
            return false;
        }

        private bool Possible()
        {
            return IsInTable() && CheckAreaLeft() && CheckAreaTop() && CheckAreaRight() && CheckAreaBottom();
        }

        private bool IsInTable()
        {
            var tableInfo = _table.Table;
            if (tableInfo == null) return false;

            return 0 <= _startRow && GetEndRow() < tableInfo.RowCount
                && 0 <= _startCol && GetEndCol() < tableInfo.ColumnCount;
        }

        private int GetEndRow()
        {
            return _startRow + _rowSpan - 1;
        }

        private int GetEndCol()
        {
            return _startCol + _colSpan - 1;
        }

        private bool CheckAreaLeft()
        {
            for (int rowIndex = _startRow; rowIndex <= GetEndRow(); rowIndex++)
            {
                var cell = FindCell(rowIndex, _startCol);
                if (cell == null)
                {
                    return false;
                }
                var lhc = cell.ListHeader;
                if (lhc == null || lhc.ColIndex != _startCol)
                {
                    return false;
                }
            }
            return true;
        }

        private Cell? FindCell(int rowIndex, int colIndex)
        {
            var rowList = _table.RowList;
            if (rowList == null) return null;

            foreach (var row in rowList)
            {
                var cellList = row.CellList;
                if (cellList == null) continue;

                foreach (var cell in cellList)
                {
                    var lhc = cell.ListHeader;
                    if (lhc == null) continue;

                    if (lhc.RowIndex <= rowIndex && rowIndex <= lhc.RowIndex + lhc.RowSpan - 1
                        && lhc.ColIndex <= colIndex && colIndex <= lhc.ColIndex + lhc.ColSpan - 1)
                    {
                        return cell;
                    }
                }
            }
            return null;
        }

        private bool CheckAreaTop()
        {
            for (int colIndex = _startCol; colIndex <= GetEndCol(); colIndex++)
            {
                var cell = FindCell(_startRow, colIndex);
                if (cell == null)
                {
                    return false;
                }
                var lhc = cell.ListHeader;
                if (lhc == null || lhc.RowIndex != _startRow)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckAreaRight()
        {
            for (int rowIndex = _startRow; rowIndex <= GetEndRow(); rowIndex++)
            {
                var cell = FindCell(rowIndex, GetEndCol());
                if (cell == null)
                {
                    return false;
                }
                var lhc = cell.ListHeader;
                if (lhc == null || lhc.ColIndex + lhc.RowSpan - 1 != GetEndCol())
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckAreaBottom()
        {
            for (int colIndex = _startCol; colIndex <= GetEndCol(); colIndex++)
            {
                var cell = FindCell(GetEndRow(), colIndex);
                if (cell == null)
                {
                    return false;
                }
                var lhc = cell.ListHeader;
                if (lhc == null || lhc.RowIndex + lhc.RowSpan - 1 != GetEndRow())
                {
                    return false;
                }
            }
            return true;
        }

        private void ResetMergedCell()
        {
            var cell = FindCell(_startRow, _startCol);
            if (cell == null) return;

            var lhc = cell.ListHeader;
            if (lhc == null) return;

            lhc.RowSpan = _rowSpan;
            lhc.ColSpan = _colSpan;
            lhc.Width = GetMergedWidth();
            lhc.Height = GetMergedHeight();
        }

        private long GetMergedWidth()
        {
            long width = 0;
            var rowList = _table.RowList;
            if (rowList == null || _startRow >= rowList.Count) return 0;

            var row = rowList[_startRow];
            var cellList = row.CellList;
            if (cellList == null) return 0;

            foreach (var cell in cellList)
            {
                var lhc = cell.ListHeader;
                if (lhc != null && _startCol <= lhc.ColIndex && lhc.ColIndex <= GetEndCol())
                {
                    width += lhc.Width;
                }
            }
            return width;
        }

        private long GetMergedHeight()
        {
            long height = 0;
            var rowList = _table.RowList;
            if (rowList == null) return 0;

            for (int rowIndex = _startRow; rowIndex <= GetEndRow() && rowIndex < rowList.Count; rowIndex++)
            {
                var row = rowList[rowIndex];
                var cellList = row.CellList;
                if (cellList == null) continue;

                foreach (var cell in cellList)
                {
                    var lhc = cell.ListHeader;
                    if (lhc != null && lhc.ColIndex == _startCol)
                    {
                        height += lhc.Height;
                    }
                }
            }
            return height;
        }

        private void RemoveRestCell()
        {
            var rowList = _table.RowList;
            if (rowList == null) return;

            var removeCells = new List<Cell>();
            for (int rowIndex = _startRow; rowIndex <= GetEndRow() && rowIndex < rowList.Count; rowIndex++)
            {
                var row = rowList[rowIndex];
                var cellList = row.CellList;
                if (cellList == null) continue;

                foreach (var cell in cellList)
                {
                    var lhc = cell.ListHeader;
                    if (lhc == null) continue;

                    if (lhc.RowIndex == _startRow && lhc.ColIndex == _startCol)
                    {
                        continue;
                    }
                    else if (lhc.ColIndex >= _startCol && lhc.ColIndex + lhc.ColSpan - 1 <= GetEndCol())
                    {
                        removeCells.Add(cell);
                    }
                }

                foreach (var c in removeCells)
                {
                    row.RemoveCell(c);
                }
                removeCells.Clear();
            }
        }

        private void ResetCellCountOfRow()
        {
            var tableInfo = _table.Table;
            if (tableInfo == null) return;

            tableInfo.ClearCellCountOfRowList();

            var rowList = _table.RowList;
            if (rowList == null) return;

            int rowCount = rowList.Count;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var cellList = rowList[rowIndex].CellList;
                int cellCount = cellList?.Count ?? 0;
                tableInfo.AddCellCountOfRow(cellCount);
            }
        }
    }
}

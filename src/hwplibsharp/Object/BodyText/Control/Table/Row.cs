// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/table/Row.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Table
{
    /// <summary>
    /// 표의 행을 나타내는 객체
    /// </summary>
    public class Row
    {
        /// <summary>
        /// 셀 리스트
        /// </summary>
        private readonly List<Cell> _cellList;

        /// <summary>
        /// 생성자
        /// </summary>
        public Row()
        {
            _cellList = new List<Cell>();
        }

        /// <summary>
        /// 새로운 셀 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 셀 객체</returns>
        public Cell AddNewCell()
        {
            var cell = new Cell();
            _cellList.Add(cell);
            return cell;
        }

        /// <summary>
        /// 셀 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<Cell> CellList => _cellList;

        /// <summary>
        /// 셀을 제거한다.
        /// </summary>
        /// <param name="cell">제거할 셀</param>
        /// <returns>제거 성공 여부</returns>
        public bool RemoveCell(Cell cell)
        {
            return _cellList.Remove(cell);
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public Row Clone()
        {
            var cloned = new Row();
            foreach (var cell in _cellList)
            {
                cloned._cellList.Add(cell.Clone());
            }
            return cloned;
        }
    }
}

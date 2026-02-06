// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControlTable.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Table;
using HwpLib.Writer.AutoSetter.Control.Gso.Part;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 표 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlTable
    {
        /// <summary>
        /// 표 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="t">표 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlTable t, InstanceID iid)
        {
            ForCtrlHeaderGso.AutoSet(t.Header, t.Caption, iid);
            ForCaption.AutoSet(t.Caption, iid);
            Table(t);
            Cells(t, iid);
        }

        /// <summary>
        /// 표 정보 객체를 자동 설정한다.
        /// </summary>
        /// <param name="t">표 컨트롤</param>
        private static void Table(ControlTable t)
        {
            var tbl = t.Table;
            tbl.RowCount = (ushort)t.RowList.Count;

            tbl.ClearCellCountOfRowList();
            foreach (var r in t.RowList)
            {
                tbl.AddCellCountOfRow(r.CellList.Count);
            }
        }

        /// <summary>
        /// 셀들을 자동 설정한다.
        /// </summary>
        /// <param name="t">표 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void Cells(ControlTable t, InstanceID iid)
        {
            foreach (var r in t.RowList)
            {
                foreach (var c in r.CellList)
                {
                    ListHeader(c);
                    ForParagraphList.AutoSet(c.ParagraphList, iid);
                }
            }
        }

        /// <summary>
        /// 셀의 리스트 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="c">셀 객체</param>
        private static void ListHeader(Cell c)
        {
            c.ListHeader.ParaCount = c.ParagraphList.ParagraphCount;
        }
    }
}

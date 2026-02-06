// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlTable.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Writer.BodyText.Control.Gso.Part;
using HwpLib.Writer.BodyText.Control.Tbl;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 표 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlTable
    {
        /// <summary>
        /// 표 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlTable t, CompoundStreamWriter sw)
        {
            ForCtrlHeaderGso.Write(t.Header, sw);

            sw.UpRecordLevel();

            ForCaption.Write(t.Caption, sw);
            ForTable.Write(t.Table, sw);
            Rows(t, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 표 컨트롤에 포함된 셀들을 쓴다.
        /// </summary>
        private static void Rows(ControlTable t, CompoundStreamWriter sw)
        {
            foreach (var r in t.RowList)
            {
                foreach (var c in r.CellList)
                {
                    ForCell.Write(c, sw);
                }
            }
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/TableCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Table;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 표 컨트롤을 복사하는 클래스
    /// </summary>
    public class TableCopier
    {
        /// <summary>
        /// 소스 <see cref="ControlTable"/>의 내용을 대상 <see cref="ControlTable"/>로 복사합니다.
        /// <para>
        /// 표의 헤더, 캡션, 테이블 속성, 행 및 셀의 내용을 모두 복사하며, <paramref name="docInfoAdder"/>가 제공될 경우
        /// 문서 정보(테두리, 스타일 등)도 함께 처리합니다.
        /// </para>
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="ControlTable"/> 인스턴스입니다.</param>
        /// <param name="target">내용이 복사될 대상 <see cref="ControlTable"/> 인스턴스입니다.</param>
        /// <param name="docInfoAdder">문서 정보 매핑을 위한 <see cref="DocInfoAdder"/> 인스턴스입니다. (null 허용)</param>
        public static void Copy(ControlTable source, ControlTable target, DocInfoAdder? docInfoAdder)
        {
            var sourceH = source.Header;
            var targetH = target.Header;
            targetH?.Copy(sourceH);

            CtrlDataCopier.Copy(source, target, docInfoAdder);
            CopyCaption(source, target, docInfoAdder);
            CopyTable(source.Table, target.Table, docInfoAdder);
            CopyRows(source, target, docInfoAdder);
        }

        private static void CopyCaption(ControlTable source, ControlTable target, DocInfoAdder? docInfoAdder)
        {
            if (source.Caption != null)
            {
                target.CreateCaption();
                CaptionCopier.Copy(source.Caption!, target.Caption!, docInfoAdder);
            }
            else
            {
                target.DeleteCaption();
            }
        }

        private static void CopyTable(Table? source, Table? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            if (target.Property != null && source.Property != null)
            {
                target.Property.Value = source.Property.Value;
            }
            target.RowCount = source.RowCount;
            target.ColumnCount = source.ColumnCount;
            target.CellSpacing = source.CellSpacing;
            target.LeftInnerMargin = source.LeftInnerMargin;
            target.RightInnerMargin = source.RightInnerMargin;
            target.TopInnerMargin = source.TopInnerMargin;
            target.BottomInnerMargin = source.BottomInnerMargin;

            foreach (var cellCountOfRow in source.CellCountOfRowList)
            {
                target.AddCellCountOfRow(cellCountOfRow);
            }

            target.BorderFillId = docInfoAdder == null ? source.BorderFillId : docInfoAdder.ForBorderFillInfo().ProcessById(source.BorderFillId);

            foreach (var zoneInfo in source.ZoneInfoList)
            {
                CopyZoneInfo(zoneInfo, target.AddNewZoneInfo(), docInfoAdder);
            }
        }

        private static void CopyZoneInfo(ZoneInfo source, ZoneInfo target, DocInfoAdder? docInfoAdder)
        {
            target.StartColumn = source.StartColumn;
            target.StartRow = source.StartRow;
            target.EndColumn = source.EndColumn;
            target.EndRow = source.EndRow;
            target.BorderFillId = docInfoAdder == null ? source.BorderFillId : docInfoAdder.ForBorderFillInfo().ProcessById(source.BorderFillId);
        }

        private static void CopyRows(ControlTable source, ControlTable target, DocInfoAdder? docInfoAdder)
        {
            foreach (var row in source.RowList)
            {
                CopyRow(row, target.AddNewRow(), docInfoAdder);
            }
        }

        private static void CopyRow(Row source, Row target, DocInfoAdder? docInfoAdder)
        {
            foreach (var cell in source.CellList)
            {
                CopyCell(cell, target.AddNewCell(), docInfoAdder);
            }
        }

        private static void CopyCell(Cell source, Cell target, DocInfoAdder? docInfoAdder)
        {
            CopyListHeader(source.ListHeader, target.ListHeader, docInfoAdder);
            ParagraphCopier.ListCopy(source.ParagraphList, target.ParagraphList, docInfoAdder);
        }

        private static void CopyListHeader(ListHeaderForCell? source, ListHeaderForCell? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.ParaCount = source.ParaCount;
            if (target.Property != null && source.Property != null)
            {
                target.Property.Value = source.Property.Value;
            }
            target.ColIndex = source.ColIndex;
            target.RowIndex = source.RowIndex;
            target.ColSpan = source.ColSpan;
            target.RowSpan = source.RowSpan;
            target.Width = source.Width;
            target.Height = source.Height;
            target.LeftMargin = source.LeftMargin;
            target.RightMargin = source.RightMargin;
            target.TopMargin = source.TopMargin;
            target.BottomMargin = source.BottomMargin;
            target.BorderFillId = docInfoAdder == null ? source.BorderFillId : docInfoAdder.ForBorderFillInfo().ProcessById(source.BorderFillId);
            target.TextWidth = source.TextWidth;
            target.FieldName = source.FieldName;
        }
    }
}

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Bookmark;
using HwpLib.Object.BodyText.Control.Table;
using HwpLib.Object.Etc;
using HwpLib.Reader.BodyText.Control;

namespace HwpLib.Reader.BodyText.Control.Tbl;

/// <summary>
/// 표의 셀을 읽기 위한 객체
/// </summary>
public static class ForCell
{
    /// <summary>
    /// 표의 셀을 읽는다.
    /// </summary>
    /// <param name="cell">표의 셀</param>
    /// <param name="sr">스트림 리더</param>
    public static void Read(Cell cell, CompoundStreamReader sr)
    {
        if (!sr.IsImmediatelyAfterReadingHeader)
        {
            sr.ReadRecordHeader();
        }
        if (sr.CurrentRecordHeader?.TagId == HWPTag.ListHeader)
        {
            ListHeader(cell.ListHeader, sr);
        }
        else
        {
            throw new InvalidOperationException("Cell's list header does not exist.");
        }
        ForParagraphList.Read(cell.ParagraphList, sr);
    }

    /// <summary>
    /// 셀의 문단 리스트 헤더 레코드를 읽는다.
    /// </summary>
    /// <param name="lh">셀의 문단 리스트 헤더 레코드</param>
    /// <param name="sr">스트림 리더</param>
    private static void ListHeader(ListHeaderForCell lh, CompoundStreamReader sr)
    {
        lh.ParaCount = sr.ReadSInt4();
        lh.Property.Value = sr.ReadUInt4();
        lh.ColIndex = sr.ReadUInt2();
        lh.RowIndex = sr.ReadUInt2();
        lh.ColSpan = sr.ReadUInt2();
        lh.RowSpan = sr.ReadUInt2();
        lh.Width = sr.ReadUInt4();
        lh.Height = sr.ReadUInt4();
        lh.LeftMargin = sr.ReadUInt2();
        lh.RightMargin = sr.ReadUInt2();
        lh.TopMargin = sr.ReadUInt2();
        lh.BottomMargin = sr.ReadUInt2();
        lh.BorderFillId = sr.ReadUInt2();
        lh.TextWidth = sr.ReadUInt4();

        if (sr.CurrentRecordHeader!.Size > (sr.CurrentPosition - sr.CurrentPositionAfterHeader))
        {
            byte flag = sr.ReadUInt1();
            if (flag == 0xff)
            {
                FieldName(lh, sr);
            }
            UnknownRestBytes(sr);
        }
    }

    /// <summary>
    /// 필드 이름을 읽는다.
    /// </summary>
    /// <param name="lh">셀의 문단 리스트 헤더 레코드</param>
    /// <param name="sr">스트림 리더</param>
    private static void FieldName(ListHeaderForCell lh, CompoundStreamReader sr)
    {
        var ps = new ParameterSet();
        ForParameterSet.Read(ps, sr);

        if (ps.Id == 0x21b)
        {
            foreach (var pi in ps.ParameterItemList)
            {
                if (pi.Id == 0x4000 && pi.Type == ParameterType.String)
                {
                    lh.FieldName = pi.Value_BSTR;
                }
            }
        }
    }

    /// <summary>
    /// 알려지지 않은 나머지 바이트를 처리한다.
    /// </summary>
    /// <param name="sr">스트림 리더</param>
    private static void UnknownRestBytes(CompoundStreamReader sr)
    {
        sr.SkipToEndRecord();
    }
}

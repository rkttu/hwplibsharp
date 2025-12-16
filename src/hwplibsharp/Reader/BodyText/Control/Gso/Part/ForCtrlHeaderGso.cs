using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Util.Binary;

namespace HwpLib.Reader.BodyText.Control.Gso.Part;

/// <summary>
/// 그리기 개체의 컨트롤 헤더 레코드를 읽기 위한 객체
/// </summary>
public static class ForCtrlHeaderGso
{
    /// <summary>
    /// 그리기 개체의 컨트롤 헤더 레코드를 읽는다.
    /// </summary>
    /// <param name="header">그리기 개체의 컨트롤 헤더 레코드</param>
    /// <param name="sr">스트림 리더</param>
    public static void Read(CtrlHeaderGso header, CompoundStreamReader sr)
    {
        header.Property.Value = sr.ReadUInt4();
        header.YOffset = sr.ReadUInt4();
        header.XOffset = sr.ReadUInt4();
        header.Width = sr.ReadUInt4();
        header.Height = sr.ReadUInt4();
        header.ZOrder = sr.ReadSInt4();
        header.OutterMarginLeft = sr.ReadUInt2();
        header.OutterMarginRight = sr.ReadUInt2();
        header.OutterMarginTop = sr.ReadUInt2();
        header.OutterMarginBottom = sr.ReadUInt2();
        header.InstanceId = sr.ReadUInt4();

        if (sr.IsEndOfRecord()) return;

        int temp = sr.ReadSInt4();
        header.PreventPageDivide = BitFlag.Get(temp, 0);

        if (sr.IsEndOfRecord()) return;

        header.Explanation.Bytes = sr.ReadHWPString();

        if (sr.IsEndOfRecord()) return;

        int length = (int)(sr.CurrentRecordHeader!.Size - (sr.CurrentPosition - sr.CurrentPositionAfterHeader));
        if (length > 0)
        {
            header.Unknown = sr.ReadBytes(length);
        }
    }
}

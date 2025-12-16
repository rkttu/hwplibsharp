using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso.Caption;

namespace HwpLib.Reader.BodyText.Control.Gso.Part;

/// <summary>
/// 캡션 정보를 읽기 위한 객체
/// </summary>
public static class ForCaption
{
    /// <summary>
    /// 캡션 정보를 읽는다.
    /// </summary>
    /// <param name="caption">캡션 정보</param>
    /// <param name="sr">스트림 리더</param>
    public static void Read(Caption caption, CompoundStreamReader sr)
    {
        ListHeader(caption.ListHeader, sr);
        ForParagraphList.Read(caption.ParagraphList, sr);
    }

    /// <summary>
    /// 캡션 정보의 문단 리스트 헤더 레코드를 읽는다.
    /// </summary>
    /// <param name="listHeader">캡션 정보의 문단 리스트 헤더 레코드</param>
    /// <param name="sr">스트림 리더</param>
    private static void ListHeader(ListHeaderForCaption listHeader, CompoundStreamReader sr)
    {
        listHeader.ParaCount = sr.ReadSInt4();
        listHeader.Property.Value = sr.ReadUInt4();
        listHeader.CaptionProperty.Value = sr.ReadUInt4();
        listHeader.CaptionWidth = sr.ReadUInt4();
        listHeader.SpaceBetweenCaptionAndFrame = sr.ReadUInt2();
        listHeader.TextWidth = sr.ReadUInt4();
        // 버전에 따라 8bytes가 있을 수 있음.
        sr.SkipToEndRecord();
    }
}

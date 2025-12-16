using HwpLib.CompoundFile;
using HwpLib.Object.BodyText;
using HwpLib.Object.Etc;
using HwpLib.Reader.BodyText.Paragraph;

namespace HwpLib.Reader.BodyText.Control;

/// <summary>
/// 문단 리스트를 읽는 객체 (캡션, 셀 등에서 사용)
/// </summary>
public static class ForParagraphList
{
    /// <summary>
    /// 문단 리스트를 읽는다.
    /// </summary>
    /// <param name="pli">문단 리스트 객체</param>
    /// <param name="sr">스트림 리더</param>
    public static void Read(IParagraphList pli, CompoundStreamReader sr)
    {
        sr.ReadRecordHeader();
        while (!sr.IsEndOfStream())
        {
            if (sr.CurrentRecordHeader?.TagId != HWPTag.ParaHeader)
            {
                break;
            }

            var para = pli.AddNewParagraph();
            ReadParagraph(para, sr);
            
            if (para.Header.LastInList)
            {
                break;
            }
        }
    }

    /// <summary>
    /// 문단을 읽는다.
    /// </summary>
    private static void ReadParagraph(Object.BodyText.Paragraph.Paragraph para, CompoundStreamReader sr)
    {
        // 문단 헤더 읽기
        ForParaHeader.Read(para.Header, sr);

        // 다음 레코드들을 읽기
        while (!sr.IsEndOfStream())
        {
            sr.ReadRecordHeader();
            if (sr.CurrentRecordHeader == null) break;

            var tagId = sr.CurrentRecordHeader.TagId;

            if (tagId == HWPTag.ParaText)
            {
                ForParaText.Read(para, sr);
            }
            else if (tagId == HWPTag.ParaCharShape)
            {
                if (para.CharShape == null) para.CreateCharShape();
                ForParaCharShape.Read(para.CharShape!, sr);
            }
            else if (tagId == HWPTag.ParaLineSeg)
            {
                if (para.LineSeg == null) para.CreateLineSeg();
                ForParaLineSeg.Read(para.LineSeg!, sr);
            }
            else if (tagId == HWPTag.ParaRangeTag)
            {
                if (para.RangeTag == null) para.CreateRangeTag();
                ForParaRangeTag.Read(para.RangeTag!, sr);
            }
            else if (tagId == HWPTag.ParaHeader)
            {
                // 다음 문단이 시작됨 - 중단
                break;
            }
            else if (tagId == HWPTag.CtrlHeader)
            {
                // 컨트롤 헤더를 만났을 때 - 셀/캡션 내에서 컨트롤 건너뛰기
                sr.SkipToEndRecord();
            }
            else if (tagId == HWPTag.ListHeader)
            {
                // 새로운 ListHeader - 다른 셀이나 캡션의 시작일 수 있음 - 중단
                break;
            }
            else if (tagId == HWPTag.Table)
            {
                // 표 정보 레코드 - 상위에서 처리해야 함 - 중단
                break;
            }
            else
            {
                // 기타 레코드는 건너뛰고 계속 읽기
                sr.SkipToEndRecord();
            }
        }
    }
}

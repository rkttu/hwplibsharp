using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;

namespace HwpLib.Reader.BodyText.Control;

/// <summary>
/// 필드 컨트롤을 읽기 위한 객체
/// </summary>
public static class ForControlField
{
    /// <summary>
    /// 필드 컨트롤 헤더를 읽는다.
    /// </summary>
    /// <param name="f">필드 컨트롤</param>
    /// <param name="sr">스트림 리더</param>
    public static void ReadCtrlHeader(ControlField f, CompoundStreamReader sr)
    {
        var h = f.GetHeader();
        if (h == null) return;

        h.Property.Value = sr.ReadUInt4();
        h.EtcProperty = (short)sr.ReadUInt1();
        h.Command.Bytes = sr.ReadHWPString();
        h.InstanceId = sr.ReadUInt4();

        // 추가 4바이트 읽기 (메모 인덱스 또는 예약 영역)
        if (!sr.IsEndOfRecord())
        {
            if (h.CtrlId == ControlType.FIELD_UNKNOWN.GetCtrlId())
            {
                h.MemoIndex = sr.ReadSInt4();
            }
            else
            {
                sr.Skip(4);
            }
        }

        // 레코드 끝까지 남은 바이트 건너뛰기
        sr.SkipToEndRecord();
    }

    /// <summary>
    /// 컨트롤 ID가 이미 읽힌 후 필드 컨트롤 헤더를 읽는다.
    /// </summary>
    /// <param name="f">필드 컨트롤</param>
    /// <param name="sr">스트림 리더</param>
    public static void ReadAfterCtrlId(ControlField f, CompoundStreamReader sr)
    {
        var h = f.GetHeader();
        if (h == null) return;

        h.Property.Value = sr.ReadUInt4();
        h.EtcProperty = (short)sr.ReadUInt1();
        h.Command.Bytes = sr.ReadHWPString();
        h.InstanceId = sr.ReadUInt4();

        // 추가 4바이트 읽기 (메모 인덱스 또는 예약 영역)
        if (!sr.IsEndOfRecord())
        {
            if (h.CtrlId == ControlType.FIELD_UNKNOWN.GetCtrlId())
            {
                h.MemoIndex = sr.ReadSInt4();
            }
            else
            {
                sr.Skip(4);
            }
        }

        // 레코드 끝까지 남은 바이트 건너뛰기
        sr.SkipToEndRecord();
    }
}

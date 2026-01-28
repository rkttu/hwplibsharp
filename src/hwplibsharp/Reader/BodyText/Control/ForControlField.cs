// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/ForControlField.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.Etc;


namespace HwpLib.Reader.BodyText.Control
{

    /// <summary>
    /// 필드 컨트롤을 읽기 위한 객체
    /// </summary>
    public static class ForControlField
    {
        /// <summary>
        /// 필드 컨트롤을 읽는다.
        /// </summary>
        /// <param name="f">필드 컨트롤</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(ControlField f, CompoundStreamReader sr)
        {
            ReadCtrlHeader(f, sr);
            ReadCtrlData(f, sr);
        }

        /// <summary>
        /// 필드 컨트롤의 컨트롤 헤더 레코드를 읽는다.
        /// </summary>
        /// <param name="f">필드 컨트롤</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadCtrlHeader(ControlField f, CompoundStreamReader sr)
        {
            var h = f.GetHeader();
            if (h == null) return;

            h.Property.Value = sr.ReadUInt4();
            h.EtcProperty = (short)sr.ReadUInt1();
            h.Command.Bytes = sr.ReadHWPString();
            h.InstanceId = sr.ReadUInt4();

            // 추가 4바이트 읽기 (메모 인덱스 또는 알 수 없는 값)
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

            // 레코드 끝까지 알 수 없는 바이트 스킵
            sr.SkipToEndRecord();
        }

        /// <summary>
        /// 컨트롤 데이터 레코드를 읽는다.
        /// </summary>
        /// <param name="f">필드 컨트롤</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadCtrlData(ControlField f, CompoundStreamReader sr)
        {
            if (sr.IsEndOfStream())
                return;

            if (!sr.ReadRecordHeader())
                return;

            var rh = sr.CurrentRecordHeader;
            if (rh != null && rh.TagId == HWPTag.CtrlData)
            {
                var ctrlData = ForCtrlData.Read(sr);
                f.SetCtrlData(ctrlData);
                sr.SkipToEndRecord();
            }
        }
    }

}
// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlHiddenComment.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.HiddenComment;
using HwpLib.Writer.BodyText.Paragraph;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 숨은 설명 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlHiddenComment
    {
        /// <summary>
        /// 숨은 설명 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlHiddenComment hc, CompoundStreamWriter sw)
        {
            CtrlHeader(hc.Header, sw);

            sw.UpRecordLevel();

            ForListHeaderForHiddenComment.Write(hc.ListHeader, sw);
            ForParagraphList.Write(hc.ParagraphList, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 숨은 설명 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(Object.BodyText.Control.CtrlHeader.CtrlHeader h, CompoundStreamWriter sw)
        {
            RecordHeader(sw);
            sw.WriteUInt4(h.CtrlId);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, 4);
        }
    }
}

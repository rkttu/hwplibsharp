// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlBookmark.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Bookmark;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 책갈피 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlBookmark
    {
        /// <summary>
        /// 책갈피 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlBookmark b, CompoundStreamWriter sw)
        {
            CtrlHeader(b.GetHeader()!, sw);

            sw.UpRecordLevel();

            ForCtrlData.Write(b.GetCtrlData(), sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 책갈피 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderBookmark h, CompoundStreamWriter sw)
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

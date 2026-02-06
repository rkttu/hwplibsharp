// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlColumnDefine.java
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
    /// 단 정의 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlColumnDefine
    {
        /// <summary>
        /// 단 정의 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlColumnDefine cd, CompoundStreamWriter sw)
        {
            CtrlHeader(cd.GetHeader()!, sw);

            sw.UpRecordLevel();

            ForCtrlData.Write(cd.GetCtrlData(), sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 단 정의 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderColumnDefine h, CompoundStreamWriter sw)
        {
            RecordHeader(h, sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteUInt2(h.Property.Value);

            int columnCount = h.Property.GetColumnCount();
            bool sameWidth = h.Property.IsSameWidth();
            if (columnCount < 2 || sameWidth == true)
            {
                sw.WriteUInt2(h.GapBetweenColumn);
                sw.WriteUInt2(h.Property2);
            }
            else
            {
                sw.WriteUInt2(h.Property2);
                ColumnInfos(h, sw);
            }

            sw.WriteUInt1((byte)h.DivideLine.Type);
            sw.WriteUInt1((byte)h.DivideLine.Thickness);
            sw.WriteUInt4(h.DivideLine.Color.Value);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CtrlHeaderColumnDefine h, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlHeader, GetSize(h));
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(CtrlHeaderColumnDefine h)
        {
            int size = 6;
            int columnCount = h.Property.GetColumnCount();
            bool sameWidth = h.Property.IsSameWidth();
            if (columnCount < 2 || sameWidth == true)
            {
                size += 4;
            }
            else
            {
                size += 2 + columnCount * 4;
            }
            size += 6;
            return size;
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 단 정보 부분을 쓴다.
        /// </summary>
        private static void ColumnInfos(CtrlHeaderColumnDefine h, CompoundStreamWriter sw)
        {
            foreach (var ci in h.ColumnInfoList)
            {
                sw.WriteUInt2(ci.Width);
                sw.WriteUInt2(ci.Gap);
            }
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlSectionDefine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Bookmark;
using HwpLib.Writer.BodyText.Control.Secd;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 구역 정의 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlSectionDefine
    {
        /// <summary>
        /// 구역 정의 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlSectionDefine sd, CompoundStreamWriter sw)
        {
            CtrlHeader(sd.Header, sw);

            sw.UpRecordLevel();

            CtrlData(sd, sw);
            ForPageDef.Write(sd.PageDef, sw);
            ForFootEndNoteShape.Write(sd.FootNoteShape, sw);
            ForFootEndNoteShape.Write(sd.EndNoteShape, sw);
            ForPageBorderFill.Write(sd.BothPageBorderFill, sw);
            ForPageBorderFill.Write(sd.EvenPageBorderFill, sw);
            ForPageBorderFill.Write(sd.OddPageBorderFill, sw);
            BatangPageInfoList(sd, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 구역 정의 컨트롤의 컨트롤 헤더 레코드를 쓴다.
        /// </summary>
        private static void CtrlHeader(CtrlHeaderSectionDefine h, CompoundStreamWriter sw)
        {
            RecordHeader(/*h, */sw);
            sw.WriteUInt4(h.CtrlId);

            sw.WriteUInt4(h.Property.Value);
            sw.WriteUInt2(h.ColumnGap);
            sw.WriteUInt2(h.VerticalLineAlign);
            sw.WriteUInt2(h.HorizontalLineAlign);
            sw.WriteUInt4(h.DefaultTabGap);
            sw.WriteUInt2(sw.CorrectParaShapeId(sw.CorrectParaShapeId(h.NumberParaShapeId)));
            sw.WriteUInt2(h.PageStartNumber);
            sw.WriteUInt2(h.ImageStartNumber);
            sw.WriteUInt2(h.TableStartNumber);
            sw.WriteUInt2(h.EquationStartNumber);
            if (sw.FileVersion.IsOver(5, 0, 1, 2))
            {
                sw.WriteUInt2(h.DefaultLanguage);
            }
            sw.WriteZero(8);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(/*CtrlHeaderSectionDefine h, */CompoundStreamWriter sw)
        {
            int size = sw.FileVersion.IsOver(5, 0, 1, 2) ? 38 : 36;
            sw.WriteRecordHeader(HWPTag.CtrlHeader, size);
        }

        /// <summary>
        /// 바탕쪽 정보를 쓴다.
        /// </summary>
        private static void BatangPageInfoList(ControlSectionDefine sd, CompoundStreamWriter sw)
        {
            foreach (var bpi in sd.BatangPageInfoList)
            {
                ForBatangPageInfo.Write(bpi, sw);
            }
        }

        /// <summary>
        /// 컨트롤 데이터를 쓴다.
        /// </summary>
        private static void CtrlData(ControlSectionDefine sd, CompoundStreamWriter sw)
        {
            if (sd.GetCtrlData() != null)
            {
                ForCtrlData.Write(sd.GetCtrlData(), sw);
            }
        }
    }
}

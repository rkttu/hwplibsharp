// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlRectangle.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Bookmark;
using HwpLib.Writer.BodyText.Control.Gso.Part;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// 사각형 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlRectangle
    {
        /// <summary>
        /// 사각형 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlRectangle rect, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            CtrlData(rect, sw);
            ForTextBox.Write(rect.TextBox, sw);
            ShapeComponentRectangle(rect.ShapeComponentRectangle, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 컨트롤 데이터 레코드를 쓴다.
        /// </summary>
        private static void CtrlData(ControlRectangle rect, CompoundStreamWriter sw)
        {
            if (rect.GetCtrlData() != null)
            {
                ForCtrlData.Write(rect.GetCtrlData(), sw);
            }
        }

        /// <summary>
        /// 사각형 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentRectangle(ShapeComponentRectangle scr, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt1((sbyte)scr.RoundRate);
            sw.WriteSInt4(scr.X1);
            sw.WriteSInt4(scr.Y1);
            sw.WriteSInt4(scr.X2);
            sw.WriteSInt4(scr.Y2);
            sw.WriteSInt4(scr.X3);
            sw.WriteSInt4(scr.Y3);
            sw.WriteSInt4(scr.X4);
            sw.WriteSInt4(scr.Y4);
        }

        /// <summary>
        /// 사각형 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentRectangle, 33);
        }
    }
}

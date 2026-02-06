// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlEllipse.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Gso.Part;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// 타원 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlEllipse
    {
        /// <summary>
        /// 타원 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlEllipse ell, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ForTextBox.Write(ell.TextBox, sw);
            ShapeComponentEllipse(ell.ShapeComponentEllipse, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 타원 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentEllipse(ShapeComponentEllipse sce, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteUInt4(sce.Property.Value);
            sw.WriteSInt4(sce.CenterX);
            sw.WriteSInt4(sce.CenterY);
            sw.WriteSInt4(sce.Axis1X);
            sw.WriteSInt4(sce.Axis1Y);
            sw.WriteSInt4(sce.Axis2X);
            sw.WriteSInt4(sce.Axis2Y);
            sw.WriteSInt4(sce.StartX);
            sw.WriteSInt4(sce.StartY);
            sw.WriteSInt4(sce.EndX);
            sw.WriteSInt4(sce.EndY);
            sw.WriteSInt4(sce.StartX2);
            sw.WriteSInt4(sce.StartY2);
            sw.WriteSInt4(sce.EndX2);
            sw.WriteSInt4(sce.EndY2);
        }

        /// <summary>
        /// 타원 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentEllipse, 60);
        }
    }
}

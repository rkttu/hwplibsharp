// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlArc.java
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
    /// 호 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlArc
    {
        /// <summary>
        /// 호 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlArc arc, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ForTextBox.Write(arc.TextBox, sw);
            ShapeComponentArc(arc.ShapeComponentArc, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 호 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentArc(ShapeComponentArc sca, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteUInt1((byte)sca.ArcType);
            sw.WriteSInt4(sca.CenterX);
            sw.WriteSInt4(sca.CenterY);
            sw.WriteSInt4(sca.Axis1X);
            sw.WriteSInt4(sca.Axis1Y);
            sw.WriteSInt4(sca.Axis2X);
            sw.WriteSInt4(sca.Axis2Y);
        }

        /// <summary>
        /// 호 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentArc, 25);
        }
    }
}

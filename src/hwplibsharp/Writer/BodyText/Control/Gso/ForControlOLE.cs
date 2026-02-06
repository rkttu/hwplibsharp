// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlOLE.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// OLE 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlOLE
    {
        /// <summary>
        /// OLE 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlOLE ole, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ShapeComponentOLE(ole.ShapeComponentOLE, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// OLE 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentOLE(ShapeComponentOLE sco, CompoundStreamWriter sw)
        {
            RecordHeader(sw, sco);

            sw.WriteUInt4(sco.Property.Value);
            sw.WriteSInt4(sco.ExtentWidth);
            sw.WriteSInt4(sco.ExtentHeight);
            sw.WriteUInt2(sco.BinDataId);
            sw.WriteUInt4(sco.BorderColor.Value);
            sw.WriteSInt4(sco.BorderThickness);
            sw.WriteUInt4(sco.BorderProperty.Value);
            if (sco.Unknown != null)
            {
                sw.WriteBytes(sco.Unknown);
            }
        }

        /// <summary>
        /// OLE 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw, ShapeComponentOLE sco)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentOle, GetSize(sco));
        }

        private static long GetSize(ShapeComponentOLE sco)
        {
            if (sco.Unknown != null)
            {
                return 26 + sco.Unknown.Length;
            }
            return 26;
        }
    }
}

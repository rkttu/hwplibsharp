// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlPolygon.java
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
    /// 다각형 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlPolygon
    {
        /// <summary>
        /// 다각형 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlPolygon poly, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ForTextBox.Write(poly.TextBox, sw);
            ShapeComponentPolygon(poly.ShapeComponentPolygon, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 다각형 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentPolygon(ShapeComponentPolygon scp, CompoundStreamWriter sw)
        {
            RecordHeader(scp, sw);

            sw.WriteSInt4(scp.PositionList.Count);
            foreach (var p in scp.PositionList)
            {
                sw.WriteSInt4((int)p.X);
                sw.WriteSInt4((int)p.Y);
            }
            sw.WriteZero(4);
        }

        /// <summary>
        /// 다각형 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ShapeComponentPolygon scp, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentPolygon, GetSize(scp));
        }

        /// <summary>
        /// 다각형 개체 속성 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ShapeComponentPolygon scp)
        {
            int size = 0;
            size += 4;
            size += 8 * scp.PositionList.Count;
            size += 4;
            return size;
        }
    }
}

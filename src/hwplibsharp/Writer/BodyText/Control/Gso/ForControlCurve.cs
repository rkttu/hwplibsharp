// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlCurve.java
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
    /// 곡선 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlCurve
    {
        /// <summary>
        /// 곡선 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlCurve curv, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ForTextBox.Write(curv.TextBox, sw);
            ShapeComponentCurve(curv.ShapeComponentCurve, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 곡선 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentCurve(ShapeComponentCurve scc, CompoundStreamWriter sw)
        {
            RecordHeader(scc, sw);

            int positionCount = scc.PositionList.Count;
            sw.WriteSInt4(positionCount);
            foreach (var p in scc.PositionList)
            {
                sw.WriteSInt4((int)p.X);
                sw.WriteSInt4((int)p.Y);
            }
            for (int index = 0; index < positionCount - 1; index++)
            {
                var cst = scc.SegmentTypeList[index];
                sw.WriteUInt1((byte)cst);
            }
            sw.WriteZero(4);
        }

        /// <summary>
        /// 곡선 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ShapeComponentCurve scc, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentCurve, GetSize(scc));
        }

        /// <summary>
        /// 곡선 개체 속성 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ShapeComponentCurve scc)
        {
            int size = 0;
            size += 4;
            size += scc.PositionList.Count * 8;
            size += scc.PositionList.Count - 1;
            size += 4;
            return size;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlObjectLinkLine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// 객체 연결선 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlObjectLinkLine
    {
        /// <summary>
        /// 객체 연결선 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlObjectLinkLine oll, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ShapeComponentLine(oll.ShapeComponentLine, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 선 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentLine(ShapeComponentLineForObjectLinkLine scl, CompoundStreamWriter sw)
        {
            RecordHeader(sw, scl);

            sw.WriteSInt4(scl.StartX);
            sw.WriteSInt4(scl.StartY);
            sw.WriteSInt4(scl.EndX);
            sw.WriteSInt4(scl.EndY);
            sw.WriteUInt4((uint)scl.Type);
            sw.WriteUInt4(scl.StartSubjectID);
            sw.WriteUInt4(scl.StartSubjectIndex);
            sw.WriteUInt4(scl.EndSubjectID);
            sw.WriteUInt4(scl.EndSubjectIndex);

            sw.WriteUInt4((uint)scl.ControlPoints.Count);
            foreach (var cp in scl.ControlPoints)
            {
                sw.WriteUInt4(cp.X);
                sw.WriteUInt4(cp.Y);
                sw.WriteUInt2(cp.Type);
            }

            sw.WriteZero(4);
        }

        /// <summary>
        /// 선 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw, ShapeComponentLineForObjectLinkLine scl)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentLine, GetSize(scl));
        }

        /// <summary>
        /// 선 개체 속성 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ShapeComponentLineForObjectLinkLine scl)
        {
            return 40 + scl.ControlPoints.Count * 10 + 4;
        }
    }
}

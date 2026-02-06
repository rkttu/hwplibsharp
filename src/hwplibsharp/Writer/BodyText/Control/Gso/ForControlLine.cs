// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlLine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// 선 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlLine
    {
        /// <summary>
        /// 선 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlLine line, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ShapeComponentLine(line.ShapeComponentLine, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 선 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentLine(ShapeComponentLine scl, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt4(scl.StartX);
            sw.WriteSInt4(scl.StartY);
            sw.WriteSInt4(scl.EndX);
            sw.WriteSInt4(scl.EndY);
            sw.WriteSInt4(GetStartedRightOrBottom(scl));
        }

        /// <summary>
        /// 선 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentLine, 20);
        }

        /// <summary>
        /// 오른쪽/아래쪽 시작인지 여부에 대한 값을 반환한다.
        /// </summary>
        private static int GetStartedRightOrBottom(ShapeComponentLine scl)
        {
            int temp = 0;
            if (scl.IsStartedRightOrBottom)
            {
                temp = 1;
            }
            return temp;
        }
    }
}

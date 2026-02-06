// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/part/shapecomponent/ForShapeComponentForContainer.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Gso.Part.ShapeComponent
{

    /// <summary>
    /// 묶음 컨트롤의 객체 공통 속성 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForShapeComponentForContainer
    {
        /// <summary>
        /// 묶음 컨트롤의 객체 공통 속성 레코드를 쓴다.
        /// </summary>
        public static void Write(ShapeComponentContainer scc, CompoundStreamWriter sw)
        {
            RecordHeader(scc, sw);

            GsoCtrlId(scc, sw);
            CommonPart_(scc, sw);
            ChildInfo(scc, sw);
            sw.WriteUInt4(scc.Instid);
        }

        /// <summary>
        /// 객체 공통 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ShapeComponentContainer scc, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponent, GetSize(scc));
        }

        /// <summary>
        /// 객체 공통 속성 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ShapeComponentContainer scc)
        {
            int size = 0;
            size += 8;
            size += CommonPart.GetSize(scc);

            size += 2;
            size += 4 * scc.ChildControlIdList.Count;

            size += 4;
            return size;
        }

        /// <summary>
        /// 그리기 객체 컨트롤 아이디를 쓴다.
        /// </summary>
        private static void GsoCtrlId(ShapeComponentContainer scc, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(scc.GsoId);
            sw.WriteUInt4(scc.GsoId);
        }

        /// <summary>
        /// 객체 공통 속성 레코드의 공통 부분을 쓴다.
        /// </summary>
        private static void CommonPart_(Object.BodyText.Control.Gso.ShapeComponent.ShapeComponent sc, CompoundStreamWriter sw)
        {
            CommonPart.Write(sc, sw);
        }

        /// <summary>
        /// 묶음 컨트롤이 포함하는 컨트롤들에 대한 정보를 쓴다.
        /// </summary>
        private static void ChildInfo(ShapeComponentContainer scc, CompoundStreamWriter sw)
        {
            int count = scc.ChildControlIdList.Count;
            sw.WriteUInt2((ushort)count);

            foreach (var childId in scc.ChildControlIdList)
            {
                sw.WriteUInt4(childId);
            }
        }

        /// <summary>
        /// 묶음 컨트롤에 포함되어 있는 묶음 컨트롤의 객체 공통 속성 레코드를 쓴다.
        /// </summary>
        public static void WriteInContainer(ShapeComponentContainer scc, CompoundStreamWriter sw)
        {
            RecordHeaderInContainer(scc, sw);

            GsoCtrlIdInContainer(scc, sw);
            CommonPart_(scc, sw);
            ChildInfo(scc, sw);
            sw.WriteZero(4);
        }

        /// <summary>
        /// 묶음 컨트롤에 포함되어 있는 묶음 컨트롤의 객체 공통 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeaderInContainer(ShapeComponentContainer scc, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponent, GetSize(scc) - 4);
        }

        /// <summary>
        /// 묶음 컨트롤에 포함되어 있는 묶음 컨트롤의 그리기 객체 컨트롤 아이디를 쓴다.
        /// </summary>
        private static void GsoCtrlIdInContainer(ShapeComponentContainer scc, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(scc.GsoId);
        }
    }
}

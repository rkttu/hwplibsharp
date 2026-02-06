// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/part/shapecomponent/ForShapeComponentForNormal.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent.ShadowInfo;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Object.Etc;
using HwpLib.Writer.DocInfo.BorderFill;

namespace HwpLib.Writer.BodyText.Control.Gso.Part.ShapeComponent
{
    /// <summary>
    /// 묶음 컨트롤이 아닌 일반 컨트롤의 객체 공통 속성 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForShapeComponentForNormal
    {
        /// <summary>
        /// 일반 컨트롤의 객체 공통 속성 레코드를 쓴다.
        /// </summary>
        public static void Write(ShapeComponentNormal scn, CompoundStreamWriter sw)
        {
            RecordHeader(scn, sw);

            GsoCtrlId(scn, sw);
            CommonPart.Write(scn, sw);
            LineInfo(scn.LineInfo, sw);
            FillInfo(scn.FillInfo, sw);
            ShadowInfo(scn.ShadowInfo, sw);
            Rest(scn, sw);
        }

        /// <summary>
        /// 객체 공통 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ShapeComponentNormal scn, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponent, GetSize(scn));
        }

        /// <summary>
        /// 객체 공통 속성 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ShapeComponentNormal scn)
        {
            int size = 0;
            size += 8;
            size += CommonPart.GetSize(scn);
            if (scn.LineInfo != null)
            {
                size += 13;
            }
            if (scn.FillInfo != null)
            {
                size += ForFillInfo.GetSize(scn.FillInfo);
            }
            if (scn.ShadowInfo != null)
            {
                size += 22;
            }

            return size;
        }

        /// <summary>
        /// 그리기 객체 컨트롤 아이디를 쓴다.
        /// </summary>
        private static void GsoCtrlId(ShapeComponentNormal scn, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(scn.GsoId);
            sw.WriteUInt4(scn.GsoId);
        }

        /// <summary>
        /// line 정보를 쓴다.
        /// </summary>
        private static void LineInfo(LineInfo? li, CompoundStreamWriter sw)
        {
            if (li != null)
            {
                sw.WriteUInt4(li.Color.Value);
                sw.WriteSInt4(li.Thickness);
                sw.WriteUInt4(li.Property.Value);
                sw.WriteUInt1((byte)li.OutlineStyle);
            }
        }

        /// <summary>
        /// 배경 정보를 쓴다.
        /// </summary>
        private static void FillInfo(FillInfo? fi, CompoundStreamWriter sw)
        {
            if (fi != null)
            {
                ForFillInfo.Write(fi, sw);
            }
        }

        /// <summary>
        /// 그림자 정보를 쓴다.
        /// </summary>
        private static void ShadowInfo(ShadowInfo? si, CompoundStreamWriter sw)
        {
            if (si != null)
            {
                sw.WriteUInt4((uint)si.Type);
                sw.WriteUInt4(si.Color.Value);
                sw.WriteSInt4(si.OffsetX);
                sw.WriteSInt4(si.OffsetY);
            }
        }

        private static void Rest(ShapeComponentNormal scn, CompoundStreamWriter sw)
        {
            if (scn.ShadowInfo != null)
            {
                sw.WriteUInt4(scn.Instid);
                sw.WriteZero(1);
                sw.WriteUInt1(scn.ShadowInfo.Transparent);
            }
        }

        /// <summary>
        /// 묶음 컨트롤에 포함되어 있는 일반 컨트롤의 객체 공통 속성 레코드를 쓴다.
        /// </summary>
        public static void WriteInContainer(ShapeComponentNormal scn, CompoundStreamWriter sw)
        {
            RecordHeaderInContainer(scn, sw);

            GsoCtrlIdInContainer(scn, sw);
            CommonPart.Write(scn, sw);
            LineInfo(scn.LineInfo, sw);
            FillInfo(scn.FillInfo, sw);
            ShadowInfo(scn.ShadowInfo, sw);
            Rest(scn, sw);
        }

        /// <summary>
        /// 묶음 컨트롤에 포함되어 있는 일반 컨트롤의 객체 공통 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeaderInContainer(ShapeComponentNormal scn, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponent, GetSize(scn) - 4);
        }

        /// <summary>
        /// 묶음 컨트롤에 포함되어 있는 일반 컨트롤의 그리기 객체 컨트롤 아이디를 쓴다.
        /// </summary>
        private static void GsoCtrlIdInContainer(ShapeComponentNormal scn, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(scn.GsoId);
        }
    }
}

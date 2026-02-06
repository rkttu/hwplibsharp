// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForGsoControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent;
using HwpLib.Writer.BodyText.Control.Gso.Part;
using HwpLib.Writer.BodyText.Control.Gso.Part.ShapeComponent;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// 그리기 개체 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForGsoControl
    {
        /// <summary>
        /// 그리기 개체 컨트롤을 쓴다.
        /// </summary>
        public static void Write(GsoControl gso, CompoundStreamWriter sw)
        {
            ForCtrlHeaderGso.Write(gso.GetHeader()!, sw);

            sw.UpRecordLevel();

            ForCaption.Write(gso.Caption, sw);
            ShapeComponent(gso, sw);
            RestPart(gso, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 그리기 개체 컨트롤의 객체 공통 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponent(GsoControl gso, CompoundStreamWriter sw)
        {
            if (gso.GsoType == GsoControlType.Container)
            {
                ForShapeComponentForContainer.Write(
                    (ShapeComponentContainer)gso.ShapeComponent, sw);
            }
            else
            {
                ForShapeComponentForNormal.Write(
                    (ShapeComponentNormal)gso.ShapeComponent, sw);
            }
        }

        /// <summary>
        /// 그리기 개체 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        private static void RestPart(GsoControl gso, CompoundStreamWriter sw)
        {
            switch (gso.GsoType)
            {
                case GsoControlType.Line:
                    ForControlLine.WriteRest((ControlLine)gso, sw);
                    break;
                case GsoControlType.Rectangle:
                    ForControlRectangle.WriteRest((ControlRectangle)gso, sw);
                    break;
                case GsoControlType.Ellipse:
                    ForControlEllipse.WriteRest((ControlEllipse)gso, sw);
                    break;
                case GsoControlType.Arc:
                    ForControlArc.WriteRest((ControlArc)gso, sw);
                    break;
                case GsoControlType.Polygon:
                    ForControlPolygon.WriteRest((ControlPolygon)gso, sw);
                    break;
                case GsoControlType.Curve:
                    ForControlCurve.WriteRest((ControlCurve)gso, sw);
                    break;
                case GsoControlType.Picture:
                    ForControlPicture.WriteRest((ControlPicture)gso, sw);
                    break;
                case GsoControlType.OLE:
                    ForControlOLE.WriteRest((ControlOLE)gso, sw);
                    break;
                case GsoControlType.Container:
                    ForControlContainer.WriteRest((ControlContainer)gso, sw);
                    break;
                case GsoControlType.ObjectLinkLine:
                    ForControlObjectLinkLine.WriteRest((ControlObjectLinkLine)gso, sw);
                    break;
                case GsoControlType.TextArt:
                    ForControlTextArt.WriteRest((ControlTextArt)gso, sw);
                    break;
            }
        }

        /// <summary>
        /// 묶음 컨트롤 안에 있는 컨트롤을 쓴다.
        /// </summary>
        public static void WriteInContainer(GsoControl child, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ShapeComponentInContainer(child, sw);
            RestPart(child, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 묶음 컨트롤 안에 있는 컨트롤의 객체 공통 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentInContainer(GsoControl child, CompoundStreamWriter sw)
        {
            if (child.GsoType == GsoControlType.Container)
            {
                ForShapeComponentForContainer.WriteInContainer(
                    (ShapeComponentContainer)child.ShapeComponent, sw);
            }
            else
            {
                ForShapeComponentForNormal.WriteInContainer(
                    (ShapeComponentNormal)child.ShapeComponent, sw);
            }
        }
    }
}

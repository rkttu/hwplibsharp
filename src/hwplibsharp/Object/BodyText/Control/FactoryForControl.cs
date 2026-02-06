// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/FactoryForControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 컨트롤을 생성하는 객체
    /// </summary>
    public static class FactoryForControl
    {
        /// <summary>
        /// 컨트롤 id에 해당되는 컨트롤을 생성한다.
        /// </summary>
        /// <param name="ctrlId">컨트롤 id</param>
        /// <returns>새로 생성된 컨트롤</returns>
        public static Control? Create(uint ctrlId)
        {
            if (ctrlId == ControlType.SectionDefine.GetCtrlId())
            {
                return new ControlSectionDefine();
            }
            else if (ctrlId == ControlType.ColumnDefine.GetCtrlId())
            {
                return new ControlColumnDefine();
            }
            else if (ctrlId == ControlType.Table.GetCtrlId())
            {
                return new ControlTable();
            }
            else if (ctrlId == ControlType.Equation.GetCtrlId())
            {
                return new ControlEquation();
            }
            else if (ctrlId == ControlType.Header.GetCtrlId())
            {
                return new ControlHeader();
            }
            else if (ctrlId == ControlType.Footer.GetCtrlId())
            {
                return new ControlFooter();
            }
            else if (ctrlId == ControlType.Footnote.GetCtrlId())
            {
                return new ControlFootnote();
            }
            else if (ctrlId == ControlType.Endnote.GetCtrlId())
            {
                return new ControlEndnote();
            }
            else if (ctrlId == ControlType.AutoNumber.GetCtrlId())
            {
                return new ControlAutoNumber();
            }
            else if (ctrlId == ControlType.NewNumber.GetCtrlId())
            {
                return new ControlNewNumber();
            }
            else if (ctrlId == ControlType.PageHide.GetCtrlId())
            {
                return new ControlPageHide();
            }
            else if (ctrlId == ControlType.PageOddEvenAdjust.GetCtrlId())
            {
                return new ControlPageOddEvenAdjust();
            }
            else if (ctrlId == ControlType.PageNumberPosition.GetCtrlId())
            {
                return new ControlPageNumberPosition();
            }
            else if (ctrlId == ControlType.IndexMark.GetCtrlId())
            {
                return new ControlIndexMark();
            }
            else if (ctrlId == ControlType.Bookmark.GetCtrlId())
            {
                return new ControlBookmark();
            }
            else if (ctrlId == ControlType.OverlappingLetter.GetCtrlId())
            {
                return new ControlOverlappingLetter();
            }
            else if (ctrlId == ControlType.AdditionalText.GetCtrlId())
            {
                return new ControlAdditionalText();
            }
            else if (ctrlId == ControlType.HiddenComment.GetCtrlId())
            {
                return new ControlHiddenComment();
            }
            else if (ControlTypeExtensions.IsField(ctrlId))
            {
                return new ControlField(ctrlId);
            }
            return null;
        }

        /// <summary>
        /// 양식 컨트롤을 생성한다.
        /// </summary>
        /// <param name="header">그리기 객체용 컨트롤 헤더</param>
        /// <returns>새로 생성된 양식 컨트롤</returns>
        public static ControlForm CreateFormControl(CtrlHeaderGso header)
        {
            return new ControlForm(header);
        }

        /// <summary>
        /// 그리기 객체 아이디(gsoId)에 해당되는 그리기 객체 컨트롤을 새로 생성한다.
        /// </summary>
        /// <param name="gsoId">그리기 객체 아이디</param>
        /// <param name="header">그리기 객체용 컨트롤 헤더</param>
        /// <returns>새로 생성된 그리기 객체 컨트롤</returns>
        public static GsoControl? CreateGso(uint gsoId, CtrlHeaderGso header)
        {
            if (gsoId == GsoControlType.Line.GetId())
            {
                return new ControlLine(header);
            }
            else if (gsoId == GsoControlType.Rectangle.GetId())
            {
                return new ControlRectangle(header);
            }
            else if (gsoId == GsoControlType.Ellipse.GetId())
            {
                return new ControlEllipse(header);
            }
            else if (gsoId == GsoControlType.Polygon.GetId())
            {
                return new ControlPolygon(header);
            }
            else if (gsoId == GsoControlType.Arc.GetId())
            {
                return new ControlArc(header);
            }
            else if (gsoId == GsoControlType.Curve.GetId())
            {
                return new ControlCurve(header);
            }
            else if (gsoId == GsoControlType.Picture.GetId())
            {
                return new ControlPicture(header);
            }
            else if (gsoId == GsoControlType.OLE.GetId())
            {
                return new ControlOLE(header);
            }
            else if (gsoId == GsoControlType.Container.GetId())
            {
                return new ControlContainer(header);
            }
            else if (gsoId == GsoControlType.ObjectLinkLine.GetId())
            {
                return new ControlObjectLinkLine(header);
            }
            else if (gsoId == GsoControlType.TextArt.GetId())
            {
                return new ControlTextArt(header);
            }
            else
            {
                return new ControlUnknown(header);
            }
        }
    }
}

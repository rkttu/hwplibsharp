// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/gso/ForGsoControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.TextBox;
using HwpLib.Writer.AutoSetter.Control.Gso.Part;

namespace HwpLib.Writer.AutoSetter.Control.Gso
{
    /// <summary>
    /// 각각의 그리기 개체 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForGsoControl
    {
        /// <summary>
        /// 그리기 개체 컨트롤를 자동 설정한다.
        /// </summary>
        /// <param name="gc">그리기 개체 컨트롤</param>
        /// <param name="iid">인스턴스 아이디</param>
        public static void AutoSet(GsoControl gc, InstanceID iid)
        {
            ForCtrlHeaderGso.AutoSet(gc.GetHeader(), gc.Caption, iid);
            ForCaption.AutoSet(gc.Caption, iid);
            RestPart(gc, iid);
        }

        /// <summary>
        /// 그리기 개체 컨트롤 별의 나머지 부분을 자동 설정한다.
        /// </summary>
        /// <param name="gc">그리기 개체 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void RestPart(GsoControl gc, InstanceID iid)
        {
            switch (gc.GsoType)
            {
                case GsoControlType.Arc:
                    Arc((ControlArc)gc, iid);
                    break;
                case GsoControlType.Container:
                    Container((ControlContainer)gc, iid);
                    break;
                case GsoControlType.Curve:
                    Curve((ControlCurve)gc, iid);
                    break;
                case GsoControlType.Ellipse:
                    Ellipse((ControlEllipse)gc, iid);
                    break;
                case GsoControlType.Line:
                    break;
                case GsoControlType.OLE:
                    break;
                case GsoControlType.Picture:
                    break;
                case GsoControlType.Polygon:
                    Polygon((ControlPolygon)gc, iid);
                    break;
                case GsoControlType.Rectangle:
                    Rectangle((ControlRectangle)gc, iid);
                    break;
                case GsoControlType.ObjectLinkLine:
                    break;
                case GsoControlType.TextArt:
                    break;
            }
        }

        /// <summary>
        /// 호 컨트롤의 나머지 부분을 자동 설정한다.
        /// </summary>
        /// <param name="arc">호 개체 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void Arc(ControlArc arc, InstanceID iid)
        {
            TextBox(arc.TextBox, iid);
        }

        /// <summary>
        /// 글상자를 자동 설정한다.
        /// </summary>
        /// <param name="tb">글상자 객체</param>
        /// <param name="iid">인스턴스 id</param>
        private static void TextBox(TextBox? tb, InstanceID iid)
        {
            if (tb == null)
            {
                return;
            }

            ListHeader(tb);
            ForParagraphList.AutoSet(tb.ParagraphList, iid);
        }

        /// <summary>
        /// 글상자의 리스트 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="tb">글상자</param>
        private static void ListHeader(TextBox tb)
        {
            tb.ListHeader.ParaCount = tb.ParagraphList.ParagraphCount;
        }

        /// <summary>
        /// 묶음 컨트롤의 나머지 부분을 자동 설정한다.
        /// </summary>
        /// <param name="cont">묶음 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void Container(ControlContainer cont, InstanceID iid)
        {
            ForControlContainer.AutoSet(cont, iid);
        }

        /// <summary>
        /// 곡선 컨트롤의 나머지 부분을 자동 설정한다.
        /// </summary>
        /// <param name="curv">곡선 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void Curve(ControlCurve curv, InstanceID iid)
        {
            TextBox(curv.TextBox, iid);
        }

        /// <summary>
        /// 타원 컨트롤의 나머지 부분을 자동 설정한다.
        /// </summary>
        /// <param name="ell">타원 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void Ellipse(ControlEllipse ell, InstanceID iid)
        {
            TextBox(ell.TextBox, iid);
        }

        /// <summary>
        /// 다각형 컨트롤의 나머지 부분을 자동 설정한다.
        /// </summary>
        /// <param name="poly">다각형 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void Polygon(ControlPolygon poly, InstanceID iid)
        {
            TextBox(poly.TextBox, iid);
        }

        /// <summary>
        /// 사각형 컨트롤의 나머지 부분을 자동 설정한다.
        /// </summary>
        /// <param name="rect">사각형 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void Rectangle(ControlRectangle rect, InstanceID iid)
        {
            TextBox(rect.TextBox, iid);
        }
    }
}

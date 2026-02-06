// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/ForGso.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.TextBox;
using HwpLib.Tool.TextExtractor.ParaHead;
using System.Text;

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 그리기 개체를 위한 텍스트 추출기 객체
    /// </summary>
    public static class ForGso
    {
        /// <summary>
        /// 그리기 개체에서 텍스트를 추출한다.
        /// </summary>
        public static void Extract(GsoControl? gc,
                                   TextExtractMethod tem,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            Extract(gc, new TextExtractOption(tem), paraHeadMaker, sb);
        }

        /// <summary>
        /// 그리기 개체에서 텍스트를 추출한다.
        /// </summary>
        public static void Extract(GsoControl? gc,
                                   TextExtractOption option,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            if (gc == null) return;

            switch (gc.GsoType)
            {
                case GsoControlType.Line:
                    break;
                case GsoControlType.Rectangle:
                    Rectangle((ControlRectangle)gc, option, paraHeadMaker, sb);
                    break;
                case GsoControlType.Ellipse:
                    Ellipse((ControlEllipse)gc, option, paraHeadMaker, sb);
                    break;
                case GsoControlType.Arc:
                    Arc((ControlArc)gc, option, paraHeadMaker, sb);
                    break;
                case GsoControlType.Polygon:
                    Polygon((ControlPolygon)gc, option, paraHeadMaker, sb);
                    break;
                case GsoControlType.Curve:
                    Curve((ControlCurve)gc, option, paraHeadMaker, sb);
                    break;
                case GsoControlType.Picture:
                    break;
                case GsoControlType.OLE:
                    break;
                case GsoControlType.Container:
                    Container((ControlContainer)gc, option, paraHeadMaker, sb);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 사각형 개체에서 텍스트를 추출한다.
        /// </summary>
        private static void Rectangle(ControlRectangle rectangle,
                                      TextExtractOption option,
                                      ParaHeadMaker? paraHeadMaker,
                                      StringBuilder sb)
        {
            TextBoxExtract(rectangle.TextBox, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 글상자 객체에서 텍스트를 추출한다.
        /// </summary>
        private static void TextBoxExtract(TextBox? textBox,
                                           TextExtractOption option,
                                           ParaHeadMaker? paraHeadMaker,
                                           StringBuilder sb)
        {
            if (textBox == null)
            {
                return;
            }

            ForParagraphList.Extract(textBox.ParagraphList, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 타원 개체에서 텍스트를 추출한다.
        /// </summary>
        private static void Ellipse(ControlEllipse ellipse,
                                    TextExtractOption option,
                                    ParaHeadMaker? paraHeadMaker,
                                    StringBuilder sb)
        {
            TextBoxExtract(ellipse.TextBox, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 호 개체에서 텍스트를 추출한다.
        /// </summary>
        private static void Arc(ControlArc arc,
                                TextExtractOption option,
                                ParaHeadMaker? paraHeadMaker,
                                StringBuilder sb)
        {
            TextBoxExtract(arc.TextBox, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 다각형 개체에서 텍스트를 추출한다.
        /// </summary>
        private static void Polygon(ControlPolygon polygon,
                                    TextExtractOption option,
                                    ParaHeadMaker? paraHeadMaker,
                                    StringBuilder sb)
        {
            TextBoxExtract(polygon.TextBox, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 곡선 개체에서 텍스트를 추출한다.
        /// </summary>
        private static void Curve(ControlCurve curve,
                                  TextExtractOption option,
                                  ParaHeadMaker? paraHeadMaker,
                                  StringBuilder sb)
        {
            TextBoxExtract(curve.TextBox, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 묶음 개체에서 텍스트를 추출한다.
        /// </summary>
        private static void Container(ControlContainer container,
                                      TextExtractOption option,
                                      ParaHeadMaker? paraHeadMaker,
                                      StringBuilder sb)
        {
            var childList = container.ChildControlList;
            if (childList == null) return;

            foreach (var child in childList)
            {
                Extract(child, option, paraHeadMaker, sb);
            }
        }
    }
}

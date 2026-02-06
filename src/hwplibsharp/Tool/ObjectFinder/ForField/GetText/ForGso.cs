// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/forfield/gettext/ForGso.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.TextBox;
using System.Text;

namespace HwpLib.Tool.ObjectFinder.ForField.GetText
{
    /// <summary>
    /// 그리기 개체에 포함된 필드의 텍스트를 가져오는 기능을 포함한 클래스
    /// </summary>
    public class ForGsoGetText
    {
        /// <summary>
        /// 그리기 개체에서 필드 텍스트를 가져온다.
        /// </summary>
        /// <param name="gc">그리기 개체</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="sb">문자열 버퍼</param>
        public static void GetFieldText(GsoControl gc, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            switch (gc.GsoType)
            {
                case GsoControlType.Line:
                    break;
                case GsoControlType.Rectangle:
                    Rectangle((ControlRectangle)gc, fieldType, fieldName, sb);
                    break;
                case GsoControlType.Ellipse:
                    Ellipse((ControlEllipse)gc, fieldType, fieldName, sb);
                    break;
                case GsoControlType.Arc:
                    Arc((ControlArc)gc, fieldType, fieldName, sb);
                    break;
                case GsoControlType.Polygon:
                    Polygon((ControlPolygon)gc, fieldType, fieldName, sb);
                    break;
                case GsoControlType.Curve:
                    Curve((ControlCurve)gc, fieldType, fieldName, sb);
                    break;
                case GsoControlType.Picture:
                    break;
                case GsoControlType.OLE:
                    break;
                case GsoControlType.Container:
                    Container((ControlContainer)gc, fieldType, fieldName, sb);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 사각형 개체에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Rectangle(ControlRectangle rectangle, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            TextBoxPart(rectangle.TextBox, fieldType, fieldName, sb);
        }

        /// <summary>
        /// 텍스트 박스에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void TextBoxPart(TextBox? textBox, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            if (textBox == null)
                return;

            string? text = ForParagraphList.GetFieldText(textBox.ParagraphList, fieldType, fieldName);
            if (text != null)
            {
                sb.Append(text);
            }
        }

        /// <summary>
        /// 타원 개체에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Ellipse(ControlEllipse ellipse, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            TextBoxPart(ellipse.TextBox, fieldType, fieldName, sb);
        }

        /// <summary>
        /// 호 개체에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Arc(ControlArc arc, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            TextBoxPart(arc.TextBox, fieldType, fieldName, sb);
        }

        /// <summary>
        /// 다각형 개체에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Polygon(ControlPolygon polygon, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            TextBoxPart(polygon.TextBox, fieldType, fieldName, sb);
        }

        /// <summary>
        /// 곡선 개체에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Curve(ControlCurve curve, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            TextBoxPart(curve.TextBox, fieldType, fieldName, sb);
        }

        /// <summary>
        /// 묶음 개체에서 필드 텍스트를 가져온다.
        /// </summary>
        private static void Container(ControlContainer container, ControlType fieldType, string fieldName, StringBuilder sb)
        {
            foreach (var child in container.ChildControlList)
            {
                GetFieldText(child, fieldType, fieldName, sb);
            }
        }
    }
}

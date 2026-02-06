// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/forfield/gettext/ForGsoWithAllField.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.TextBox;
using System.Collections.Generic;

namespace HwpLib.Tool.ObjectFinder.ForField.GetText
{
    /// <summary>
    /// 그리기 개체에 포함된 모든 필드의 텍스트를 가져오는 기능을 포함한 클래스
    /// </summary>
    public class ForGsoWithAllField
    {
        /// <summary>
        /// 그리기 개체에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        /// <param name="gc">그리기 개체</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="results">결과 리스트</param>
        public static void GetFieldText(GsoControl gc, ControlType fieldType, string fieldName, List<string> results)
        {
            switch (gc.GsoType)
            {
                case GsoControlType.Line:
                    break;
                case GsoControlType.Rectangle:
                    Rectangle((ControlRectangle)gc, fieldType, fieldName, results);
                    break;
                case GsoControlType.Ellipse:
                    Ellipse((ControlEllipse)gc, fieldType, fieldName, results);
                    break;
                case GsoControlType.Arc:
                    Arc((ControlArc)gc, fieldType, fieldName, results);
                    break;
                case GsoControlType.Polygon:
                    Polygon((ControlPolygon)gc, fieldType, fieldName, results);
                    break;
                case GsoControlType.Curve:
                    Curve((ControlCurve)gc, fieldType, fieldName, results);
                    break;
                case GsoControlType.Picture:
                    break;
                case GsoControlType.OLE:
                    break;
                case GsoControlType.Container:
                    Container((ControlContainer)gc, fieldType, fieldName, results);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 사각형 개체에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Rectangle(ControlRectangle rectangle, ControlType fieldType, string fieldName, List<string> results)
        {
            TextBoxPart(rectangle.TextBox, fieldType, fieldName, results);
        }

        /// <summary>
        /// 텍스트 박스에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void TextBoxPart(TextBox? textBox, ControlType fieldType, string fieldName, List<string> results)
        {
            if (textBox == null)
                return;

            ForParagraphList.GetAllFieldText(textBox.ParagraphList, fieldType, fieldName, results);
        }

        /// <summary>
        /// 타원 개체에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Ellipse(ControlEllipse ellipse, ControlType fieldType, string fieldName, List<string> results)
        {
            TextBoxPart(ellipse.TextBox, fieldType, fieldName, results);
        }

        /// <summary>
        /// 호 개체에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Arc(ControlArc arc, ControlType fieldType, string fieldName, List<string> results)
        {
            TextBoxPart(arc.TextBox, fieldType, fieldName, results);
        }

        /// <summary>
        /// 다각형 개체에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Polygon(ControlPolygon polygon, ControlType fieldType, string fieldName, List<string> results)
        {
            TextBoxPart(polygon.TextBox, fieldType, fieldName, results);
        }

        /// <summary>
        /// 곡선 개체에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Curve(ControlCurve curve, ControlType fieldType, string fieldName, List<string> results)
        {
            TextBoxPart(curve.TextBox, fieldType, fieldName, results);
        }

        /// <summary>
        /// 묶음 개체에서 모든 필드 텍스트를 가져온다.
        /// </summary>
        private static void Container(ControlContainer container, ControlType fieldType, string fieldName, List<string> results)
        {
            foreach (var child in container.ChildControlList)
            {
                GetFieldText(child, fieldType, fieldName, results);
            }
        }
    }
}

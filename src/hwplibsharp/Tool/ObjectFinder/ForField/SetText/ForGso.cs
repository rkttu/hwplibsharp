// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/forfield/settext/ForGso.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.TextBox;

namespace HwpLib.Tool.ObjectFinder.ForField.SetText
{
    /// <summary>
    /// 그리기 개체에 포함된 필드의 텍스트를 설정하는 기능을 포함한 클래스
    /// </summary>
    public class ForGsoSetText
    {
        /// <summary>
        /// 그리기 개체에서 필드 텍스트를 설정한다.
        /// </summary>
        /// <param name="gc">그리기 개체</param>
        /// <param name="fieldType">필드 타입</param>
        /// <param name="fieldName">필드 이름</param>
        /// <param name="textBuffer">텍스트 버퍼</param>
        /// <returns>필드 설정 결과값</returns>
        public static SetFieldResult SetFieldText(GsoControl gc, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            switch (gc.GsoType)
            {
                case GsoControlType.Line:
                    break;
                case GsoControlType.Rectangle:
                    return Rectangle((ControlRectangle)gc, fieldType, fieldName, textBuffer);
                case GsoControlType.Ellipse:
                    return Ellipse((ControlEllipse)gc, fieldType, fieldName, textBuffer);
                case GsoControlType.Arc:
                    return Arc((ControlArc)gc, fieldType, fieldName, textBuffer);
                case GsoControlType.Polygon:
                    return Polygon((ControlPolygon)gc, fieldType, fieldName, textBuffer);
                case GsoControlType.Curve:
                    return Curve((ControlCurve)gc, fieldType, fieldName, textBuffer);
                case GsoControlType.Picture:
                    break;
                case GsoControlType.OLE:
                    break;
                case GsoControlType.Container:
                    return Container((ControlContainer)gc, fieldType, fieldName, textBuffer);
                default:
                    break;
            }
            return SetFieldResult.InProcess;
        }

        /// <summary>
        /// 사각형 개체에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Rectangle(ControlRectangle rectangle, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return TextBoxPart(rectangle.TextBox, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 텍스트 박스에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult TextBoxPart(TextBox? textBox, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            if (textBox == null)
                return SetFieldResult.InProcess;

            return ForParagraphList.SetFieldText(textBox.ParagraphList, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 타원 개체에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Ellipse(ControlEllipse ellipse, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return TextBoxPart(ellipse.TextBox, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 호 개체에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Arc(ControlArc arc, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return TextBoxPart(arc.TextBox, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 다각형 개체에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Polygon(ControlPolygon polygon, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return TextBoxPart(polygon.TextBox, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 곡선 개체에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Curve(ControlCurve curve, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            return TextBoxPart(curve.TextBox, fieldType, fieldName, textBuffer);
        }

        /// <summary>
        /// 묶음 개체에서 필드 텍스트를 설정한다.
        /// </summary>
        private static SetFieldResult Container(ControlContainer container, ControlType fieldType, string fieldName, TextBuffer textBuffer)
        {
            foreach (var child in container.ChildControlList)
            {
                SetFieldResult result = SetFieldText(child, fieldType, fieldName, textBuffer);
                if (result == SetFieldResult.NotEnoughText)
                {
                    return SetFieldResult.NotEnoughText;
                }
            }
            return SetFieldResult.InProcess;
        }
    }
}

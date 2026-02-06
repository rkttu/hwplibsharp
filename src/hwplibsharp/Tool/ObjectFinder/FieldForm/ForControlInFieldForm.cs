// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/fieldform/ForControlInFieldForm.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Form;
using HwpLib.Object.BodyText.Control.Form.Properties;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.TextBox;
using HwpLib.Object.BodyText.Paragraph;
using System.Collections.Generic;

namespace HwpLib.Tool.ObjectFinder.FieldForm
{
    /// <summary>
    /// 컨트롤에서 필드를 찾는 클래스
    /// </summary>
    public static class ForControlInFieldForm
    {
        /// <summary>
        /// 컨트롤 리스트에서 필드를 찾는다.
        /// </summary>
        /// <param name="controlList">컨트롤 리스트</param>
        /// <param name="result">결과 객체</param>
        /// <param name="option">검색 옵션</param>
        public static void FindInControlList(List<Control> controlList, FieldFormFinder.Result result, FieldFormFinder.Option option)
        {
            if (option.NameToFind != null && option.OnlyFirst && result.Added)
            {
                throw new FieldFormFinder.StopFindException();
            }

            foreach (var control in controlList)
            {
                FindInControl(control, result, option);
            }
        }

        private static void FindInControl(Control control, FieldFormFinder.Result result, FieldFormFinder.Option option)
        {
            switch (control.Type)
            {
                case ControlType.Table:
                    FindInTable((ControlTable)control, result, option);
                    break;
                case ControlType.Gso:
                    FindInGso((GsoControl)control, result, option);
                    break;
                case ControlType.Form:
                    if (option.FindForm)
                    {
                        FindInForm((ControlForm)control, result, option);
                    }
                    break;
            }
        }

        private static void FindInTable(ControlTable table, FieldFormFinder.Result result, FieldFormFinder.Option option)
        {
            foreach (var row in table.RowList)
            {
                foreach (var cell in row.CellList)
                {
                    if (option.FindCell)
                    {
                        string? fieldName = cell.ListHeader.FieldName;
                        if (fieldName != null && fieldName.Length > 0)
                        {
                            if (option.NameToFind != null)
                            {
                                if (option.NameToFind.Equals(fieldName))
                                {
                                    result.AddFieldData(FieldDataForAllParagraphs(fieldName, FieldType.Cell, cell, cell.ParagraphList));

                                    if (option.OnlyFirst)
                                    {
                                        throw new FieldFormFinder.StopFindException();
                                    }
                                }
                            }
                            else
                            {
                                result.AddFieldData(FieldDataForAllParagraphs(fieldName, FieldType.Cell, cell, cell.ParagraphList));
                            }
                        }
                    }

                    FieldFormFinder.FindInParagraphList(cell.ParagraphList, result, option);
                }
            }
        }

        private static FieldData FieldDataForAllParagraphs(string fieldName, FieldType fieldType, object parent, ParagraphList paragraphList)
        {
            var fieldData = new FieldData(fieldName, fieldType, parent, paragraphList);
            fieldData.SetStartPosition(0, 0);
            fieldData.SetEndPosition(paragraphList.ParagraphCount - 1, 0xffff);
            return fieldData;
        }

        private static void FindInGso(GsoControl control, FieldFormFinder.Result result, FieldFormFinder.Option option)
        {
            switch (control.GsoType)
            {
                case GsoControlType.Rectangle:
                    FindInTextBox(control, ((ControlRectangle)control).TextBox, result, option);
                    break;
                case GsoControlType.Ellipse:
                    FindInTextBox(control, ((ControlEllipse)control).TextBox, result, option);
                    break;
                case GsoControlType.Arc:
                    FindInTextBox(control, ((ControlArc)control).TextBox, result, option);
                    break;
                case GsoControlType.Polygon:
                    FindInTextBox(control, ((ControlPolygon)control).TextBox, result, option);
                    break;
                case GsoControlType.Curve:
                    FindInTextBox(control, ((ControlCurve)control).TextBox, result, option);
                    break;
                case GsoControlType.Container:
                    FindInContainer((ControlContainer)control, result, option);
                    break;
            }
        }

        private static void FindInTextBox(GsoControl control, TextBox? textBox, FieldFormFinder.Result result, FieldFormFinder.Option option)
        {
            if (textBox == null)
            {
                return;
            }

            if (option.FindGso)
            {
                string? fieldName = textBox.ListHeader.FieldName;
                if (fieldName != null && fieldName.Length > 0)
                {
                    if (option.NameToFind != null)
                    {
                        if (option.NameToFind.Equals(fieldName))
                        {
                            result.AddFieldData(FieldDataForAllParagraphs(fieldName, FieldType.Gso, control, textBox.ParagraphList));

                            if (option.OnlyFirst)
                            {
                                throw new FieldFormFinder.StopFindException();
                            }
                        }
                    }
                    else
                    {
                        result.AddFieldData(FieldDataForAllParagraphs(fieldName, FieldType.Gso, control, textBox.ParagraphList));
                    }
                }
            }

            FieldFormFinder.FindInParagraphList(textBox.ParagraphList, result, option);
        }

        private static void FindInContainer(ControlContainer container, FieldFormFinder.Result result, FieldFormFinder.Option option)
        {
            foreach (var childControl in container.ChildControlList)
            {
                FindInGso(childControl, result, option);
            }
        }

        private static void FindInForm(ControlForm form, FieldFormFinder.Result result, FieldFormFinder.Option option)
        {
            if (form.FormObject.Type == FormObjectType.RadioButton ||
                form.FormObject.Type == FormObjectType.CheckBox)
            {
                var commonSet = form.FormObject.Properties.GetProperty("CommonSet") as PropertySet;
                var name = commonSet?.GetProperty("Name") as PropertyNormal;

                var buttonSet = form.FormObject.Properties.GetProperty("ButtonSet") as PropertySet;
                var value = buttonSet?.GetProperty("Value") as PropertyNormal;

                if (name?.Value != null && value?.Value != null)
                {
                    if (option.NameToFind != null)
                    {
                        if (option.NameToFind.Equals(name.Value))
                        {
                            result.AddFormData(new FormData(name.Value, form.FormObject.Type ?? FormObjectType.RadioButton, value.Value));
                            if (option.OnlyFirst)
                            {
                                throw new FieldFormFinder.StopFindException();
                            }
                        }
                    }
                    else
                    {
                        result.AddFormData(new FormData(name.Value, form.FormObject.Type ?? FormObjectType.RadioButton, value.Value));
                    }
                }
            }
        }
    }
}

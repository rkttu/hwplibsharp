// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/ForControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Tool.TextExtractor.ParaHead;
using System.Text;

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 컨트롤을 위한 텍스트 추출기 객체
    /// </summary>
    public static class ForControl
    {
        /// <summary>
        /// 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        public static void Extract(Control? c,
                                   TextExtractMethod tem,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            Extract(c, new TextExtractOption(tem), paraHeadMaker, sb);
        }

        /// <summary>
        /// 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        public static void Extract(Control? c,
                                   TextExtractOption option,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            if (c == null) return;

            if (c.IsField)
            {
                // Field는 처리하지 않음
            }
            else
            {
                switch (c.Type)
                {
                    case ControlType.Table:
                        Table((ControlTable)c, option, paraHeadMaker, sb);
                        break;
                    case ControlType.Gso:
                        ForGso.Extract((GsoControl)c, option, paraHeadMaker, sb);
                        break;
                    case ControlType.Equation:
                        Equation((ControlEquation)c, sb);
                        break;
                    case ControlType.SectionDefine:
                        break;
                    case ControlType.ColumnDefine:
                        break;
                    case ControlType.Header:
                        Header((ControlHeader)c, option, paraHeadMaker, sb);
                        break;
                    case ControlType.Footer:
                        Footer((ControlFooter)c, option, paraHeadMaker, sb);
                        break;
                    case ControlType.Footnote:
                        Footnote((ControlFootnote)c, option, paraHeadMaker, sb);
                        break;
                    case ControlType.Endnote:
                        Endnote((ControlEndnote)c, option, paraHeadMaker, sb);
                        break;
                    case ControlType.AutoNumber:
                        break;
                    case ControlType.NewNumber:
                        break;
                    case ControlType.PageHide:
                        break;
                    case ControlType.PageOddEvenAdjust:
                        break;
                    case ControlType.PageNumberPosition:
                        break;
                    case ControlType.IndexMark:
                        break;
                    case ControlType.Bookmark:
                        break;
                    case ControlType.OverlappingLetter:
                        break;
                    case ControlType.AdditionalText:
                        AdditionalText((ControlAdditionalText)c, sb);
                        break;
                    case ControlType.HiddenComment:
                        HiddenComment((ControlHiddenComment)c, option, paraHeadMaker, sb);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 표 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void Table(ControlTable table,
                                  TextExtractOption option,
                                  ParaHeadMaker? paraHeadMaker,
                                  StringBuilder sb)
        {
            var rowList = table.RowList;
            if (rowList == null) return;

            foreach (var r in rowList)
            {
                var cellList = r.CellList;
                if (cellList == null) continue;

                foreach (var c in cellList)
                {
                    ForParagraphList.Extract(c.ParagraphList, option, paraHeadMaker, sb);
                }
            }
        }

        /// <summary>
        /// 수식 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void Equation(ControlEquation equation, StringBuilder sb)
        {
            var script = equation.EQEdit?.Script?.ToUTF16LEString();
            if (script != null)
            {
                sb.Append(script).Append('\n');
            }
        }

        /// <summary>
        /// 머리말 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void Header(ControlHeader header,
                                   TextExtractOption option,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            ForParagraphList.Extract(header.ParagraphList, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 꼬리말 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void Footer(ControlFooter footer,
                                   TextExtractOption option,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            ForParagraphList.Extract(footer.ParagraphList, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 각주 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void Footnote(ControlFootnote footnote,
                                     TextExtractOption option,
                                     ParaHeadMaker? paraHeadMaker,
                                     StringBuilder sb)
        {
            ForParagraphList.Extract(footnote.ParagraphList, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 미주 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void Endnote(ControlEndnote endnote,
                                    TextExtractOption option,
                                    ParaHeadMaker? paraHeadMaker,
                                    StringBuilder sb)
        {
            ForParagraphList.Extract(endnote.ParagraphList, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// 덧말 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void AdditionalText(ControlAdditionalText additionalText, StringBuilder sb)
        {
            var mainText = additionalText.GetHeader()?.MainText?.ToUTF16LEString();
            var subText = additionalText.GetHeader()?.SubText?.ToUTF16LEString();
            if (mainText != null) sb.Append(mainText).Append('\n');
            if (subText != null) sb.Append(subText).Append('\n');
        }

        /// <summary>
        /// 숨은 설명 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void HiddenComment(ControlHiddenComment hiddenComment,
                                          TextExtractOption option,
                                          ParaHeadMaker? paraHeadMaker,
                                          StringBuilder sb)
        {
            ForParagraphList.Extract(hiddenComment.ParagraphList, option, paraHeadMaker, sb);
        }
    }
}

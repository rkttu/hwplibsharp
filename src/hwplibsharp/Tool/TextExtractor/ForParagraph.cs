// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/ForParagraph.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Object.BodyText.Paragraph.Text;
using HwpLib.Tool.TextExtractor.ParaHead;
using System.Collections.Generic;
using System.Text;

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 문단을 위한 텍스트 추출기 객체
    /// </summary>
    public static class ForParagraph
    {
        /// <summary>
        /// 문단 텍스트 추출의 시작 인덱스를 나타냅니다.
        /// </summary>
        public const int ParaStart = -1;
        /// <summary>
        /// 문단 텍스트 추출의 종료 인덱스를 나타냅니다.
        /// </summary>
        public const int ParaEnd = 0xffff;

        /// <summary>
        /// startIndex 순번 부터 끝 순번 까지의 문단의 텍스트를 추출한다.
        /// </summary>
        public static void Extract(Paragraph? p,
                                   int startIndex,
                                   TextExtractMethod tem,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            Extract(p, startIndex, ParaEnd, false, new TextExtractOption(tem), paraHeadMaker, sb);
        }

        /// <summary>
        /// startIndex 순번 부터 끝 순번 까지의 문단의 텍스트를 추출한다.
        /// </summary>
        public static void Extract(Paragraph? p,
                                   int startIndex,
                                   TextExtractOption option,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            Extract(p, startIndex, ParaEnd, false, option, paraHeadMaker, sb);
        }

        /// <summary>
        /// startIndex 순번 부터 endIndex 순번 까지의 문단의 텍스트를 추출한다.
        /// </summary>
        public static void Extract(Paragraph? p,
                                   int startIndex,
                                   int endIndex,
                                   TextExtractMethod tem,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            Extract(p, startIndex, endIndex, false, new TextExtractOption(tem), paraHeadMaker, sb);
        }

        /// <summary>
        /// 문단의 텍스트를 추출한다.
        /// </summary>
        public static void Extract(Paragraph? p,
                                   TextExtractMethod tem,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            Extract(p, ParaStart, ParaEnd, false, new TextExtractOption(tem), paraHeadMaker, sb);
        }

        /// <summary>
        /// startIndex 순번 부터 endIndex 순번 까지의 문단의 텍스트를 추출한다.
        /// </summary>
        public static void Extract(Paragraph? p,
                                   int startIndex,
                                   int endIndex,
                                   bool appendLF,
                                   TextExtractOption option,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            if (p == null) return;

            if (option.IsInsertParaHead() && startIndex <= 0 && paraHeadMaker != null)
            {
                var head = paraHeadMaker.ParaHeadString(p);
                if (!string.IsNullOrEmpty(head))
                {
                    sb.Append(head).Append(' ');
                }
            }

            var controlList = new List<Control>();
            var pt = p.Text;
            if (pt != null)
            {
                int controlIndex = 0;
                var charList = pt.CharList;
                if (charList != null)
                {
                    int charCount = charList.Count;
                    for (int charIndex = 0; charIndex < charCount; charIndex++)
                    {
                        var ch = charList[charIndex];
                        switch (ch.Type)
                        {
                            case HWPCharType.Normal:
                                if (startIndex <= charIndex && charIndex <= endIndex)
                                {
                                    NormalText(ch, sb);
                                }
                                break;
                            case HWPCharType.ControlChar:
                            case HWPCharType.ControlInline:
                                if (startIndex <= charIndex && charIndex <= endIndex)
                                {
                                    if (option.IsWithControlChar())
                                    {
                                        ControlText(ch, sb);
                                    }
                                }
                                break;
                            case HWPCharType.ControlExtend:
                                if (startIndex <= charIndex && charIndex <= endIndex)
                                {
                                    if (option.GetMethod() == TextExtractMethod.InsertControlTextBetweenParagraphText)
                                    {
                                        sb.Append('\n');
                                        var ctrlList = p.ControlList;
                                        if (ctrlList != null && controlIndex < ctrlList.Count)
                                        {
                                            ForControl.Extract(ctrlList[controlIndex], option, paraHeadMaker, sb);
                                        }
                                    }
                                    else
                                    {
                                        var ctrlList = p.ControlList;
                                        if (ctrlList != null && controlIndex < ctrlList.Count)
                                        {
                                            controlList.Add(ctrlList[controlIndex]);
                                        }
                                    }
                                }
                                controlIndex++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (appendLF && option.IsAppendEndingLF())
            {
                sb.Append('\n');
            }

            if (option.GetMethod() == TextExtractMethod.AppendControlTextAfterParagraphText)
            {
                Controls(controlList, option, paraHeadMaker, sb);
            }
        }

        /// <summary>
        /// 일반 문자에서 문자를 추출한다.
        /// </summary>
        private static void NormalText(HWPChar ch, StringBuilder sb)
        {
            if (ch is HWPCharNormal normal)
            {
                sb.Append(normal.Ch);
            }
        }

        private static void ControlText(HWPChar ch, StringBuilder sb)
        {
            switch (ch.Code)
            {
                case 9:
                    sb.Append('\t');
                    break;
                case 10:
                    sb.Append('\n');
                    break;
                case 24:
                    sb.Append('_');
                    break;
            }
        }

        /// <summary>
        /// 컨트롤 리스트에 포함된 컨트롤에서 텍스트를 추출한다.
        /// </summary>
        private static void Controls(List<Control> controlList,
                                     TextExtractOption option,
                                     ParaHeadMaker? paraHeadMaker,
                                     StringBuilder sb)
        {
            foreach (var c in controlList)
            {
                ForControl.Extract(c, option, paraHeadMaker, sb);
            }
        }
    }
}

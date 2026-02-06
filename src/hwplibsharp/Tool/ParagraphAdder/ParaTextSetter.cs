// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/ParaTextSetter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Object.BodyText.Paragraph.CharShape;
using HwpLib.Object.BodyText.Paragraph.Text;
using System.Collections.Generic;
using System.Text;

namespace HwpLib.Tool.ParagraphAdder
{
    /// <summary>
    /// 문단 텍스트를 설정하는 기능을 포함하는 클래스
    /// </summary>
    public class ParaTextSetter
    {
        /// <summary>
        /// 문단의 텍스트를 변경한다.
        /// </summary>
        public static void ChangeText(Paragraph p, int startIndex, int endIndex, string text)
        {
            string text2 = ReplaceCRLF(text);
            DeleteOriginChar(p.Text, startIndex, endIndex);
            InsertChar(p.Text, startIndex, text2);
            AdjustParaCharShape(p.CharShape, startIndex, endIndex, text2);
            DeleteLineSeg(p);
        }

        private static string ReplaceCRLF(string text)
        {
            var sb = new StringBuilder();
            int len = text.Length;
            for (int index = 0; index < len; index++)
            {
                char ch = text[index];
                if (ch == '\r')
                {
                    if (index + 1 < len && text[index + 1] == '\n')
                    {
                        index++;
                    }
                    sb.Append('\r');
                }
                else if (ch == '\n')
                {
                    if (index + 1 < len && text[index + 1] == '\r')
                    {
                        index++;
                    }
                    sb.Append('\r');
                }
                else
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }

        private static void DeleteOriginChar(ParaText? paraText, int startIndex, int endIndex)
        {
            if (paraText == null) return;

            for (int index = startIndex; index <= endIndex; index++)
            {
                paraText.RemoveCharAt(startIndex);
            }
        }

        private static void InsertChar(ParaText? paraText, int startIndex, string text)
        {
            if (paraText == null) return;

            int len = text.Length;
            for (int index = 0; index < len; index++)
            {
                var ch = new HWPCharNormal
                {
                    Code = (short)text[index]
                };
                paraText.InsertChar(startIndex + index, ch);
            }
        }

        private static void AdjustParaCharShape(ParaCharShape? paraCharShapeInfo, int startIndex, int endIndex, string text)
        {
            if (paraCharShapeInfo == null) return;

            int len = text.Length;
            var list = paraCharShapeInfo.PositionShapeIdPairList;
            var deleteItems = new List<CharPositionShapeIdPair>();

            foreach (var cpsip in list)
            {
                if (cpsip.Position < startIndex)
                {
                    continue;
                }
                else if (cpsip.Position >= startIndex && cpsip.Position <= endIndex)
                {
                    deleteItems.Add(cpsip);
                }
                else if (cpsip.Position > endIndex)
                {
                    int oldLen = endIndex - startIndex + 1;
                    cpsip.Position = cpsip.Position + oldLen - len;
                }
            }

            foreach (var cpsip in deleteItems)
            {
                paraCharShapeInfo.RemoveParaCharShape(cpsip);
            }
        }

        private static void DeleteLineSeg(Paragraph p)
        {
            p.DeleteLineSeg();
        }

        /// <summary>
        /// 문단에 텍스트를 from 위치부터 삭제한다.
        /// </summary>
        public static void DeleteParaTextFrom(Paragraph p, int from)
        {
            int leftCtrlCount = 0;
            int leftCharSize = 0;

            if (p.Text != null)
            {
                var charList = p.Text!.CharList;
                for (int charIndex = 0; charIndex < from; charIndex++)
                {
                    var hwpChar = charList[charIndex];
                    if (hwpChar.Type == HWPCharType.ControlExtend)
                    {
                        leftCtrlCount++;
                    }
                    leftCharSize += hwpChar.CharSize;
                }

                int deleteCharCount = charList.Count - from - 1;
                for (int index = 0; index < deleteCharCount; index++)
                {
                    p.Text!.RemoveCharAt(from);
                }
            }

            if (p.ControlList != null)
            {
                var controlList = p.ControlList!;
                int deleteCtrlCount = controlList.Count - leftCtrlCount;
                for (int index = 0; index < deleteCtrlCount; index++)
                {
                    p.RemoveControlAt(leftCtrlCount);
                }
            }

            if (p.CharShape != null)
            {
                var list = p.CharShape!.PositionShapeIdPairList;
                var deletings = new List<CharPositionShapeIdPair>();

                foreach (var cpsip in list)
                {
                    if (cpsip.Position > leftCharSize)
                    {
                        deletings.Add(cpsip);
                    }
                }

                foreach (var cpsip in deletings)
                {
                    p.CharShape!.RemoveParaCharShape(cpsip);
                }
            }
        }

        /// <summary>
        /// 문단에 텍스트를 to 위치까지 삭제한다.
        /// </summary>
        public static void DeleteParaTextTo(Paragraph p, int to)
        {
            int deleteCtrlCount = 0;
            int deleteCharSize = 0;

            if (p.Text != null)
            {
                var charList = p.Text!.CharList;
                for (int charIndex = 0; charIndex < to + 1 && charIndex < charList.Count - 1; charIndex++)
                {
                    var hwpChar = charList[charIndex];
                    if (hwpChar.Type == HWPCharType.ControlExtend)
                    {
                        deleteCtrlCount++;
                    }
                }

                for (int index = 0; index < to + 1; index++)
                {
                    if (charList.Count == 1)
                    {
                        break;
                    }
                    deleteCharSize += charList[0].CharSize;
                    p.Text!.RemoveCharAt(0);
                }
            }

            if (p.ControlList != null)
            {
                //var controlList = p.ControlList!;
                for (int index = 0; index < deleteCtrlCount; index++)
                {
                    p.RemoveControlAt(0);
                }
            }

            if (p.CharShape != null)
            {
                var list = p.CharShape!.PositionShapeIdPairList;
                var deletings = new List<CharPositionShapeIdPair>();

                foreach (var cpsip in list)
                {
                    if (cpsip.Position != 0)
                    {
                        if (cpsip.Position < to + 1)
                        {
                            deletings.Add(cpsip);
                        }
                        else
                        {
                            cpsip.Position -= deleteCharSize;
                        }
                    }
                }

                foreach (var cpsip in deletings)
                {
                    p.CharShape!.RemoveParaCharShape(cpsip);
                }
            }
        }

        /// <summary>
        /// 문단 para1 끝에 문단 para2를 병합한다.
        /// </summary>
        public static void MergeParagraph(Paragraph para1, Paragraph para2)
        {
            if (para1.Text == null) return;

            int para1CharSize = para1.Text!.GetCharSize();
            var para1CharList = para1.Text!.CharList;
            para1.Text!.RemoveCharAt(para1CharList.Count - 1);
            para1CharSize -= 1;

            if (para2.Text != null && para2.Text!.CharList.Count > 0)
            {
                if (para1.Text == null)
                {
                    para1.CreateText();
                }
                foreach (var hwpChar in para2.Text!.CharList)
                {
                    para1.Text!.AddChar(hwpChar);
                }
            }

            if (para2.ControlList != null && para2.ControlList!.Count > 0)
            {
                if (para1.ControlList == null)
                {
                    para1.CreateControlList();
                }
                foreach (var control in para2.ControlList!)
                {
                    para1.AddControl(control);
                }
            }

            if (para2.CharShape != null && para2.CharShape!.PositionShapeIdPairList.Count > 0)
            {
                if (para1.CharShape == null)
                {
                    para1.CreateCharShape();
                }
                foreach (var cpsip in para2.CharShape!.PositionShapeIdPairList)
                {
                    cpsip.Position += para1CharSize;
                    para1.CharShape!.AddParaCharShape(cpsip);
                }
            }
        }
    }
}

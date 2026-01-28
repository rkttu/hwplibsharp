// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/ForParagraph.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Object.BodyText.Paragraph.Header;
using HwpLib.Object.BodyText.Paragraph.Text;
using HwpLib.Writer.AutoSetter.Control;


namespace HwpLib.Writer.AutoSetter
{

    /// <summary>
    /// 문단 객체를 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForParagraph
    {
        /// <summary>
        /// 문단 객체를 자동 설정한다.
        /// </summary>
        /// <param name="p">문단 객체</param>
        /// <param name="lastInList">리스트의 마지막인지 여부</param>
        /// <param name="iid">인스턴스 ID</param>
        public static void AutoSet(Paragraph p, bool lastInList, InstanceID iid)
        {
            Header(p, lastInList);
            Controls(p, iid);
        }

        /// <summary>
        /// 문단 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="p">문단 객체</param>
        /// <param name="lastInList">리스트의 마지막인지 여부</param>
        private static void Header(Paragraph p, bool lastInList)
        {
            var h = p.Header;

            h.LastInList = lastInList;
            SetCharacterCount(h, p.Text);
            SetControlMask(h.ControlMask, p.Text);

            if (p.CharShape != null)
            {
                h.CharShapeCount = p.CharShape.PositionShapeIdPairList.Count;
            }
            else
            {
                h.CharShapeCount = 0;
            }

            if (p.RangeTag != null)
            {
                h.RangeTagCount = p.RangeTag.RangeTagItemList.Count;
            }
            else
            {
                h.RangeTagCount = 0;
            }

            if (p.LineSeg != null)
            {
                h.LineAlignCount = p.LineSeg.LineSegItemList.Count;
            }
            else
            {
                h.LineAlignCount = 0;
            }
        }

        /// <summary>
        /// 문단 헤더 레코드의 문자 개수를 자동 설정한다.
        /// </summary>
        /// <param name="h">문단 헤더 레코드</param>
        /// <param name="t">문단 텍스트 레코드</param>
        private static void SetCharacterCount(ParaHeader h, ParaText? t)
        {
            if (t != null)
            {
                int charCount = 0;
                foreach (var ch in t.CharList)
                {
                    charCount += ch.CharSize;
                }
                h.CharacterCount = charCount;
            }
            else
            {
                h.CharacterCount = 1;
            }
        }

        /// <summary>
        /// 문단 헤더 레코드의 Control Mask 부분을 자동 설정한다.
        /// </summary>
        /// <param name="cm">문단 헤더 레코드의 Control Mask</param>
        /// <param name="t">문단 텍스트 레코드</param>
        private static void SetControlMask(ControlMask cm, ParaText? t)
        {
            cm.Value = 0;
            if (t == null)
            {
                return;
            }

            foreach (var ch in t.CharList)
            {
                switch (ch.Code)
                {
                    case 2:
                        cm.HasSectColDef = true;
                        break;
                    case 3:
                        cm.HasFieldStart = true;
                        break;
                    case 4:
                        cm.HasFieldEnd = true;
                        break;
                    case 8:
                        cm.HasTitleMark = true;
                        // Java 원본과 동일하게 case 9로 폴스루 (break 없음)
                        goto case 9;
                    case 9:
                        cm.HasTab = true;
                        break;
                    case 10:
                        cm.HasLineBreak = true;
                        break;
                    case 11:
                        cm.HasGsoTable = true;
                        break;
                    case 15:
                        cm.HasHiddenComment = true;
                        break;
                    case 16:
                        cm.HasHeaderFooter = true;
                        break;
                    case 17:
                        cm.HasFootnoteEndnote = true;
                        break;
                    case 18:
                        cm.HasAutoNumber = true;
                        break;
                    case 21:
                        cm.HasPageControl = true;
                        break;
                    case 22:
                        cm.HasBookmark = true;
                        break;
                    case 23:
                        cm.HasAdditionalTextOverlappingLetter = true;
                        break;
                    case 24:
                        cm.HasHyphen = true;
                        break;
                    case 30:
                        cm.HasBundleBlank = true;
                        break;
                    case 31:
                        cm.HasFixWidthBlank = true;
                        break;
                }
            }
        }

        /// <summary>
        /// 문단에 포함된 컨트롤들을 자동 설정한다.
        /// </summary>
        /// <param name="p">문단</param>
        /// <param name="iid">인스턴스 ID</param>
        private static void Controls(Paragraph p, InstanceID iid)
        {
            if (p.ControlList == null)
            {
                return;
            }

            foreach (var c in p.ControlList)
            {
                ForControl.AutoSet(c, iid);
            }
        }
    }

}
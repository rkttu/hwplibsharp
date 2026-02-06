// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/ParaTextCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Paragraph.Text;

namespace HwpLib.Tool.ParagraphAdder
{
    /// <summary>
    /// Paragraph의 ParaText 객체를 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class ParaTextCopier
    {
        /// <summary>
        /// ParaText를 복사한다.
        /// </summary>
        /// <param name="source">소스 ParaText</param>
        /// <param name="target">대상 ParaText</param>
        /// <param name="includingSectionDefine">구역 정의 포함 여부</param>
        /// <returns>구역 정의 제외 여부</returns>
        public static bool Copy(ParaText source, ParaText target, bool includingSectionDefine)
        {
            bool excludedSectionDefine = false;

            foreach (var hwpChar in source.CharList)
            {
                switch (hwpChar.Type)
                {
                    case HWPCharType.Normal:
                        CopyNormalChar((HWPCharNormal)hwpChar, target.AddNewNormalChar());
                        break;
                    case HWPCharType.ControlChar:
                        CopyControlChar((HWPCharControlChar)hwpChar, target.AddNewCharControlChar());
                        break;
                    case HWPCharType.ControlInline:
                        CopyInlineChar((HWPCharControlInline)hwpChar, target.AddNewInlineControlChar());
                        break;
                    case HWPCharType.ControlExtend:
                        var ec = (HWPCharControlExtend)hwpChar;
                        if (includingSectionDefine)
                        {
                            CopyExtendChar(ec, target.AddNewExtendControlChar());
                        }
                        else
                        {
                            if (NotSectionDefine(ec))
                            {
                                CopyExtendChar(ec, target.AddNewExtendControlChar());
                            }
                            else
                            {
                                excludedSectionDefine = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return excludedSectionDefine;
        }

        private static bool NotSectionDefine(HWPCharControlExtend ec)
        {
            int code = ec.Code;
            return ec.IsColumnDefine ||   // 단 정의
                   code == 3 ||             // 필드 시작
                   code == 11 ||            // 그리기 개체/표/수식
                   code == 15 ||            // 숨은 설명
                   code == 17 ||            // 각주/미주
                   code == 18 ||            // 자동번호
                   code == 21 ||            // 페이지 컨트롤
                   code == 22 ||            // 책갈피/찾아보기 표식
                   code == 23;              // 덧말/글자 겹침
        }

        private static void CopyNormalChar(HWPCharNormal source, HWPCharNormal target)
        {
            target.Code = source.Code;
        }

        private static void CopyControlChar(HWPCharControlChar source, HWPCharControlChar target)
        {
            target.Code = source.Code;
        }

        private static void CopyInlineChar(HWPCharControlInline source, HWPCharControlInline target)
        {
            target.Code = source.Code;
            var addition = source.Addition;
            if (addition != null)
            {
                target.SetAddition((byte[])addition.Clone());
            }
        }

        private static void CopyExtendChar(HWPCharControlExtend source, HWPCharControlExtend target)
        {
            target.Code = source.Code;
            var addition = source.Addition;
            if (addition != null)
            {
                target.SetAddition((byte[])addition.Clone());
            }
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/CaptionCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.Caption;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 캡션을 복사하는 클래스
    /// </summary>
    public class CaptionCopier
    {
        /// <summary>
        /// 소스 Caption을 대상에 복사합니다.
        /// </summary>
        /// <param name="source">소스 Caption</param>
        /// <param name="target">대상 Caption</param>
        /// <param name="docInfoAdder">DocInfoAdder 인스턴스</param>
        public static void Copy(Caption source, Caption target, DocInfoAdder? docInfoAdder)
        {
            var sourceLH = source.ListHeader;
            var targetLH = target.ListHeader;
            targetLH?.Copy(sourceLH);

            ParagraphCopier.ListCopy(source.ParagraphList, target.ParagraphList, docInfoAdder);
        }
    }
}

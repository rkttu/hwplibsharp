// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/EquationCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 수식 컨트롤을 복사하는 클래스
    /// </summary>
    public class EquationCopier
    {
        /// <summary>
        /// source의 <see cref="ControlEquation"/>을 target의 <see cref="ControlEquation"/>으로 복사합니다.
        /// <paramref name="docInfoAdder"/>가 제공되면 문서 정보 매핑을 수행합니다.
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="ControlEquation"/> 인스턴스</param>
        /// <param name="target">복사 대상 <see cref="ControlEquation"/> 인스턴스</param>
        /// <param name="docInfoAdder">문서 정보 매핑에 사용할 <see cref="DocInfoAdder"/> 인스턴스, null일 수 있음</param>
        public static void Copy(ControlEquation source, ControlEquation target, DocInfoAdder? docInfoAdder)
        {
            var sourceH = source.GetHeader();
            var targetH = target.GetHeader();
            if (sourceH != null)
            {
                targetH?.Copy(sourceH);
            }

            CtrlDataCopier.Copy(source, target, docInfoAdder);
            CopyCaption(source, target, docInfoAdder);

            var sourceEE = source.EQEdit;
            var targetEE = target.EQEdit;
            targetEE?.Copy(sourceEE);
        }

        private static void CopyCaption(ControlEquation source, ControlEquation target, DocInfoAdder? docInfoAdder)
        {
            if (source.Caption != null)
            {
                target.CreateCaption();
                CaptionCopier.Copy(source.Caption!, target.Caption!, docInfoAdder);
            }
            else
            {
                target.DeleteCaption();
            }
        }
    }
}

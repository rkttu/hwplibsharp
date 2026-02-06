// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/OverlappingLetterCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 글자 겹침 컨트롤을 복사하는 클래스
    /// </summary>
    public class OverlappingLetterCopier
    {
        /// <summary>
        /// 글자 겹침 컨트롤을 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="ControlOverlappingLetter"/> 인스턴스입니다.</param>
        /// <param name="target">복사 대상 <see cref="ControlOverlappingLetter"/> 인스턴스입니다.</param>
        /// <param name="docInfoAdder">문서 정보 매핑을 위한 <see cref="DocInfoAdder"/> 인스턴스입니다. null일 수 있습니다.</param>
        public static void Copy(ControlOverlappingLetter source, ControlOverlappingLetter target, DocInfoAdder? docInfoAdder)
        {
            CopyHeader(source.GetHeader(), target.GetHeader(), docInfoAdder);
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        private static void CopyHeader(HwpLib.Object.BodyText.Control.CtrlHeader.CtrlHeaderOverlappingLetter? source,
                                       HwpLib.Object.BodyText.Control.CtrlHeader.CtrlHeaderOverlappingLetter? target,
                                       DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.BorderType = source.BorderType;
            target.ExpendInsideLetter = source.ExpendInsideLetter;
            target.InternalFontSize = source.InternalFontSize;

            foreach (var s in source.OverlappingLetterList)
            {
                target.AddOverlappingLetter(s.Clone());
            }

            foreach (var charShapeId in source.CharShapeIdList)
            {
                target.AddCharShapeId(docInfoAdder == null ? charShapeId : (uint)docInfoAdder.ForCharShapeInfo().ProcessById((int)charShapeId));
            }
        }
    }
}

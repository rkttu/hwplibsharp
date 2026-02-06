// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/AdditionalTextCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 덧말 컨트롤을 복사하는 클래스
    /// </summary>
    public class AdditionalTextCopier
    {
        /// <summary>
        /// 소스 ControlAdditionalText를 대상에 복사합니다.
        /// </summary>
        /// <param name="source">소스 ControlAdditionalText</param>
        /// <param name="target">대상 ControlAdditionalText</param>
        /// <param name="docInfoAdder">DocInfoAdder 인스턴스</param>
        public static void Copy(ControlAdditionalText source, ControlAdditionalText target, DocInfoAdder? docInfoAdder)
        {
            CopyHeader(source.GetHeader(), target.GetHeader(), docInfoAdder);
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        private static void CopyHeader(HwpLib.Object.BodyText.Control.CtrlHeader.CtrlHeaderAdditionalText? source,
                                       HwpLib.Object.BodyText.Control.CtrlHeader.CtrlHeaderAdditionalText? target,
                                       DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.MainText?.Copy(source.MainText);
            target.SubText?.Copy(source.SubText);
            target.Position = source.Position;
            target.Fsizeratio = source.Fsizeratio;
            target.Option = source.Option;
            target.StyleId = docInfoAdder == null ? source.StyleId : (uint)docInfoAdder.ForStyle().ProcessById((int)source.StyleId);
            target.Alignment = source.Alignment;
        }
    }
}

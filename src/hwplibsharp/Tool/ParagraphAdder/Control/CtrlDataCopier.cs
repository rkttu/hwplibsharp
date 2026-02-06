// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/CtrlDataCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 컨트롤 데이터를 복사하는 클래스
    /// </summary>
    public class CtrlDataCopier
    {
        /// <summary>
        /// 소스 컨트롤의 데이터를 타겟 컨트롤로 복사합니다.
        /// 컨트롤 데이터가 존재하면 생성 및 복사하고, 없으면 삭제합니다.
        /// </summary>
        /// <param name="source">복사할 원본 컨트롤</param>
        /// <param name="target">데이터를 복사받을 대상 컨트롤</param>
        /// <param name="docInfoAdder">문서 정보 추가 도우미(필요시 null 가능)</param>
        public static void Copy(HwpLib.Object.BodyText.Control.Control source, HwpLib.Object.BodyText.Control.Control target, DocInfoAdder? docInfoAdder)
        {
            if (source.GetControlData() != null)
            {
                target.CreateCtrlData();
                ParameterSetCopier.Copy(source.GetControlData()!.ParameterSet, target.GetControlData()!.ParameterSet, docInfoAdder);
            }
            else
            {
                target.DeleteCtrlData();
            }
        }
    }
}

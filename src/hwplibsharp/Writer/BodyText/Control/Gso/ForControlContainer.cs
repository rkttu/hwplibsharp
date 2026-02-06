// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlContainer.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// 묶음 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlContainer
    {
        /// <summary>
        /// 묶음 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlContainer cont, CompoundStreamWriter sw)
        {
            ChildControls(cont, sw);
        }

        /// <summary>
        /// 묶음 컨트롤에 포함된 컨트롤들을 쓴다.
        /// </summary>
        private static void ChildControls(ControlContainer cont, CompoundStreamWriter sw)
        {
            foreach (var child in cont.ChildControlList)
            {
                ForGsoControl.WriteInContainer(child, sw);
            }
        }
    }
}

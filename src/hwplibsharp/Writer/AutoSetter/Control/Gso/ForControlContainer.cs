// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/gso/ForControlContainer.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent;

namespace HwpLib.Writer.AutoSetter.Control.Gso
{
    /// <summary>
    /// 묶음 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlContainer
    {
        /// <summary>
        /// 묶음 컨트롤을 자동 설정하다.
        /// </summary>
        /// <param name="cont">묶음 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlContainer cont, InstanceID iid)
        {
            ShapeComponent(cont);
            ChildControls(cont, iid);
        }

        /// <summary>
        /// 묶음 컨트롤의 객체 공통 속성 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="cont">묶음 컨트롤</param>
        private static void ShapeComponent(ControlContainer cont)
        {
            var scc = (ShapeComponentContainer)cont.ShapeComponent;
            scc.ClearChildControlIdList();
            foreach (var child in cont.ChildControlList)
            {
                scc.AddChildControlId(child.GsoId);
            }
        }

        /// <summary>
        /// 묶음 컨트롤의 자식 컨트롤들을 자동 설정한다.
        /// </summary>
        /// <param name="cont">묶음 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        private static void ChildControls(ControlContainer cont, InstanceID iid)
        {
            foreach (var child in cont.ChildControlList)
            {
                ForGsoControl.AutoSet(child, iid);
            }
        }
    }
}

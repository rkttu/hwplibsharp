// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControlEquation.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Writer.AutoSetter.Control.Gso.Part;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 수식 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlEquation
    {
        /// <summary>
        /// 수식 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="eq">수식 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlEquation eq, InstanceID iid)
        {
            ForCtrlHeaderGso.AutoSet(eq.GetHeader(), eq.Caption, iid);
            ForCaption.AutoSet(eq.Caption, iid);
        }
    }
}

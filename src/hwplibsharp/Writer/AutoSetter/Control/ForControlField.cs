// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/ForControlField.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Writer.AutoSetter.Control
{
    /// <summary>
    /// 필드 컨트롤을 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForControlField
    {
        /// <summary>
        /// 필드 컨트롤을 자동 설정한다.
        /// </summary>
        /// <param name="f">필드 컨트롤</param>
        /// <param name="iid">인스턴스 id</param>
        public static void AutoSet(ControlField f, InstanceID iid)
        {
            CtrlHeader(f.GetHeader()!, iid);
        }

        /// <summary>
        /// 컨트롤 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="h">컨트롤 헤더</param>
        /// <param name="iid">인스턴스 id</param>
        private static void CtrlHeader(CtrlHeaderField h, InstanceID iid)
        {
            h.InstanceId = (uint)iid.Get();
        }
    }
}

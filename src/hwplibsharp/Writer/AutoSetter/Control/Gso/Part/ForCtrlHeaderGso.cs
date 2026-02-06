// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/control/gso/part/ForCtrlHeaderGso.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.Caption;

namespace HwpLib.Writer.AutoSetter.Control.Gso.Part
{
    /// <summary>
    /// 그리기 개체의 컨트롤 헤더 레코드를 쓰기 전에 자동 설정하기 위한 객체
    /// </summary>
    public static class ForCtrlHeaderGso
    {
        /// <summary>
        /// 그리기 개체의 컨트롤 헤더 레코드를 자동 설정한다.
        /// </summary>
        /// <param name="h">그리기 개체의 컨트롤 헤더 레코드</param>
        /// <param name="c">캡션</param>
        /// <param name="iid">인스턴스 아이디</param>
        public static void AutoSet(CtrlHeaderGso? h, Caption? c, InstanceID iid)
        {
            if (h == null)
            {
                return;
            }
            h.InstanceId = (uint)iid.Get();

            if (c != null)
            {
                h.Property.SetHasCaption(true);
            }
            else
            {
                h.Property.SetHasCaption(false);
            }
        }
    }
}

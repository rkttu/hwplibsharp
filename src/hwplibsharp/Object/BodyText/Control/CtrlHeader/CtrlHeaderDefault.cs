// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderDefault.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 기본 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderDefault : CtrlHeader
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ctrlId">컨트롤 아이디</param>
        public CtrlHeaderDefault(uint ctrlId)
            : base(ctrlId)
        {
        }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            // nothing
        }
    }
}

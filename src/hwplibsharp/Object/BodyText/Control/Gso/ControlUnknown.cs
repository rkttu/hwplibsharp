// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlUnknown.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 알 수 없는 개체 컨트롤
    /// </summary>
    public class ControlUnknown : GsoControl
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlUnknown()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlUnknown(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.Unknown.GetId());
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlUnknown cloned = new ControlUnknown();
            cloned.CopyGsoControlPart(this);
            return cloned;
        }
    }
}

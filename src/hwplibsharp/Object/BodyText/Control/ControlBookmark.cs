// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlBookmark.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 책갈피 컨트롤에 대한 객체
    /// </summary>
    public class ControlBookmark : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlBookmark()
            : base(new CtrlHeaderBookmark())
        {
        }

        /// <summary>
        /// 책갈피용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>책갈피용 컨트롤 헤더</returns>
        public new CtrlHeaderBookmark? GetHeader() => Header as CtrlHeaderBookmark;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlBookmark cloned = new ControlBookmark();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlIndexMark.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 찾아보기 표식 컨트롤
    /// </summary>
    public class ControlIndexMark : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlIndexMark()
            : base(new CtrlHeaderIndexMark())
        {
        }

        /// <summary>
        /// 찾아보기 표식용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>찾아보기 표식용 컨트롤 헤더</returns>
        public new CtrlHeaderIndexMark? GetHeader() => Header as CtrlHeaderIndexMark;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlIndexMark cloned = new ControlIndexMark();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

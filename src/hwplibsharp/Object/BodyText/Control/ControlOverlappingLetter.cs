// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlOverlappingLetter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 글자 겹침 컨트롤
    /// </summary>
    public class ControlOverlappingLetter : Control
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ControlOverlappingLetter()
            : base(new CtrlHeaderOverlappingLetter())
        {
        }

        /// <summary>
        /// 글자 겹침용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>글자 겹침용 컨트롤 헤더</returns>
        public new CtrlHeaderOverlappingLetter? GetHeader() => Header as CtrlHeaderOverlappingLetter;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlOverlappingLetter cloned = new ControlOverlappingLetter();
            cloned.CopyControlPart(this);
            return cloned;
        }
    }
}

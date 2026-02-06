// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlForm.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Form;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 양식 개체 컨트롤
    /// </summary>
    public class ControlForm : Control
    {
        private readonly FormObject formObject;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlForm()
            : this(new CtrlHeaderGso(ControlType.Form))
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">양식 개체를 위한 컨트롤 헤더</param>
        public ControlForm(CtrlHeaderGso header)
            : base(header)
        {
            formObject = new FormObject();
        }

        /// <summary>
        /// 그리기 객체용 컨트롤 헤더를 반환한다.
        /// </summary>
        /// <returns>그리기 객체용 컨트롤 헤더</returns>
        public new CtrlHeaderGso? GetHeader() => Header as CtrlHeaderGso;

        /// <summary>
        /// 양식 개체를 반환한다.
        /// </summary>
        /// <returns>양식 개체</returns>
        public FormObject FormObject => formObject;

        /// <summary>
        /// 이 컨트롤을 복제합니다.
        /// </summary>
        /// <returns>복제된 <see cref="ControlAdditionalText"/> 인스턴스</returns>
        public override Control Clone()
        {
            ControlForm cloned = new ControlForm();
            cloned.CopyControlPart(this);

            cloned.formObject.Copy(formObject);
            return cloned;
        }
    }
}

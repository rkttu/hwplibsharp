// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlCurve.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 곡선 개체 컨트롤
    /// </summary>
    public class ControlCurve : GsoControl
    {
        /// <summary>
        /// 글상자
        /// </summary>
        private TextBox.TextBox? _textBox;

        /// <summary>
        /// 곡선 개체 속성
        /// </summary>
        private readonly ShapeComponentCurve _shapeComponentCurve;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlCurve()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlCurve(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.Curve.GetId());

            _textBox = null;
            _shapeComponentCurve = new ShapeComponentCurve();
        }

        /// <summary>
        /// 글상자 객체를 생성한다.
        /// </summary>
        public void CreateTextBox()
        {
            _textBox = new TextBox.TextBox();
        }

        /// <summary>
        /// 글상자 객체를 삭제한다.
        /// </summary>
        public void DeleteTextBox()
        {
            _textBox = null;
        }

        /// <summary>
        /// 글상자 객체를 반환한다.
        /// </summary>
        public TextBox.TextBox? TextBox => _textBox;

        /// <summary>
        /// 곡선 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentCurve ShapeComponentCurve => _shapeComponentCurve;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlCurve cloned = new ControlCurve();
            cloned.CopyGsoControlPart(this);

            if (_textBox != null)
            {
                cloned.CreateTextBox();
                cloned._textBox!.Copy(_textBox);
            }

            cloned._shapeComponentCurve.Copy(_shapeComponentCurve);
            return cloned;
        }
    }
}

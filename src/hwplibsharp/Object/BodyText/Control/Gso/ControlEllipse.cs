// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlEllipse.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 타원 개체 컨트롤
    /// </summary>
    public class ControlEllipse : GsoControl
    {
        /// <summary>
        /// 글상자
        /// </summary>
        private TextBox.TextBox? _textBox;

        /// <summary>
        /// 타원 개체 속성
        /// </summary>
        private readonly ShapeComponentEllipse _shapeComponentEllipse;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlEllipse()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlEllipse(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.Ellipse.GetId());

            _textBox = null;
            _shapeComponentEllipse = new ShapeComponentEllipse();
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
        /// 타원 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentEllipse ShapeComponentEllipse => _shapeComponentEllipse;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlEllipse cloned = new ControlEllipse();
            cloned.CopyGsoControlPart(this);

            if (_textBox != null)
            {
                cloned.CreateTextBox();
                cloned._textBox!.Copy(_textBox);
            }

            cloned._shapeComponentEllipse.Copy(_shapeComponentEllipse);
            return cloned;
        }
    }
}

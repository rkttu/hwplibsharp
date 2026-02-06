// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlPolygon.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 다각형 개체 컨트롤
    /// </summary>
    public class ControlPolygon : GsoControl
    {
        /// <summary>
        /// 글상자
        /// </summary>
        private TextBox.TextBox? _textBox;

        /// <summary>
        /// 다각형 개체 속성
        /// </summary>
        private readonly ShapeComponentPolygon _shapeComponentPolygon;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlPolygon()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlPolygon(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.Polygon.GetId());

            _textBox = null;
            _shapeComponentPolygon = new ShapeComponentPolygon();
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
        /// 다각형 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentPolygon ShapeComponentPolygon => _shapeComponentPolygon;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlPolygon cloned = new ControlPolygon();
            cloned.CopyGsoControlPart(this);

            if (_textBox != null)
            {
                cloned.CreateTextBox();
                cloned._textBox!.Copy(_textBox);
            }

            cloned._shapeComponentPolygon.Copy(_shapeComponentPolygon);
            return cloned;
        }
    }
}

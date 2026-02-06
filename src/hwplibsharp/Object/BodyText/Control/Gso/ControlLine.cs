// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlLine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 선 개체 컨트롤
    /// </summary>
    public class ControlLine : GsoControl
    {
        /// <summary>
        /// 선 개체 속성
        /// </summary>
        private readonly ShapeComponentLine _shapeComponentLine;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlLine()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlLine(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.Line.GetId());

            _shapeComponentLine = new ShapeComponentLine();
        }

        /// <summary>
        /// 선 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentLine ShapeComponentLine => _shapeComponentLine;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlLine cloned = new ControlLine();
            cloned.CopyGsoControlPart(this);
            cloned._shapeComponentLine.Copy(_shapeComponentLine);
            return cloned;
        }
    }
}

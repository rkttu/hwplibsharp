// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlObjectLinkLine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 객체 연결선 컨트롤
    /// </summary>
    public class ControlObjectLinkLine : GsoControl
    {
        /// <summary>
        /// 선 개체 속성
        /// </summary>
        private readonly ShapeComponentLineForObjectLinkLine _shapeComponentLine;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlObjectLinkLine()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlObjectLinkLine(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.ObjectLinkLine.GetId());

            _shapeComponentLine = new ShapeComponentLineForObjectLinkLine();
        }

        /// <summary>
        /// 선 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentLineForObjectLinkLine ShapeComponentLine => _shapeComponentLine;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlObjectLinkLine cloned = new ControlObjectLinkLine();
            cloned.CopyGsoControlPart(this);
            cloned._shapeComponentLine.Copy(_shapeComponentLine);
            return cloned;
        }
    }
}

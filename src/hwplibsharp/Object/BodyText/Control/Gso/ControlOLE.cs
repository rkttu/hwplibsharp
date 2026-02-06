// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlOLE.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// OLE 개체 컨트롤
    /// </summary>
    public class ControlOLE : GsoControl
    {
        /// <summary>
        /// OLE 개체 속성
        /// </summary>
        private readonly ShapeComponentOLE _shapeComponentOLE;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlOLE()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlOLE(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.OLE.GetId());

            _shapeComponentOLE = new ShapeComponentOLE();
        }

        /// <summary>
        /// OLE 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentOLE ShapeComponentOLE => _shapeComponentOLE;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlOLE cloned = new ControlOLE();
            cloned.CopyGsoControlPart(this);
            cloned._shapeComponentOLE.Copy(_shapeComponentOLE);
            return cloned;
        }
    }
}

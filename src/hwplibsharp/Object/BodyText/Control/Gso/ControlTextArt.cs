// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlTextArt.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 글맵시 컨트롤
    /// </summary>
    public class ControlTextArt : GsoControl
    {
        /// <summary>
        /// 글맵시 개체 속성
        /// </summary>
        private readonly ShapeComponentTextArt _shapeComponentTextArt;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlTextArt()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlTextArt(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.TextArt.GetId());
            _shapeComponentTextArt = new ShapeComponentTextArt();
        }

        /// <summary>
        /// 글맵시 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentTextArt ShapeComponentTextArt => _shapeComponentTextArt;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlTextArt cloned = new ControlTextArt();
            cloned.CopyGsoControlPart(this);
            cloned._shapeComponentTextArt.Copy(_shapeComponentTextArt);
            return cloned;
        }
    }
}

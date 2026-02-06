// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlPicture.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 그림 개체 컨트롤
    /// </summary>
    public class ControlPicture : GsoControl
    {
        /// <summary>
        /// 그림 개체 속성
        /// </summary>
        private readonly ShapeComponentPicture _shapeComponentPicture;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlPicture()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlPicture(CtrlHeaderGso header)
            : base(header)
        {
            SetGsoId((uint)GsoControlType.Picture.GetId());

            _shapeComponentPicture = new ShapeComponentPicture();
        }

        /// <summary>
        /// 그림 개체의 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentPicture ShapeComponentPicture => _shapeComponentPicture;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            ControlPicture cloned = new ControlPicture();
            cloned.CopyGsoControlPart(this);
            cloned._shapeComponentPicture.Copy(_shapeComponentPicture);
            return cloned;
        }
    }
}

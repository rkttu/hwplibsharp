// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/polygon/PositionXY.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Polygon
{
    /// <summary>
    /// 좌표를 나타내는 객체
    /// </summary>
    public class PositionXY
    {
        /// <summary>
        /// x값
        /// </summary>
        private uint _x;

        /// <summary>
        /// y값
        /// </summary>
        private uint _y;

        /// <summary>
        /// 생성자
        /// </summary>
        public PositionXY()
        {
        }

        /// <summary>
        /// x값을 반환하거나 설정한다.
        /// </summary>
        public uint X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// y값을 반환하거나 설정한다.
        /// </summary>
        public uint Y
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public PositionXY Clone()
        {
            var cloned = new PositionXY();
            cloned.Copy(this);
            return cloned;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PositionXY from)
        {
            _x = from._x;
            _y = from._y;
        }
    }
}

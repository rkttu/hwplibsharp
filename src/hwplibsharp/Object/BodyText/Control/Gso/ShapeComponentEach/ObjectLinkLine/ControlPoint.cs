// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/objectlinkline/ControlPoint.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.ObjectLinkLine
{
    /// <summary>
    /// 개체 연결선의 제어점
    /// </summary>
    public class ControlPoint
    {
        /// <summary>
        /// X 좌표
        /// </summary>
        private uint _x;

        /// <summary>
        /// Y 좌표
        /// </summary>
        private uint _y;

        /// <summary>
        /// 타입
        /// </summary>
        private int _type;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlPoint()
        {
        }

        /// <summary>
        /// X 좌표를 반환하거나 설정한다.
        /// </summary>
        public uint X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Y 좌표를 반환하거나 설정한다.
        /// </summary>
        public uint Y
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        /// 타입을 반환하거나 설정한다.
        /// </summary>
        public int Type
        {
            get => _type;
            set => _type = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ControlPoint from)
        {
            _x = from._x;
            _y = from._y;
            _type = from._type;
        }
    }
}

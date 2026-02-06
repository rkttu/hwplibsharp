// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentArc.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Arc;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 호 개체 속성 레코드
    /// </summary>
    public class ShapeComponentArc
    {
        /// <summary>
        /// 호 테두리 타입
        /// </summary>
        private ArcType _arcType;

        /// <summary>
        /// 타원의 중심 좌표 X값
        /// </summary>
        private int _centerX;

        /// <summary>
        /// 타원의 중심 좌표 Y값
        /// </summary>
        private int _centerY;

        /// <summary>
        /// 제1축 X좌표 값
        /// </summary>
        private int _axis1X;

        /// <summary>
        /// 제1축 Y좌표 값
        /// </summary>
        private int _axis1Y;

        /// <summary>
        /// 제2축 X좌표 값
        /// </summary>
        private int _axis2X;

        /// <summary>
        /// 제2축 Y좌표 값
        /// </summary>
        private int _axis2Y;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentArc()
        {
        }

        /// <summary>
        /// 호 테두리 타입을 반환하거나 설정한다.
        /// </summary>
        public ArcType ArcType
        {
            get => _arcType;
            set => _arcType = value;
        }

        /// <summary>
        /// 타원의 중심 좌표 X값을 반환하거나 설정한다.
        /// </summary>
        public int CenterX
        {
            get => _centerX;
            set => _centerX = value;
        }

        /// <summary>
        /// 타원의 중심 좌표 Y값을 반환하거나 설정한다.
        /// </summary>
        public int CenterY
        {
            get => _centerY;
            set => _centerY = value;
        }

        /// <summary>
        /// 제1축 X좌표 값을 반환하거나 설정한다.
        /// </summary>
        public int Axis1X
        {
            get => _axis1X;
            set => _axis1X = value;
        }

        /// <summary>
        /// 제1축 Y좌표 값을 반환하거나 설정한다.
        /// </summary>
        public int Axis1Y
        {
            get => _axis1Y;
            set => _axis1Y = value;
        }

        /// <summary>
        /// 제2축 X좌표 값을 반환하거나 설정한다.
        /// </summary>
        public int Axis2X
        {
            get => _axis2X;
            set => _axis2X = value;
        }

        /// <summary>
        /// 제2축 Y좌표 값을 반환하거나 설정한다.
        /// </summary>
        public int Axis2Y
        {
            get => _axis2Y;
            set => _axis2Y = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentArc from)
        {
            _arcType = from._arcType;
            _centerX = from._centerX;
            _centerY = from._centerY;
            _axis1X = from._axis1X;
            _axis1Y = from._axis1Y;
            _axis2X = from._axis2X;
            _axis2Y = from._axis2Y;
        }
    }
}

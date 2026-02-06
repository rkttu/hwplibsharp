// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentEllipse.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Ellipse;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 타원 개체 속성 레코드
    /// </summary>
    public class ShapeComponentEllipse
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly ShapeComponentEllipseProperty _property;

        /// <summary>
        /// 중심 좌표의 X값
        /// </summary>
        private int _centerX;

        /// <summary>
        /// 중심 좌표의 Y값
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
        /// start pos x
        /// </summary>
        private int _startX;

        /// <summary>
        /// start pos y
        /// </summary>
        private int _startY;

        /// <summary>
        /// end pos x
        /// </summary>
        private int _endX;

        /// <summary>
        /// end pos y
        /// </summary>
        private int _endY;

        /// <summary>
        /// start pos x2 interval of curve (effective only when it is an arc)
        /// </summary>
        private int _startX2;

        /// <summary>
        /// start pos y2
        /// </summary>
        private int _startY2;

        /// <summary>
        /// end pos x2
        /// </summary>
        private int _endX2;

        /// <summary>
        /// end pos y2
        /// </summary>
        private int _endY2;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentEllipse()
        {
            _property = new ShapeComponentEllipseProperty();
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentEllipseProperty Property => _property;

        /// <summary>
        /// 중심 좌표의 X값을 반환하거나 설정한다.
        /// </summary>
        public int CenterX
        {
            get => _centerX;
            set => _centerX = value;
        }

        /// <summary>
        /// 중심 좌표의 Y값을 반환하거나 설정한다.
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
        /// start pos x값을 반환하거나 설정한다.
        /// </summary>
        public int StartX
        {
            get => _startX;
            set => _startX = value;
        }

        /// <summary>
        /// start pos y값을 반환하거나 설정한다.
        /// </summary>
        public int StartY
        {
            get => _startY;
            set => _startY = value;
        }

        /// <summary>
        /// end pos x값을 반환하거나 설정한다.
        /// </summary>
        public int EndX
        {
            get => _endX;
            set => _endX = value;
        }

        /// <summary>
        /// end pos y값을 반환하거나 설정한다.
        /// </summary>
        public int EndY
        {
            get => _endY;
            set => _endY = value;
        }

        /// <summary>
        /// start pos x2값을 반환하거나 설정한다.
        /// </summary>
        public int StartX2
        {
            get => _startX2;
            set => _startX2 = value;
        }

        /// <summary>
        /// start pos y2값을 반환하거나 설정한다.
        /// </summary>
        public int StartY2
        {
            get => _startY2;
            set => _startY2 = value;
        }

        /// <summary>
        /// end pos x2값을 반환하거나 설정한다.
        /// </summary>
        public int EndX2
        {
            get => _endX2;
            set => _endX2 = value;
        }

        /// <summary>
        /// end pos y2값을 반환하거나 설정한다.
        /// </summary>
        public int EndY2
        {
            get => _endY2;
            set => _endY2 = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentEllipse from)
        {
            _property.Copy(from._property);
            _centerX = from._centerX;
            _centerY = from._centerY;
            _axis1X = from._axis1X;
            _axis1Y = from._axis1Y;
            _axis2X = from._axis2X;
            _axis2Y = from._axis2Y;
            _startX = from._startX;
            _startY = from._startY;
            _endX = from._endX;
            _endY = from._endY;
            _startX2 = from._startX2;
            _startY2 = from._startY2;
            _endX2 = from._endX2;
            _endY2 = from._endY2;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentRectangle.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 사각형 개체 속성 레코드
    /// </summary>
    public class ShapeComponentRectangle
    {
        /// <summary>
        /// 모서리 둥근 비율
        /// </summary>
        private byte _roundRate;

        /// <summary>
        /// x1
        /// </summary>
        private int _x1;

        /// <summary>
        /// y1
        /// </summary>
        private int _y1;

        /// <summary>
        /// x2
        /// </summary>
        private int _x2;

        /// <summary>
        /// y2
        /// </summary>
        private int _y2;

        /// <summary>
        /// x3
        /// </summary>
        private int _x3;

        /// <summary>
        /// y3
        /// </summary>
        private int _y3;

        /// <summary>
        /// x4
        /// </summary>
        private int _x4;

        /// <summary>
        /// y4
        /// </summary>
        private int _y4;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentRectangle()
        {
        }

        /// <summary>
        /// 모서리 둥근 비율을 반환하거나 설정한다.
        /// </summary>
        public byte RoundRate
        {
            get => _roundRate;
            set => _roundRate = value;
        }

        /// <summary>
        /// x1 값을 반환하거나 설정한다.
        /// </summary>
        public int X1
        {
            get => _x1;
            set => _x1 = value;
        }

        /// <summary>
        /// y1 값을 반환하거나 설정한다.
        /// </summary>
        public int Y1
        {
            get => _y1;
            set => _y1 = value;
        }

        /// <summary>
        /// x2 값을 반환하거나 설정한다.
        /// </summary>
        public int X2
        {
            get => _x2;
            set => _x2 = value;
        }

        /// <summary>
        /// y2 값을 반환하거나 설정한다.
        /// </summary>
        public int Y2
        {
            get => _y2;
            set => _y2 = value;
        }

        /// <summary>
        /// x3 값을 반환하거나 설정한다.
        /// </summary>
        public int X3
        {
            get => _x3;
            set => _x3 = value;
        }

        /// <summary>
        /// y3 값을 반환하거나 설정한다.
        /// </summary>
        public int Y3
        {
            get => _y3;
            set => _y3 = value;
        }

        /// <summary>
        /// x4 값을 반환하거나 설정한다.
        /// </summary>
        public int X4
        {
            get => _x4;
            set => _x4 = value;
        }

        /// <summary>
        /// y4 값을 반환하거나 설정한다.
        /// </summary>
        public int Y4
        {
            get => _y4;
            set => _y4 = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentRectangle from)
        {
            _roundRate = from._roundRate;
            _x1 = from._x1;
            _y1 = from._y1;
            _x2 = from._x2;
            _y2 = from._y2;
            _x3 = from._x3;
            _y3 = from._y3;
            _x4 = from._x4;
            _y4 = from._y4;
        }
    }
}

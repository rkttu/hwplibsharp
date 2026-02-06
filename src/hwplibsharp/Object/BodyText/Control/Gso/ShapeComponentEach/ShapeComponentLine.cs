// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentLine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 선 개체 속성 레코드
    /// </summary>
    public class ShapeComponentLine
    {
        /// <summary>
        /// 시작점 x 좌표
        /// </summary>
        private int _startX;

        /// <summary>
        /// 시작점 y 좌표
        /// </summary>
        private int _startY;

        /// <summary>
        /// 끝점 x 좌표
        /// </summary>
        private int _endX;

        /// <summary>
        /// 끝점 y 좌표
        /// </summary>
        private int _endY;

        /// <summary>
        /// 선이 오른쪽이나 아래쪽 부터 시작되었는지 여부
        /// 속성. 처음 생성 시 수직 또는 수평선일 때, 선의 방향이 언제나 오른쪽(위쪽)으로 잡힘으로 인한 현상 때문에,
        /// 방향을 바로 잡아주기 위한 플래그.
        /// </summary>
        private bool _startedRightOrBottom;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentLine()
        {
        }

        /// <summary>
        /// 시작점 x 좌표를 반환하거나 설정한다.
        /// </summary>
        public int StartX
        {
            get => _startX;
            set => _startX = value;
        }

        /// <summary>
        /// 시작점 y 좌표를 반환하거나 설정한다.
        /// </summary>
        public int StartY
        {
            get => _startY;
            set => _startY = value;
        }

        /// <summary>
        /// 끝점 x 좌표를 반환하거나 설정한다.
        /// </summary>
        public int EndX
        {
            get => _endX;
            set => _endX = value;
        }

        /// <summary>
        /// 끝점 y 좌표를 반환하거나 설정한다.
        /// </summary>
        public int EndY
        {
            get => _endY;
            set => _endY = value;
        }

        /// <summary>
        /// 선이 오른쪽이나 아래쪽 부터 시작되었는지 여부를 반환하거나 설정한다.
        /// </summary>
        public bool IsStartedRightOrBottom
        {
            get => _startedRightOrBottom;
            set => _startedRightOrBottom = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentLine from)
        {
            _startX = from._startX;
            _startY = from._startY;
            _endX = from._endX;
            _endY = from._endY;
            _startedRightOrBottom = from._startedRightOrBottom;
        }
    }
}

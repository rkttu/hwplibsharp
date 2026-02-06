// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/InnerMargin.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 안쪽 여백 정보
    /// </summary>
    public class InnerMargin
    {
        /// <summary>
        /// 왼쪽 여백
        /// </summary>
        private int _left;

        /// <summary>
        /// 오른쪽 여백
        /// </summary>
        private int _right;

        /// <summary>
        /// 위쪽 여백
        /// </summary>
        private int _top;

        /// <summary>
        /// 아래쪽 여백
        /// </summary>
        private int _bottom;

        /// <summary>
        /// 생성자
        /// </summary>
        public InnerMargin()
        {
        }

        /// <summary>
        /// 왼쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int Left
        {
            get => _left;
            set => _left = value;
        }

        /// <summary>
        /// 오른쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int Right
        {
            get => _right;
            set => _right = value;
        }

        /// <summary>
        /// 위쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int Top
        {
            get => _top;
            set => _top = value;
        }

        /// <summary>
        /// 아래쪽 여백의 크기를 반환하거나 설정한다.
        /// </summary>
        public int Bottom
        {
            get => _bottom;
            set => _bottom = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(InnerMargin from)
        {
            _left = from._left;
            _right = from._right;
            _top = from._top;
            _bottom = from._bottom;
        }
    }
}

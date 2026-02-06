// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/PageBorderFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 쪽 테두리/배경 정보에 대한 레코드
    /// </summary>
    public class PageBorderFill
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly PageBorderFillProperty _property;

        /// <summary>
        /// 테두리/배경 위치 왼쪽 간격
        /// </summary>
        private int _leftGap;

        /// <summary>
        /// 테두리/배경 위치 오른쪽 간격
        /// </summary>
        private int _rightGap;

        /// <summary>
        /// 테두리/배경 위치 위쪽 간격
        /// </summary>
        private int _topGap;

        /// <summary>
        /// 테두리/배경 위치 아래쪽 간격
        /// </summary>
        private int _bottomGap;

        /// <summary>
        /// 참조된 테두리/배경의 id
        /// </summary>
        private int _borderFillId;

        /// <summary>
        /// 생성자
        /// </summary>
        public PageBorderFill()
        {
            _property = new PageBorderFillProperty();
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public PageBorderFillProperty Property => _property;

        /// <summary>
        /// 테두리/배경 위치 왼쪽 간격을 반환하거나 설정한다.
        /// </summary>
        public int LeftGap
        {
            get => _leftGap;
            set => _leftGap = value;
        }

        /// <summary>
        /// 테두리/배경 위치 오른쪽 간격을 반환하거나 설정한다.
        /// </summary>
        public int RightGap
        {
            get => _rightGap;
            set => _rightGap = value;
        }

        /// <summary>
        /// 테두리/배경 위치 위쪽 간격을 반환하거나 설정한다.
        /// </summary>
        public int TopGap
        {
            get => _topGap;
            set => _topGap = value;
        }

        /// <summary>
        /// 테두리/배경 위치 아래쪽 간격을 반환하거나 설정한다.
        /// </summary>
        public int BottomGap
        {
            get => _bottomGap;
            set => _bottomGap = value;
        }

        /// <summary>
        /// 참조된 테두리/배경의 id를 반환하거나 설정한다.
        /// </summary>
        public int BorderFillId
        {
            get => _borderFillId;
            set => _borderFillId = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PageBorderFill from)
        {
            _property.Copy(from._property);
            _leftGap = from._leftGap;
            _rightGap = from._rightGap;
            _topGap = from._topGap;
            _bottomGap = from._bottomGap;
            _borderFillId = from._borderFillId;
        }
    }
}

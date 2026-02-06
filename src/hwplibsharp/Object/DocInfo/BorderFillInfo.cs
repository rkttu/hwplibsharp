// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/BorderFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 테두리/배경의 모양을 나타내는 레코드
    /// </summary>
    public class BorderFillInfo
    {
        private readonly BorderFillProperty _property;
        private readonly EachBorder _leftBorder;
        private readonly EachBorder _rightBorder;
        private readonly EachBorder _topBorder;
        private readonly EachBorder _bottomBorder;
        private readonly EachBorder _diagonalBorder;
        private readonly FillInfo _fillInfo;

        /// <summary>
        /// <see cref="BorderFillInfo"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public BorderFillInfo()
        {
            _property = new BorderFillProperty();
            _leftBorder = new EachBorder();
            _rightBorder = new EachBorder();
            _topBorder = new EachBorder();
            _bottomBorder = new EachBorder();
            _diagonalBorder = new EachBorder();
            _fillInfo = new FillInfo();
        }

        /// <summary>
        /// 테두리/배경의 속성 정보를 가져옵니다.
        /// </summary>
        public BorderFillProperty Property => _property;

        /// <summary>
        /// 왼쪽 테두리 정보를 가져옵니다.
        /// </summary>
        public EachBorder LeftBorder => _leftBorder;

        /// <summary>
        /// 오른쪽 테두리 정보를 가져옵니다.
        /// </summary>
        public EachBorder RightBorder => _rightBorder;

        /// <summary>
        /// 위쪽 테두리 정보를 가져옵니다.
        /// </summary>
        public EachBorder TopBorder => _topBorder;

        /// <summary>
        /// 아래쪽 테두리 정보를 가져옵니다.
        /// </summary>
        public EachBorder BottomBorder => _bottomBorder;

        /// <summary>
        /// 대각선 테두리 정보를 가져옵니다.
        /// </summary>
        public EachBorder DiagonalBorder => _diagonalBorder;

        /// <summary>
        /// 배경 채우기 정보를 가져옵니다.
        /// </summary>
        public FillInfo FillInfo => _fillInfo;

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="BorderFillInfo"/>의 새 인스턴스입니다.</returns>
        public BorderFillInfo Clone()
        {
            var cloned = new BorderFillInfo();
            cloned._property.Copy(_property);
            cloned._leftBorder.Copy(_leftBorder);
            cloned._rightBorder.Copy(_rightBorder);
            cloned._topBorder.Copy(_topBorder);
            cloned._bottomBorder.Copy(_bottomBorder);
            cloned._diagonalBorder.Copy(_diagonalBorder);
            cloned._fillInfo.Copy(_fillInfo);
            return cloned;
        }
    }
}

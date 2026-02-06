// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/table/ZoneInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Table
{
    /// <summary>
    /// 영역 속성
    /// </summary>
    public class ZoneInfo
    {
        /// <summary>
        /// 시작 열 주소
        /// </summary>
        private int _startColumn;

        /// <summary>
        /// 시작 행 주소
        /// </summary>
        private int _startRow;

        /// <summary>
        /// 끝 열 주소
        /// </summary>
        private int _endColumn;

        /// <summary>
        /// 끝 행 주소
        /// </summary>
        private int _endRow;

        /// <summary>
        /// 참조된 테두리/배경 Id
        /// </summary>
        private int _borderFillId;

        /// <summary>
        /// 생성자
        /// </summary>
        public ZoneInfo()
        {
        }

        /// <summary>
        /// 시작 열 주소를 반환하거나 설정한다.
        /// </summary>
        public int StartColumn
        {
            get => _startColumn;
            set => _startColumn = value;
        }

        /// <summary>
        /// 시작 행 주소를 반환하거나 설정한다.
        /// </summary>
        public int StartRow
        {
            get => _startRow;
            set => _startRow = value;
        }

        /// <summary>
        /// 끝 열 주소를 반환하거나 설정한다.
        /// </summary>
        public int EndColumn
        {
            get => _endColumn;
            set => _endColumn = value;
        }

        /// <summary>
        /// 끝 행 주소를 반환하거나 설정한다.
        /// </summary>
        public int EndRow
        {
            get => _endRow;
            set => _endRow = value;
        }

        /// <summary>
        /// 참조된 테두리/배경 Id를 반환하거나 설정한다.
        /// </summary>
        public int BorderFillId
        {
            get => _borderFillId;
            set => _borderFillId = value;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ZoneInfo Clone()
        {
            ZoneInfo cloned = new ZoneInfo
            {
                _startColumn = _startColumn,
                _startRow = _startRow,
                _endColumn = _endColumn,
                _endRow = _endRow,
                _borderFillId = _borderFillId
            };
            return cloned;
        }
    }
}

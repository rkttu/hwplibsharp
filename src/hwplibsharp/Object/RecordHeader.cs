// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/RecordHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object
{
    /// <summary>
    /// 레코드 헤더
    /// </summary>
    public class RecordHeader
    {
        /// <summary>
        /// 테그 아이디 - 레코드의 종류
        /// </summary>
        private short _tagId;

        /// <summary>
        /// 레벨 - 트리구조에서 항목의 레벨
        /// </summary>
        private short _level;

        /// <summary>
        /// 크기
        /// </summary>
        private long _size;

        /// <summary>
        /// 생성자
        /// </summary>
        public RecordHeader()
        {
        }

        /// <summary>
        /// 테그 아이디를 반환하거나 설정한다.
        /// </summary>
        public short TagId
        {
            get => _tagId;
            set => _tagId = value;
        }

        /// <summary>
        /// 레벨을 반환하거나 설정한다.
        /// </summary>
        public short Level
        {
            get => _level;
            set => _level = value;
        }

        /// <summary>
        /// 크기를 반환하거나 설정한다.
        /// </summary>
        public long Size
        {
            get => _size;
            set => _size = value;
        }

        /// <summary>
        /// 새로운 레코드 헤더 객체를 생성하고 값을 복사한다.
        /// </summary>
        /// <returns>새로 생성된 레코드 헤더 객체</returns>
        public RecordHeader Clone()
        {
            var cloned = new RecordHeader
            {
                _tagId = _tagId,
                _level = _level,
                _size = _size
            };
            return cloned;
        }
    }
}

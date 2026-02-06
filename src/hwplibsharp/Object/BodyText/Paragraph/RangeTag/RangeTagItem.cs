// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/rangetag/RangeTagItem.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;

namespace HwpLib.Object.BodyText.Paragraph.RangeTag
{
    /// <summary>
    /// 영역 태그 정보에 대한 객체
    /// </summary>
    public class RangeTagItem
    {
        /// <summary>
        /// 영역 시작
        /// </summary>
        public long RangeStart { get; set; }

        /// <summary>
        /// 영역 끝
        /// </summary>
        public long RangeEnd { get; set; }

        /// <summary>
        /// 태그 종류
        /// </summary>
        public short Sort { get; set; }

        /// <summary>
        /// 태그 데이터 (3 bytes)
        /// </summary>
        private byte[]? _data;

        /// <summary>
        /// 생성자
        /// </summary>
        public RangeTagItem()
        {
        }

        /// <summary>
        /// 태그 데이터를 반환한다.
        /// </summary>
        public byte[]? Data => _data;

        /// <summary>
        /// 태그 데이터를 설정한다.
        /// </summary>
        /// <param name="data">태그 데이터 (반드시 3 bytes여야 함)</param>
        /// <exception cref="ArgumentException">태그 데이터가 3 bytes가 아닐 때</exception>
        public void SetData(byte[] data)
        {
            if (data.Length != 3)
            {
                throw new ArgumentException("data must be 3 bytes.", nameof(data));
            }
            _data = data;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public RangeTagItem Clone()
        {
            var cloned = new RangeTagItem
            {
                RangeStart = RangeStart,
                RangeEnd = RangeEnd,
                Sort = Sort,
                _data = _data != null ? (byte[])_data.Clone() : null,
            };
            return cloned;
        }
    }
}

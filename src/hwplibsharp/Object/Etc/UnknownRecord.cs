// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/etc/UnknownRecord.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using CfRecordHeader = HwpLib.CompoundFile.RecordHeader;

namespace HwpLib.Object.Etc
{
    /// <summary>
    /// 알려지지 않은 레코드
    /// </summary>
    public class UnknownRecord
    {
        /// <summary>
        /// 레코드 헤더
        /// </summary>
        private RecordHeader? _header;

        /// <summary>
        /// 레코드 데이터
        /// </summary>
        private byte[]? _body;

        /// <summary>
        /// 생성자
        /// </summary>
        public UnknownRecord()
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">레코드 헤더</param>
        public UnknownRecord(RecordHeader header)
        {
            _header = header.Clone();
        }

        /// <summary>
        /// 생성자 (CompoundFile.RecordHeader로부터)
        /// </summary>
        /// <param name="header">CompoundFile 레코드 헤더</param>
        public UnknownRecord(CfRecordHeader header)
        {
            _header = new RecordHeader
            {
                TagId = (short)header.TagId,
                Level = (short)header.Level,
                Size = header.Size
            };
        }

        /// <summary>
        /// 레코드 헤더
        /// </summary>
        public RecordHeader? Header
        {
            get => _header;
            set => _header = value?.Clone();
        }

        /// <summary>
        /// 레코드 데이터
        /// </summary>
        public byte[]? Body
        {
            get => _body;
            set => _body = value;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public UnknownRecord Clone()
        {
            var cloned = new UnknownRecord();
            if (_header != null)
            {
                cloned._header = _header.Clone();
            }
            if (_body != null)
            {
                cloned._body = (byte[])_body.Clone();
            }
            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bindata/EmbeddedBinaryData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BinData;

namespace HwpLib.Object.BinData
{
    /// <summary>
    /// HWP 파일내에서 사용하는 이미지등의 바이너리 데이터를 저장하는 객체
    /// </summary>
    public class EmbeddedBinaryData
    {
        /// <summary>
        /// 바이너리 데이터의 이름
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 실제 데이터
        /// </summary>
        public byte[]? Data { get; set; }

        /// <summary>
        /// 압축 방법
        /// </summary>
        public BinDataCompress CompressMethod { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public EmbeddedBinaryData()
        {
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <param name="deepCopyImage">이미지 데이터를 깊은 복사할지 여부</param>
        /// <returns>복제된 객체</returns>
        public EmbeddedBinaryData Clone(bool deepCopyImage)
        {
            var cloned = new EmbeddedBinaryData
            {
                Name = Name,
                Data = deepCopyImage && Data != null ? (byte[])Data.Clone() : Data,
                CompressMethod = CompressMethod
            };
            return cloned;
        }
    }
}
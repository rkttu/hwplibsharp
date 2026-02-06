// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/bindata/BinDataType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BinData
{
    /// <summary>
    /// 바이너리 데이터의 타입
    /// </summary>
    public enum BinDataType : byte
    {
        /// <summary>
        /// LINK. 그림 외부 파일 참조
        /// </summary>
        Link = 0,

        /// <summary>
        /// EMBEDDING. 그림 파일 포함
        /// </summary>
        Embedding = 1,

        /// <summary>
        /// STORAGE. OLE 포함
        /// </summary>
        Storage = 2
    }

    /// <summary>
    /// BinDataType 확장 메서드
    /// </summary>
    public static class BinDataTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="type">BinDataType 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this BinDataType type)
        {
            return (byte)type;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static BinDataType FromValue(byte value)
        {
            return value switch
            {
                0 => BinDataType.Link,
                1 => BinDataType.Embedding,
                2 => BinDataType.Storage,
                _ => BinDataType.Link
            };
        }
    }
}

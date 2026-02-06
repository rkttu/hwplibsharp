// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/bindata/BinDataCompress.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BinData
{
    /// <summary>
    /// 바이너리 데이터의 압축 방법
    /// </summary>
    public enum BinDataCompress : byte
    {
        /// <summary>
        /// 스토리지의 디폴트 모드 따라감
        /// </summary>
        ByStorageDefault = 0,

        /// <summary>
        /// 무조건 압축
        /// </summary>
        Compress = 1,

        /// <summary>
        /// 무조건 압축하지 않음
        /// </summary>
        NoCompress = 2
    }

    /// <summary>
    /// BinDataCompress 확장 메서드
    /// </summary>
    public static class BinDataCompressExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="compress">BinDataCompress 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this BinDataCompress compress)
        {
            return (byte)compress;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static BinDataCompress FromValue(byte value)
        {
            return value switch
            {
                0 => BinDataCompress.ByStorageDefault,
                1 => BinDataCompress.Compress,
                2 => BinDataCompress.NoCompress,
                _ => BinDataCompress.ByStorageDefault
            };
        }
    }
}

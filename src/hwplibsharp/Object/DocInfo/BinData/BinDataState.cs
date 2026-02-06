// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/bindata/BinDataState.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BinData
{
    /// <summary>
    /// 바이너리 데이터의 상태
    /// </summary>
    public enum BinDataState : byte
    {
        /// <summary>
        /// 아직 access 된 적이 없는 상태
        /// </summary>
        NotAccess = 0,

        /// <summary>
        /// access에 성공하여 파일을 찾은 상태
        /// </summary>
        SuccessAccess = 1,

        /// <summary>
        /// access가 실패한 에러 상태
        /// </summary>
        FailAccess = 2,

        /// <summary>
        /// 링크 access가 실패했으나 무시된 상태
        /// </summary>
        FailAccessButIgnore = 3
    }

    /// <summary>
    /// BinDataState 확장 메서드
    /// </summary>
    public static class BinDataStateExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="state">BinDataState 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this BinDataState state)
        {
            return (byte)state;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static BinDataState FromValue(byte value)
        {
            return value switch
            {
                0 => BinDataState.NotAccess,
                1 => BinDataState.SuccessAccess,
                2 => BinDataState.FailAccess,
                3 => BinDataState.FailAccessButIgnore,
                _ => BinDataState.NotAccess
            };
        }
    }
}

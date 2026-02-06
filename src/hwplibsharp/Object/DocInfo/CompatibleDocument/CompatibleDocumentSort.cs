// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/compatibledocument/CompatibleDocumentSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.CompatibleDocument
{
    /// <summary>
    /// 대상 프로그램의 종류
    /// </summary>
    public enum CompatibleDocumentSort : byte
    {
        /// <summary>
        /// 한글 문서(현재 버전)
        /// </summary>
        HWPCurrent = 0,

        /// <summary>
        /// 한글 2007 호환 문서
        /// </summary>
        HWP2007 = 1,

        /// <summary>
        /// MS 워드 호환 문서
        /// </summary>
        MSWord = 2
    }

    /// <summary>
    /// CompatibleDocumentSort 확장 메서드
    /// </summary>
    public static class CompatibleDocumentSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="sort">CompatibleDocumentSort 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this CompatibleDocumentSort sort)
        {
            return (byte)sort;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static CompatibleDocumentSort FromValue(byte value)
        {
            return value switch
            {
                0 => CompatibleDocumentSort.HWPCurrent,
                1 => CompatibleDocumentSort.HWP2007,
                2 => CompatibleDocumentSort.MSWord,
                _ => CompatibleDocumentSort.HWPCurrent
            };
        }
    }
}

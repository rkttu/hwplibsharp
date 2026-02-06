// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/SetFieldResult.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Tool.ObjectFinder
{
    /// <summary>
    /// SetField 처리 결과상태
    /// </summary>
    public enum SetFieldResult
    {
        /// <summary>
        /// 처리중
        /// </summary>
        InProcess,

        /// <summary>
        /// 파일 끝까지 찾지 못함
        /// </summary>
        NotFound,

        /// <summary>
        /// Text가 남음
        /// </summary>
        TextRemains,

        /// <summary>
        /// 모든 text를 설정함
        /// </summary>
        SetAllText,

        /// <summary>
        /// text가 부족함
        /// </summary>
        NotEnoughText,

        /// <summary>
        /// 기타 에러
        /// </summary>
        ETCError
    }
}

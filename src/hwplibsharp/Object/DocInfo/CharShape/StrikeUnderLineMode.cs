// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/StrikeUnderLineMode.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 취소선/밑줄 모드
    /// </summary>
    public enum StrikeUnderLineMode
    {
        /// <summary>
        /// 취소선과 밑줄 없음
        /// </summary>
        None,
        /// <summary>
        /// 취소선만 있음
        /// </summary>
        OnlyStrike,
        /// <summary>
        /// 밑줄만 있음
        /// </summary>
        OnlyUnderLine,
        /// <summary>
        /// 취소선과 밑줄 모두 있음
        /// </summary>
        StrikeAndUnderLine
    }
}

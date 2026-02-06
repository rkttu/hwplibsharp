// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/tabdef/TabInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill;

namespace HwpLib.Object.DocInfo.TabDef
{
    /// <summary>
    /// 탭 정보에 대한 객체
    /// </summary>
    public class TabInfo
    {
        /// <summary>
        /// 탭의 위치
        /// </summary>
        public uint Position { get; set; }

        /// <summary>
        /// 탭의 종류
        /// </summary>
        public TabSort TabSort { get; set; }

        /// <summary>
        /// 채움 종류
        /// </summary>
        public BorderType FillSort { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public TabInfo()
        {
        }

        /// <summary>
        /// TabInfo를 복제한다.
        /// </summary>
        /// <returns>복제된 TabInfo</returns>
        public TabInfo Clone()
        {
            return new TabInfo
            {
                Position = Position,
                TabSort = TabSort,
                FillSort = FillSort
            };
        }
    }
}

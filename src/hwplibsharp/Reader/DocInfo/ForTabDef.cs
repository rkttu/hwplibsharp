// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForTabDef.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.BorderFill;
using HwpLib.Object.DocInfo.TabDef;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 탭 정의 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForTabDef
    {
        /// <summary>
        /// 탭 정의 레코드를 읽는다.
        /// </summary>
        /// <param name="td">탭 정의 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(TabDefInfo td, CompoundStreamReader sr)
        {
            td.Property.Value = sr.ReadUInt4();
            uint tabInfoCount = sr.ReadUInt4();
            if (tabInfoCount > 0)
            {
                ReadTabInfos(td, sr, tabInfoCount);
            }
        }

        /// <summary>
        /// 탭 정보 부분을 읽는다.
        /// </summary>
        /// <param name="td">탭 정의 레코드</param>
        /// <param name="sr">스트림 리더</param>
        /// <param name="tabInfoCount">탭 정의의 개수</param>
        private static void ReadTabInfos(TabDefInfo td, CompoundStreamReader sr, uint tabInfoCount)
        {
            for (uint i = 0; i < tabInfoCount; i++)
            {
                TabInfo ti = td.AddNewTabInfo();
                ti.Position = sr.ReadUInt4();
                ti.TabSort = TabSortExtensions.FromValue(sr.ReadUInt1());
                ti.FillSort = BorderTypeExtensions.FromValue(sr.ReadUInt1());
                sr.Skip(2); // reserved
            }
        }
    }
}

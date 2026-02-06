// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/TabDefAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 탭 정의 정보를 추가하는 클래스
    /// </summary>
    public static class TabDefInfoAdder
    {
        /// <summary>
        /// 탭 정의 정보를 추가한다.
        /// </summary>
        /// <param name="docInfo">문서 정보</param>
        public static void Add(DocInfo docInfo)
        {
            TabDefInfo1(docInfo.AddNewTabDef());
            TabDefInfo2(docInfo.AddNewTabDef());
        }

        private static void TabDefInfo1(TabDefInfo tabDef)
        {
            tabDef.Property.Value = 0;
        }

        private static void TabDefInfo2(TabDefInfo tabDef)
        {
            tabDef.Property.Value = 1;
        }
    }
}

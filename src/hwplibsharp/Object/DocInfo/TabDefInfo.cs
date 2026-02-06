// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/TabDef.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.TabDef;
using System.Collections.Generic;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 탭 정의에 대한 레코드
    /// </summary>
    public class TabDefInfo
    {
        private readonly TabDefProperty _property;
        private readonly List<TabInfo> _tabInfoList;

        /// <summary>
        /// <see cref="TabDefInfo"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public TabDefInfo()
        {
            _property = new TabDefProperty();
            _tabInfoList = new List<TabInfo>();
        }

        /// <summary>
        /// 탭 정의의 속성 정보를 가져옵니다.
        /// </summary>
        public TabDefProperty Property => _property;

        /// <summary>
        /// 새로운 <see cref="TabInfo"/> 인스턴스를 생성하여 리스트에 추가합니다.
        /// </summary>
        /// <returns>추가된 <see cref="TabInfo"/> 인스턴스입니다.</returns>
        public TabInfo AddNewTabInfo()
        {
            var tabInfo = new TabInfo();
            _tabInfoList.Add(tabInfo);
            return tabInfo;
        }

        /// <summary>
        /// 탭 정보 리스트를 읽기 전용으로 가져옵니다.
        /// </summary>
        public IReadOnlyList<TabInfo> TabInfoList => _tabInfoList;

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="TabDefInfo"/>의 새 인스턴스입니다.</returns>
        public TabDefInfo Clone()
        {
            var cloned = new TabDefInfo();
            cloned._property.Copy(_property);

            cloned._tabInfoList.Clear();
            foreach (var tabInfo in _tabInfoList)
            {
                cloned._tabInfoList.Add(tabInfo.Clone());
            }

            return cloned;
        }
    }
}

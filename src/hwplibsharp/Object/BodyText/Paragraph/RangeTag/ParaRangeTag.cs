// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/rangetag/ParaRangeTag.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Paragraph.RangeTag
{
    /// <summary>
    /// 문단의 영역 태그에 대한 레코드
    /// </summary>
    public class ParaRangeTag
    {
        /// <summary>
        /// 영역 태그 정보에 대한 객체의 리스트
        /// </summary>
        private readonly List<RangeTagItem> _rangeTagItemList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaRangeTag()
        {
            _rangeTagItemList = new List<RangeTagItem>();
        }

        /// <summary>
        /// 영역 태그 정보에 대한 객체의 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<RangeTagItem> RangeTagItemList => _rangeTagItemList;

        /// <summary>
        /// 새로운 영역 태그 정보의 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 영역 태그 정보에 대한 객체</returns>
        public RangeTagItem AddNewRangeTagItem()
        {
            var rt = new RangeTagItem();
            _rangeTagItemList.Add(rt);
            return rt;
        }

        /// <summary>
        /// 영역 태그 정보를 리스트에 추가한다.
        /// </summary>
        /// <param name="item">추가할 RangeTagItem</param>
        public void AddRangeTagItem(RangeTagItem item)
        {
            _rangeTagItemList.Add(item);
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ParaRangeTag Clone()
        {
            var cloned = new ParaRangeTag();

            foreach (var rangeTagItem in _rangeTagItemList)
            {
                cloned._rangeTagItemList.Add(rangeTagItem.Clone());
            }

            return cloned;
        }
    }
}

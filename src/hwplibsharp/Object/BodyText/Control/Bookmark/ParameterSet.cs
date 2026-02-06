// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/bookmark/ParameterSet.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Bookmark
{
    /// <summary>
    /// 파라미터 셋 객체
    /// </summary>
    public class ParameterSet
    {
        /// <summary>
        /// 파라미터 셋 id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 파라미터 아이탬 리스트
        /// </summary>
        private readonly List<ParameterItem> _parameterItemList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ParameterSet()
        {
            Id = 0;
            _parameterItemList = new List<ParameterItem>();
        }

        /// <summary>
        /// 파라미터 아이탬을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 파라미터 아이탬</returns>
        public ParameterItem AddNewParameterItem()
        {
            var pi = new ParameterItem();
            _parameterItemList.Add(pi);
            return pi;
        }

        /// <summary>
        /// 파라미터 아이탬 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<ParameterItem> ParameterItemList => _parameterItemList;

        /// <summary>
        /// 아이디가 id인 파라미터 아이탬을 반환한다.
        /// </summary>
        /// <param name="id">파리미터 아이탬의 아이디</param>
        /// <returns>아이디가 id인 파라미터 아이탬</returns>
        public ParameterItem? GetParameterItem(long id)
        {
            foreach (var pi in _parameterItemList)
            {
                if (pi.Id == id)
                {
                    return pi;
                }
            }
            return null;
        }

        /// <summary>
        /// 필드 이름을 위한 파라미터 셋 객체를 만든다.
        /// </summary>
        /// <param name="fieldName">필드 이름</param>
        /// <returns>필드 이름을 위한 파라미터 셋 객체</returns>
        public static ParameterSet? CreateForFieldName(string? fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return null;
            }

            var ps = new ParameterSet
            {
                Id = 0x21b
            };

            var pi = ps.AddNewParameterItem();
            pi.Id = 0x4000;
            pi.Type = ParameterType.String;
            pi.Value_BSTR = fieldName;

            return ps;
        }

        /// <summary>
        /// 다른 ParameterSet 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParameterSet from)
        {
            Id = from.Id;
            _parameterItemList.Clear();

            foreach (var parameterItem in from._parameterItemList)
            {
                _parameterItemList.Add(parameterItem.Clone());
            }
        }
    }
}

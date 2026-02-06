// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/BodyText.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Paragraph.Memo;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText
{
    /// <summary>
    /// 본문을 나타내는 객체. HWP파일 내에 "BodyText" storage에 저장된다.
    /// </summary>
    public class BodyText
    {
        /// <summary>
        /// 문서 영역(섹션) 리스트
        /// </summary>
        private readonly List<Section> _sectionList;

        /// <summary>
        /// 메모 리스트
        /// </summary>
        private List<Memo>? _memoList;

        /// <summary>
        /// 생성자
        /// </summary>
        public BodyText()
        {
            _sectionList = new List<Section>();
        }

        /// <summary>
        /// 새로운 문서 영역(섹션)을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 문서 영역(섹션)</returns>
        public Section AddNewSection()
        {
            var s = new Section();
            _sectionList.Add(s);
            return s;
        }

        /// <summary>
        /// 문서 영역(섹션) 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<Section> SectionList => _sectionList;

        /// <summary>
        /// 마지막 섹션을 반환한다.
        /// </summary>
        /// <returns>마지막 섹션 (없으면 null)</returns>
        public Section? GetLastSection()
        {
            if (_sectionList.Count == 0)
            {
                return null;
            }
            return _sectionList[_sectionList.Count - 1];
        }

        /// <summary>
        /// 새로운 메모를 생성하여 반환한다.
        /// </summary>
        /// <returns>새로 생성된 메모</returns>
        public Memo AddNewMemo()
        {
            _memoList ??= new List<Memo>();
            var m = new Memo();
            _memoList.Add(m);
            return m;
        }

        /// <summary>
        /// 메모 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<Memo>? MemoList => _memoList;

        /// <summary>
        /// 다른 BodyText 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(BodyText from)
        {
            _sectionList.Clear();
            foreach (var section in from._sectionList)
            {
                _sectionList.Add(section.Clone());
            }

            if (from._memoList != null)
            {
                _memoList = new List<Memo>();
                foreach (var memo in from._memoList)
                {
                    _memoList.Add(memo.Clone());
                }
            }
            else
            {
                _memoList = null;
            }
        }
    }
}

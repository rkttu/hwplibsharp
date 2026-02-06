// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/Section.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.SectionDefine;
using System.Collections;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText
{
    /// <summary>
    /// 문단 구역(섹션)을 나타내는 객체. HWP 파일내의 "BodyText" storage 안에 "Section[번호]" stream에 저장된다.
    /// </summary>
    public class Section : IParagraphList
    {
        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly List<Paragraph.Paragraph> _paragraphList;

        /// <summary>
        /// 마지막 바탕쪽 정보
        /// </summary>
        private BatangPageInfo? _lastBatangPageInfo;

        /// <summary>
        /// 임의의 바탕쪽 정보
        /// </summary>
        private BatangPageInfo? _anyBatangPageInfo;

        /// <summary>
        /// 생성자
        /// </summary>
        public Section()
        {
            _paragraphList = new List<Paragraph.Paragraph>();
            _lastBatangPageInfo = null;
            _anyBatangPageInfo = null;
        }

        /// <summary>
        /// 새로운 문단을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 문단</returns>
        public Paragraph.Paragraph AddNewParagraph()
        {
            var p = new Paragraph.Paragraph();
            _paragraphList.Add(p);
            return p;
        }

        /// <summary>
        /// 문단 개수를 반환한다.
        /// </summary>
        public int ParagraphCount => _paragraphList.Count;

        /// <summary>
        /// index 번째의 문단을 반환한다.
        /// </summary>
        /// <param name="index">찾고자 하는 문단의 순번</param>
        /// <returns>index 번째의 문단</returns>
        public Paragraph.Paragraph GetParagraph(int index)
        {
            return _paragraphList[index];
        }

        /// <summary>
        /// 문단 배열을 리턴한다.
        /// </summary>
        /// <returns>문단 배열</returns>
        public Paragraph.Paragraph[] GetParagraphs()
        {
            return _paragraphList.ToArray();
        }

        /// <summary>
        /// index 번째의 문단을 삭제한다.
        /// </summary>
        /// <param name="index">삭제할 문단의 순번</param>
        public void DeleteParagraph(int index)
        {
            _paragraphList.RemoveAt(index);
        }

        /// <summary>
        /// 모든 문단을 삭제한다.
        /// </summary>
        public void DeleteAllParagraphs()
        {
            _paragraphList.Clear();
        }

        /// <summary>
        /// 문단을 삽입한다.
        /// </summary>
        /// <param name="index">삽입할 위치</param>
        /// <param name="para">문단</param>
        public void InsertParagraph(int index, Paragraph.Paragraph para)
        {
            _paragraphList.Insert(index, para);
        }

        /// <summary>
        /// index 번째의 문단을 새로 생성하여 삽입한다.
        /// </summary>
        /// <param name="index">삽입하고자 하는 문단의 순번</param>
        /// <returns>새로 삽입된 문단</returns>
        public Paragraph.Paragraph InsertNewParagraph(int index)
        {
            var p = new Paragraph.Paragraph();
            _paragraphList.Insert(index, p);
            return p;
        }

        /// <summary>
        /// IEnumerator&lt;Paragraph&gt; 객체를 반환한다.
        /// </summary>
        /// <returns>IEnumerator&lt;Paragraph&gt; 객체</returns>
        public IEnumerator<Paragraph.Paragraph> GetEnumerator()
        {
            return _paragraphList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 마지막 문단을 반환한다.
        /// </summary>
        /// <returns>마지막 문단 (없으면 null)</returns>
        public Paragraph.Paragraph? GetLastParagraph()
        {
            if (_paragraphList.Count > 0)
            {
                return _paragraphList[_paragraphList.Count - 1];
            }
            return null;
        }

        /// <summary>
        /// 마지막 바탕쪽 정보 객체를 생성한다.
        /// </summary>
        public void CreateLastBatangPageInfo()
        {
            _lastBatangPageInfo = new BatangPageInfo();
        }

        /// <summary>
        /// 마지막 바탕쪽 정보를 리턴한다.
        /// </summary>
        public BatangPageInfo? LastBatangPageInfo => _lastBatangPageInfo;

        /// <summary>
        /// 임의의 바탕쪽 정보 객체를 생성한다.
        /// </summary>
        public void CreateAnyBatangPageInfo()
        {
            _anyBatangPageInfo = new BatangPageInfo();
        }

        /// <summary>
        /// 임의의 바탕쪽 정보를 리턴한다.
        /// </summary>
        public BatangPageInfo? AnyBatangPageInfo => _anyBatangPageInfo;

        /// <summary>
        /// Section을 복제한다.
        /// </summary>
        /// <returns>복제된 Section</returns>
        public Section Clone()
        {
            var cloned = new Section();

            cloned._paragraphList.Clear();
            foreach (var paragraph in _paragraphList)
            {
                cloned._paragraphList.Add(paragraph.Clone());
            }

            if (_lastBatangPageInfo != null)
            {
                cloned._lastBatangPageInfo = _lastBatangPageInfo.Clone();
            }
            else
            {
                cloned._lastBatangPageInfo = null;
            }

            if (_anyBatangPageInfo != null)
            {
                cloned._anyBatangPageInfo = _anyBatangPageInfo.Clone();
            }
            else
            {
                cloned._anyBatangPageInfo = null;
            }

            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/ParagraphList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HwpLib.Object.BodyText.Paragraph
{
    /// <summary>
    /// 문단 리스트를 나타내는 객체
    /// </summary>
    public class ParagraphList : IParagraphList
    {
        /// <summary>
        /// 문단 리스트
        /// </summary>
        private readonly List<Paragraph> _paragraphList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ParagraphList()
        {
            _paragraphList = new List<Paragraph>();
        }

        /// <summary>
        /// 새로운 문단를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 문단</returns>
        public Paragraph AddNewParagraph()
        {
            var p = new Paragraph();
            _paragraphList.Add(p);
            return p;
        }

        /// <summary>
        /// 문단를 리스트에 추가한다.
        /// </summary>
        /// <param name="para">추가할 문단</param>
        public void AddParagraph(Paragraph para)
        {
            _paragraphList.Add(para);
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
        public Paragraph GetParagraph(int index)
        {
            return _paragraphList[index];
        }

        /// <summary>
        /// 문단 배열을 리턴한다.
        /// </summary>
        /// <returns>문단 배열</returns>
        public Paragraph[] GetParagraphs()
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
        public void InsertParagraph(int index, Paragraph para)
        {
            _paragraphList.Insert(index, para);
        }

        /// <summary>
        /// index 번째의 문단을 새로 생성하여 삽입한다.
        /// </summary>
        /// <param name="index">삽입하고자 하는 문단의 순번</param>
        /// <returns>새로 삽입된 문단</returns>
        public Paragraph InsertNewParagraph(int index)
        {
            var p = new Paragraph();
            _paragraphList.Insert(index, p);
            return p;
        }

        /// <summary>
        /// IEnumerator를 반환한다.
        /// </summary>
        /// <returns>IEnumerator 객체</returns>
        public IEnumerator<Paragraph> GetEnumerator()
        {
            return _paragraphList.GetEnumerator();
        }

        /// <summary>
        /// IEnumerator를 반환한다.
        /// </summary>
        /// <returns>IEnumerator 객체</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 문단 리스트의 일반 문자열을 반환한다.
        /// </summary>
        /// <returns>문단 리스트의 일반 문자열</returns>
        public string GetNormalString()
        {
            var sb = new StringBuilder();
            foreach (var p in _paragraphList)
            {
                sb.Append(p.GetNormalString());
                sb.Append('\n');
            }
            return sb.ToString();
        }

        /// <summary>
        /// 다른 ParagraphList에서 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본</param>
        public void Copy(ParagraphList from)
        {
            _paragraphList.Clear();
            foreach (var paragraph in from._paragraphList)
            {
                _paragraphList.Add(paragraph.Clone());
            }
        }
    }
}

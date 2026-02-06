// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/ParagraphListInterface.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText
{
    /// <summary>
    /// 문단 리스트 인터페이스
    /// </summary>
    public interface IParagraphList : IEnumerable<Paragraph.Paragraph>
    {
        /// <summary>
        /// 새로운 문단를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 문단</returns>
        Paragraph.Paragraph AddNewParagraph();

        /// <summary>
        /// 문단 개수를 반환한다.
        /// </summary>
        int ParagraphCount { get; }

        /// <summary>
        /// index 번째의 문단을 반환한다.
        /// </summary>
        /// <param name="index">찾고자 하는 문단의 순번</param>
        /// <returns>index 번째의 문단</returns>
        Paragraph.Paragraph GetParagraph(int index);

        /// <summary>
        /// 문단 배열을 리턴한다.
        /// </summary>
        /// <returns>문단 배열</returns>
        Paragraph.Paragraph[] GetParagraphs();

        /// <summary>
        /// index 번째의 문단을 삭제한다.
        /// </summary>
        /// <param name="index">삭제할 문단의 순번</param>
        void DeleteParagraph(int index);

        /// <summary>
        /// 모든 문단을 삭제한다.
        /// </summary>
        void DeleteAllParagraphs();

        /// <summary>
        /// 문단을 삽입한다.
        /// </summary>
        /// <param name="index">삽입할 위치</param>
        /// <param name="para">문단</param>
        void InsertParagraph(int index, Paragraph.Paragraph para);

        /// <summary>
        /// index 번째의 문단을 새로 생성하여 삽입한다.
        /// </summary>
        /// <param name="index">삽입하고자 하는 문단의 순번</param>
        /// <returns>새로 삽입된 문단</returns>
        Paragraph.Paragraph InsertNewParagraph(int index);
    }
}

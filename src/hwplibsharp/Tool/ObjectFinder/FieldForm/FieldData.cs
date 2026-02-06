// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/fieldform/FieldData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Tool.ObjectFinder.FieldForm
{
    /// <summary>
    /// 필드 데이터
    /// </summary>
    public class FieldData
    {
        /// <summary>
        /// 필드 이름
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 필드 타입
        /// </summary>
        public FieldType Type { get; }

        /// <summary>
        /// 부모 객체
        /// </summary>
        public object? Parent { get; }

        /// <summary>
        /// 문단 리스트
        /// </summary>
        public IParagraphList ParagraphList { get; }

        /// <summary>
        /// 시작 문단 인덱스
        /// </summary>
        public int StartParaIndex { get; private set; }

        /// <summary>
        /// 시작 문자 인덱스
        /// </summary>
        public int StartCharIndex { get; private set; }

        /// <summary>
        /// 종료 문단 인덱스
        /// </summary>
        public int EndParaIndex { get; private set; }

        /// <summary>
        /// 종료 문자 인덱스
        /// </summary>
        public int EndCharIndex { get; private set; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="name">필드 이름</param>
        /// <param name="type">필드 타입</param>
        /// <param name="parent">부모 객체</param>
        /// <param name="paragraphList">문단 리스트</param>
        public FieldData(string name, FieldType type, object? parent, IParagraphList paragraphList)
        {
            Name = name;
            Type = type;
            Parent = parent;
            ParagraphList = paragraphList;

            StartParaIndex = -1;
            StartCharIndex = -1;
            EndParaIndex = -1;
            EndCharIndex = -1;
        }

        /// <summary>
        /// 시작 문단을 반환한다.
        /// </summary>
        public Paragraph StartParagraph => ParagraphList.GetParagraph(StartParaIndex);

        /// <summary>
        /// 종료 문단을 반환한다.
        /// </summary>
        public Paragraph EndParagraph => ParagraphList.GetParagraph(EndParaIndex);

        /// <summary>
        /// 시작 위치를 설정한다.
        /// </summary>
        /// <param name="startParaIndex">시작 문단 인덱스</param>
        /// <param name="startCharIndex">시작 문자 인덱스</param>
        public void SetStartPosition(int startParaIndex, int startCharIndex)
        {
            StartParaIndex = startParaIndex;
            StartCharIndex = startCharIndex;
        }

        /// <summary>
        /// 종료 위치를 설정한다.
        /// </summary>
        /// <param name="endParaIndex">종료 문단 인덱스</param>
        /// <param name="endCharIndex">종료 문자 인덱스</param>
        public void SetEndPosition(int endParaIndex, int endCharIndex)
        {
            EndParaIndex = endParaIndex;
            EndCharIndex = endCharIndex;
        }

        /// <summary>
        /// 빈 필드인지 여부를 반환한다.
        /// </summary>
        public bool IsEmptyField()
        {
            return ((Type == FieldType.ClickHere || Type == FieldType.ETC) &&
                    (StartParaIndex != -1 && StartParaIndex == EndParaIndex) &&
                    EndCharIndex - StartCharIndex == 1);
        }
    }
}

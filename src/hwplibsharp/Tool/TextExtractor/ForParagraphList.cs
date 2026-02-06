// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/ForParagraphList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText;
using HwpLib.Tool.TextExtractor.ParaHead;
using System.Text;

namespace HwpLib.Tool.TextExtractor
{
    /// <summary>
    /// 문단 리스트를 위한 텍스트 추출기 객체
    /// </summary>
    public static class ForParagraphList
    {
        /// <summary>
        /// 문단 리스트에서 텍스트를 추출한다.
        /// </summary>
        /// <param name="paragraphList">문단 리스트</param>
        /// <param name="tem">텍스트 추출 방법</param>
        /// <param name="paraHeadMaker">문단 번호/글머리표 생성기</param>
        /// <param name="sb">추출된 텍스트를 저장할 StringBuilder 객체</param>
        public static void Extract(IParagraphList? paragraphList,
                                   TextExtractMethod tem,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            Extract(paragraphList, new TextExtractOption(tem, true), paraHeadMaker, sb);
        }

        /// <summary>
        /// 문단 리스트에서 텍스트를 추출한다.
        /// </summary>
        /// <param name="paragraphList">문단 리스트</param>
        /// <param name="option">추출 옵션</param>
        /// <param name="paraHeadMaker">문단 번호/글머리표 생성기</param>
        /// <param name="sb">추출된 텍스트를 저장할 StringBuilder 객체</param>
        public static void Extract(IParagraphList? paragraphList,
                                   TextExtractOption option,
                                   ParaHeadMaker? paraHeadMaker,
                                   StringBuilder sb)
        {
            if (paragraphList == null || paragraphList.ParagraphCount == 0)
            {
                return;
            }

            for (int index = 0; index < paragraphList.ParagraphCount; index++)
            {
                bool isLast = index == paragraphList.ParagraphCount - 1;

                ForParagraph.Extract(
                    paragraphList.GetParagraph(index),
                    ForParagraph.ParaStart,
                    ForParagraph.ParaEnd,
                    !isLast,
                    option,
                    paraHeadMaker,
                    sb);
            }
        }

        /// <summary>
        /// 지정한 범위(문단 및 문자 인덱스)에서 텍스트를 추출한다.
        /// </summary>
        /// <param name="paragraphList">문단 리스트</param>
        /// <param name="startParaIndex">시작 문단 인덱스</param>
        /// <param name="startCharIndex">시작 문자 인덱스</param>
        /// <param name="endParaIndex">끝 문단 인덱스</param>
        /// <param name="endCharIndex">끝 문자 인덱스</param>
        /// <param name="option">텍스트 추출 옵션</param>
        /// <param name="sb">추출된 텍스트를 저장할 StringBuilder 객체</param>
        public static void Extract(IParagraphList? paragraphList,
                                   int startParaIndex,
                                   int startCharIndex,
                                   int endParaIndex,
                                   int endCharIndex,
                                   TextExtractOption option,
                                   StringBuilder sb)
        {
            if (paragraphList == null) return;

            if (startParaIndex == endParaIndex)
            {
                ForParagraph.Extract(
                    paragraphList.GetParagraph(startParaIndex),
                    startCharIndex,
                    endCharIndex,
                    false,
                    option,
                    null,
                    sb);
            }
            else
            {
                ForParagraph.Extract(
                    paragraphList.GetParagraph(startParaIndex),
                    startCharIndex,
                    ForParagraph.ParaEnd,
                    true,
                    option,
                    null,
                    sb);

                if (startParaIndex + 1 < endParaIndex)
                {
                    for (int paraIndex = startParaIndex + 1; paraIndex <= endParaIndex - 1; paraIndex++)
                    {
                        ForParagraph.Extract(
                            paragraphList.GetParagraph(paraIndex),
                            ForParagraph.ParaStart,
                            ForParagraph.ParaEnd,
                            true,
                            option,
                            null,
                            sb);
                    }
                }

                ForParagraph.Extract(
                    paragraphList.GetParagraph(endParaIndex),
                    ForParagraph.ParaStart,
                    endCharIndex,
                    false,
                    option,
                    null,
                    sb);
            }
        }

        /// <summary>
        /// 지정한 범위(문단 및 문자 인덱스)에서 텍스트를 추출한다.
        /// </summary>
        /// <param name="paragraphList">문단 리스트</param>
        /// <param name="startParaIndex">시작 문단 인덱스</param>
        /// <param name="startCharIndex">시작 문자 인덱스</param>
        /// <param name="endParaIndex">끝 문단 인덱스</param>
        /// <param name="endCharIndex">끝 문자 인덱스</param>
        /// <param name="appendLF">문단 끝에 줄바꿈 추가 여부</param>
        /// <param name="tem">텍스트 추출 방법</param>
        /// <param name="sb">추출된 텍스트를 저장할 StringBuilder 객체</param>
        public static void Extract(IParagraphList? paragraphList,
                                   int startParaIndex,
                                   int startCharIndex,
                                   int endParaIndex,
                                   int endCharIndex,
                                   bool appendLF,
                                   TextExtractMethod tem,
                                   StringBuilder sb)
        {
            Extract(paragraphList, startParaIndex, startCharIndex, endParaIndex, endCharIndex, new TextExtractOption(tem, appendLF), sb);
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 컨트롤 타입
    /// </summary>
    public enum ControlType : uint
    {
        /// <summary>
        /// 표
        /// </summary>
        Table = ('t' << 24) | ('b' << 16) | ('l' << 8) | ' ',

        /// <summary>
        /// 그리기 객체(??)
        /// </summary>
        Gso = ('g' << 24) | ('s' << 16) | ('o' << 8) | ' ',

        /// <summary>
        /// 한글 수식 객체
        /// </summary>
        Equation = ('e' << 24) | ('q' << 16) | ('e' << 8) | 'd',

        /// <summary>
        /// 구역 정의
        /// </summary>
        SectionDefine = ('s' << 24) | ('e' << 16) | ('c' << 8) | 'd',

        /// <summary>
        /// 단 정의
        /// </summary>
        ColumnDefine = ('c' << 24) | ('o' << 16) | ('l' << 8) | 'd',

        /// <summary>
        /// 머리말
        /// </summary>
        Header = ('h' << 24) | ('e' << 16) | ('a' << 8) | 'd',

        /// <summary>
        /// 꼬리말
        /// </summary>
        Footer = ('f' << 24) | ('o' << 16) | ('o' << 8) | 't',

        /// <summary>
        /// 각주
        /// </summary>
        Footnote = ('f' << 24) | ('n' << 16) | (' ' << 8) | ' ',

        /// <summary>
        /// 미주
        /// </summary>
        Endnote = ('e' << 24) | ('n' << 16) | (' ' << 8) | ' ',

        /// <summary>
        /// 자동번호
        /// </summary>
        AutoNumber = ('a' << 24) | ('t' << 16) | ('n' << 8) | 'o',

        /// <summary>
        /// 새 번호 지정
        /// </summary>
        NewNumber = ('n' << 24) | ('w' << 16) | ('n' << 8) | 'o',

        /// <summary>
        /// 감추기
        /// </summary>
        PageHide = ('p' << 24) | ('g' << 16) | ('h' << 8) | 'd',

        /// <summary>
        /// 홀/짝수 조정
        /// </summary>
        PageOddEvenAdjust = ('p' << 24) | ('g' << 16) | ('c' << 8) | 't',

        /// <summary>
        /// 쪽 번호 위치
        /// </summary>
        PageNumberPosition = ('p' << 24) | ('g' << 16) | ('n' << 8) | 'p',

        /// <summary>
        /// 찾아보기 표식
        /// </summary>
        IndexMark = ('i' << 24) | ('d' << 16) | ('x' << 8) | 'm',

        /// <summary>
        /// 책갈피
        /// </summary>
        Bookmark = ('b' << 24) | ('o' << 16) | ('k' << 8) | 'm',

        /// <summary>
        /// 글자 겹침
        /// </summary>
        OverlappingLetter = ('t' << 24) | ('c' << 16) | ('p' << 8) | 's',

        /// <summary>
        /// 덧말
        /// </summary>
        AdditionalText = ('t' << 24) | ('d' << 16) | ('u' << 8) | 't',

        /// <summary>
        /// 숨은 설명
        /// </summary>
        HiddenComment = ('t' << 24) | ('c' << 16) | ('m' << 8) | 't',

        /// <summary>
        /// 양식 개체
        /// </summary>
        Form = ('f' << 24) | ('o' << 16) | ('r' << 8) | 'm',

        /// <summary>
        /// 알 수 없는 필드
        /// </summary>
        FIELD_UNKNOWN = ('%' << 24) | ('u' << 16) | ('n' << 8) | 'k',

        /// <summary>
        /// 날짜 필드
        /// </summary>
        FIELD_DATE = ('%' << 24) | ('d' << 16) | ('t' << 8) | 'e',

        /// <summary>
        /// 문서 날짜 필드
        /// </summary>
        FIELD_DOCDATE = ('%' << 24) | ('d' << 16) | ('d' << 8) | 't',

        /// <summary>
        /// 경로 필드
        /// </summary>
        FIELD_PATH = ('%' << 24) | ('p' << 16) | ('a' << 8) | 't',

        /// <summary>
        /// 책갈피 필드
        /// </summary>
        FIELD_BOOKMARK = ('%' << 24) | ('b' << 16) | ('m' << 8) | 'k',

        /// <summary>
        /// 메일 머지 필드
        /// </summary>
        FIELD_MAILMERGE = ('%' << 24) | ('m' << 16) | ('m' << 8) | 'g',

        /// <summary>
        /// 상호 참조 필드
        /// </summary>
        FIELD_CROSSREF = ('%' << 24) | ('x' << 16) | ('r' << 8) | 'f',

        /// <summary>
        /// 수식 필드
        /// </summary>
        FIELD_FORMULA = ('%' << 24) | ('f' << 16) | ('m' << 8) | 'u',

        /// <summary>
        /// 클릭 유도 필드
        /// </summary>
        FIELD_CLICKHERE = ('%' << 24) | ('c' << 16) | ('l' << 8) | 'k',

        /// <summary>
        /// 요약 정보 필드
        /// </summary>
        FIELD_SUMMARY = ('%' << 24) | ('s' << 16) | ('m' << 8) | 'r',

        /// <summary>
        /// 사용자 정보 필드
        /// </summary>
        FIELD_USERINFO = ('%' << 24) | ('u' << 16) | ('s' << 8) | 'r',

        /// <summary>
        /// 하이퍼링크 필드
        /// </summary>
        FIELD_HYPERLINK = ('%' << 24) | ('h' << 16) | ('l' << 8) | 'k',

        /// <summary>
        /// 개정 서명 필드
        /// </summary>
        FIELD_REVISION_SIGN = ('%' << 24) | ('s' << 16) | ('i' << 8) | 'g',

        /// <summary>
        /// 개정 삭제 필드
        /// </summary>
        FIELD_REVISION_DELETE = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'd',

        /// <summary>
        /// 개정 첨부 필드
        /// </summary>
        FIELD_REVISION_ATTACH = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'a',

        /// <summary>
        /// 개정 클리핑 필드
        /// </summary>
        FIELD_REVISION_CLIPPING = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'C',

        /// <summary>
        /// 개정 생각 필드
        /// </summary>
        FIELD_REVISION_THINKING = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'T',

        /// <summary>
        /// 개정 칭찬 필드
        /// </summary>
        FIELD_REVISION_PRAISE = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'P',

        /// <summary>
        /// 개정 선 필드
        /// </summary>
        FIELD_REVISION_LINE = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'L',

        /// <summary>
        /// 개정 단순 변경 필드
        /// </summary>
        FIELD_REVISION_SIMPLECHANGE = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'c',

        /// <summary>
        /// 개정 하이퍼링크 필드
        /// </summary>
        FIELD_REVISION_HYPERLINK = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'h',

        /// <summary>
        /// 개정 선 첨부 필드
        /// </summary>
        FIELD_REVISION_LINEATTACH = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'A',

        /// <summary>
        /// 개정 선 링크 필드
        /// </summary>
        FIELD_REVISION_LINELINK = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'i',

        /// <summary>
        /// 개정 선 이동 필드
        /// </summary>
        FIELD_REVISION_LINETRANSFER = ('%' << 24) | ('%' << 16) | ('*' << 8) | 't',

        /// <summary>
        /// 개정 오른쪽 이동 필드
        /// </summary>
        FIELD_REVISION_RIGHTMOVE = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'r',

        /// <summary>
        /// 개정 왼쪽 이동 필드
        /// </summary>
        FIELD_REVISION_LEFTMOVE = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'l',

        /// <summary>
        /// 개정 이동 필드
        /// </summary>
        FIELD_REVISION_TRANSFER = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'n',

        /// <summary>
        /// 개정 단순 삽입 필드
        /// </summary>
        FIELD_REVISION_SIMPLEINSERT = ('%' << 24) | ('%' << 16) | ('*' << 8) | 'e',

        /// <summary>
        /// 개정 분할 필드
        /// </summary>
        FIELD_REVISION_SPLIT = ('%' << 24) | ('s' << 16) | ('p' << 8) | 'l',

        /// <summary>
        /// 개정 변경 필드
        /// </summary>
        FIELD_REVISION_CHANGE = ('%' << 24) | ('%' << 16) | ('m' << 8) | 'r',

        /// <summary>
        /// 메모 필드
        /// </summary>
        FIELD_MEMO = ('%' << 24) | ('%' << 16) | ('m' << 8) | 'e',

        /// <summary>
        /// 개인정보 보호 필드
        /// </summary>
        FIELD_PRIVATE_INFO_SECURITY = ('%' << 24) | ('c' << 16) | ('p' << 8) | 'r',

        /// <summary>
        /// 목차 필드
        /// </summary>
        FIELD_TABLEOFCONTENTS = ('%' << 24) | ('t' << 16) | ('o' << 8) | 'c',
    }

    /// <summary>
    /// ControlType enum 확장 메서드
    /// </summary>
    public static class ControlTypeExtensions
    {
        /// <summary>
        /// 컨트롤 id를 반환한다.
        /// </summary>
        /// <param name="controlType">컨트롤 타입</param>
        /// <returns>컨트롤 id</returns>
        public static uint GetCtrlId(this ControlType controlType)
        {
            return (uint)controlType;
        }

        /// <summary>
        /// 필드 인지 여부를 반환한다.
        /// </summary>
        /// <param name="controlType">컨트롤 타입</param>
        /// <returns>필드 인지 여부</returns>
        public static bool IsField(this ControlType controlType)
        {
            return IsField(controlType.GetCtrlId());
        }

        /// <summary>
        /// 컨트롤 id에 해당되는 ControlType을 반환한다.
        /// </summary>
        /// <param name="ctrlId">컨트롤 id</param>
        /// <returns>컨트롤 타입</returns>
        public static ControlType CtrlIdOf(uint ctrlId)
        {
#if NET5_0_OR_GREATER
            // .NET 5+ uses AOT-compatible Enum.GetValues<T>()
            foreach (ControlType ct in System.Enum.GetValues<ControlType>())
#else
            // .NET Framework / .NET Standard uses reflection-based approach (AOT not applicable)
            foreach (ControlType ct in (ControlType[])System.Enum.GetValues(typeof(ControlType)))
#endif
            {
                if ((uint)ct == ctrlId)
                {
                    return ct;
                }
            }
            return ControlType.Table;
        }

        /// <summary>
        /// 컨트롤 id가 필드인지 아닌지 여부를 반환한다.
        /// </summary>
        /// <param name="ctrlId">컨트롤 id</param>
        /// <returns>컨트롤 id가 필드인지 아닌지 여부</returns>
        public static bool IsField(uint ctrlId)
        {
            return ctrlId == (uint)ControlType.FIELD_UNKNOWN
                || ctrlId == (uint)ControlType.FIELD_DATE
                || ctrlId == (uint)ControlType.FIELD_DOCDATE
                || ctrlId == (uint)ControlType.FIELD_PATH
                || ctrlId == (uint)ControlType.FIELD_BOOKMARK
                || ctrlId == (uint)ControlType.FIELD_MAILMERGE
                || ctrlId == (uint)ControlType.FIELD_CROSSREF
                || ctrlId == (uint)ControlType.FIELD_FORMULA
                || ctrlId == (uint)ControlType.FIELD_CLICKHERE
                || ctrlId == (uint)ControlType.FIELD_SUMMARY
                || ctrlId == (uint)ControlType.FIELD_USERINFO
                || ctrlId == (uint)ControlType.FIELD_HYPERLINK
                || ctrlId == (uint)ControlType.FIELD_REVISION_SIGN
                || ctrlId == (uint)ControlType.FIELD_REVISION_DELETE
                || ctrlId == (uint)ControlType.FIELD_REVISION_ATTACH
                || ctrlId == (uint)ControlType.FIELD_REVISION_CLIPPING
                || ctrlId == (uint)ControlType.FIELD_REVISION_THINKING
                || ctrlId == (uint)ControlType.FIELD_REVISION_PRAISE
                || ctrlId == (uint)ControlType.FIELD_REVISION_LINE
                || ctrlId == (uint)ControlType.FIELD_REVISION_SIMPLECHANGE
                || ctrlId == (uint)ControlType.FIELD_REVISION_HYPERLINK
                || ctrlId == (uint)ControlType.FIELD_REVISION_LINEATTACH
                || ctrlId == (uint)ControlType.FIELD_REVISION_LINELINK
                || ctrlId == (uint)ControlType.FIELD_REVISION_LINETRANSFER
                || ctrlId == (uint)ControlType.FIELD_REVISION_RIGHTMOVE
                || ctrlId == (uint)ControlType.FIELD_REVISION_LEFTMOVE
                || ctrlId == (uint)ControlType.FIELD_REVISION_TRANSFER
                || ctrlId == (uint)ControlType.FIELD_REVISION_SIMPLEINSERT
                || ctrlId == (uint)ControlType.FIELD_REVISION_SPLIT
                || ctrlId == (uint)ControlType.FIELD_REVISION_CHANGE
                || ctrlId == (uint)ControlType.FIELD_MEMO
                || ctrlId == (uint)ControlType.FIELD_PRIVATE_INFO_SECURITY
                || ctrlId == (uint)ControlType.FIELD_TABLEOFCONTENTS;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/text/ParaText.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;
using System.Text;

namespace HwpLib.Object.BodyText.Paragraph.Text
{
    /// <summary>
    /// 문단의 텍스트 레코드
    /// </summary>
    public class ParaText
    {
        /// <summary>
        /// 글자(Character) 리스트
        /// </summary>
        private readonly List<HWPChar> _charList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaText()
        {
            _charList = new List<HWPChar>();
        }

        /// <summary>
        /// 글자(Character) 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<HWPChar> CharList => _charList;

        /// <summary>
        /// 새로운 [일반 Character]를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 [일반 Character]</returns>
        public HWPCharNormal AddNewNormalChar()
        {
            var nc = new HWPCharNormal();
            _charList.Add(nc);
            return nc;
        }

        /// <summary>
        /// 새로운 [일반 Character]를 생성하고 지정된 위치에 삽입한다.
        /// </summary>
        /// <param name="position">삽입할 위치</param>
        /// <returns>새로 생성된 [일반 Character]</returns>
        public HWPCharNormal InsertNewNormalChar(int position)
        {
            var nc = new HWPCharNormal();
            _charList.Insert(position, nc);
            return nc;
        }

        /// <summary>
        /// 새로운 [문자 컨트롤 Character]를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 [문자 컨트롤 Character]</returns>
        public HWPCharControlChar AddNewCharControlChar()
        {
            var ccc = new HWPCharControlChar();
            _charList.Add(ccc);
            return ccc;
        }

        /// <summary>
        /// 새로운 [인라인 컨트롤 Character]를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 [인라인 컨트롤 Character]</returns>
        public HWPCharControlInline AddNewInlineControlChar()
        {
            var icc = new HWPCharControlInline();
            _charList.Add(icc);
            return icc;
        }

        /// <summary>
        /// 새로운 [확장 컨트롤 Character]를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 [확장 컨트롤 Character]</returns>
        public HWPCharControlExtend AddNewExtendControlChar()
        {
            var ecc = new HWPCharControlExtend();
            _charList.Add(ecc);
            return ecc;
        }

        /// <summary>
        /// 확장 컨트롤 Character 순번에 해당하는 글자의 문단 내의 순번을 반환한다.
        /// </summary>
        /// <param name="extendCharIndex">확장 컨트롤 Character 순번</param>
        /// <returns>확장 컨트롤 Character 순번에 해당하는 글자의 문단 내의 순번</returns>
        public int GetCharIndexFromExtendCharIndex(int extendCharIndex)
        {
            int extendCharIndex2 = 0;
            int count = _charList.Count;
            for (int index = 0; index < count; index++)
            {
                if (_charList[index].Type == HWPCharType.ControlExtend)
                {
                    if (extendCharIndex == extendCharIndex2)
                    {
                        return index;
                    }
                    extendCharIndex2++;
                }
            }
            return -1;
        }

        /// <summary>
        /// startIndex 순번부터 코드가 charCode인 인라인 컨트롤 character의 순번을 반환한다.
        /// </summary>
        /// <param name="startIndex">검색을 시작할 순번</param>
        /// <param name="charCode">찾을 인라인 컨트롤 character의 코드</param>
        /// <returns>인라인 컨트롤 character의 순번</returns>
        public int GetInlineCharIndex(int startIndex, short charCode)
        {
            int count = _charList.Count;
            for (int index = startIndex; index < count; index++)
            {
                HWPChar ch = _charList[index];
                if (ch.Type == HWPCharType.ControlInline && ch.Code == charCode)
                {
                    return index;
                }
            }
            return -1;
        }

        /// <summary>
        /// startIndex 순번 부터 endIndex 순번 까지의 일반 Character의 문자열을 반환한다.
        /// </summary>
        /// <param name="startIndex">시작 순번</param>
        /// <param name="endIndex">끝 순번</param>
        /// <returns>startIndex 순번 부터 endIndex 순번 까지의 일반 Character의 문자열</returns>
        public string GetNormalString(int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                return string.Empty;
            }
            if (startIndex > endIndex)
            {
                return string.Empty;
            }
            var sb = new StringBuilder();
            for (int index = startIndex; index <= endIndex; index++)
            {
                HWPChar ch = _charList[index];
                if (ch.Type == HWPCharType.Normal)
                {
                    var chn = (HWPCharNormal)ch;
                    sb.Append(chn.Ch);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// startIndex 순번 부터 끝까지의 일반 Character의 문자열을 반환한다
        /// </summary>
        /// <param name="startIndex">시작 순번</param>
        /// <returns>startIndex 순번 부터 끝까지의 일반 Character의 문자열</returns>
        public string GetNormalString(int startIndex)
        {
            return GetNormalString(startIndex, _charList.Count - 1);
        }

        /// <summary>
        /// 문자열을 추가한다.
        /// </summary>
        /// <param name="str">추가할 문자열</param>
        public void AddString(string str)
        {
            int len = str.Length;
            for (int index = 0; index < len; index++)
            {
                HWPCharNormal ch = AddNewNormalChar();
                ch.Code = (short)char.ConvertToUtf32(str, index);
                // 서로게이트 페어 처리
                if (char.IsHighSurrogate(str[index]) && index + 1 < len && char.IsLowSurrogate(str[index + 1]))
                {
                    index++;
                }
            }
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 문자열을 삽입한다.
        /// </summary>
        /// <param name="position">삽입할 위치</param>
        /// <param name="str">추가할 문자열</param>
        /// <returns>추가된 문자 크기</returns>
        public int InsertString(int position, string str)
        {
            int oldCharSize = GetCharSize();

            int len = str.Length;
            for (int strIndex = 0, posOffset = 0; strIndex < len; strIndex++, posOffset++)
            {
                HWPCharNormal ch = InsertNewNormalChar(position + posOffset);
                ch.Code = (short)char.ConvertToUtf32(str, strIndex);
                // 서로게이트 페어 처리
                if (char.IsHighSurrogate(str[strIndex]) && strIndex + 1 < len && char.IsLowSurrogate(str[strIndex + 1]))
                {
                    strIndex++;
                }
            }
            ProcessEndOfParagraph();

            return GetCharSize() - oldCharSize;
        }

        /// <summary>
        /// 구역 정의 컨트롤를 추가하기 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForSectionDefine()
        {
            HWPCharControlExtend chExtend = AddNewExtendControlChar();
            chExtend.Code = 0x0002;
            byte[] addition = new byte[12];
            addition[3] = (byte)'s';
            addition[2] = (byte)'e';
            addition[1] = (byte)'c';
            addition[0] = (byte)'d';
            chExtend.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 문단 끝을 나타내는 문자를 찾아서 마지막으로 보낸다.
        /// </summary>
        private void ProcessEndOfParagraph()
        {
            for (int i = _charList.Count - 1; i >= 0; i--)
            {
                if (_charList[i].Code == 0x0d /* para break */)
                {
                    _charList.RemoveAt(i);
                    break;
                }
            }

            HWPCharNormal ch2 = AddNewNormalChar();
            ch2.Code = 0x0d;
        }

        /// <summary>
        /// 단 정의 컨트롤를 추가하기 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForColumnDefine()
        {
            HWPCharControlExtend chExtend = AddNewExtendControlChar();
            chExtend.Code = 0x0002;
            byte[] addition = new byte[12];
            addition[3] = (byte)'c';
            addition[2] = (byte)'o';
            addition[1] = (byte)'l';
            addition[0] = (byte)'d';
            chExtend.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 표 컨트롤를 추가하기 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForTable()
        {
            HWPCharControlExtend chExtend = AddNewExtendControlChar();
            chExtend.Code = 0x000b;
            byte[] addition = new byte[12];
            addition[3] = (byte)'t';
            addition[2] = (byte)'b';
            addition[1] = (byte)'l';
            addition[0] = (byte)' ';
            chExtend.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 그리기 개체 컨트롤를 추가하기 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForGSO()
        {
            HWPCharControlExtend chExtend = AddNewExtendControlChar();
            chExtend.Code = 0x000b;
            byte[] addition = new byte[12];
            addition[3] = (byte)'g';
            addition[2] = (byte)'s';
            addition[1] = (byte)'o';
            addition[0] = (byte)' ';
            chExtend.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 하이퍼 링크의 시작을 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForHyperlinkStart()
        {
            HWPCharControlExtend chExtend = AddNewExtendControlChar();
            chExtend.Code = 0x0003;
            byte[] addition = new byte[12];
            addition[3] = (byte)'%';
            addition[2] = (byte)'h';
            addition[1] = (byte)'l';
            addition[0] = (byte)'k';
            chExtend.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 하이퍼 링크의 끝을 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForHyperlinkEnd()
        {
            HWPCharControlInline chInline = AddNewInlineControlChar();
            chInline.Code = 0x0004;
            byte[] addition = new byte[12];
            addition[3] = (byte)'%';
            addition[2] = (byte)'h';
            addition[1] = (byte)'l';
            addition[0] = (byte)'k';
            chInline.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 머리말을 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForHeader()
        {
            HWPCharControlExtend chExtend = AddNewExtendControlChar();
            chExtend.Code = 0x0010;
            byte[] addition = new byte[12];
            addition[3] = (byte)'h';
            addition[2] = (byte)'e';
            addition[1] = (byte)'a';
            addition[0] = (byte)'d';
            chExtend.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 꼬리말을 위한 확장 컨트롤 문자를 추가한다.
        /// </summary>
        public void AddExtendCharForFooter()
        {
            HWPCharControlExtend chExtend = AddNewExtendControlChar();
            chExtend.Code = 0x0010;
            byte[] addition = new byte[12];
            addition[3] = (byte)'f';
            addition[2] = (byte)'o';
            addition[1] = (byte)'o';
            addition[0] = (byte)'t';
            chExtend.SetAddition(addition);
            ProcessEndOfParagraph();
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ParaText Clone()
        {
            var cloned = new ParaText();
            foreach (HWPChar hwpChar in _charList)
            {
                cloned._charList.Add(hwpChar.Clone());
            }
            return cloned;
        }

        /// <summary>
        /// 문자 크기를 반환한다.
        /// </summary>
        /// <returns>문자 크기</returns>
        public int GetCharSize()
        {
            int length = 0;
            foreach (HWPChar hwpChar in _charList)
            {
                length += hwpChar.CharSize;
            }
            return length;
        }

        /// <summary>
        /// 문자 크기 (속성)
        /// </summary>
        public int CharSize => GetCharSize();

        /// <summary>
        /// 글자를 지정된 위치에서 삭제한다.
        /// </summary>
        /// <param name="index">삭제할 위치</param>
        public void RemoveCharAt(int index)
        {
            _charList.RemoveAt(index);
        }

        /// <summary>
        /// 글자를 지정된 위치에 삽입한다.
        /// </summary>
        /// <param name="index">삽입할 위치</param>
        /// <param name="hwpChar">삽입할 글자</param>
        public void InsertChar(int index, HWPChar hwpChar)
        {
            _charList.Insert(index, hwpChar);
        }

        /// <summary>
        /// 글자 리스트를 모두 삭제한다.
        /// </summary>
        public void Clear()
        {
            _charList.Clear();
        }

        /// <summary>
        /// 글자를 리스트에 추가한다.
        /// </summary>
        /// <param name="hwpChar">추가할 글자</param>
        public void AddChar(HWPChar hwpChar)
        {
            _charList.Add(hwpChar);
        }
    }
}

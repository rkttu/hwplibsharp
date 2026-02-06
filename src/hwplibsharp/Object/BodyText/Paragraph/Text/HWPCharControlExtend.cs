// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/text/HWPCharControlExtend.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using System;

namespace HwpLib.Object.BodyText.Paragraph.Text
{
    /// <summary>
    /// 확장 컨트롤 Character
    /// </summary>
    public class HWPCharControlExtend : HWPChar
    {
        /// <summary>
        /// 추가 정보
        /// </summary>
        private byte[]? _addition;

        /// <summary>
        /// 생성자
        /// </summary>
        public HWPCharControlExtend()
        {
        }

        /// <summary>
        /// 글자의 종류를 반환한다.
        /// </summary>
        public override HWPCharType Type => HWPCharType.ControlExtend;

        /// <summary>
        /// 글자 크기를 반환한다.
        /// </summary>
        public override int CharSize => 8;

        /// <summary>
        /// 추가 정보를 반환한다.
        /// </summary>
        public byte[]? Addition => _addition;

        /// <summary>
        /// 추가 정보를 설정한다.
        /// </summary>
        /// <param name="addition">추가 정보 (반드시 12 bytes여야 함)</param>
        /// <exception cref="ArgumentException">추가 정보가 12 bytes가 아닐 때</exception>
        public void SetAddition(byte[] addition)
        {
            if (addition.Length != 12)
            {
                throw new ArgumentException("addition's length must be 12", nameof(addition));
            }
            _addition = addition;
        }

        /// <summary>
        /// 컨트롤 객체의 Instance Id를 반환한다.
        /// </summary>
        /// <returns>컨트롤 객체의 Instance Id</returns>
        public string GetInstanceId()
        {
            if (_addition == null)
                return string.Empty;

            int bufferIndex = 0;
            bool insert = false;
            byte[] buf = new byte[_addition.Length];
            for (int index = _addition.Length - 1; index >= 0; index--)
            {
                if (_addition[index] != 0)
                {
                    insert = true;
                }

                if (insert)
                {
                    buf[bufferIndex++] = _addition[index];
                }
            }
            return System.Text.Encoding.ASCII.GetString(buf, 0, bufferIndex);
        }

        private bool HasAddition(char byte1, char byte2, char byte3, char byte4)
        {
            if (_addition != null
                && _addition[3] == byte1
                && _addition[2] == byte2
                && _addition[1] == byte3
                && _addition[0] == byte4)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 구역 정의인지 확인
        /// </summary>
        public bool IsSectionDefine => Code == 0x0002 && HasAddition('s', 'e', 'c', 'd');

        /// <summary>
        /// 단 정의인지 확인
        /// </summary>
        public bool IsColumnDefine => Code == 0x0002 && HasAddition('c', 'o', 'l', 'd');

        /// <summary>
        /// 필드 시작인지 확인
        /// </summary>
        public bool IsFieldStart
        {
            get
            {
                if (Code == 0x0003 && _addition != null)
                {
                    uint ctrlID = CtrlID.Make((char)_addition[3], (char)_addition[2], (char)_addition[1], (char)_addition[0]);
                    return ControlTypeExtensions.IsField(ctrlID);
                }
                return false;
            }
        }

        /// <summary>
        /// 하이퍼링크 시작인지 확인
        /// </summary>
        public bool IsHyperlinkStart => Code == 0x0003 && HasAddition('%', 'h', 'l', 'k');

        /// <summary>
        /// 표인지 확인
        /// </summary>
        public bool IsTable => Code == 0x000b && HasAddition('t', 'b', 'l', ' ');

        /// <summary>
        /// GSO인지 확인
        /// </summary>
        public bool IsGSO => Code == 0x000b && HasAddition('g', 's', 'o', ' ');

        /// <summary>
        /// 수식인지 확인
        /// </summary>
        public bool IsEquation => Code == 0x000b && HasAddition('e', 'q', 'e', 'd');

        /// <summary>
        /// 폼인지 확인
        /// </summary>
        public bool IsForm => Code == 0x000b && HasAddition('f', 'o', 'r', 'm');

        /// <summary>
        /// 숨은 설명인지 확인
        /// </summary>
        public bool IsHiddenComment => Code == 0x000f && HasAddition('t', 'c', 'm', 't');

        /// <summary>
        /// 머리말인지 확인
        /// </summary>
        public bool IsHeader => Code == 0x0010 && HasAddition('h', 'e', 'a', 'd');

        /// <summary>
        /// 꼬리말인지 확인
        /// </summary>
        public bool IsFooter => Code == 0x0010 && HasAddition('f', 'o', 'o', 't');

        /// <summary>
        /// 각주인지 확인
        /// </summary>
        public bool IsFootNote => Code == 0x11 && HasAddition('f', 'n', ' ', ' ');

        /// <summary>
        /// 미주인지 확인
        /// </summary>
        public bool IsEndNote => Code == 0x11 && HasAddition('e', 'n', ' ', ' ');

        /// <summary>
        /// 자동 번호인지 확인
        /// </summary>
        public bool IsAutoNumber => Code == 0x12 && HasAddition('a', 't', 'n', 'o');

        /// <summary>
        /// 페이지 감추기인지 확인
        /// </summary>
        public bool IsPageHide => Code == 0x15 && HasAddition('p', 'g', 'h', 'd');

        /// <summary>
        /// 페이지 홀짝수 조정인지 확인
        /// </summary>
        public bool IsPageOddEvenAdjust => Code == 0x15 && HasAddition('p', 'g', 'c', 't');

        /// <summary>
        /// 페이지 번호 위치인지 확인
        /// </summary>
        public bool IsPageNumberPosition => Code == 0x15 && HasAddition('p', 'g', 'n', 'p');

        /// <summary>
        /// 찾아보기 표식인지 확인
        /// </summary>
        public bool IsIndexMark => Code == 0x0016 && HasAddition('i', 'd', 'x', 'm');

        /// <summary>
        /// 책갈피인지 확인
        /// </summary>
        public bool IsBookmark => Code == 0x0016 && HasAddition('b', 'o', 'k', 'm');

        /// <summary>
        /// 덧말인지 확인
        /// </summary>
        public bool IsAdditionalText => Code == 0x0017 && HasAddition('t', 'd', 'u', 't');

        /// <summary>
        /// 글자 겹침인지 확인
        /// </summary>
        public bool IsOverlappingLetter => Code == 0x0017 && HasAddition('t', 'c', 'p', 's');

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override HWPChar Clone()
        {
            var cloned = new HWPCharControlExtend
            {
                code = code,
                _addition = _addition != null ? (byte[])_addition.Clone() : null,
            };
            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/text/HWPCharControlInline.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;

namespace HwpLib.Object.BodyText.Paragraph.Text
{
    /// <summary>
    /// 인라인 컨트롤 Character
    /// </summary>
    public class HWPCharControlInline : HWPChar
    {
        /// <summary>
        /// 추가 정보
        /// </summary>
        private byte[]? _addition;

        /// <summary>
        /// 생성자
        /// </summary>
        public HWPCharControlInline()
        {
        }

        /// <summary>
        /// 글자의 종류를 반환한다.
        /// </summary>
        public override HWPCharType Type => HWPCharType.ControlInline;

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
        /// 하이퍼링크 끝인지 확인
        /// </summary>
        public bool IsHyperlinkEnd => Code == 0x0004 && HasAddition('%', 'h', 'l', 'k');

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override HWPChar Clone()
        {
            var cloned = new HWPCharControlInline
            {
                code = code,
                _addition = _addition != null ? (byte[])_addition.Clone() : null,
            };
            return cloned;
        }
    }
}

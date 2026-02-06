// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/text/HWPCharControlChar.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Text;

namespace HwpLib.Object.BodyText.Paragraph.Text
{
    /// <summary>
    /// 문자 컨트롤 Character
    /// </summary>
    public class HWPCharControlChar : HWPChar
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public HWPCharControlChar()
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="code">문자 코드</param>
        public HWPCharControlChar(int code)
        {
            this.code = code;
        }

        /// <summary>
        /// 글자의 종류를 반환한다.
        /// </summary>
        public override HWPCharType Type => HWPCharType.ControlChar;

        /// <summary>
        /// 글자 크기를 반환한다.
        /// </summary>
        public override int CharSize => 1;

        /// <summary>
        /// 문자 코드를 설정한다.
        /// </summary>
        /// <param name="ch">문자열</param>
        public void SetCode(string ch)
        {
            byte[] b = Encoding.Unicode.GetBytes(ch); // UTF-16LE

            if (b.Length >= 2)
            {
                Code = ((b[1] & 0xFF) << 8) | (b[0] & 0xFF);
            }
            else if (b.Length == 1)
            {
                Code = b[0] & 0xFF;
            }
            else
            {
                Code = 0;
            }
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override HWPChar Clone()
        {
            return new HWPCharControlChar
            {
                code = code,
            };
        }
    }
}

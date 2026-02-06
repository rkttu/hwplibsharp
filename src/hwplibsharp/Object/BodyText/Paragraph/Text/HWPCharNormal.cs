// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/text/HWPCharNormal.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Text;

namespace HwpLib.Object.BodyText.Paragraph.Text
{
    /// <summary>
    /// 일반 Character
    /// </summary>
    public class HWPCharNormal : HWPChar
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public HWPCharNormal()
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="code">문자 코드</param>
        public HWPCharNormal(int code)
        {
            this.code = code;
        }

        /// <summary>
        /// 글자의 종류를 반환한다.
        /// </summary>
        public override HWPCharType Type => HWPCharType.Normal;

        /// <summary>
        /// 글자 크기를 반환한다.
        /// </summary>
        public override int CharSize => 1;

        /// <summary>
        /// 글자를 반환한다.
        /// </summary>
        public string Ch => IntToString(code);

        /// <summary>
        /// 2 byte 문자코드를 문자열로 변환한다.
        /// </summary>
        /// <param name="code">2 byte 문자코드</param>
        /// <returns>변환된 문자열</returns>
        private static string IntToString(int code)
        {
            byte[] ch = new byte[2];
            ch[0] = (byte)(code & 0xff);
            ch[1] = (byte)((code >> 8) & 0xff);
            return Encoding.Unicode.GetString(ch, 0, 2); // UTF-16LE
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override HWPChar Clone()
        {
            return new HWPCharNormal
            {
                code = code,
            };
        }
    }
}

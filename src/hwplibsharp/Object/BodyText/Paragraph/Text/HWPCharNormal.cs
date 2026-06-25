// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/text/HWPCharNormal.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

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
            // 2 byte 문자코드를 그대로 보존한다. UTF-16 서러게이트 쌍(보충 평면 문자)은
            // 두 개의 HWPCharNormal에 나뉘어 저장되는데, 각 2 byte를 따로 UTF-16LE로
            // 디코딩하면 외톨이 서러게이트가 U+FFFD로 바뀐다. 코드 단위를 그대로 두면
            // Ch를 이어붙이는 StringBuilder에서 서러게이트 쌍이 올바른 코드 포인트로
            // 다시 합쳐진다.
            return ((char)code).ToString();
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

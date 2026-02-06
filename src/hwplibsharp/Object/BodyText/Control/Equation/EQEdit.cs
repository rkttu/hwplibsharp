// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/equation/EQEdit.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.Equation
{
    /// <summary>
    /// 수식 컨트롤의 수식 정보를 나타내는 레코드
    /// </summary>
    public class EQEdit
    {
        /// <summary>
        /// 속성 (스크립트가 차지하는 범위. 첫 비트가 켜져 있으면 줄 단위, 꺼져 있으면 글자 단위??)
        /// </summary>
        public long Property { get; set; }

        /// <summary>
        /// 한글 수식 스크립트
        /// </summary>
        public HWPString Script { get; }

        /// <summary>
        /// 수식 글자 크기
        /// </summary>
        public long LetterSize { get; set; }

        /// <summary>
        /// 글자 색상
        /// </summary>
        public Color4Byte LetterColor { get; }

        /// <summary>
        /// base line
        /// </summary>
        public short BaseLine { get; set; }

        /// <summary>
        /// 알수 없는 2 byte
        /// </summary>
        public int Unknown { get; set; }

        /// <summary>
        /// 버전 정보
        /// </summary>
        public HWPString VersionInfo { get; }

        /// <summary>
        /// 폰트 이름
        /// </summary>
        public HWPString FontName { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        public EQEdit()
        {
            Script = new HWPString();
            LetterColor = new Color4Byte();
            VersionInfo = new HWPString();
            FontName = new HWPString();
        }

        /// <summary>
        /// 다른 EQEdit 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(EQEdit from)
        {
            Property = from.Property;
            Script.Copy(from.Script);
            LetterSize = from.LetterSize;
            LetterColor.Copy(from.LetterColor);
            BaseLine = from.BaseLine;
            Unknown = from.Unknown;
            VersionInfo.Copy(from.VersionInfo);
            FontName.Copy(from.FontName);
        }
    }
}

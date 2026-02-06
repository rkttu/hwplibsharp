// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/documentproperties/StartNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.DocumentProperties
{
    /// <summary>
    /// 각종 시작번호에 대한 정보
    /// </summary>
    public class StartNumber
    {
        /// <summary>
        /// 페이지 시작 번호
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 각주 시작 번호
        /// </summary>
        public int Footnote { get; set; }

        /// <summary>
        /// 미주 시작 번호
        /// </summary>
        public int Endnote { get; set; }

        /// <summary>
        /// 그림 시작 번호
        /// </summary>
        public int Picture { get; set; }

        /// <summary>
        /// 표 시작 번호
        /// </summary>
        public int Table { get; set; }

        /// <summary>
        /// 수식 시작 번호
        /// </summary>
        public int Equation { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public StartNumber()
        {
        }

        /// <summary>
        /// 다른 StartNumber 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(StartNumber from)
        {
            Page = from.Page;
            Footnote = from.Footnote;
            Endnote = from.Endnote;
            Picture = from.Picture;
            Table = from.Table;
            Equation = from.Equation;
        }
    }
}

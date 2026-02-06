// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/documentproperties/CaretPosition.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.DocumentProperties
{
    /// <summary>
    /// 캐럿의 위치 정보
    /// </summary>
    public class CaretPosition
    {
        /// <summary>
        /// 리스트 아이디 - (구역 ??)
        /// </summary>
        public uint ListID { get; set; }

        /// <summary>
        /// 문단 아이디
        /// </summary>
        public uint ParagraphID { get; set; }

        /// <summary>
        /// 문단 내에서의 글자 단위 위치
        /// </summary>
        public uint PositionInParagraph { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public CaretPosition()
        {
        }

        /// <summary>
        /// 다른 CaretPosition 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(CaretPosition from)
        {
            ListID = from.ListID;
            ParagraphID = from.ParagraphID;
            PositionInParagraph = from.PositionInParagraph;
        }
    }
}

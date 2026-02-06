// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/numbering/ParagraphHeadInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.Numbering
{
    /// <summary>
    /// 문단 머리 정보 객체
    /// </summary>
    public class ParagraphHeadInfo
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly ParagraphHeadInfoProperty _property;

        /// <summary>
        /// 너비 보정값
        /// </summary>
        public int CorrectionValueForWidth { get; set; }

        /// <summary>
        /// 본문과의 거리
        /// </summary>
        public int DistanceFromBody { get; set; }

        /// <summary>
        /// 참조된 글자 모양 아이디
        /// </summary>
        public uint CharShapeID { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ParagraphHeadInfo()
        {
            _property = new ParagraphHeadInfoProperty();
        }

        /// <summary>
        /// 문단 머리 정보의 속성 객체를 반환한다.
        /// </summary>
        public ParagraphHeadInfoProperty Property => _property;

        /// <summary>
        /// 다른 ParagraphHeadInfo 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParagraphHeadInfo from)
        {
            _property.Copy(from._property);
            CorrectionValueForWidth = from.CorrectionValueForWidth;
            DistanceFromBody = from.DistanceFromBody;
            CharShapeID = from.CharShapeID;
        }
    }
}

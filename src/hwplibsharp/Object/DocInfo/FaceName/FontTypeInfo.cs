// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/facename/FontTypeInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.FaceName
{
    /// <summary>
    /// 글꼴 유형 정보에 대한 객체
    /// </summary>
    public class FontTypeInfo
    {
        /// <summary>
        /// 글꼴 계열
        /// </summary>
        public short FontType { get; set; }

        /// <summary>
        /// 세리프 유형
        /// </summary>
        public short SerifType { get; set; }

        /// <summary>
        /// 굵기
        /// </summary>
        public short Thickness { get; set; }

        /// <summary>
        /// 비례
        /// </summary>
        public short Ratio { get; set; }

        /// <summary>
        /// 대조
        /// </summary>
        public short Contrast { get; set; }

        /// <summary>
        /// 스트로크 편차
        /// </summary>
        public short StrokeDeviation { get; set; }

        /// <summary>
        /// 자획 유형
        /// </summary>
        public short CharacterStrokeType { get; set; }

        /// <summary>
        /// 글자형
        /// </summary>
        public short CharacterShape { get; set; }

        /// <summary>
        /// 중간선
        /// </summary>
        public short MiddleLine { get; set; }

        /// <summary>
        /// X-높이
        /// </summary>
        public short XHeight { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public FontTypeInfo()
        {
        }

        /// <summary>
        /// 다른 FontTypeInfo 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FontTypeInfo from)
        {
            FontType = from.FontType;
            SerifType = from.SerifType;
            Thickness = from.Thickness;
            Ratio = from.Ratio;
            Contrast = from.Contrast;
            StrokeDeviation = from.StrokeDeviation;
            CharacterStrokeType = from.CharacterStrokeType;
            CharacterShape = from.CharacterShape;
            MiddleLine = from.MiddleLine;
            XHeight = from.XHeight;
        }
    }
}

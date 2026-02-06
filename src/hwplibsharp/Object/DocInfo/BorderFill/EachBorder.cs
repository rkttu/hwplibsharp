// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/EachBorder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// 테두리/배경 객체에서 4방향의 각각의 선을 나타내는 객체
    /// </summary>
    public class EachBorder
    {
        /// <summary>
        /// 선 종류
        /// </summary>
        public BorderType Type { get; set; }

        /// <summary>
        /// 두께
        /// </summary>
        public BorderThickness Thickness { get; set; }

        /// <summary>
        /// 색상
        /// </summary>
        private readonly Color4Byte color;

        /// <summary>
        /// 생성자
        /// </summary>
        public EachBorder()
        {
            color = new Color4Byte();
        }

        /// <summary>
        /// 선의 색상 객체를 반환한다.
        /// </summary>
        public Color4Byte Color => color;

        /// <summary>
        /// 다른 EachBorder 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(EachBorder from)
        {
            Type = from.Type;
            Thickness = from.Thickness;
            color.Copy(from.color);
        }
    }
}

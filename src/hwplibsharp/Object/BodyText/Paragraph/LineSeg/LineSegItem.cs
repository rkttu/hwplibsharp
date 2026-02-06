// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/lineseg/LineSegItem.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Paragraph.LineSeg
{
    /// <summary>
    /// 각 줄의 align 정보에 대한 객체
    /// </summary>
    public class LineSegItem
    {
        /// <summary>
        /// 텍스트 시작 위치
        /// </summary>
        public long TextStartPosition { get; set; }

        /// <summary>
        /// 줄의 세로 위치
        /// </summary>
        public int LineVerticalPosition { get; set; }

        /// <summary>
        /// 줄의 높이
        /// </summary>
        public int LineHeight { get; set; }

        /// <summary>
        /// 텍스트 부분의 높이
        /// </summary>
        public int TextPartHeight { get; set; }

        /// <summary>
        /// 줄의 세로 위치에서 베이스라인까지 거리
        /// </summary>
        public int DistanceBaseLineToLineVerticalPosition { get; set; }

        /// <summary>
        /// 줄간격
        /// </summary>
        public int LineSpace { get; set; }

        /// <summary>
        /// 컬럼에서의 시작 위치
        /// </summary>
        public int StartPositionFromColumn { get; set; }

        /// <summary>
        /// 세그먼트의 폭
        /// </summary>
        public int SegmentWidth { get; set; }

        /// <summary>
        /// tag 정보
        /// </summary>
        public LineSegItemTag Tag { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        public LineSegItem()
        {
            Tag = new LineSegItemTag();
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public LineSegItem Clone()
        {
            var cloned = new LineSegItem
            {
                TextStartPosition = TextStartPosition,
                LineVerticalPosition = LineVerticalPosition,
                LineHeight = LineHeight,
                TextPartHeight = TextPartHeight,
                DistanceBaseLineToLineVerticalPosition = DistanceBaseLineToLineVerticalPosition,
                LineSpace = LineSpace,
                StartPositionFromColumn = StartPositionFromColumn,
                SegmentWidth = SegmentWidth,
            };
            cloned.Tag.Copy(Tag);
            return cloned;
        }
    }
}

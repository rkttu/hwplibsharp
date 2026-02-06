// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/charshape/CharPositionShapeIdPair.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Paragraph.CharShape
{
    /// <summary>
    /// 글자 위치와 글자 모양의 쌍
    /// </summary>
    public class CharPositionShapeIdPair
    {
        /// <summary>
        /// 글자 모양이 바뀌는 시작 위치
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// 글자 모양 ID
        /// </summary>
        public long ShapeId { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public CharPositionShapeIdPair()
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="position">글자 모양이 바뀌는 시작 위치</param>
        /// <param name="shapeId">글자 모양 ID</param>
        public CharPositionShapeIdPair(long position, long shapeId)
        {
            Position = position;
            ShapeId = shapeId;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public CharPositionShapeIdPair Clone()
        {
            return new CharPositionShapeIdPair
            {
                Position = Position,
                ShapeId = ShapeId,
            };
        }
    }
}

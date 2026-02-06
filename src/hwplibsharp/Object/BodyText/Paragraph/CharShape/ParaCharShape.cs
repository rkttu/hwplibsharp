// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/charshape/ParaCharShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Paragraph.CharShape
{
    /// <summary>
    /// 문단의 글자 모양에 대한 레코드.
    /// 예: (위치:0, 글자모양:1), (위치:5, 글자모양:3), (위치:9, 글자모양:2) 이럴 경우,
    /// 1번 글자모양으로 시작해서, 5번째 글자부터 3번으로 글자모양으로 적용되다가, 9번째 글자부터 끝까지 2번 글자모양으로 적용된다.
    /// </summary>
    public class ParaCharShape
    {
        /// <summary>
        /// 위치와 글자 모양의 쌍에 대한 리스트
        /// </summary>
        private readonly List<CharPositionShapeIdPair> _positionShapeIdPairList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaCharShape()
        {
            _positionShapeIdPairList = new List<CharPositionShapeIdPair>();
        }

        /// <summary>
        /// 위치와 글자 모양의 쌍에 대한 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<CharPositionShapeIdPair> PositionShapeIdPairList => _positionShapeIdPairList;

        /// <summary>
        /// position 위치와 charShapeId 글자 모양의 쌍에 대한 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="position">글자모양이 charShapeId로 바꿔지는 글자의 위치</param>
        /// <param name="charShapeId">참조된 글자모양 id</param>
        public void AddParaCharShape(long position, long charShapeId)
        {
            var cpsp = new CharPositionShapeIdPair(position, charShapeId);
            _positionShapeIdPairList.Add(cpsp);
        }

        /// <summary>
        /// 위치와 글자 모양의 쌍을 리스트에 추가한다.
        /// </summary>
        /// <param name="pair">추가할 쌍</param>
        public void AddParaCharShape(CharPositionShapeIdPair pair)
        {
            _positionShapeIdPairList.Add(pair);
        }

        /// <summary>
        /// 위치와 글자 모양의 쌍을 리스트에서 제거한다.
        /// </summary>
        /// <param name="pair">제거할 쌍</param>
        /// <returns>제거 성공 여부</returns>
        public bool RemoveParaCharShape(CharPositionShapeIdPair pair)
        {
            return _positionShapeIdPairList.Remove(pair);
        }

        /// <summary>
        /// 지정된 인덱스의 위치와 글자 모양의 쌍을 리스트에서 제거한다.
        /// </summary>
        /// <param name="index">제거할 인덱스</param>
        public void RemoveParaCharShapeAt(int index)
        {
            _positionShapeIdPairList.RemoveAt(index);
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ParaCharShape Clone()
        {
            var cloned = new ParaCharShape();

            foreach (var charPositionShapeIdPair in _positionShapeIdPairList)
            {
                cloned._positionShapeIdPairList.Add(charPositionShapeIdPair.Clone());
            }

            return cloned;
        }
    }
}

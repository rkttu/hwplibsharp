// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentPolygon.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Polygon;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 다각형 개체 속성 레코드
    /// </summary>
    public class ShapeComponentPolygon
    {
        /// <summary>
        /// 좌표 리스트
        /// </summary>
        private readonly List<PositionXY> _positionList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentPolygon()
        {
            _positionList = new List<PositionXY>();
        }

        /// <summary>
        /// 새로운 좌표 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 좌표 객체</returns>
        public PositionXY AddNewPosition()
        {
            PositionXY p = new PositionXY();
            _positionList.Add(p);
            return p;
        }

        /// <summary>
        /// 좌표 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<PositionXY> PositionList => _positionList;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentPolygon from)
        {
            _positionList.Clear();
            foreach (var positionXY in from._positionList)
            {
                _positionList.Add(positionXY.Clone());
            }
        }
    }
}

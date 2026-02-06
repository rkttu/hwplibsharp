// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentCurve.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Curve;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Polygon;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 곡선 개체 속성 레코드
    /// </summary>
    public class ShapeComponentCurve
    {
        /// <summary>
        /// 좌표 리스트
        /// </summary>
        private readonly List<PositionXY> _positionList;

        /// <summary>
        /// segment type 리스트
        /// </summary>
        private readonly List<CurveSegmentType> _segmentTypeList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentCurve()
        {
            _positionList = new List<PositionXY>();
            _segmentTypeList = new List<CurveSegmentType>();
        }

        /// <summary>
        /// 좌표 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<PositionXY> PositionList => _positionList;

        /// <summary>
        /// segment type 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<CurveSegmentType> SegmentTypeList => _segmentTypeList;

        /// <summary>
        /// 새로운 좌표 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 좌표 객체</returns>
        public PositionXY AddNewPosition()
        {
            var p = new PositionXY();
            _positionList.Add(p);
            return p;
        }

        /// <summary>
        /// segment type을 리스트에 추가한다.
        /// </summary>
        /// <param name="cst">segment type</param>
        public void AddCurveSegmentType(CurveSegmentType cst)
        {
            _segmentTypeList.Add(cst);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentCurve from)
        {
            _positionList.Clear();
            foreach (var positionXY in from._positionList)
            {
                _positionList.Add(positionXY.Clone());
            }

            _segmentTypeList.Clear();
            foreach (var curveSegmentType in from._segmentTypeList)
            {
                _segmentTypeList.Add(curveSegmentType);
            }
        }
    }
}

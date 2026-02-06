// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentLineForObjectLinkLine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.ObjectLinkLine;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// 객체 연결선 컨트롤을 위한 선 개체 속성 레코드
    /// </summary>
    public class ShapeComponentLineForObjectLinkLine
    {
        /// <summary>
        /// 시작점 x 좌표
        /// </summary>
        private int _startX;

        /// <summary>
        /// 시작점 y 좌표
        /// </summary>
        private int _startY;

        /// <summary>
        /// 끝점 x 좌표
        /// </summary>
        private int _endX;

        /// <summary>
        /// 끝점 y 좌표
        /// </summary>
        private int _endY;

        /// <summary>
        /// 연결선 타입
        /// </summary>
        private LinkLineType _type;

        /// <summary>
        /// 시작 대상 ID
        /// </summary>
        private uint _startSubjectID;

        /// <summary>
        /// 시작 대상 인덱스
        /// </summary>
        private uint _startSubjectIndex;

        /// <summary>
        /// 끝 대상 ID
        /// </summary>
        private uint _endSubjectID;

        /// <summary>
        /// 끝 대상 인덱스
        /// </summary>
        private uint _endSubjectIndex;

        /// <summary>
        /// 제어점 리스트
        /// </summary>
        private readonly List<ControlPoint> _controlPoints;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentLineForObjectLinkLine()
        {
            _controlPoints = new List<ControlPoint>();
        }

        /// <summary>
        /// 시작점 x 좌표를 반환하거나 설정한다.
        /// </summary>
        public int StartX
        {
            get => _startX;
            set => _startX = value;
        }

        /// <summary>
        /// 시작점 y 좌표를 반환하거나 설정한다.
        /// </summary>
        public int StartY
        {
            get => _startY;
            set => _startY = value;
        }

        /// <summary>
        /// 끝점 x 좌표를 반환하거나 설정한다.
        /// </summary>
        public int EndX
        {
            get => _endX;
            set => _endX = value;
        }

        /// <summary>
        /// 끝점 y 좌표를 반환하거나 설정한다.
        /// </summary>
        public int EndY
        {
            get => _endY;
            set => _endY = value;
        }

        /// <summary>
        /// 연결선 타입을 반환하거나 설정한다.
        /// </summary>
        public LinkLineType Type
        {
            get => _type;
            set => _type = value;
        }

        /// <summary>
        /// 시작 대상 ID를 반환하거나 설정한다.
        /// </summary>
        public uint StartSubjectID
        {
            get => _startSubjectID;
            set => _startSubjectID = value;
        }

        /// <summary>
        /// 시작 대상 인덱스를 반환하거나 설정한다.
        /// </summary>
        public uint StartSubjectIndex
        {
            get => _startSubjectIndex;
            set => _startSubjectIndex = value;
        }

        /// <summary>
        /// 끝 대상 ID를 반환하거나 설정한다.
        /// </summary>
        public uint EndSubjectID
        {
            get => _endSubjectID;
            set => _endSubjectID = value;
        }

        /// <summary>
        /// 끝 대상 인덱스를 반환하거나 설정한다.
        /// </summary>
        public uint EndSubjectIndex
        {
            get => _endSubjectIndex;
            set => _endSubjectIndex = value;
        }

        /// <summary>
        /// 제어점 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<ControlPoint> ControlPoints => _controlPoints;

        /// <summary>
        /// 새로운 제어점 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 제어점 객체</returns>
        public ControlPoint AddNewControlPoint()
        {
            var newCP = new ControlPoint();
            _controlPoints.Add(newCP);
            return newCP;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentLineForObjectLinkLine from)
        {
            _startX = from._startX;
            _startY = from._startY;
            _endX = from._endX;
            _endY = from._endY;
            _type = from._type;
            _startSubjectID = from._startSubjectID;
            _startSubjectIndex = from._startSubjectIndex;
            _endSubjectID = from._endSubjectID;
            _endSubjectIndex = from._endSubjectIndex;

            _controlPoints.Clear();
            foreach (var fromCP in from._controlPoints)
            {
                AddNewControlPoint().Copy(fromCP);
            }
        }
    }
}

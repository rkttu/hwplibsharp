// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/GradientFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;
using System.Collections.Generic;

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 그러데이션 채우기 객체
    /// </summary>
    public class GradientFill
    {
        /// <summary>
        /// 그러데이션 유형
        /// </summary>
        private GradientType _gradientType;

        /// <summary>
        /// 그러데이션의 기울임
        /// </summary>
        private uint _startAngle;

        /// <summary>
        /// 그러데이션의 가로 중심
        /// </summary>
        private uint _centerX;

        /// <summary>
        /// 그러데이션의 세로 중심
        /// </summary>
        private uint _centerY;

        /// <summary>
        /// 그러데이션 번짐 정도(0 -100)
        /// </summary>
        private uint _blurringDegree;

        /// <summary>
        /// 색상이 바뀌는 곳의 위치 리스트 (num > 2 일 경우에만)
        /// </summary>
        private readonly List<int> _changePointList;

        /// <summary>
        /// 색상 리스트
        /// </summary>
        private readonly List<Color4Byte> _colorList;

        /// <summary>
        /// 번짐 중심 (추가 속성)
        /// </summary>
        private short _blurringCenter;

        /// <summary>
        /// 생성자
        /// </summary>
        public GradientFill()
        {
            _changePointList = new List<int>();
            _colorList = new List<Color4Byte>();
        }

        /// <summary>
        /// 그러데이션 유형을 반환하거나 설정한다.
        /// </summary>
        public GradientType GradientType
        {
            get => _gradientType;
            set => _gradientType = value;
        }

        /// <summary>
        /// 그러데이션의 기울임을 반환하거나 설정한다.
        /// </summary>
        public uint StartAngle
        {
            get => _startAngle;
            set => _startAngle = value;
        }

        /// <summary>
        /// 그러데이션의 가로 중심을 반환하거나 설정한다.
        /// </summary>
        public uint CenterX
        {
            get => _centerX;
            set => _centerX = value;
        }

        /// <summary>
        /// 그러데이션의 세로 중심을 반환하거나 설정한다.
        /// </summary>
        public uint CenterY
        {
            get => _centerY;
            set => _centerY = value;
        }

        /// <summary>
        /// 그러데이션 번짐 정도를 반환하거나 설정한다.
        /// </summary>
        public uint BlurringDegree
        {
            get => _blurringDegree;
            set => _blurringDegree = value;
        }

        /// <summary>
        /// 색상이 바뀌는 곳의 위치 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<int> ChangePointList => _changePointList;

        /// <summary>
        /// 색상 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<Color4Byte> ColorList => _colorList;

        /// <summary>
        /// 번짐 중심을 반환하거나 설정한다.
        /// </summary>
        public short BlurringCenter
        {
            get => _blurringCenter;
            set => _blurringCenter = value;
        }

        /// <summary>
        /// 색상이 바뀌는 곳의 위치를 추가한다.
        /// </summary>
        /// <param name="changePoint">색상이 바뀌는 곳의 위치</param>
        public void AddChangePoint(int changePoint)
        {
            _changePointList.Add(changePoint);
        }

        /// <summary>
        /// 새로운 색상 객체를 생성하고 색상 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 색상 객체</returns>
        public Color4Byte AddNewColor()
        {
            var c = new Color4Byte();
            _colorList.Add(c);
            return c;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(GradientFill from)
        {
            _gradientType = from._gradientType;
            _startAngle = from._startAngle;
            _centerX = from._centerX;
            _centerY = from._centerY;
            _blurringDegree = from._blurringDegree;

            _changePointList.Clear();
            foreach (var changePoint in from._changePointList)
            {
                _changePointList.Add(changePoint);
            }

            _colorList.Clear();
            foreach (var color4Byte in from._colorList)
            {
                _colorList.Add(color4Byte.Clone());
            }

            _blurringCenter = from._blurringCenter;
        }
    }
}

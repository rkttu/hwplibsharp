// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/renderinginfo/Matrix.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.RenderingInfo
{
    /// <summary>
    /// 행렬을 나타내는 객체. 각 행렬는 원소가 double로 표현되는 3 X 3 matrix로 구현된다.
    /// 마지막 행은 항상 [0,0,1]이기 떄문에 생략되어 실제 6개의 원소만 저장한다.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// 행렬의 원소를 저장하는 배열
        /// </summary>
        private double[] _values;

        /// <summary>
        /// 생성자
        /// </summary>
        public Matrix()
        {
            _values = new double[6];
        }

        /// <summary>
        /// 행렬의 원소를 반환한다.
        /// </summary>
        /// <param name="index">원소의 인덱스</param>
        /// <returns>행렬의 원소</returns>
        public double GetValue(int index)
        {
            return _values[index];
        }

        /// <summary>
        /// 행렬의 원소를 설정한다.
        /// </summary>
        /// <param name="index">원소의 인덱스</param>
        /// <param name="value">행렬의 원소</param>
        public void SetValue(int index, double value)
        {
            _values[index] = value;
        }

        /// <summary>
        /// 행렬의 원소를 저장하는 배열을 반환한다.
        /// </summary>
        public double[] Values => _values;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(Matrix from)
        {
            _values = (double[])from._values.Clone();
        }
    }
}

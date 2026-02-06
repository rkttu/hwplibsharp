// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/renderinginfo/ScaleRotateMatrixPair.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.RenderingInfo
{
    /// <summary>
    /// 확장/회전을 위한 행렬의 쌍을 나타내는 객체
    /// </summary>
    public class ScaleRotateMatrixPair
    {
        /// <summary>
        /// 확장을 위한 행렬
        /// </summary>
        private readonly Matrix _scaleMatrix;

        /// <summary>
        /// 회전을 위한 행렬
        /// </summary>
        private readonly Matrix _rotateMatrix;

        /// <summary>
        /// 생성자
        /// </summary>
        public ScaleRotateMatrixPair()
        {
            _scaleMatrix = new Matrix();
            _rotateMatrix = new Matrix();
        }

        /// <summary>
        /// 확장을 위한 행렬을 반환한다.
        /// </summary>
        public Matrix ScaleMatrix => _scaleMatrix;

        /// <summary>
        /// 회전을 위한 행렬을 반환한다.
        /// </summary>
        public Matrix RotateMatrix => _rotateMatrix;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ScaleRotateMatrixPair Clone()
        {
            var cloned = new ScaleRotateMatrixPair();
            cloned._scaleMatrix.Copy(_scaleMatrix);
            cloned._rotateMatrix.Copy(_rotateMatrix);
            return cloned;
        }
    }
}

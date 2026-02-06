// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/renderinginfo/RenderingInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.RenderingInfo
{
    /// <summary>
    /// Rendering 정보
    /// </summary>
    public class RenderingInfo
    {
        /// <summary>
        /// 이동을 위한 행렬
        /// </summary>
        private readonly Matrix _translationMatrix;

        /// <summary>
        /// 확장/회전을 위한 행렬의 쌍에 대한 리스트
        /// </summary>
        private readonly List<ScaleRotateMatrixPair> _scaleRotateMatrixPairList;

        /// <summary>
        /// 생성자
        /// </summary>
        public RenderingInfo()
        {
            _translationMatrix = new Matrix();
            _scaleRotateMatrixPairList = new List<ScaleRotateMatrixPair>();
        }

        /// <summary>
        /// 이동을 위한 행렬 객체를 반환한다.
        /// </summary>
        public Matrix TranslationMatrix => _translationMatrix;

        /// <summary>
        /// 확장/회전을 위한 행렬의 쌍에 대한 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<ScaleRotateMatrixPair> ScaleRotateMatrixPairList => _scaleRotateMatrixPairList;

        /// <summary>
        /// 새로운 확장/회전을 위한 행렬의 쌍을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 확장/회전을 위한 행렬의 쌍</returns>
        public ScaleRotateMatrixPair AddNewScaleRotateMatrixPair()
        {
            var srmp = new ScaleRotateMatrixPair();
            _scaleRotateMatrixPairList.Add(srmp);
            return srmp;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(RenderingInfo from)
        {
            _translationMatrix.Copy(from._translationMatrix);

            _scaleRotateMatrixPairList.Clear();
            foreach (var matrixPair in from._scaleRotateMatrixPairList)
            {
                _scaleRotateMatrixPairList.Add(matrixPair.Clone());
            }
        }
    }
}

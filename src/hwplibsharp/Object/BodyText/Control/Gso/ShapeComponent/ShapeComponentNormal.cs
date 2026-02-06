// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/ShapeComponentNormal.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill.FillInfo;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent
{
    /// <summary>
    /// 일반 컨트롤을 위한 객체 공통 속성 레코드
    /// </summary>
    public class ShapeComponentNormal : ShapeComponent
    {
        /// <summary>
        /// 테두리 선 정보
        /// </summary>
        private LineInfo.LineInfo? _lineInfo;

        /// <summary>
        /// 채움 정보
        /// </summary>
        private FillInfo? _fillInfo;

        /// <summary>
        /// 그림자 정보
        /// </summary>
        private ShadowInfo.ShadowInfo? _shadowInfo;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentNormal()
        {
            _lineInfo = null;
            _fillInfo = null;
            _shadowInfo = null;
        }

        /// <summary>
        /// 테두리 선 정보 객체를 반환한다.
        /// </summary>
        public LineInfo.LineInfo? LineInfo => _lineInfo;

        /// <summary>
        /// 채움 정보 객체를 반환한다.
        /// </summary>
        public FillInfo? FillInfo => _fillInfo;

        /// <summary>
        /// 그림자 정보 객체를 반환한다.
        /// </summary>
        public ShadowInfo.ShadowInfo? ShadowInfo => _shadowInfo;

        /// <summary>
        /// 테두리 선 정보 객체를 생성한다.
        /// </summary>
        public void CreateLineInfo()
        {
            _lineInfo = new LineInfo.LineInfo();
        }

        /// <summary>
        /// 테두리 선 정보 객체를 삭제한다.
        /// </summary>
        public void DeleteLineInfo()
        {
            _lineInfo = null;
        }

        /// <summary>
        /// 채움 정보 객체를 생성한다.
        /// </summary>
        public void CreateFillInfo()
        {
            _fillInfo = new FillInfo();
        }

        /// <summary>
        /// 채움 정보 객체를 삭제한다.
        /// </summary>
        public void DeleteFillInfo()
        {
            _fillInfo = null;
        }

        /// <summary>
        /// 그림자 정보 객체를 생성한다.
        /// </summary>
        public void CreateShadowInfo()
        {
            _shadowInfo = new ShadowInfo.ShadowInfo();
        }

        /// <summary>
        /// 그림자 정보 객체를 삭제한다.
        /// </summary>
        public void DeleteShadowInfo()
        {
            _shadowInfo = null;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public override void Copy(ShapeComponent from)
        {
            CopyShapeComponent(from);

            if (from is ShapeComponentNormal from2)
            {
                if (from2._lineInfo != null)
                {
                    CreateLineInfo();
                    _lineInfo!.Copy(from2._lineInfo);
                }
                else
                {
                    _lineInfo = null;
                }

                if (from2._fillInfo != null)
                {
                    CreateFillInfo();
                    _fillInfo!.Copy(from2._fillInfo);
                }
                else
                {
                    _fillInfo = null;
                }

                if (from2._shadowInfo != null)
                {
                    CreateShadowInfo();
                    _shadowInfo!.Copy(from2._shadowInfo);
                }
                else
                {
                    _shadowInfo = null;
                }
            }
        }
    }
}

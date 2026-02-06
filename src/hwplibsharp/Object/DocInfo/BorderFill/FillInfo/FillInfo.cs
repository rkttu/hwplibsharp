// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/FillInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 채우기 정보를 나타내는 객체
    /// </summary>
    public class FillInfo
    {
        /// <summary>
        /// 채우기 종류
        /// </summary>
        private readonly FillType _type;

        /// <summary>
        /// 단색 채우기
        /// </summary>
        private PatternFill? _patternFill;

        /// <summary>
        /// 그러데이션 채우기
        /// </summary>
        private GradientFill? _gradientFill;

        /// <summary>
        /// 이미지 채우기
        /// </summary>
        private ImageFill? _imageFill;

        /// <summary>
        /// 생성자
        /// </summary>
        public FillInfo()
        {
            _type = new FillType();
        }

        /// <summary>
        /// 채우기 종류 객체를 반환한다.
        /// </summary>
        public FillType Type => _type;

        /// <summary>
        /// 단색 채우기 객체를 반환한다.
        /// </summary>
        public PatternFill? PatternFill => _patternFill;

        /// <summary>
        /// 그러데이션 채우기 객체를 반환한다.
        /// </summary>
        public GradientFill? GradientFill => _gradientFill;

        /// <summary>
        /// 이미지 채우기 객체를 반환한다.
        /// </summary>
        public ImageFill? ImageFill => _imageFill;

        /// <summary>
        /// 단색 채우기 객체를 생성한다.
        /// </summary>
        public void CreatePatternFill()
        {
            _patternFill = new PatternFill();
        }

        /// <summary>
        /// 단색 채우기 객체를 삭제한다.
        /// </summary>
        public void DeletePatternFill()
        {
            _patternFill = null;
        }

        /// <summary>
        /// 그러데이션 채우기 객체를 생성한다.
        /// </summary>
        public void CreateGradientFill()
        {
            _gradientFill = new GradientFill();
        }

        /// <summary>
        /// 그러데이션 채우기 객체를 삭제한다.
        /// </summary>
        public void DeleteGradientFill()
        {
            _gradientFill = null;
        }

        /// <summary>
        /// 이미지 채우기 객체를 생성한다.
        /// </summary>
        public void CreateImageFill()
        {
            _imageFill = new ImageFill();
        }

        /// <summary>
        /// 이미지 채우기 객체를 삭제한다.
        /// </summary>
        public void DeleteImageFill()
        {
            _imageFill = null;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FillInfo from)
        {
            _type.Copy(from._type);

            if (from._patternFill != null)
            {
                CreatePatternFill();
                _patternFill!.Copy(from._patternFill);
            }
            else
            {
                DeletePatternFill();
            }

            if (from._gradientFill != null)
            {
                CreateGradientFill();
                _gradientFill!.Copy(from._gradientFill);
            }
            else
            {
                DeleteGradientFill();
            }

            if (from._imageFill != null)
            {
                CreateImageFill();
                _imageFill!.Copy(from._imageFill);
            }
            else
            {
                DeleteImageFill();
            }
        }
    }
}

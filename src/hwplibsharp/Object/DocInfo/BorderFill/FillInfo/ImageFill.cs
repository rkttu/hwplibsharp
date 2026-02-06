// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/ImageFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 이미지 채우기 객체
    /// </summary>
    public class ImageFill
    {
        /// <summary>
        /// 이미지 채우기 유형
        /// </summary>
        private ImageFillType _imageFillType;

        /// <summary>
        /// 그림 정보
        /// </summary>
        private readonly PictureInfo _pictureInfo;

        /// <summary>
        /// 생성자
        /// </summary>
        public ImageFill()
        {
            _pictureInfo = new PictureInfo();
        }

        /// <summary>
        /// 이미지 채우기 유형을 반환하거나 설정한다.
        /// </summary>
        public ImageFillType ImageFillType
        {
            get => _imageFillType;
            set => _imageFillType = value;
        }

        /// <summary>
        /// 그림 정보 객체를 반환한다.
        /// </summary>
        public PictureInfo PictureInfo => _pictureInfo;

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ImageFill from)
        {
            _imageFillType = from._imageFillType;
            _pictureInfo.Copy(from._pictureInfo);
        }
    }
}

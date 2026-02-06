// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/PictureInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 그림 정보 객체
    /// </summary>
    public class PictureInfo
    {
        /// <summary>
        /// 밝기
        /// </summary>
        private sbyte _brightness;

        /// <summary>
        /// 명암
        /// </summary>
        private sbyte _contrast;

        /// <summary>
        /// 그림 효과
        /// </summary>
        private PictureEffect _effect;

        /// <summary>
        /// BinItem의 아이디 참조값 - 이미지가 저장된 바이너리 데이터의 id
        /// </summary>
        private int _binItemID;

        /// <summary>
        /// 생성자
        /// </summary>
        public PictureInfo()
        {
            _effect = PictureEffect.RealPicture;
        }

        /// <summary>
        /// 밝기를 반환하거나 설정한다.
        /// </summary>
        public sbyte Brightness
        {
            get => _brightness;
            set => _brightness = value;
        }

        /// <summary>
        /// 명암을 반환하거나 설정한다.
        /// </summary>
        public sbyte Contrast
        {
            get => _contrast;
            set => _contrast = value;
        }

        /// <summary>
        /// 그림 효과를 반환하거나 설정한다.
        /// </summary>
        public PictureEffect Effect
        {
            get => _effect;
            set => _effect = value;
        }

        /// <summary>
        /// BinItem의 아이디 참조값을 반환하거나 설정한다.
        /// </summary>
        public int BinItemID
        {
            get => _binItemID;
            set => _binItemID = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PictureInfo from)
        {
            _brightness = from._brightness;
            _contrast = from._contrast;
            _effect = from._effect;
            _binItemID = from._binItemID;
        }
    }
}

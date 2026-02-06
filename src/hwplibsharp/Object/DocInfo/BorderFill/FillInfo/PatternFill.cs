// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/PatternFill.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 단색 채우기 객체
    /// </summary>
    public class PatternFill
    {
        /// <summary>
        /// 배경색
        /// </summary>
        private readonly Color4Byte _backColor;

        /// <summary>
        /// 무늬색
        /// </summary>
        private readonly Color4Byte _patternColor;

        /// <summary>
        /// 무늬 종류
        /// </summary>
        private PatternType _patternType;

        /// <summary>
        /// 생성자
        /// </summary>
        public PatternFill()
        {
            _backColor = new Color4Byte();
            _patternColor = new Color4Byte();
        }

        /// <summary>
        /// 배경색 객체를 반환한다.
        /// </summary>
        public Color4Byte BackColor => _backColor;

        /// <summary>
        /// 무늬색 객체를 반환한다.
        /// </summary>
        public Color4Byte PatternColor => _patternColor;

        /// <summary>
        /// 무늬 종류를 반환하거나 설정한다.
        /// </summary>
        public PatternType PatternType
        {
            get => _patternType;
            set => _patternType = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PatternFill from)
        {
            _backColor.Copy(from._backColor);
            _patternColor.Copy(from._patternColor);
            _patternType = from._patternType;
        }
    }
}

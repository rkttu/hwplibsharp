// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/FillType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 채우기 종류
    /// </summary>
    public class FillType
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private uint _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public FillType()
        {
        }

        /// <summary>
        /// 파일에 저장되는 정수값을 반환하거나 설정한다.
        /// </summary>
        public uint Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// 단색 채우기 적용 여부를 반환하거나 설정한다. (0 bit)
        /// </summary>
        public bool HasPatternFill
        {
            get => BitFlag.Get(_value, 0);
            set => _value = (uint)BitFlag.Set(_value, 0, value);
        }

        /// <summary>
        /// 이미지 채우기 적용 여부를 반환하거나 설정한다. (1 bit)
        /// </summary>
        public bool HasImageFill
        {
            get => BitFlag.Get(_value, 1);
            set => _value = (uint)BitFlag.Set(_value, 1, value);
        }

        /// <summary>
        /// 그러데이션 채우기 적용 여부를 반환하거나 설정한다. (2 bit)
        /// </summary>
        public bool HasGradientFill
        {
            get => BitFlag.Get(_value, 2);
            set => _value = (uint)BitFlag.Set(_value, 2, value);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FillType from)
        {
            _value = from._value;
        }
    }
}

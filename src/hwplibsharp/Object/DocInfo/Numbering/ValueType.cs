// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/numbering/ValueType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.Numbering
{
    /// <summary>
    /// 수준별 본문과의 거리 종류
    /// </summary>
    public enum ValueType : byte
    {
        /// <summary>
        /// 글자 크기에 대한 상대 비율
        /// </summary>
        RatioForLetter = 0,

        /// <summary>
        /// 값
        /// </summary>
        Value = 1
    }

    /// <summary>
    /// ValueType 확장 메서드
    /// </summary>
    public static class ValueTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ValueType valueType)
        {
            return (byte)valueType;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ValueType FromValue(byte value)
        {
            return value switch
            {
                0 => ValueType.RatioForLetter,
                1 => ValueType.Value,
                _ => ValueType.RatioForLetter
            };
        }
    }
}

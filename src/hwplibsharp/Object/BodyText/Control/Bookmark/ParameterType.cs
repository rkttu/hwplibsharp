// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/bookmark/ParameterType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Bookmark
{
    /// <summary>
    /// 파라미터 아이템 종류
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// PIT_NULL
        /// </summary>
        Null = 0,

        /// <summary>
        /// PIT_BSTR
        /// </summary>
        String = 1,

        /// <summary>
        /// PIT_I1
        /// </summary>
        Integer1 = 2,

        /// <summary>
        /// PIT_I2
        /// </summary>
        Integer2 = 3,

        /// <summary>
        /// PIT_I4
        /// </summary>
        Integer4 = 4,

        /// <summary>
        /// PIT_I
        /// </summary>
        Integer = 5,

        /// <summary>
        /// PIT_UI1
        /// </summary>
        UnsignedInteger1 = 6,

        /// <summary>
        /// PIT_UI2
        /// </summary>
        UnsignedInteger2 = 7,

        /// <summary>
        /// PIT_UI4
        /// </summary>
        UnsignedInteger4 = 8,

        /// <summary>
        /// PIT_UI
        /// </summary>
        UnsignedInteger = 9,

        /// <summary>
        /// PIT_SET
        /// </summary>
        ParameterSet = 0x8000,

        /// <summary>
        /// PIT_ARRAY
        /// </summary>
        Array = 0x8001,

        /// <summary>
        /// PIT_BINDATA
        /// </summary>
        BinDataId = 0x8002
    }

    /// <summary>
    /// ParameterType 확장 메서드
    /// </summary>
    public static class ParameterTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="type">ParameterType 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static int GetValue(this ParameterType type)
        {
            return (int)type;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static ParameterType FromValue(int value)
        {
            return value switch
            {
                0 => ParameterType.Null,
                1 => ParameterType.String,
                2 => ParameterType.Integer1,
                3 => ParameterType.Integer2,
                4 => ParameterType.Integer4,
                5 => ParameterType.Integer,
                6 => ParameterType.UnsignedInteger1,
                7 => ParameterType.UnsignedInteger2,
                8 => ParameterType.UnsignedInteger4,
                9 => ParameterType.UnsignedInteger,
                0x8000 => ParameterType.ParameterSet,
                0x8001 => ParameterType.Array,
                0x8002 => ParameterType.BinDataId,
                _ => ParameterType.Null
            };
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/form/properties/PropertyType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Form.Properties
{
    /// <summary>
    /// 폼 속성 타입
    /// </summary>
    public enum PropertyType
    {
        /// <summary>
        /// NULL
        /// </summary>
        Null,

        /// <summary>
        /// set
        /// </summary>
        Set,

        /// <summary>
        /// wstring
        /// </summary>
        WString,

        /// <summary>
        /// int
        /// </summary>
        Int,

        /// <summary>
        /// bool
        /// </summary>
        Bool,
    }

    /// <summary>
    /// PropertyType 열거형에 대한 확장 메서드
    /// </summary>
    public static class PropertyTypeExtensions
    {
        /// <summary>
        /// PropertyType을 문자열로 변환한다.
        /// </summary>
        /// <param name="type">PropertyType 값</param>
        /// <returns>문자열 표현</returns>
        public static string ToTypeString(this PropertyType type) => type switch
        {
            PropertyType.Null => "",
            PropertyType.Set => "set",
            PropertyType.WString => "wstring",
            PropertyType.Int => "int",
            PropertyType.Bool => "bool",
            _ => "",
        };

        /// <summary>
        /// 문자열에서 PropertyType으로 변환한다.
        /// </summary>
        /// <param name="str">문자열</param>
        /// <returns>PropertyType 값</returns>
        public static PropertyType FromString(string str) => str switch
        {
            "set" => PropertyType.Set,
            "wstring" => PropertyType.WString,
            "int" => PropertyType.Int,
            "bool" => PropertyType.Bool,
            _ => PropertyType.Null,
        };
    }
}

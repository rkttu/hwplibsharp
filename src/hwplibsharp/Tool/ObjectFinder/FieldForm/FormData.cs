// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/fieldform/FormData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Form;

namespace HwpLib.Tool.ObjectFinder.FieldForm
{
    /// <summary>
    /// 폼 데이터
    /// </summary>
    public class FormData
    {
        /// <summary>
        /// 폼 이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 폼 타입
        /// </summary>
        public FormObjectType Type { get; set; }

        /// <summary>
        /// 폼 값
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="name">폼 이름</param>
        /// <param name="type">폼 타입</param>
        /// <param name="value">폼 값</param>
        public FormData(string name, FormObjectType type, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}

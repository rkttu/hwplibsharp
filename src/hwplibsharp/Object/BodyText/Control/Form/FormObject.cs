// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/form/FormObject.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Form.Properties;

namespace HwpLib.Object.BodyText.Control.Form
{
    /// <summary>
    /// 양식 개체
    /// </summary>
    public class FormObject
    {
        /// <summary>
        /// 양식 개체 타입
        /// </summary>
        public FormObjectType? Type { get; set; }

        /// <summary>
        /// 속성 집합
        /// </summary>
        public PropertySet Properties { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        public FormObject()
        {
            Type = null;
            Properties = new PropertySet(string.Empty);
        }

        /// <summary>
        /// 다른 FormObject 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FormObject from)
        {
            Type = from.Type;
            Properties.Copy(from.Properties);
        }
    }
}

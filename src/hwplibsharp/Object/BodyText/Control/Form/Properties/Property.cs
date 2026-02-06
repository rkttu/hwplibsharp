// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/form/properties/Property.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Form.Properties
{
    /// <summary>
    /// 폼 속성의 추상 기본 클래스
    /// </summary>
    public abstract class Property
    {
        /// <summary>
        /// 속성 이름
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        protected Property()
        {
        }

        /// <summary>
        /// 속성 타입을 반환한다.
        /// </summary>
        public abstract PropertyType Type { get; }

        /// <summary>
        /// 속성을 복제한다.
        /// </summary>
        /// <returns>복제된 속성</returns>
        public abstract Property Clone();
    }
}

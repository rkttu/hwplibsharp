// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/form/properties/PropertyNormal.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Form.Properties
{
    /// <summary>
    /// 일반 폼 속성 (WString, Int, Bool 타입)
    /// </summary>
    public class PropertyNormal : Property
    {
        private PropertyType _type;

        /// <summary>
        /// 속성 값
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="name">속성 이름</param>
        public PropertyNormal(string name)
        {
            Name = name;
        }

        /// <inheritdoc />
        public override PropertyType Type => _type;

        /// <summary>
        /// 속성 타입을 설정한다.
        /// </summary>
        /// <param name="type">속성 타입</param>
        public void SetType(PropertyType type)
        {
            _type = type;
        }

        /// <inheritdoc />
        public override Property Clone()
        {
            return new PropertyNormal(Name ?? string.Empty)
            {
                _type = _type,
                Value = Value,
            };
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            if (_type == PropertyType.WString)
            {
                sb.Append(Name)
                  .Append(':')
                  .Append(_type.ToTypeString())
                  .Append(':')
                  .Append(Value?.Length ?? 0)
                  .Append(':')
                  .Append(Value);
            }
            else
            {
                sb.Append(Name)
                  .Append(':')
                  .Append(_type.ToTypeString())
                  .Append(':')
                  .Append(Value);
            }
            return sb.ToString();
        }
    }
}

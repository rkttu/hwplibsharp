// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/form/properties/PropertySet.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Form.Properties
{
    /// <summary>
    /// 속성 집합 (Set 타입)
    /// </summary>
    public class PropertySet : Property
    {
        private readonly Dictionary<string, Property> _propertyMap;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="name">속성 이름</param>
        public PropertySet(string name)
        {
            Name = name;
            _propertyMap = new Dictionary<string, Property>();
        }

        /// <summary>
        /// 새 일반 속성을 추가한다.
        /// </summary>
        /// <param name="name">속성 이름</param>
        /// <param name="type">속성 타입 문자열</param>
        /// <returns>추가된 PropertyNormal</returns>
        public PropertyNormal AddNewNormalProperty(string name, string type)
        {
            var propertyNormal = new PropertyNormal(name);
            propertyNormal.SetType(PropertyTypeExtensions.FromString(type));
            _propertyMap[name] = propertyNormal;
            return propertyNormal;
        }

        /// <summary>
        /// 새 속성 집합을 추가한다.
        /// </summary>
        /// <param name="name">속성 이름</param>
        /// <returns>추가된 PropertySet</returns>
        public PropertySet AddNewPropertySet(string name)
        {
            var propertySet = new PropertySet(name);
            _propertyMap[name] = propertySet;
            return propertySet;
        }

        /// <summary>
        /// 이름으로 속성을 가져온다.
        /// </summary>
        /// <param name="name">속성 이름</param>
        /// <returns>속성</returns>
        public Property? GetProperty(string name)
        {
            return _propertyMap.TryGetValue(name, out var property) ? property : null;
        }

        /// <summary>
        /// 모든 속성 이름을 반환한다.
        /// </summary>
        public IReadOnlyCollection<string> Names => _propertyMap.Keys;

        /// <inheritdoc />
        public override PropertyType Type => PropertyType.Set;

        /// <summary>
        /// 다른 PropertySet 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PropertySet from)
        {
            Name = from.Name;
            _propertyMap.Clear();
            foreach (var entry in from._propertyMap)
            {
                _propertyMap[entry.Key] = entry.Value.Clone();
            }
        }

        /// <inheritdoc />
        public override Property Clone()
        {
            var cloned = new PropertySet(Name ?? string.Empty);
            foreach (var entry in _propertyMap)
            {
                cloned._propertyMap[entry.Key] = entry.Value.Clone();
            }
            return cloned;
        }

        /// <summary>
        /// 문자열 데이터를 파싱하여 속성을 구성한다.
        /// </summary>
        /// <param name="data">파싱할 문자열</param>
        public void Parse(string data)
        {
            while (data.Length > 0)
            {
                int position = data.IndexOf(':');
                string name = data.Substring(0, position);
                data = data.Substring(position + 1);

                position = data.IndexOf(':');
                string type = data.Substring(0, position);
                data = data.Substring(position + 1);

                if (type == "set")
                {
                    position = data.IndexOf(':');
                    int length = int.Parse(data.Substring(0, position));
                    data = data.Substring(position + 1);
                    string setData = data.Substring(0, length);
                    data = data.Substring(length + 1);

                    AddNewPropertySet(name).Parse(setData);
                }
                else if (type == "wstring")
                {
                    position = data.IndexOf(':');
                    int length = int.Parse(data.Substring(0, position));
                    data = data.Substring(position + 1);

                    string value = data.Substring(0, length);
                    data = data.Substring(length + 1);

                    AddNewNormalProperty(name, type).Value = value;
                }
                else
                {
                    position = data.IndexOf(' ');
                    string value = data.Substring(0, position);
                    data = data.Substring(position + 1);

                    AddNewNormalProperty(name, type).Value = value;
                }
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            if (!string.IsNullOrEmpty(Name))
            {
                var sb2 = new System.Text.StringBuilder();
                foreach (var property in _propertyMap.Values)
                {
                    sb2.Append(property.ToString()).Append(' ');
                }

                sb.Append(Name)
                  .Append(':')
                  .Append(Type.ToTypeString())
                  .Append(':')
                  .Append(sb2.Length)
                  .Append(':')
                  .Append(sb2);
            }
            else
            {
                foreach (var property in _propertyMap.Values)
                {
                    sb.Append(property.ToString()).Append(' ');
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// HWPString으로 변환한다.
        /// </summary>
        /// <returns>HWPString</returns>
        public HWPString ToHWPString()
        {
            var ret = new HWPString();
            ret.FromUTF16LEString(ToString());
            return ret;
        }
    }
}

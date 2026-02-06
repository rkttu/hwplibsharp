// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ole/ShapeComponentOLEProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Ole
{
    /// <summary>
    /// OLE 개체의 속성에 대한 객체
    /// </summary>
    public class ShapeComponentOLEProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private uint _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentOLEProperty()
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
        /// DVASPECT값을 반환하거나 설정한다.
        /// </summary>
        public DVASPECT DVASPECT
        {
            get => DVASPECTExtensions.FromValue((byte)BitFlag.Get(_value, 0, 7));
            set => _value = (uint)BitFlag.Set(_value, 0, 7, value.GetValue());
        }

        /// <summary>
        /// moniker가 지정되었는지 여부를 반환하거나 설정한다.
        /// </summary>
        public bool IsMoniker
        {
            get => BitFlag.Get(_value, 8);
            set => _value = (uint)BitFlag.Set(_value, 8, value);
        }

        /// <summary>
        /// 베이스라인 값을 반환하거나 설정한다.
        /// 0은 디폴트(85%)를 뜻하고, 1～101이 0～100%를 나타낸다.
        /// 현재는 수식만이 베이스라인을 별도로 가진다.
        /// </summary>
        public byte BaseLine
        {
            get => (byte)BitFlag.Get(_value, 9, 15);
            set => _value = (uint)BitFlag.Set(_value, 9, 15, value);
        }

        /// <summary>
        /// 개체 종류를 반환하거나 설정한다.
        /// </summary>
        public ObjectSort ObjectSort
        {
            get => ObjectSortExtensions.FromValue((byte)BitFlag.Get(_value, 16, 21));
            set => _value = (uint)BitFlag.Set(_value, 16, 21, value.GetValue());
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentOLEProperty from)
        {
            _value = from._value;
        }
    }
}

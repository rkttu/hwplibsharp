// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ShapeComponentOLE.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.ShapeComponent.LineInfo;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Ole;
using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach
{
    /// <summary>
    /// OLE 개체 속성 레코드
    /// </summary>
    public class ShapeComponentOLE
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly ShapeComponentOLEProperty _property;

        /// <summary>
        /// 오브젝트 자체의 extent x크기
        /// </summary>
        private int _extentWidth;

        /// <summary>
        /// 오브젝트 자체의 extent y크기
        /// </summary>
        private int _extentHeight;

        /// <summary>
        /// 오브젝트가 사용하는 스토리지의 BinData ID
        /// </summary>
        private int _binDataId;

        /// <summary>
        /// 테두리 색
        /// </summary>
        private readonly Color4Byte _borderColor;

        /// <summary>
        /// 테두리 두께
        /// </summary>
        private int _borderThickness;

        /// <summary>
        /// 테두리 속성
        /// </summary>
        private readonly LineInfoProperty _borderProperty;

        /// <summary>
        /// 알 수 없는 데이터
        /// </summary>
        private byte[]? _unknown;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentOLE()
        {
            _property = new ShapeComponentOLEProperty();
            _borderColor = new Color4Byte();
            _borderProperty = new LineInfoProperty();
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public ShapeComponentOLEProperty Property => _property;

        /// <summary>
        /// 오브젝트 자체의 extent x크기를 반환하거나 설정한다.
        /// </summary>
        public int ExtentWidth
        {
            get => _extentWidth;
            set => _extentWidth = value;
        }

        /// <summary>
        /// 오브젝트 자체의 extent y크기를 반환하거나 설정한다.
        /// </summary>
        public int ExtentHeight
        {
            get => _extentHeight;
            set => _extentHeight = value;
        }

        /// <summary>
        /// 오브젝트가 사용하는 스토리지의 BinData ID를 반환하거나 설정한다.
        /// </summary>
        public int BinDataId
        {
            get => _binDataId;
            set => _binDataId = value;
        }

        /// <summary>
        /// 테두리 색상 객체를 반환한다.
        /// </summary>
        public Color4Byte BorderColor => _borderColor;

        /// <summary>
        /// 테두리 두께를 반환하거나 설정한다.
        /// </summary>
        public int BorderThickness
        {
            get => _borderThickness;
            set => _borderThickness = value;
        }

        /// <summary>
        /// 테두리 속성 객체를 반환한다.
        /// </summary>
        public LineInfoProperty BorderProperty => _borderProperty;

        /// <summary>
        /// 알 수 없는 데이터를 반환하거나 설정한다.
        /// </summary>
        public byte[]? Unknown
        {
            get => _unknown;
            set => _unknown = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShapeComponentOLE from)
        {
            _property.Copy(from._property);
            _extentWidth = from._extentWidth;
            _extentHeight = from._extentHeight;
            _binDataId = from._binDataId;
            _borderColor.Copy(from._borderColor);
            _borderThickness = from._borderThickness;
            _borderProperty.Copy(from._borderProperty);

            if (from._unknown != null)
            {
                _unknown = (byte[])from._unknown.Clone();
            }
            else
            {
                _unknown = null;
            }
        }
    }
}

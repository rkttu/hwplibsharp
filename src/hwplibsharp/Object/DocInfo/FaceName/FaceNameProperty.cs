// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/facename/FaceNameProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.FaceName
{
    /// <summary>
    /// 글꼴에 대한 속성 객체
    /// </summary>
    public class FaceNameProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 1 byte)
        /// </summary>
        public byte Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public FaceNameProperty()
        {
        }

        /// <summary>
        /// 글꼴 타입 (0~1 bit)
        /// </summary>
        public FontType Type
        {
            get => FontTypeExtensions.FromValue((byte)BitFlag.Get(Value, 0, 1));
            set => Value = (byte)BitFlag.Set(Value, 0, 1, value.GetValue());
        }

        /// <summary>
        /// 대체 글꼴 존재 여부 (0x80, 7 bit)
        /// </summary>
        public bool HasSubstituteFont
        {
            get => BitFlag.Get(Value, 7);
            set => Value = (byte)BitFlag.Set(Value, 7, value);
        }

        /// <summary>
        /// 글꼴 유형 정보 존재 여부 (0x40, 6 bit)
        /// </summary>
        public bool HasFontInfo
        {
            get => BitFlag.Get(Value, 6);
            set => Value = (byte)BitFlag.Set(Value, 6, value);
        }

        /// <summary>
        /// 기본 글꼴 존재 여부 (5 bit)
        /// </summary>
        public bool HasBaseFont
        {
            get => BitFlag.Get(Value, 5);
            set => Value = (byte)BitFlag.Set(Value, 5, value);
        }

        /// <summary>
        /// 다른 FaceNameProperty 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FaceNameProperty from)
        {
            Value = from.Value;
        }
    }
}

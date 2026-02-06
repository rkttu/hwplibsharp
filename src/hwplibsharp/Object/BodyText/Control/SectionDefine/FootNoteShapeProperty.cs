// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/FootNoteShapeProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 각주 모양에 대한 속성을 나타내는 객체
    /// </summary>
    public class FootNoteShapeProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private long _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public FootNoteShapeProperty()
        {
        }

        /// <summary>
        /// 파일에 저장되는 정수값을 반환하거나 설정한다.
        /// </summary>
        public long Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// 번호 모양을 반환하거나 설정한다. (0~7 bit) (0~16 은 범용. 0x80, 0x81은 각주/미주 전용)
        /// </summary>
        public NumberShape NumberShape
        {
            get => NumberShapeExtensions.FromValue((short)BitFlag.Get(_value, 0, 7));
            set => _value = BitFlag.Set(_value, 0, 7, value.GetValue());
        }

        /// <summary>
        /// 한 페이지 내에서 각주를 다단에 위치시킬 방법을 반환하거나 설정한다.(각주 일 경우) (8~9 bit)
        /// </summary>
        public FootNoteDisplayMethod FootNoteDisplayMethod
        {
            get => FootNoteDisplayMethodExtensions.FromValue((byte)BitFlag.Get(_value, 8, 9));
            set => _value = BitFlag.Set(_value, 8, 9, value.GetValue());
        }

        /// <summary>
        /// 미주를 위치시킬 방법을 반환하거나 설정한다.(미주 일 경우) (8~9 bit)
        /// </summary>
        public EndNoteDisplayMethod EndNoteDisplayMethod
        {
            get => EndNoteDisplayMethodExtensions.FromValue((byte)BitFlag.Get(_value, 8, 9));
            set => _value = BitFlag.Set(_value, 8, 9, value.GetValue());
        }

        /// <summary>
        /// 번호 매김 방법을 반환하거나 설정한다. (10~11 bit)
        /// </summary>
        public NumberingMethod NumberingMethod
        {
            get => NumberingMethodExtensions.FromValue((byte)BitFlag.Get(_value, 10, 11));
            set => _value = BitFlag.Set(_value, 10, 11, value.GetValue());
        }

        /// <summary>
        /// 각주 내용 중 번호 코드의 모양을 위 첨자 형식으로 할지 여부를 반환하거나 설정한다. (12 bit)
        /// </summary>
        public bool DisplayWithSupscript
        {
            get => BitFlag.Get(_value, 12);
            set => _value = BitFlag.Set(_value, 12, value);
        }

        /// <summary>
        /// 텍스트에 이어 바로 출력할지 여부를 반환하거나 설정한다. (13 bit)
        /// </summary>
        public bool ContinueFromText
        {
            get => BitFlag.Get(_value, 13);
            set => _value = BitFlag.Set(_value, 13, value);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FootNoteShapeProperty from)
        {
            _value = from._value;
        }
    }
}

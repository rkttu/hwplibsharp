// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/sectiondefine/PageDefProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.SectionDefine
{
    /// <summary>
    /// 용지 설정의 속성에 대한 객체
    /// </summary>
    public class PageDefProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        private long _value;

        /// <summary>
        /// 생성자
        /// </summary>
        public PageDefProperty()
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
        /// 용지 방향을 반환하거나 설정한다. (0 bit)
        /// </summary>
        public PaperDirection PaperDirection
        {
            get => BitFlag.Get(_value, 0) ? PaperDirection.Landscape : PaperDirection.Portrait;
            set => _value = BitFlag.Set(_value, 0, value == PaperDirection.Landscape);
        }

        /// <summary>
        /// 제책 방법을 반환하거나 설정한다. (1~2 bit)
        /// </summary>
        public MakingBookMethod MakingBookMethod
        {
            get => MakingBookMethodExtensions.FromValue((byte)BitFlag.Get(_value, 1, 2));
            set => _value = BitFlag.Set(_value, 1, 2, value.GetValue());
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(PageDefProperty from)
        {
            _value = from._value;
        }
    }
}

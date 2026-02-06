// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/pagehide/PageHideHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.CtrlHeader.PageHide
{
    /// <summary>
    /// 감추기 컨트롤의 속성을 나타내는 객체
    /// </summary>
    public class PageHideHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public PageHideHeaderProperty()
        {
        }

        /// <summary>
        /// 머리말 숨김 여부 (0 bit)
        /// </summary>
        public bool HideHeader
        {
            get => BitFlag.Get(Value, 0);
            set => Value = (uint)BitFlag.Set(Value, 0, value);
        }

        /// <summary>
        /// 꼬리말 숨김 여부 (1 bit)
        /// </summary>
        public bool HideFooter
        {
            get => BitFlag.Get(Value, 1);
            set => Value = (uint)BitFlag.Set(Value, 1, value);
        }

        /// <summary>
        /// 바탕 쪽 숨김 여부 (2 bit)
        /// </summary>
        public bool HideBatangPage
        {
            get => BitFlag.Get(Value, 2);
            set => Value = (uint)BitFlag.Set(Value, 2, value);
        }

        /// <summary>
        /// 테두리 숨김 여부 (3 bit)
        /// </summary>
        public bool HideBorder
        {
            get => BitFlag.Get(Value, 3);
            set => Value = (uint)BitFlag.Set(Value, 3, value);
        }

        /// <summary>
        /// 배경 숨김 여부 (4 bit)
        /// </summary>
        public bool HideFill
        {
            get => BitFlag.Get(Value, 4);
            set => Value = (uint)BitFlag.Set(Value, 4, value);
        }

        /// <summary>
        /// 페이지 번호 숨김 여부 (5 bit)
        /// </summary>
        public bool HidePageNumber
        {
            get => BitFlag.Get(Value, 5);
            set => Value = (uint)BitFlag.Set(Value, 5, value);
        }

        /// <summary>
        /// 다른 <see cref="PageHideHeaderProperty"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="PageHideHeaderProperty"/> 인스턴스입니다.</param>
        public void Copy(PageHideHeaderProperty from)
        {
            Value = from.Value;
        }
    }
}

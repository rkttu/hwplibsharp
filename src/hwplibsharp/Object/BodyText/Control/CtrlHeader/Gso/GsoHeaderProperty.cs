// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/GsoHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 그리기 객체 컨트롤의 속성을 나타내는 객체
    /// </summary>
    public class GsoHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public GsoHeaderProperty()
        {
        }

        /// <summary>
        /// 글자처럼 취급 여부를 반환한다. (0 bit)
        /// </summary>
        public bool IsLikeWord() => BitFlag.Get((long)Value, 0);

        /// <summary>
        /// 글자처럼 취급 여부를 설정한다. (0 bit)
        /// </summary>
        public void SetLikeWord(bool likeWord) => Value = (uint)BitFlag.Set((long)Value, 0, likeWord);

        /// <summary>
        /// 줄 간격에 영향을 줄지 여부를 반환한다. (2 bit)
        /// </summary>
        public bool IsApplyLineSpace() => BitFlag.Get((long)Value, 2);

        /// <summary>
        /// 줄 간격에 영향을 줄지 여부를 설정한다. (2 bit)
        /// </summary>
        public void SetApplyLineSpace(bool applyLineSpace) => Value = (uint)BitFlag.Set((long)Value, 2, applyLineSpace);

        /// <summary>
        /// 세로 위치의 기준을 반환한다. (3~4 bit)
        /// </summary>
        public VertRelTo GetVertRelTo() => VertRelToExtensions.FromValue((byte)BitFlag.Get((long)Value, 3, 4));

        /// <summary>
        /// 세로 위치의 기준을 설정한다. (3~4 bit)
        /// </summary>
        public void SetVertRelTo(VertRelTo vertRelTo) => Value = (uint)BitFlag.Set((long)Value, 3, 4, vertRelTo.GetValue());

        /// <summary>
        /// 세로 위치의 기준에 대한 상대적인 배열방식을 반환한다. (5~7 bit)
        /// </summary>
        public RelativeArrange GetVertRelativeArrange() => RelativeArrangeExtensions.FromValue((byte)BitFlag.Get((long)Value, 5, 7));

        /// <summary>
        /// 세로 위치의 기준에 대한 상대적인 배열방식을 설정한다. (5~7 bit)
        /// </summary>
        public void SetVertRelativeArrange(RelativeArrange vertRelativeArrange) => Value = (uint)BitFlag.Set((long)Value, 5, 7, vertRelativeArrange.GetValue());

        /// <summary>
        /// 가로 위치의 기준을 반환한다. (8~9 bit)
        /// </summary>
        public HorzRelTo GetHorzRelTo() => HorzRelToExtensions.FromValue((byte)BitFlag.Get((long)Value, 8, 9));

        /// <summary>
        /// 가로 위치의 기준을 설정한다. (8~9 bit)
        /// </summary>
        public void SetHorzRelTo(HorzRelTo horzRelTo) => Value = (uint)BitFlag.Set((long)Value, 8, 9, horzRelTo.GetValue());

        /// <summary>
        /// HorzRelTo에 대한 상대적인 배열방식을 반환한다. (10~12 bit)
        /// </summary>
        public RelativeArrange GetHorzRelativeArrange() => RelativeArrangeExtensions.FromValue((byte)BitFlag.Get((long)Value, 10, 12));

        /// <summary>
        /// HorzRelTo에 대한 상대적인 배열방식을 설정한다. (10~12 bit)
        /// </summary>
        public void SetHorzRelativeArrange(RelativeArrange horzRelativeArrange) => Value = (uint)BitFlag.Set((long)Value, 10, 12, horzRelativeArrange.GetValue());

        /// <summary>
        /// VertRelTo이 'para'일 때 오브젝트의 세로 위치를 본문 영역으로 제한할지 여부를 반환한다. (13 bit)
        /// </summary>
        public bool IsVertRelToParaLimit() => BitFlag.Get((long)Value, 13);

        /// <summary>
        /// VertRelTo이 'para'일 때 오브젝트의 세로 위치를 본문 영역으로 제한할지 여부를 설정한다. (13 bit)
        /// </summary>
        public void SetVertRelToParaLimit(bool vertRelToParaLimit) => Value = (uint)BitFlag.Set((long)Value, 13, vertRelToParaLimit);

        /// <summary>
        /// 다른 오브젝트와 겹치는 것을 허용할지 여부를 반환한다. (14 bit)
        /// </summary>
        public bool IsAllowOverlap() => BitFlag.Get((long)Value, 14);

        /// <summary>
        /// 다른 오브젝트와 겹치는 것을 허용할지 여부를 설정한다. (14 bit)
        /// </summary>
        public void SetAllowOverlap(bool allowOverlap) => Value = (uint)BitFlag.Set((long)Value, 14, allowOverlap);

        /// <summary>
        /// 오브젝트 폭의 기준을 반환한다. (15~17 bit)
        /// </summary>
        public WidthCriterion GetWidthCriterion() => WidthCriterionExtensions.FromValue((byte)BitFlag.Get((long)Value, 15, 17));

        /// <summary>
        /// 오브젝트 폭의 기준을 설정한다. (15~17 bit)
        /// </summary>
        public void SetWidthCriterion(WidthCriterion widthCriterion) => Value = (uint)BitFlag.Set((long)Value, 15, 17, widthCriterion.GetValue());

        /// <summary>
        /// 오브젝트 높이의 기준을 반환한다. (18~19 bit)
        /// </summary>
        public HeightCriterion GetHeightCriterion() => HeightCriterionExtensions.FromValue((byte)BitFlag.Get((long)Value, 18, 19));

        /// <summary>
        /// 오브젝트 높이의 기준을 설정한다. (18~19 bit)
        /// </summary>
        public void SetHeightCriterion(HeightCriterion heightCriterion) => Value = (uint)BitFlag.Set((long)Value, 18, 19, heightCriterion.GetValue());

        /// <summary>
        /// VertRelTo이 para일 때 크기 보호 여부를 반환한다. (20 bit)
        /// </summary>
        public bool IsProtectSize() => BitFlag.Get((long)Value, 20);

        /// <summary>
        /// VertRelTo이 para일 때 크기 보호 여부를 설정한다. (20 bit)
        /// </summary>
        public void SetProtectSize(bool protectSize) => Value = (uint)BitFlag.Set((long)Value, 20, protectSize);

        /// <summary>
        /// 오브젝트 주위를 텍스트가 어떻게 흘러갈지 지정하는 옵션을 반환한다. (21~23 bit)
        /// </summary>
        public TextFlowMethod GetTextFlowMethod() => TextFlowMethodExtensions.FromValue((byte)BitFlag.Get((long)Value, 21, 23));

        /// <summary>
        /// 오브젝트 주위를 텍스트가 어떻게 흘러갈지 지정하는 옵션을 설정한다. (21~23 bit)
        /// </summary>
        public void SetTextFlowMethod(TextFlowMethod textFlowMethod) => Value = (uint)BitFlag.Set((long)Value, 21, 23, textFlowMethod.GetValue());

        /// <summary>
        /// 오브젝트의 좌/우 어느 쪽에 글을 배치할지 지정하는 옵션을 반환한다. (24~25 bit)
        /// </summary>
        public TextHorzArrange GetTextHorzArrange() => TextHorzArrangeExtensions.FromValue((byte)BitFlag.Get((long)Value, 24, 25));

        /// <summary>
        /// 오브젝트의 좌/우 어느 쪽에 글을 배치할지 지정하는 옵션을 설정한다. (24~25 bit)
        /// </summary>
        public void SetTextHorzArrange(TextHorzArrange textHorzArrange) => Value = (uint)BitFlag.Set((long)Value, 24, 25, textHorzArrange.GetValue());

        /// <summary>
        /// 개체가 속하는 번호 범주를 반환한다. (26~28 bit)
        /// </summary>
        public ObjectNumberSort GetObjectNumberSort() => ObjectNumberSortExtensions.FromValue((byte)BitFlag.Get((long)Value, 26, 28));

        /// <summary>
        /// 개체가 속하는 번호 범주를 설정한다. (26~28 bit)
        /// </summary>
        public void SetObjectNumberSort(ObjectNumberSort objectNumberSort) => Value = (uint)BitFlag.Set((long)Value, 26, 28, objectNumberSort.GetValue());

        /// <summary>
        /// 캡션을 가졌는지 여부를 반환한다. (29 bit)
        /// </summary>
        public bool HasCaption() => BitFlag.Get((long)Value, 29);

        /// <summary>
        /// 캡션을 가졌는지 여부를 설정한다. (29 bit)
        /// </summary>
        public void SetHasCaption(bool hasCaption) => Value = (uint)BitFlag.Set((long)Value, 29, hasCaption);

        /// <summary>
        /// 다른 GsoHeaderProperty 객체로부터 복사한다.
        /// </summary>
        public void Copy(GsoHeaderProperty from) => Value = from.Value;
    }
}

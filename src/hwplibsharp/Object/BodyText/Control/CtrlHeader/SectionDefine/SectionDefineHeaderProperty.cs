// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/sectiondefine/SectionDefineHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.CtrlHeader.SectionDefine
{
    /// <summary>
    /// 구역 정의 컨트롤의 속성 객체
    /// </summary>
    public class SectionDefineHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public SectionDefineHeaderProperty()
        {
        }

        /// <summary>
        /// 머리말을 감출지 여부 (0 bit)
        /// </summary>
        public bool HideHeader
        {
            get => BitFlag.Get(Value, 0);
            set => Value = (uint)BitFlag.Set(Value, 0, value);
        }

        /// <summary>
        /// 꼬리말을 감출지 여부 (1 bit)
        /// </summary>
        public bool HideFooter
        {
            get => BitFlag.Get(Value, 1);
            set => Value = (uint)BitFlag.Set(Value, 1, value);
        }

        /// <summary>
        /// 바탕쪽을 감출지 여부 (2 bit)
        /// </summary>
        public bool HideBatangPage
        {
            get => BitFlag.Get(Value, 2);
            set => Value = (uint)BitFlag.Set(Value, 2, value);
        }

        /// <summary>
        /// 테두리를 감출지 여부 (3 bit)
        /// </summary>
        public bool HideBorder
        {
            get => BitFlag.Get(Value, 3);
            set => Value = (uint)BitFlag.Set(Value, 3, value);
        }

        /// <summary>
        /// 배경을 감출지 여부 (4 bit)
        /// </summary>
        public bool HideBackground
        {
            get => BitFlag.Get(Value, 4);
            set => Value = (uint)BitFlag.Set(Value, 4, value);
        }

        /// <summary>
        /// 쪽 번호 위치를 감출지 여부 (5 bit)
        /// </summary>
        public bool HidePageNumberPosition
        {
            get => BitFlag.Get(Value, 5);
            set => Value = (uint)BitFlag.Set(Value, 5, value);
        }

        /// <summary>
        /// 구역의 첫 쪽에만 테두리 표시 여부 (8 bit)
        /// </summary>
        public bool DisplayBorderAtFirstPageOfSection
        {
            get => BitFlag.Get(Value, 8);
            set => Value = (uint)BitFlag.Set(Value, 8, value);
        }

        /// <summary>
        /// 구역의 첫 쪽에만 배경 표시 여부 (9 bit)
        /// </summary>
        public bool DisplayBackgroundAtFirstPageOfSection
        {
            get => BitFlag.Get(Value, 9);
            set => Value = (uint)BitFlag.Set(Value, 9, value);
        }

        /// <summary>
        /// 텍스트 방향 (16~18 bit)
        /// </summary>
        public TextDirection TextDirection
        {
            get => TextDirectionExtensions.FromValue((byte)BitFlag.Get(Value, 16, 18));
            set => Value = (uint)BitFlag.Set(Value, 16, 18, value.GetValue());
        }

        /// <summary>
        /// 빈 줄 감춤 여부 (19 bit)
        /// </summary>
        public bool HideEmptyLine
        {
            get => BitFlag.Get(Value, 19);
            set => Value = (uint)BitFlag.Set(Value, 19, value);
        }

        /// <summary>
        /// 시작 쪽번호 타입 (20~21 bit)
        /// </summary>
        public StartPageNumberType StartPageNumberType
        {
            get => StartPageNumberTypeExtensions.FromValue((byte)BitFlag.Get(Value, 20, 21));
            set => Value = (uint)BitFlag.Set(Value, 20, 21, value.GetValue());
        }

        /// <summary>
        /// 원고지 정서법 적용 여부 (22 bit)
        /// </summary>
        public bool ApplyWongoji
        {
            get => BitFlag.Get(Value, 22);
            set => Value = (uint)BitFlag.Set(Value, 22, value);
        }

        /// <summary>
        /// 양쪽 바탕쪽 적용 여부 (29 bit)
        /// </summary>
        public bool ApplyBothBatangPage
        {
            get => BitFlag.Get(Value, 29);
            set => Value = (uint)BitFlag.Set(Value, 29, value);
        }

        /// <summary>
        /// 짝수쪽 바탕쪽 적용 여부 (30 bit)
        /// </summary>
        public bool ApplyEvenBatangPage
        {
            get => BitFlag.Get(Value, 30);
            set => Value = (uint)BitFlag.Set(Value, 30, value);
        }

        /// <summary>
        /// 홀수쪽 바탕쪽 적용 여부 (31 bit)
        /// </summary>
        public bool ApplyOddBatangPage
        {
            get => BitFlag.Get(Value, 31);
            set => Value = (uint)BitFlag.Set(Value, 31, value);
        }

        /// <summary>
        /// 다른 <see cref="SectionDefineHeaderProperty"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="SectionDefineHeaderProperty"/> 인스턴스입니다.</param>
        public void Copy(SectionDefineHeaderProperty from)
        {
            Value = from.Value;
        }
    }
}

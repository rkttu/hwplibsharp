// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/ParaShapeProperty2.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 문단 모양의 속성2 객체 (5.0.1.7 버전 이상)
    /// </summary>
    public class ParaShapeProperty2
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaShapeProperty2()
        {
        }

        /// <summary>
        /// 한 줄로 입력 여부 (0~1 bit)
        /// </summary>
        public bool IsInputSingleLine
        {
            get => BitFlag.Get(Value, 0) || BitFlag.Get(Value, 1);
            set
            {
                Value = (uint)BitFlag.Set(Value, 0, value);
                Value = (uint)BitFlag.Set(Value, 1, value);
            }
        }

        /// <summary>
        /// 한글과 영어 간격을 자동 조절 여부 (4 bit)
        /// </summary>
        public bool IsAutoAdjustGapHangulEnglish
        {
            get => BitFlag.Get(Value, 4);
            set => Value = (uint)BitFlag.Set(Value, 4, value);
        }

        /// <summary>
        /// 한글과 숫자 간격을 자동 조절 여부 (5 bit)
        /// </summary>
        public bool IsAutoAdjustGapHangulNumber
        {
            get => BitFlag.Get(Value, 5);
            set => Value = (uint)BitFlag.Set(Value, 5, value);
        }

        /// <summary>
        /// 줄번호 제거 여부 (6 bit)
        /// </summary>
        public bool IsSuppressLineNumbers
        {
            get => BitFlag.Get(Value, 6);
            set => Value = (uint)BitFlag.Set(Value, 6, value);
        }

        /// <summary>
        /// 다른 ParaShapeProperty2 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParaShapeProperty2 from)
        {
            Value = from.Value;
        }
    }
}

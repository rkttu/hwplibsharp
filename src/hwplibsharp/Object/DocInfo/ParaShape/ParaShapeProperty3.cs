// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/ParaShapeProperty3.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 문단 모양의 속성3 객체 (5.0.2.5 버전 이상)
    /// </summary>
    public class ParaShapeProperty3
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaShapeProperty3()
        {
        }

        /// <summary>
        /// 줄 간격 종류 (0~4 bit)
        /// </summary>
        public LineSpaceSort LineSpaceSort
        {
            get => LineSpaceSortExtensions.FromValue((byte)BitFlag.Get(Value, 0, 4));
            set => Value = (uint)BitFlag.Set(Value, 0, 4, value.GetValue());
        }

        /// <summary>
        /// 다른 ParaShapeProperty3 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParaShapeProperty3 from)
        {
            Value = from.Value;
        }
    }
}

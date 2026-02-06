// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/bindata/BinDataProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.BinData
{
    /// <summary>
    /// 바이너리 데이터의 속성
    /// </summary>
    public class BinDataProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 2 byte)
        /// </summary>
        public ushort Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public BinDataProperty()
        {
        }

        /// <summary>
        /// 바이너리 데이터의 타입 (0~3 bit)
        /// </summary>
        public BinDataType Type
        {
            get => BinDataTypeExtensions.FromValue((byte)BitFlag.Get(Value, 0, 3));
            set => Value = (ushort)BitFlag.Set(Value, 0, 3, value.GetValue());
        }

        /// <summary>
        /// 바이너리 데이터의 압축 방법 (4~5 bit)
        /// </summary>
        public BinDataCompress Compress
        {
            get => BinDataCompressExtensions.FromValue((byte)BitFlag.Get(Value, 4, 5));
            set => Value = (ushort)BitFlag.Set(Value, 4, 5, value.GetValue());
        }

        /// <summary>
        /// 바이너리 데이터의 상태 (8~9 bit)
        /// </summary>
        public BinDataState State
        {
            get => BinDataStateExtensions.FromValue((byte)BitFlag.Get(Value, 8, 9));
            set => Value = (ushort)BitFlag.Set(Value, 8, 9, value.GetValue());
        }

        /// <summary>
        /// 다른 BinDataProperty 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(BinDataProperty from)
        {
            Value = from.Value;
        }
    }
}

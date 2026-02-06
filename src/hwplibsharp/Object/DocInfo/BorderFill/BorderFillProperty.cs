// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/BorderFillProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// 테두리/배경 객체의 속성
    /// </summary>
    public class BorderFillProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 2 byte)
        /// </summary>
        public ushort Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public BorderFillProperty()
        {
        }

        /// <summary>
        /// 3D 효과의 유무 (0 bit)
        /// </summary>
        public bool Is3DEffect
        {
            get => BitFlag.Get(Value, 0);
            set => Value = (ushort)BitFlag.Set(Value, 0, value);
        }

        /// <summary>
        /// 그림자 효과의 유무 (1 bit)
        /// </summary>
        public bool IsShadowEffect
        {
            get => BitFlag.Get(Value, 1);
            set => Value = (ushort)BitFlag.Set(Value, 1, value);
        }

        /// <summary>
        /// Slash 대각선 모양 (2~4 bit)
        /// </summary>
        public SlashDiagonalShape SlashDiagonalShape
        {
            get => SlashDiagonalShapeExtensions.FromValue((byte)BitFlag.Get(Value, 2, 4));
            set => Value = (ushort)BitFlag.Set(Value, 2, 4, value.GetValue());
        }

        /// <summary>
        /// BackSlash 대각선 모양 (5~7 bit)
        /// </summary>
        public BackSlashDiagonalShape BackSlashDiagonalShape
        {
            get => BackSlashDiagonalShapeExtensions.FromValue((byte)BitFlag.Get(Value, 5, 7));
            set => Value = (ushort)BitFlag.Set(Value, 5, 7, value.GetValue());
        }

        /// <summary>
        /// Slash 대각선이 꺾은선인지 여부 (8~9 bit)
        /// </summary>
        public bool IsBrokenSlashDiagonal
        {
            get => BitFlag.Get(Value, 8) || BitFlag.Get(Value, 9);
            set
            {
                Value = (ushort)BitFlag.Set(Value, 8, value);
                Value = (ushort)BitFlag.Set(Value, 9, value);
            }
        }

        /// <summary>
        /// BackSlash 대각선이 꺾은선인지 여부 (10 bit)
        /// </summary>
        public bool IsBrokenBackSlashDiagonal
        {
            get => BitFlag.Get(Value, 10);
            set => Value = (ushort)BitFlag.Set(Value, 10, value);
        }

        /// <summary>
        /// Slash 대각선의 180도 회전 여부 (11 bit)
        /// </summary>
        public bool IsRotateSlashDiagonal180
        {
            get => BitFlag.Get(Value, 11);
            set => Value = (ushort)BitFlag.Set(Value, 11, value);
        }

        /// <summary>
        /// BackSlash 대각선의 180도 회전 여부 (12 bit)
        /// </summary>
        public bool IsRotateBackSlashDiagonal180
        {
            get => BitFlag.Get(Value, 12);
            set => Value = (ushort)BitFlag.Set(Value, 12, value);
        }

        /// <summary>
        /// 중심선을 가졌는지 여부 (13 bit)
        /// </summary>
        public bool HasCenterLine
        {
            get => BitFlag.Get(Value, 13);
            set => Value = (ushort)BitFlag.Set(Value, 13, value);
        }

        /// <summary>
        /// 중심선 종류 (8~9 bit)
        /// </summary>
        public CenterLineSort CenterLineSort
        {
            get => CenterLineSortExtensions.FromValue((byte)BitFlag.Get(Value, 8, 9));
            set => Value = (ushort)BitFlag.Set(Value, 8, 9, value.GetValue());
        }

        /// <summary>
        /// 다른 BorderFillProperty 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(BorderFillProperty from)
        {
            Value = from.Value;
        }
    }
}

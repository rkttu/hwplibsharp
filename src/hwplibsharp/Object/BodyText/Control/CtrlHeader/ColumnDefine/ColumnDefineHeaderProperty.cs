// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/columndefine/ColumnDefineHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.CtrlHeader.ColumnDefine
{
    /// <summary>
    /// 단 정의 컨트롤의 속성 객체
    /// </summary>
    public class ColumnDefineHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 2 byte)
        /// </summary>
        public ushort Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ColumnDefineHeaderProperty()
        {
        }

        /// <summary>
        /// 단 종류를 반환한다. (0~1 bit)
        /// </summary>
        /// <returns>단 종류</returns>
        public ColumnSort GetColumnSort()
        {
            return ColumnSortExtensions.FromValue((byte)BitFlag.Get((int)Value, 0, 1));
        }

        /// <summary>
        /// 단 종류를 설정한다. (0~1 bit)
        /// </summary>
        /// <param name="columnSort">단 종류</param>
        public void SetColumnSort(ColumnSort columnSort)
        {
            Value = (ushort)BitFlag.Set((int)Value, 0, 1, columnSort.GetValue());
        }

        /// <summary>
        /// 단 개수를 반환한다. (2~9 bit)
        /// </summary>
        /// <returns>단 개수</returns>
        public short GetColumnCount()
        {
            return (short)BitFlag.Get((int)Value, 2, 9);
        }

        /// <summary>
        /// 단 개수를 설정한다. (2~9 bit)
        /// </summary>
        /// <param name="columnCount">단 개수</param>
        public void SetColumnCount(short columnCount)
        {
            Value = (ushort)BitFlag.Set((int)Value, 2, 9, columnCount);
        }

        /// <summary>
        /// 단 방향을 반환한다. (10~11 bit)
        /// </summary>
        /// <returns>단 방향</returns>
        public ColumnDirection GetColumnDirection()
        {
            return ColumnDirectionExtensions.FromValue((byte)BitFlag.Get((int)Value, 10, 11));
        }

        /// <summary>
        /// 단 방향을 설정한다. (10~11 bit)
        /// </summary>
        /// <param name="columnDirection">단 방향</param>
        public void SetColumnDirection(ColumnDirection columnDirection)
        {
            Value = (ushort)BitFlag.Set((int)Value, 10, 11, columnDirection.GetValue());
        }

        /// <summary>
        /// 단 너비 동일하게 여부를 반환한다. (12 bit)
        /// </summary>
        /// <returns>단 너비 동일하게 여부</returns>
        public bool IsSameWidth()
        {
            return BitFlag.Get((int)Value, 12);
        }

        /// <summary>
        /// 단 너비 동일하게 여부를 설정한다. (12 bit)
        /// </summary>
        /// <param name="sameWidth">단 너비 동일하게 여부</param>
        public void SetSameWidth(bool sameWidth)
        {
            Value = (ushort)BitFlag.Set((int)Value, 12, sameWidth);
        }

        /// <summary>
        /// 다른 ColumnDefineHeaderProperty 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ColumnDefineHeaderProperty from)
        {
            Value = from.Value;
        }
    }
}

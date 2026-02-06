// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/gso/ObjectNumberSort.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Gso
{
    /// <summary>
    /// 개체가 속하는 번호 범주
    /// </summary>
    public enum ObjectNumberSort : byte
    {
        /// <summary>
        /// 없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 그림
        /// </summary>
        Figure = 1,

        /// <summary>
        /// 표
        /// </summary>
        Table = 2,

        /// <summary>
        /// 수식
        /// </summary>
        Equation = 3
    }

    /// <summary>
    /// ObjectNumberSort 확장 메서드
    /// </summary>
    public static class ObjectNumberSortExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ObjectNumberSort objectNumberSort) => (byte)objectNumberSort;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ObjectNumberSort FromValue(byte value) => value switch
        {
            0 => ObjectNumberSort.None,
            1 => ObjectNumberSort.Figure,
            2 => ObjectNumberSort.Table,
            3 => ObjectNumberSort.Equation,
            _ => ObjectNumberSort.None
        };
    }
}

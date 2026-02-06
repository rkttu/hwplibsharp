// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/pagenumberposition/NumberPosition.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.PageNumberPosition
{
    /// <summary>
    /// 번호의 표시 위치
    /// </summary>
    public enum NumberPosition : byte
    {
        /// <summary>
        /// 쪽 번호 없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 왼쪽 위
        /// </summary>
        LeftTop = 1,

        /// <summary>
        /// 가운데 위
        /// </summary>
        CenterTop = 2,

        /// <summary>
        /// 오른쪽 위
        /// </summary>
        RightTop = 3,

        /// <summary>
        /// 왼쪽 아래
        /// </summary>
        LeftBottom = 4,

        /// <summary>
        /// 가운데 아래
        /// </summary>
        CenterBottom = 5,

        /// <summary>
        /// 오른쪽 아래
        /// </summary>
        RightBottom = 6,

        /// <summary>
        /// 바깥쪽 위
        /// </summary>
        OutsideTop = 7,

        /// <summary>
        /// 바깥쪽 아래
        /// </summary>
        OutsideBottom = 8,

        /// <summary>
        /// 안쪽 위
        /// </summary>
        InsideTop = 9,

        /// <summary>
        /// 안쪽 아래
        /// </summary>
        InsideBottom = 10,
    }

    /// <summary>
    /// NumberPosition enum 확장 메서드
    /// </summary>
    public static class NumberPositionExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="numberPosition">enum 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this NumberPosition numberPosition)
        {
            return (byte)numberPosition;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static NumberPosition FromValue(byte value)
        {
            return value switch
            {
                0 => NumberPosition.None,
                1 => NumberPosition.LeftTop,
                2 => NumberPosition.CenterTop,
                3 => NumberPosition.RightTop,
                4 => NumberPosition.LeftBottom,
                5 => NumberPosition.CenterBottom,
                6 => NumberPosition.RightBottom,
                7 => NumberPosition.OutsideTop,
                8 => NumberPosition.OutsideBottom,
                9 => NumberPosition.InsideTop,
                10 => NumberPosition.InsideBottom,
                _ => NumberPosition.None,
            };
        }
    }
}

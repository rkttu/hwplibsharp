// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/shadowinfo/ShadowType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.ShadowInfo
{
    /// <summary>
    /// 그림자 종류
    /// </summary>
    public enum ShadowType : byte
    {
        /// <summary>
        /// 없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 왼쪽 위
        /// </summary>
        LeftTop = 1,

        /// <summary>
        /// 오른쪽 위
        /// </summary>
        RightTop = 2,

        /// <summary>
        /// 왼쪽 아래
        /// </summary>
        LeftBottom = 3,

        /// <summary>
        /// 오른쪽 아래
        /// </summary>
        RightBottom = 4,

        /// <summary>
        /// 왼쪽 뒤
        /// </summary>
        LeftBack = 5,

        /// <summary>
        /// 오른쪽 뒤
        /// </summary>
        RightBack = 6,

        /// <summary>
        /// 왼쪽 앞
        /// </summary>
        LeftFront = 7,

        /// <summary>
        /// 오른쪽 앞
        /// </summary>
        RightFront = 8,

        /// <summary>
        /// 작게
        /// </summary>
        Small = 13,

        /// <summary>
        /// 크게
        /// </summary>
        Large = 14,
    }

    /// <summary>
    /// ShadowType 확장 메서드
    /// </summary>
    public static class ShadowTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="type">그림자 종류</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this ShadowType type)
            => (byte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static ShadowType FromValue(byte value)
            => value switch
            {
                0 => ShadowType.None,
                1 => ShadowType.LeftTop,
                2 => ShadowType.RightTop,
                3 => ShadowType.LeftBottom,
                4 => ShadowType.RightBottom,
                5 => ShadowType.LeftBack,
                6 => ShadowType.RightBack,
                7 => ShadowType.LeftFront,
                8 => ShadowType.RightFront,
                13 => ShadowType.Small,
                14 => ShadowType.Large,
                _ => ShadowType.None,
            };
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/BorderType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// 테두리선 종류
    /// </summary>
    public enum BorderType : byte
    {
        /// <summary>
        /// 선없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 실선
        /// </summary>
        Solid = 1,

        /// <summary>
        /// 긴 점선 (쇄선)
        /// </summary>
        Dash = 2,

        /// <summary>
        /// 점선
        /// </summary>
        Dot = 3,

        /// <summary>
        /// -.-.-.-.(일점 쇄선)
        /// </summary>
        DashDot = 4,

        /// <summary>
        /// -..-..-..(이점 쇄선)
        /// </summary>
        DashDotDot = 5,

        /// <summary>
        /// Dash보다 긴 선분의 반복
        /// </summary>
        LongDash = 6,

        /// <summary>
        /// Dot보다 큰 동그라미의 반복
        /// </summary>
        CircleDot = 7,

        /// <summary>
        /// 2중선
        /// </summary>
        Double = 8,

        /// <summary>
        /// 가는선 + 굵은선 2중선
        /// </summary>
        ThinThick = 9,

        /// <summary>
        /// 굵은선 + 가는선 2중선
        /// </summary>
        ThickThin = 10,

        /// <summary>
        /// 가는선 + 굵은선 + 가는선 3중선
        /// </summary>
        ThinThickThin = 11,

        /// <summary>
        /// 물결
        /// </summary>
        Wave = 12,

        /// <summary>
        /// 물결 2중선
        /// </summary>
        DoubleWave = 13,

        /// <summary>
        /// 두꺼운 3D
        /// </summary>
        Thick3D = 14,

        /// <summary>
        /// 두꺼운 3D(광원 반대)
        /// </summary>
        Thick3DReverseLighting = 15,

        /// <summary>
        /// 3D 단선
        /// </summary>
        Solid3D = 16,

        /// <summary>
        /// 3D 단선(광원 반대)
        /// </summary>
        Solid3DReverseLighting = 17,
    }

    /// <summary>
    /// BorderType enum 확장 메서드
    /// </summary>
    public static class BorderTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="borderType">enum 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this BorderType borderType)
        {
            return (byte)borderType;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static BorderType FromValue(byte value)
        {
            return value switch
            {
                0 => BorderType.None,
                1 => BorderType.Solid,
                2 => BorderType.Dash,
                3 => BorderType.Dot,
                4 => BorderType.DashDot,
                5 => BorderType.DashDotDot,
                6 => BorderType.LongDash,
                7 => BorderType.CircleDot,
                8 => BorderType.Double,
                9 => BorderType.ThinThick,
                10 => BorderType.ThickThin,
                11 => BorderType.ThinThickThin,
                12 => BorderType.Wave,
                13 => BorderType.DoubleWave,
                14 => BorderType.Thick3D,
                15 => BorderType.Thick3DReverseLighting,
                16 => BorderType.Solid3D,
                17 => BorderType.Solid3DReverseLighting,
                _ => BorderType.Solid,
            };
        }
    }
}

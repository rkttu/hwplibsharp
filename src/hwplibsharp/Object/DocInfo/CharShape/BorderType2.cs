// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/BorderType2.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill;

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 문자선(밑줄 or 취소선) 종류
    /// </summary>
    public enum BorderType2 : byte
    {
        /// <summary>실선</summary>
        Solid = 0,
        /// <summary>긴 점선 (쇄선)</summary>
        Dash = 1,
        /// <summary>점선</summary>
        Dot = 2,
        /// <summary>-.-.-.-.(일점 쇄선)</summary>
        DashDot = 3,
        /// <summary>-..-..-..(이점 쇄선)</summary>
        DashDotDot = 4,
        /// <summary>Dash보다 긴 선분의 반복</summary>
        LongDash = 5,
        /// <summary>Dot보다 큰 동그라미의 반복</summary>
        CircleDot = 6,
        /// <summary>2중선</summary>
        Double = 7,
        /// <summary>가는선 + 굵은선 2중선</summary>
        ThinThick = 8,
        /// <summary>굵은선 + 가는선 2중선</summary>
        ThickThin = 9,
        /// <summary>가는선 + 굵은선 + 가는선 3중선</summary>
        ThinThickThin = 10,
        /// <summary>물결</summary>
        Wave = 11,
        /// <summary>물결 2중선</summary>
        DoubleWave = 12,
        /// <summary>두꺼운 3D</summary>
        Thick3D = 13,
        /// <summary>두꺼운 3D(광원 반대)</summary>
        Thick3DReverseLighting = 14,
        /// <summary>3D 단선</summary>
        Solid3D = 15,
        /// <summary>3D 단선(광원 반대)</summary>
        Solid3DReverseLighting = 16
    }

    /// <summary>
    /// BorderType2 열거형에 대한 확장 메서드를 제공합니다.
    /// </summary>
    public static class BorderType2Extensions
    {
        /// <summary>
        /// BorderType2 값의 byte 표현을 반환합니다.
        /// </summary>
        /// <param name="type">변환할 BorderType2 값</param>
        /// <returns>byte로 변환된 값</returns>
        public static byte GetValue(this BorderType2 type) => (byte)type;

        /// <summary>
        /// byte 값을 BorderType2 열거형 값으로 변환합니다.
        /// </summary>
        /// <param name="value">변환할 byte 값</param>
        /// <returns>변환된 BorderType2 값</returns>
        public static BorderType2 FromValue(byte value) => value switch
        {
            0 => BorderType2.Solid,
            1 => BorderType2.Dash,
            2 => BorderType2.Dot,
            3 => BorderType2.DashDot,
            4 => BorderType2.DashDotDot,
            5 => BorderType2.LongDash,
            6 => BorderType2.CircleDot,
            7 => BorderType2.Double,
            8 => BorderType2.ThinThick,
            9 => BorderType2.ThickThin,
            10 => BorderType2.ThinThickThin,
            11 => BorderType2.Wave,
            12 => BorderType2.DoubleWave,
            13 => BorderType2.Thick3D,
            14 => BorderType2.Thick3DReverseLighting,
            15 => BorderType2.Solid3D,
            16 => BorderType2.Solid3DReverseLighting,
            _ => BorderType2.Solid
        };

        /// <summary>
        /// BorderType2 값을 BorderType 값으로 변환합니다.
        /// </summary>
        /// <param name="type">변환할 BorderType2 값</param>
        /// <returns>변환된 BorderType 값</returns>
        public static BorderType ToBorderType(this BorderType2 type) => type switch
        {
            BorderType2.Solid => BorderType.Solid,
            BorderType2.Dash => BorderType.Dash,
            BorderType2.Dot => BorderType.Dot,
            BorderType2.DashDot => BorderType.DashDot,
            BorderType2.DashDotDot => BorderType.DashDotDot,
            BorderType2.LongDash => BorderType.LongDash,
            BorderType2.CircleDot => BorderType.CircleDot,
            BorderType2.Double => BorderType.Double,
            BorderType2.ThinThick => BorderType.ThinThick,
            BorderType2.ThickThin => BorderType.ThickThin,
            BorderType2.ThinThickThin => BorderType.ThinThickThin,
            BorderType2.Wave => BorderType.Wave,
            BorderType2.DoubleWave => BorderType.DoubleWave,
            BorderType2.Thick3D => BorderType.Thick3D,
            BorderType2.Thick3DReverseLighting => BorderType.Thick3DReverseLighting,
            BorderType2.Solid3D => BorderType.Solid3D,
            BorderType2.Solid3DReverseLighting => BorderType.Solid3DReverseLighting,
            _ => BorderType.None
        };
    }
}

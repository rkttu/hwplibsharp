// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/BorderThickness.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill
{
    /// <summary>
    /// 테두리선의 두께
    /// </summary>
    public enum BorderThickness : byte
    {
        /// <summary>
        /// 0.1 mm
        /// </summary>
        MM0_1 = 0,

        /// <summary>
        /// 0.12 mm
        /// </summary>
        MM0_12 = 1,

        /// <summary>
        /// 0.15 mm
        /// </summary>
        MM0_15 = 2,

        /// <summary>
        /// 0.2 mm
        /// </summary>
        MM0_2 = 3,

        /// <summary>
        /// 0.25 mm
        /// </summary>
        MM0_25 = 4,

        /// <summary>
        /// 0.3 mm
        /// </summary>
        MM0_3 = 5,

        /// <summary>
        /// 0.4 mm
        /// </summary>
        MM0_4 = 6,

        /// <summary>
        /// 0.5 mm
        /// </summary>
        MM0_5 = 7,

        /// <summary>
        /// 0.6 mm
        /// </summary>
        MM0_6 = 8,

        /// <summary>
        /// 0.7 mm
        /// </summary>
        MM0_7 = 9,

        /// <summary>
        /// 1.0 mm
        /// </summary>
        MM1_0 = 10,

        /// <summary>
        /// 1.5 mm
        /// </summary>
        MM1_5 = 11,

        /// <summary>
        /// 2.0 mm
        /// </summary>
        MM2_0 = 12,

        /// <summary>
        /// 3.0 mm
        /// </summary>
        MM3_0 = 13,

        /// <summary>
        /// 4.0 mm
        /// </summary>
        MM4_0 = 14,

        /// <summary>
        /// 5.0 mm
        /// </summary>
        MM5_0 = 15,
    }

    /// <summary>
    /// BorderThickness enum 확장 메서드
    /// </summary>
    public static class BorderThicknessExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        /// <param name="thickness">enum 값</param>
        /// <returns>파일에 저장되는 정수값</returns>
        public static byte GetValue(this BorderThickness thickness)
        {
            return (byte)thickness;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        /// <param name="value">파일에 저장되는 정수값</param>
        /// <returns>enum 값</returns>
        public static BorderThickness FromValue(byte value)
        {
            return value switch
            {
                0 => BorderThickness.MM0_1,
                1 => BorderThickness.MM0_12,
                2 => BorderThickness.MM0_15,
                3 => BorderThickness.MM0_2,
                4 => BorderThickness.MM0_25,
                5 => BorderThickness.MM0_3,
                6 => BorderThickness.MM0_4,
                7 => BorderThickness.MM0_5,
                8 => BorderThickness.MM0_6,
                9 => BorderThickness.MM0_7,
                10 => BorderThickness.MM1_0,
                11 => BorderThickness.MM1_5,
                12 => BorderThickness.MM2_0,
                13 => BorderThickness.MM3_0,
                14 => BorderThickness.MM4_0,
                15 => BorderThickness.MM5_0,
                _ => BorderThickness.MM0_1,
            };
        }
    }
}

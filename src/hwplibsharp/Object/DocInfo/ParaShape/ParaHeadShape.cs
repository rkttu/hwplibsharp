// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/parashape/ParaHeadShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.ParaShape
{
    /// <summary>
    /// 문단 머리 모양의 종류
    /// </summary>
    public enum ParaHeadShape : byte
    {
        /// <summary>
        /// 없음
        /// </summary>
        None = 0,

        /// <summary>
        /// 개요
        /// </summary>
        Outline = 1,

        /// <summary>
        /// 번호
        /// </summary>
        Numbering = 2,

        /// <summary>
        /// 글머리표(bullet)
        /// </summary>
        Bullet = 3
    }

    /// <summary>
    /// ParaHeadShape 확장 메서드
    /// </summary>
    public static class ParaHeadShapeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ParaHeadShape shape)
        {
            return (byte)shape;
        }

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ParaHeadShape FromValue(byte value)
        {
            return value switch
            {
                0 => ParaHeadShape.None,
                1 => ParaHeadShape.Outline,
                2 => ParaHeadShape.Numbering,
                3 => ParaHeadShape.Bullet,
                _ => ParaHeadShape.None
            };
        }
    }
}

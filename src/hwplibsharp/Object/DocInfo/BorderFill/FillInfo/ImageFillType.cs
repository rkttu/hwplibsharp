// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/borderfill/fillinfo/ImageFillType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.DocInfo.BorderFill.FillInfo
{
    /// <summary>
    /// 이미지 채우기 유형
    /// </summary>
    public enum ImageFillType : byte
    {
        /// <summary>
        /// 바둑판식으로-모두
        /// </summary>
        TileAll = 0,

        /// <summary>
        /// 바둑판식으로-가로/위
        /// </summary>
        TileHorizonalTop = 1,

        /// <summary>
        /// 바둑판식으로-가로/아래
        /// </summary>
        TileHorizonalBottom = 2,

        /// <summary>
        /// 바둑판식으로-세로/왼쪽
        /// </summary>
        TileVerticalLeft = 3,

        /// <summary>
        /// 바둑판식으로-세로/오른쪽
        /// </summary>
        TileVerticalRight = 4,

        /// <summary>
        /// 크기에 맞추어
        /// </summary>
        FitSize = 5,

        /// <summary>
        /// 가운데로
        /// </summary>
        Center = 6,

        /// <summary>
        /// 가운데 위로
        /// </summary>
        CenterTop = 7,

        /// <summary>
        /// 가운데 아래로
        /// </summary>
        CenterBottom = 8,

        /// <summary>
        /// 왼쪽 가운데로
        /// </summary>
        LeftCenter = 9,

        /// <summary>
        /// 왼쪽 위로
        /// </summary>
        LeftTop = 10,

        /// <summary>
        /// 왼쪽 아래로
        /// </summary>
        LeftBottom = 11,

        /// <summary>
        /// 오른쪽 가운데로
        /// </summary>
        RightCenter = 12,

        /// <summary>
        /// 오른쪽 위로
        /// </summary>
        RightTop = 13,

        /// <summary>
        /// 오른쪽 아래로
        /// </summary>
        RightBottom = 14,

        /// <summary>
        /// 원래 크기에 비례하여
        /// </summary>
        Zoom = 15,
    }

    /// <summary>
    /// ImageFillType 확장 메서드
    /// </summary>
    public static class ImageFillTypeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this ImageFillType type)
            => (byte)type;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static ImageFillType FromValue(byte value)
            => value switch
            {
                0 => ImageFillType.TileAll,
                1 => ImageFillType.TileHorizonalTop,
                2 => ImageFillType.TileHorizonalBottom,
                3 => ImageFillType.TileVerticalLeft,
                4 => ImageFillType.TileVerticalRight,
                5 => ImageFillType.FitSize,
                6 => ImageFillType.Center,
                7 => ImageFillType.CenterTop,
                8 => ImageFillType.CenterBottom,
                9 => ImageFillType.LeftCenter,
                10 => ImageFillType.LeftTop,
                11 => ImageFillType.LeftBottom,
                12 => ImageFillType.RightCenter,
                13 => ImageFillType.RightTop,
                14 => ImageFillType.RightBottom,
                15 => ImageFillType.Zoom,
                _ => ImageFillType.Center,
            };
    }
}

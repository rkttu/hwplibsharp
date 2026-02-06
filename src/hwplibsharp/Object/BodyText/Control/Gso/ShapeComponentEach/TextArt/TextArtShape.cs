// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/textart/TextArtShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.TextArt
{
    /// <summary>
    /// 글맵시 모양
    /// </summary>
    public enum TextArtShape : byte
    {
        /// <summary>
        /// 평행사변형
        /// </summary>
        Parallelogram = 0,
        /// <summary>
        /// 역(反) 평행사변형
        /// </summary>
        InvertedParallelogram = 1,
        /// <summary>
        /// 역상향 계단형
        /// </summary>
        InvertedUpwardCascade = 2,
        /// <summary>
        /// 역하향 계단형
        /// </summary>
        InvertedDownwardCascade = 3,
        /// <summary>
        /// 상향 계단형
        /// </summary>
        UpwardCascade = 4,
        /// <summary>
        /// 하향 계단형
        /// </summary>
        DownwardCascade = 5,
        /// <summary>
        /// 오른쪽 축소형
        /// </summary>
        ReduceRight = 6,
        /// <summary>
        /// 왼쪽 축소형
        /// </summary>
        ReduceLeft = 7,
        /// <summary>
        /// 이등변 사다리꼴
        /// </summary>
        IsoscelesTrapezoid = 8,
        /// <summary>
        /// 역 이등변 사다리꼴
        /// </summary>
        InvertedIsoscelesTrapezoid = 9,
        /// <summary>
        /// 상단 리본 사각형
        /// </summary>
        TopRibbonRectangle = 10,
        /// <summary>
        /// 하단 리본 사각형
        /// </summary>
        BottomRibbonRectangle = 11,
        /// <summary>
        /// 아래로 향한 갈매기형
        /// </summary>
        ChevronDown = 12,
        /// <summary>
        /// 갈매기형
        /// </summary>
        Chevron = 13,
        /// <summary>
        /// 나비넥타이형
        /// </summary>
        BowTie = 14,
        /// <summary>
        /// 육각형
        /// </summary>
        Hexagon = 15,
        /// <summary>
        /// 물결1
        /// </summary>
        Wave1 = 16,
        /// <summary>
        /// 물결2
        /// </summary>
        Wave2 = 17,
        /// <summary>
        /// 물결3
        /// </summary>
        Wave3 = 18,
        /// <summary>
        /// 물결4
        /// </summary>
        Wave4 = 19,
        /// <summary>
        /// 왼쪽 기울어진 원통
        /// </summary>
        LeftTiltCylinder = 20,
        /// <summary>
        /// 오른쪽 기울어진 원통
        /// </summary>
        RightTiltCylinder = 21,
        /// <summary>
        /// 하단이 넓은 원통
        /// </summary>
        BottomWideCylinder = 22,
        /// <summary>
        /// 상단이 넓은 원통
        /// </summary>
        TopWideCylinder = 23,
        /// <summary>
        /// 얇은 상향 곡선1
        /// </summary>
        ThinCurveUp1 = 24,
        /// <summary>
        /// 얇은 상향 곡선2
        /// </summary>
        ThinCurveUp2 = 25,
        /// <summary>
        /// 얇은 하향 곡선1
        /// </summary>
        ThinCurveDown1 = 26,
        /// <summary>
        /// 얇은 하향 곡선2
        /// </summary>
        ThinCurveDown2 = 27,
        /// <summary>
        /// 역 손톱형
        /// </summary>
        InversedFingernail = 28,
        /// <summary>
        /// 손톱형
        /// </summary>
        Fingernail = 29,
        /// <summary>
        /// 은행잎1
        /// </summary>
        GinkoLeaf1 = 30,
        /// <summary>
        /// 은행잎2
        /// </summary>
        GinkoLeaf2 = 31,
        /// <summary>
        /// 오른쪽 팽창형
        /// </summary>
        InflateRight = 32,
        /// <summary>
        /// 왼쪽 팽창형
        /// </summary>
        InflateLeft = 33,
        /// <summary>
        /// 위쪽 볼록 팽창형
        /// </summary>
        InflateUpConvex = 34,
        /// <summary>
        /// 아래쪽 볼록 팽창형
        /// </summary>
        InflateBottomConvex = 35,
        /// <summary>
        /// 위쪽 오목 축소형
        /// </summary>
        DeflateTop = 36,
        /// <summary>
        /// 아래쪽 오목 축소형
        /// </summary>
        DeflateBottom = 37,
        /// <summary>
        /// 전체 오목 축소형
        /// </summary>
        Deflate = 38,
        /// <summary>
        /// 전체 볼록 팽창형
        /// </summary>
        Inflate = 39,
        /// <summary>
        /// 위쪽 팽창형
        /// </summary>
        InflateTop = 40,
        /// <summary>
        /// 아래쪽 팽창형
        /// </summary>
        InflateBottom = 41,
        /// <summary>
        /// 사각형
        /// </summary>
        Rectangle = 42,
        /// <summary>
        /// 왼쪽 원통
        /// </summary>
        LeftCylinder = 43,
        /// <summary>
        /// 원통
        /// </summary>
        Cylinder = 44,
        /// <summary>
        /// 오른쪽 원통
        /// </summary>
        RightCylinder = 45,
        /// <summary>
        /// 원형
        /// </summary>
        Circle = 46,
        /// <summary>
        /// 하향 곡선
        /// </summary>
        CurveDown = 47,
        /// <summary>
        /// 상향 아치형
        /// </summary>
        ArchUp = 48,
        /// <summary>
        /// 하향 아치형
        /// </summary>
        ArchDown = 49,
        /// <summary>
        /// 단일선 원형1
        /// </summary>
        SingleLineCircle1 = 50,
        /// <summary>
        /// 단일선 원형2
        /// </summary>
        SingleLineCircle2 = 51,
        /// <summary>
        /// 삼중선 원형1
        /// </summary>
        TripleLineCircle1 = 52,
        /// <summary>
        /// 삼중선 원형2
        /// </summary>
        TripleLineCircle2 = 53,
        /// <summary>
        /// 이중선 원형
        /// </summary>
        DoubleLineCircle = 54,
    }

    /// <summary>
    /// TextArtShape 확장 메서드
    /// </summary>
    public static class TextArtShapeExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this TextArtShape shape)
            => (byte)shape;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static TextArtShape FromValue(byte value)
        {
            if (Enum.IsDefined(typeof(TextArtShape), value))
            {
                return (TextArtShape)value;
            }
            return TextArtShape.Parallelogram;
        }
    }
}

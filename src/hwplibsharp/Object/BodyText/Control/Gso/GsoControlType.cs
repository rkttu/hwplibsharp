// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/GsoControlType.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 그리기 개체 타입
    /// </summary>
    public enum GsoControlType
    {
        /// <summary>
        /// 선
        /// </summary>
        Line,

        /// <summary>
        /// 사각형
        /// </summary>
        Rectangle,

        /// <summary>
        /// 타원
        /// </summary>
        Ellipse,

        /// <summary>
        /// 호
        /// </summary>
        Arc,

        /// <summary>
        /// 다각형
        /// </summary>
        Polygon,

        /// <summary>
        /// 곡선
        /// </summary>
        Curve,

        /// <summary>
        /// 그림
        /// </summary>
        Picture,

        /// <summary>
        /// OLE
        /// </summary>
        OLE,

        /// <summary>
        /// 묶음 객체
        /// </summary>
        Container,

        /// <summary>
        /// 객체 연결선
        /// </summary>
        ObjectLinkLine,

        /// <summary>
        /// 글맵시
        /// </summary>
        TextArt,

        /// <summary>
        /// 알 수 없는 개체
        /// </summary>
        Unknown
    }

    /// <summary>
    /// GsoControlType enum에 대한 확장 메서드
    /// </summary>
    public static class GsoControlTypeExtensions
    {
        private static readonly long LineId = CtrlID.Make('$', 'l', 'i', 'n');
        private static readonly long RectangleId = CtrlID.Make('$', 'r', 'e', 'c');
        private static readonly long EllipseId = CtrlID.Make('$', 'e', 'l', 'l');
        private static readonly long ArcId = CtrlID.Make('$', 'a', 'r', 'c');
        private static readonly long PolygonId = CtrlID.Make('$', 'p', 'o', 'l');
        private static readonly long CurveId = CtrlID.Make('$', 'c', 'u', 'r');
        private static readonly long PictureId = CtrlID.Make('$', 'p', 'i', 'c');
        private static readonly long OLEId = CtrlID.Make('$', 'o', 'l', 'e');
        private static readonly long ContainerId = CtrlID.Make('$', 'c', 'o', 'n');
        private static readonly long ObjectLinkLineId = CtrlID.Make('$', 'c', 'o', 'l');
        private static readonly long TextArtId = CtrlID.Make('$', 't', 'a', 't');
        private static readonly long UnknownId = CtrlID.Make('$', 'u', 'n', 'k');

        /// <summary>
        /// 아이디를 반환한다.
        /// </summary>
        /// <param name="type">GsoControlType 값</param>
        /// <returns>아이디</returns>
        public static long GetId(this GsoControlType type)
        {
            return type switch
            {
                GsoControlType.Line => LineId,
                GsoControlType.Rectangle => RectangleId,
                GsoControlType.Ellipse => EllipseId,
                GsoControlType.Arc => ArcId,
                GsoControlType.Polygon => PolygonId,
                GsoControlType.Curve => CurveId,
                GsoControlType.Picture => PictureId,
                GsoControlType.OLE => OLEId,
                GsoControlType.Container => ContainerId,
                GsoControlType.ObjectLinkLine => ObjectLinkLineId,
                GsoControlType.TextArt => TextArtId,
                GsoControlType.Unknown => UnknownId,
                _ => LineId
            };
        }

        /// <summary>
        /// 아이디에 해당하는 그리기 개체 타입을 반환한다.
        /// </summary>
        /// <param name="id">아이디</param>
        /// <returns>그리기 개체 타입</returns>
        public static GsoControlType IdOf(long id)
        {
            if (id == LineId) return GsoControlType.Line;
            if (id == RectangleId) return GsoControlType.Rectangle;
            if (id == EllipseId) return GsoControlType.Ellipse;
            if (id == ArcId) return GsoControlType.Arc;
            if (id == PolygonId) return GsoControlType.Polygon;
            if (id == CurveId) return GsoControlType.Curve;
            if (id == PictureId) return GsoControlType.Picture;
            if (id == OLEId) return GsoControlType.OLE;
            if (id == ContainerId) return GsoControlType.Container;
            if (id == ObjectLinkLineId) return GsoControlType.ObjectLinkLine;
            if (id == TextArtId) return GsoControlType.TextArt;
            if (id == UnknownId) return GsoControlType.Unknown;
            return GsoControlType.Line;
        }
    }
}

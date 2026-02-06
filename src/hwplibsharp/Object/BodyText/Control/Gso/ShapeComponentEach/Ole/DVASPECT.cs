// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/ole/DVASPECT.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Ole
{
    /// <summary>
    /// Windows API DVASPECT enumeration
    /// </summary>
    public enum DVASPECT : byte
    {
        /// <summary>
        /// CONTENT
        /// </summary>
        Content = 1,

        /// <summary>
        /// THUMBNAIL
        /// </summary>
        Thumbnail = 2,

        /// <summary>
        /// ICON
        /// </summary>
        Icon = 4,

        /// <summary>
        /// DOCPRINT
        /// </summary>
        DocPrint = 8,
    }

    /// <summary>
    /// DVASPECT 확장 메서드
    /// </summary>
    public static class DVASPECTExtensions
    {
        /// <summary>
        /// 파일에 저장되는 정수값을 반환한다.
        /// </summary>
        public static byte GetValue(this DVASPECT aspect)
            => (byte)aspect;

        /// <summary>
        /// 파일에 저장되는 정수값에 해당되는 enum 값을 반환한다.
        /// </summary>
        public static DVASPECT FromValue(byte value)
            => value switch
            {
                1 => DVASPECT.Content,
                2 => DVASPECT.Thumbnail,
                4 => DVASPECT.Icon,
                8 => DVASPECT.DocPrint,
                _ => DVASPECT.Content,
            };
    }
}

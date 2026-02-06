// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderBookmark.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 책갈피 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderBookmark : CtrlHeader
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderBookmark()
            : base(ControlType.Bookmark.GetCtrlId())
        {
        }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
        }
    }
}

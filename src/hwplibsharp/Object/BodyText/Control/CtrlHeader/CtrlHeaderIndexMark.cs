// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderIndexMark.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 찾아보기 표식 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderIndexMark : CtrlHeader
    {
        /// <summary>
        /// 키워드 1
        /// </summary>
        private readonly HWPString keyword1;

        /// <summary>
        /// 키워드 2
        /// </summary>
        private readonly HWPString keyword2;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderIndexMark()
            : base(ControlType.IndexMark.GetCtrlId())
        {
            keyword1 = new HWPString();
            keyword2 = new HWPString();
        }

        /// <summary>
        /// 키워드 1을 반환한다.
        /// </summary>
        public HWPString Keyword1 => keyword1;

        /// <summary>
        /// 키워드 2을 반환한다.
        /// </summary>
        public HWPString Keyword2 => keyword2;

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderIndexMark from2 = (CtrlHeaderIndexMark)from;
            keyword1.Copy(from2.keyword1);
            keyword2.Copy(from2.keyword2);
        }
    }
}

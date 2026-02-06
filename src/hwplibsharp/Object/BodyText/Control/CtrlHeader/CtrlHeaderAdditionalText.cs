// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderAdditionalText.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.AdditionalText;
using HwpLib.Object.DocInfo.ParaShape;
using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 덧말 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderAdditionalText : CtrlHeader
    {
        /// <summary>
        /// main text
        /// </summary>
        private readonly HWPString mainText;

        /// <summary>
        /// sub text
        /// </summary>
        private readonly HWPString subText;

        /// <summary>
        /// 덧말 위치
        /// </summary>
        public AdditionalTextPosition Position { get; set; }

        /// <summary>
        /// 폰트 크기 비율(??)
        /// </summary>
        public uint Fsizeratio { get; set; }

        /// <summary>
        /// 옵션(??)
        /// </summary>
        public uint Option { get; set; }

        /// <summary>
        /// Style Number
        /// </summary>
        public uint StyleId { get; set; }

        /// <summary>
        /// 정렬 기준
        /// </summary>
        public Alignment Alignment { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderAdditionalText()
            : base(ControlType.AdditionalText.GetCtrlId())
        {
            mainText = new HWPString();
            subText = new HWPString();
        }

        /// <summary>
        /// main text를 반환한다.
        /// </summary>
        public HWPString MainText => mainText;

        /// <summary>
        /// sub text를 반환한다.
        /// </summary>
        public HWPString SubText => subText;

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderAdditionalText from2 = (CtrlHeaderAdditionalText)from;
            mainText.Copy(from2.mainText);
            subText.Copy(from2.subText);
            Position = from2.Position;
            Fsizeratio = from2.Fsizeratio;
            Option = from2.Option;
            StyleId = from2.StyleId;
            Alignment = from2.Alignment;
        }
    }
}

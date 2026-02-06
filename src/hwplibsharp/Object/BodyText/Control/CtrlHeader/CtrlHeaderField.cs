// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderField.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.Field;
using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 필드 컨트롤를 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderField : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly FieldHeaderProperty property;

        /// <summary>
        /// command
        /// </summary>
        private readonly HWPString command;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderField()
            : this(ControlType.FIELD_UNKNOWN.GetCtrlId())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ctrlId">컨트롤 아이디(필드 아이디)</param>
        public CtrlHeaderField(uint ctrlId)
            : base(ctrlId)
        {
            property = new FieldHeaderProperty();
            command = new HWPString();
        }

        /// <summary>
        /// 컨트롤 아이디(필드 아이디)를 설정한다.
        /// </summary>
        public new uint CtrlId
        {
            get => ctrlId;
            set => ctrlId = value;
        }

        /// <summary>
        /// 필드 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public FieldHeaderProperty Property => property;

        /// <summary>
        /// 기타 속성
        /// </summary>
        public short EtcProperty { get; set; }

        /// <summary>
        /// 필드 command를 반환한다.
        /// </summary>
        public HWPString Command => command;

        /// <summary>
        /// 문서 내 고유 아이디
        /// </summary>
        public uint InstanceId { get; set; }

        /// <summary>
        /// 메모 인덱스
        /// </summary>
        public int MemoIndex { get; set; }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderField from2 = (CtrlHeaderField)from;
            property.Copy(from2.property);
            EtcProperty = from2.EtcProperty;
            command.Copy(from2.command);
            InstanceId = from2.InstanceId;
            MemoIndex = from2.MemoIndex;
        }
    }
}

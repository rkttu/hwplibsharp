// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderGso.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.Gso;
using HwpLib.Object.Etc;
using System;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 그리기 개체을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderGso : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly GsoHeaderProperty property;

        /// <summary>
        /// 개체 설명문
        /// </summary>
        private readonly HWPString explanation;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderGso()
            : base(ControlType.Gso.GetCtrlId())
        {
            property = new GsoHeaderProperty();
            explanation = new HWPString();
            Unknown = null;
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="controlType">컨트롤 타입</param>
        public CtrlHeaderGso(ControlType controlType)
            : base(controlType.GetCtrlId())
        {
            property = new GsoHeaderProperty();
            explanation = new HWPString();
        }

        /// <summary>
        /// 그리기 객체 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public GsoHeaderProperty Property => property;

        /// <summary>
        /// 세로 오프셋 값
        /// </summary>
        public uint YOffset { get; set; }

        /// <summary>
        /// 가로 오프셋 값
        /// </summary>
        public uint XOffset { get; set; }

        /// <summary>
        /// 오브젝트의 폭
        /// </summary>
        public uint Width { get; set; }

        /// <summary>
        /// 오브젝트의 높이
        /// </summary>
        public uint Height { get; set; }

        /// <summary>
        /// z-order
        /// </summary>
        public int ZOrder { get; set; }

        /// <summary>
        /// 오브젝트의 바깥 왼쪽 여백
        /// </summary>
        public int OutterMarginLeft { get; set; }

        /// <summary>
        /// 오브젝트의 바깥 오른쪽 여백
        /// </summary>
        public int OutterMarginRight { get; set; }

        /// <summary>
        /// 오브젝트의 바깥 위쪽 여백
        /// </summary>
        public int OutterMarginTop { get; set; }

        /// <summary>
        /// 오브젝트의 바깥 아래쪽 여백
        /// </summary>
        public int OutterMarginBottom { get; set; }

        /// <summary>
        /// 문서 내 각 개체에 대한 고유 아이디
        /// </summary>
        public uint InstanceId { get; set; }

        /// <summary>
        /// 쪽나눔 방지 on(1) / off(0) = (객체와 조판 부호를 항상 같은 쪽에 넣기) ??
        /// </summary>
        public bool PreventPageDivide { get; set; }

        /// <summary>
        /// 개체 설명문을 반환한다.
        /// </summary>
        public HWPString Explanation => explanation;

        /// <summary>
        /// 알 수 없는 바이트 : 2024 버전에서...
        /// </summary>
        public byte[]? Unknown { get; set; }

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderGso from2 = (CtrlHeaderGso)from;
            property.Copy(from2.property);
            YOffset = from2.YOffset;
            XOffset = from2.XOffset;
            Width = from2.Width;
            Height = from2.Height;
            ZOrder = from2.ZOrder;
            OutterMarginLeft = from2.OutterMarginLeft;
            OutterMarginRight = from2.OutterMarginRight;
            OutterMarginTop = from2.OutterMarginTop;
            OutterMarginBottom = from2.OutterMarginBottom;
            InstanceId = from2.InstanceId;
            PreventPageDivide = from2.PreventPageDivide;
            explanation.Copy(from2.explanation);
            if (from2.Unknown != null)
            {
                Unknown = new byte[from2.Unknown.Length];
                Array.Copy(from2.Unknown, Unknown, from2.Unknown.Length);
            }
            else
            {
                Unknown = null;
            }
        }
    }
}

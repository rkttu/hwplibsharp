// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderSectionDefine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.SectionDefine;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 구역 정의 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderSectionDefine : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        public SectionDefineHeaderProperty Property { get; }

        /// <summary>
        /// 동일한 페이지에서 서로 다른 단 사이의 간격
        /// </summary>
        public int ColumnGap { get; set; }

        /// <summary>
        /// 세로로 줄맞춤을 할지 여부
        /// </summary>
        public int VerticalLineAlign { get; set; }

        /// <summary>
        /// 가로로 줄맞춤을 할지 여부
        /// </summary>
        public int HorizontalLineAlign { get; set; }

        /// <summary>
        /// 기본 탭 간격
        /// </summary>
        public long DefaultTabGap { get; set; }

        /// <summary>
        /// 번호 문단 모양 ID
        /// </summary>
        public int NumberParaShapeId { get; set; }

        /// <summary>
        /// 쪽 시작 번호
        /// </summary>
        public int PageStartNumber { get; set; }

        /// <summary>
        /// 그림 시작 번호
        /// </summary>
        public int ImageStartNumber { get; set; }

        /// <summary>
        /// 표 시작 번호
        /// </summary>
        public int TableStartNumber { get; set; }

        /// <summary>
        /// 수식 시작 번호
        /// </summary>
        public int EquationStartNumber { get; set; }

        /// <summary>
        /// 대표 Language (5.0.1.5 이상)
        /// </summary>
        public int DefaultLanguage { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderSectionDefine()
            : base(ControlType.SectionDefine.GetCtrlId())
        {
            Property = new SectionDefineHeaderProperty();
        }

        /// <inheritdoc />
        public override void Copy(CtrlHeader from)
        {
            if (!(from is CtrlHeaderSectionDefine from2))
                return;

            Property.Copy(from2.Property);
            ColumnGap = from2.ColumnGap;
            VerticalLineAlign = from2.VerticalLineAlign;
            HorizontalLineAlign = from2.HorizontalLineAlign;
            DefaultTabGap = from2.DefaultTabGap;
            NumberParaShapeId = from2.NumberParaShapeId;
            PageStartNumber = from2.PageStartNumber;
            ImageStartNumber = from2.ImageStartNumber;
            TableStartNumber = from2.TableStartNumber;
            EquationStartNumber = from2.EquationStartNumber;
            DefaultLanguage = from2.DefaultLanguage;
        }
    }
}

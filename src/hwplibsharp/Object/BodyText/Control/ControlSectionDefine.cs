// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ControlSectionDefine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.SectionDefine;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 구역 정의 컨트롤
    /// </summary>
    public class ControlSectionDefine : Control
    {
        /// <summary>
        /// 용지설정 정보
        /// </summary>
        private readonly PageDef _pageDef;

        /// <summary>
        /// 각주 모양 정보
        /// </summary>
        private readonly FootEndNoteShape _footNoteShape;

        /// <summary>
        /// 미주 모양 정보
        /// </summary>
        private readonly FootEndNoteShape _endNoteShape;

        /// <summary>
        /// 쪽 테두리/배경 정보 - 양 쪽
        /// </summary>
        private readonly PageBorderFill _bothPageBorderFill;

        /// <summary>
        /// 쪽 테두리/배경 정보 - 짝수 쪽
        /// </summary>
        private readonly PageBorderFill _evenPageBorderFill;

        /// <summary>
        /// 쪽 테두리/배경 정보 - 홀수 쪽
        /// </summary>
        private readonly PageBorderFill _oddPageBorderFill;

        /// <summary>
        /// 바탕쪽 정보(양 쪽, 짝수 쪽, 홀수 쪽) 리스트
        /// </summary>
        private readonly List<BatangPageInfo> _batangPageInfoList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlSectionDefine()
            : base(new CtrlHeaderSectionDefine())
        {
            _pageDef = new PageDef();
            _footNoteShape = new FootEndNoteShape();
            _endNoteShape = new FootEndNoteShape();
            _bothPageBorderFill = new PageBorderFill();
            _evenPageBorderFill = new PageBorderFill();
            _oddPageBorderFill = new PageBorderFill();
            _batangPageInfoList = new List<BatangPageInfo>();
        }

        /// <summary>
        /// 구역 정의 컨트롤 용 컨트롤 헤더를 반환한다.
        /// </summary>
        public new CtrlHeaderSectionDefine Header => (CtrlHeaderSectionDefine)base.Header!;

        /// <summary>
        /// 용지설정 정보를 반환한다.
        /// </summary>
        public PageDef PageDef => _pageDef;

        /// <summary>
        /// 각주 모양 정보를 반환한다.
        /// </summary>
        public FootEndNoteShape FootNoteShape => _footNoteShape;

        /// <summary>
        /// 미주 모양 정보를 반환한다.
        /// </summary>
        public FootEndNoteShape EndNoteShape => _endNoteShape;

        /// <summary>
        /// 쪽 테두리/배경 정보(양 쪽)를 반환한다.
        /// </summary>
        public PageBorderFill BothPageBorderFill => _bothPageBorderFill;

        /// <summary>
        /// 쪽 테두리/배경 정보(짝수 쪽)를 반환한다.
        /// </summary>
        public PageBorderFill EvenPageBorderFill => _evenPageBorderFill;

        /// <summary>
        /// 쪽 테두리/배경 정보(홀수 쪽)를 반환한다.
        /// </summary>
        public PageBorderFill OddPageBorderFill => _oddPageBorderFill;

        /// <summary>
        /// 바탕쪽 정보 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<BatangPageInfo> BatangPageInfoList => _batangPageInfoList;

        /// <summary>
        /// 새로운 바탕 쪽 정보 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 바탕 쪽 정보 객체</returns>
        public BatangPageInfo AddNewBatangPageInfo()
        {
            var bpi = new BatangPageInfo();
            _batangPageInfoList.Add(bpi);
            return bpi;
        }

        /// <inheritdoc />
        public override Control Clone()
        {
            var cloned = new ControlSectionDefine();
            cloned.CopyControlPart(this);
            cloned._pageDef.Copy(_pageDef);
            cloned._footNoteShape.Copy(_footNoteShape);
            cloned._endNoteShape.Copy(_endNoteShape);
            cloned._bothPageBorderFill.Copy(_bothPageBorderFill);
            cloned._evenPageBorderFill.Copy(_evenPageBorderFill);
            cloned._oddPageBorderFill.Copy(_oddPageBorderFill);

            foreach (var batangPageInfo in _batangPageInfoList)
            {
                cloned._batangPageInfoList.Add(batangPageInfo.Clone());
            }

            return cloned;
        }
    }
}

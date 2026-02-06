// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeaderColumnDefine.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader.ColumnDefine;
using HwpLib.Object.DocInfo.BorderFill;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 단 정의 컨트롤을 위한 컨트롤 헤더 레코드
    /// </summary>
    public class CtrlHeaderColumnDefine : CtrlHeader
    {
        /// <summary>
        /// 속성
        /// </summary>
        private readonly ColumnDefineHeaderProperty property;

        /// <summary>
        /// 단 정보 리스트
        /// </summary>
        private readonly List<ColumnInfo> columnInfoList;

        /// <summary>
        /// 단 구분선 정보
        /// </summary>
        private readonly EachBorder divideLine;

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlHeaderColumnDefine()
            : base(ControlType.ColumnDefine.GetCtrlId())
        {
            property = new ColumnDefineHeaderProperty();
            columnInfoList = new List<ColumnInfo>();
            divideLine = new EachBorder();
        }

        /// <summary>
        /// 단 정의 컨트롤의 속성 객체를 반환한다.
        /// </summary>
        public ColumnDefineHeaderProperty Property => property;

        /// <summary>
        /// 단 사이 간격
        /// </summary>
        public int GapBetweenColumn { get; set; }

        /// <summary>
        /// 속성2(정보 없음)
        /// </summary>
        public int Property2 { get; set; }

        /// <summary>
        /// 단 정보 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<ColumnInfo> ColumnInfoList => columnInfoList;

        /// <summary>
        /// 새로운 단 정보 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 단 정보 객체</returns>
        public ColumnInfo AddNewColumnInfo()
        {
            ColumnInfo ci = new ColumnInfo();
            columnInfoList.Add(ci);
            return ci;
        }

        /// <summary>
        /// 단 구분선 정보를 반환한다.
        /// </summary>
        public EachBorder DivideLine => divideLine;

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public override void Copy(CtrlHeader from)
        {
            CtrlHeaderColumnDefine from2 = (CtrlHeaderColumnDefine)from;
            property.Copy(from2.property);
            GapBetweenColumn = from2.GapBetweenColumn;
            Property2 = from2.Property2;

            columnInfoList.Clear();
            foreach (ColumnInfo columnInfo in from2.columnInfoList)
            {
                columnInfoList.Add(columnInfo.Clone());
            }
            divideLine.Copy(from2.divideLine);
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/lineseg/ParaLineSeg.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Paragraph.LineSeg
{
    /// <summary>
    /// 문단의 레이아웃 레코드
    /// </summary>
    public class ParaLineSeg
    {
        /// <summary>
        /// 각 줄의 align 정보의 리스트
        /// </summary>
        private readonly List<LineSegItem> _lineSegItemList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaLineSeg()
        {
            _lineSegItemList = new List<LineSegItem>();
        }

        /// <summary>
        /// 각 줄의 align 정보의 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<LineSegItem> LineSegItemList => _lineSegItemList;

        /// <summary>
        /// 각 줄의 align 정보에 대한 객체를 새로 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 각 줄의 align 정보에 대한 객체</returns>
        public LineSegItem AddNewLineSegItem()
        {
            var plsi = new LineSegItem();
            _lineSegItemList.Add(plsi);
            return plsi;
        }

        /// <summary>
        /// 각 줄의 align 정보를 리스트에 추가한다.
        /// </summary>
        /// <param name="item">추가할 LineSegItem</param>
        public void AddLineSegItem(LineSegItem item)
        {
            _lineSegItemList.Add(item);
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ParaLineSeg Clone()
        {
            var cloned = new ParaLineSeg();

            foreach (var lineSegItem in _lineSegItemList)
            {
                cloned._lineSegItemList.Add(lineSegItem.Clone());
            }

            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/ControlFilter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Paragraph;

namespace HwpLib.Tool.ObjectFinder
{
    /// <summary>
    /// 원하는 컨트롤을 찾기 위한 조건을 입력할 수 있는 인터페이스
    /// </summary>
    public interface IControlFilter
    {
        /// <summary>
        /// 원하는 컨트롤을 찾기 위한 조건에 맞는지 여부를 반환한다.
        /// </summary>
        /// <param name="control">컨트롤</param>
        /// <param name="paragraph">현재 문단</param>
        /// <param name="section">현재 구역</param>
        /// <returns>원하는 컨트롤을 찾기 위한 조건에 맞는지 여부</returns>
        bool IsMatched(Control control, Paragraph paragraph, Section section);
    }
}

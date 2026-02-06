// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/bookmark/CtrlData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Bookmark
{
    /// <summary>
    /// 임의 데이터 레코드
    /// </summary>
    public class CtrlData
    {
        /// <summary>
        /// 파라미터 셋
        /// </summary>
        public ParameterSet ParameterSet { get; }

        /// <summary>
        /// 생성자
        /// </summary>
        public CtrlData()
        {
            ParameterSet = new ParameterSet();
        }

        /// <summary>
        /// 다른 CtrlData 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(CtrlData from)
        {
            ParameterSet.Copy(from.ParameterSet);
        }
    }
}

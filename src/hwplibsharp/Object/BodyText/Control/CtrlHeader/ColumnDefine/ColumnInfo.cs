// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/columndefine/ColumnInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader.ColumnDefine
{
    /// <summary>
    /// 하나의 단에 대한 정보를 나타내는 객체
    /// </summary>
    public class ColumnInfo
    {
        /// <summary>
        /// 다단의 폭
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 다음 단과의 간격
        /// </summary>
        public int Gap { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ColumnInfo()
        {
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ColumnInfo Clone()
        {
            return new ColumnInfo
            {
                Width = Width,
                Gap = Gap
            };
        }
    }
}

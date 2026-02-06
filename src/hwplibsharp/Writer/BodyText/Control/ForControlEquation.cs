// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForControlEquation.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Writer.BodyText.Control.Eqed;
using HwpLib.Writer.BodyText.Control.Gso.Part;

namespace HwpLib.Writer.BodyText.Control
{
    /// <summary>
    /// 수식 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlEquation
    {
        /// <summary>
        /// 수식 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlEquation eqed, CompoundStreamWriter sw)
        {
            ForCtrlHeaderGso.Write(eqed.GetHeader()!, sw);

            sw.UpRecordLevel();

            ForCaption.Write(eqed.Caption, sw);
            ForEQEdit.Write(eqed.EQEdit, sw);

            sw.DownRecordLevel();
        }
    }
}

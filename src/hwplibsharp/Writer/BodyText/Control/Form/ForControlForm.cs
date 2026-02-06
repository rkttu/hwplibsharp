// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/form/ForControlForm.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Form;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Gso.Part;

namespace HwpLib.Writer.BodyText.Control.Form
{
    /// <summary>
    /// 양식 개체 컨트롤을 쓰기 위한 객체
    /// </summary>
    public static class ForControlForm
    {
        /// <summary>
        /// 양식 개체 컨트롤을 쓴다.
        /// </summary>
        public static void Write(ControlForm form, CompoundStreamWriter sw)
        {
            ForCtrlHeaderGso.Write(form.GetHeader()!, sw);

            sw.UpRecordLevel();

            FormObject(form.FormObject, sw);

            sw.DownRecordLevel();
        }

        private static void FormObject(FormObject fo, CompoundStreamWriter sw)
        {
            HWPString propertiesString = fo.Properties.ToHWPString();
            RecordHeader(/*fo, */propertiesString, sw);
            sw.WriteUInt4(fo.Type?.GetId() ?? 0);
            sw.WriteUInt4(fo.Type?.GetId() ?? 0);
            sw.WriteUInt2((ushort)propertiesString.GetWCharsSize());
            sw.WriteZero(2);
            sw.WriteHWPString(propertiesString);
        }

        private static void RecordHeader(/*FormObject fo, */HWPString propertiesString, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.FormObject, GetSize(/*fo, */propertiesString));
        }

        private static long GetSize(/*FormObject fo, */HWPString propertiesString)
        {
            return 12 + propertiesString.GetWCharsSize();
        }
    }
}

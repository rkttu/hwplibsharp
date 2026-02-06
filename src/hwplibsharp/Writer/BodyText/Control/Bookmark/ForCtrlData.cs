// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/bookmark/ForCtrlData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Bookmark;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Bookmark
{
    /// <summary>
    /// 임의 데이터 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForCtrlData
    {
        /// <summary>
        /// 임의 데이터 레코드를 쓴다.
        /// </summary>
        public static void Write(CtrlData? cd, CompoundStreamWriter sw)
        {
            if (cd == null)
            {
                return;
            }

            RecordHeader(cd, sw);
            ForParameterSet.Write(cd.ParameterSet, sw);
        }

        /// <summary>
        /// 임의 데이터 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(CtrlData cd, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CtrlData, GetSize(cd));
        }

        /// <summary>
        /// 임의 데이터 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(CtrlData cd)
        {
            return ForParameterSet.GetSize(cd.ParameterSet);
        }
    }
}

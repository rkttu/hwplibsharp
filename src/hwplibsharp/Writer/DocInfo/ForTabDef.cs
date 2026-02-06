// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForTabDef.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 탭 정의 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForTabDef
    {
        /// <summary>
        /// 탭 정의 레코드를 쓴다.
        /// </summary>
        /// <param name="td">탭 정의 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(TabDefInfo td, CompoundStreamWriter sw)
        {
            RecordHeader(td, sw);

            sw.WriteUInt4(td.Property.Value);

            long tabInfoCount = td.TabInfoList.Count;
            sw.WriteUInt4(tabInfoCount);

            if (tabInfoCount > 0)
            {
                TabInfos(td, sw);
            }
        }

        /// <summary>
        /// 탭 정의 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="td">탭 정의 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(TabDefInfo td, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.TabDef, GetSize(td));
        }

        /// <summary>
        /// 탭 정의 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="td">탭 정의 레코드</param>
        /// <returns>탭 정의 레코드의 크기</returns>
        private static int GetSize(TabDefInfo td)
        {
            int size = 0;
            size += 8;
            size += 8 * td.TabInfoList.Count;
            return size;
        }

        /// <summary>
        /// 탭 정보 부분을 쓴다.
        /// </summary>
        /// <param name="td">탭 정의 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void TabInfos(TabDefInfo td, CompoundStreamWriter sw)
        {
            foreach (var ti in td.TabInfoList)
            {
                sw.WriteUInt4(ti.Position);
                sw.WriteUInt1((byte)ti.TabSort);
                sw.WriteUInt1((byte)ti.FillSort);
                sw.WriteZero(2);
            }
        }
    }
}

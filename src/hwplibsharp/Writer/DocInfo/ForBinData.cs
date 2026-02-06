// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForBinData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.BinData;
using HwpLib.Object.Etc;
using HwpLib.Util;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 바이너리 데이타 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForBinData
    {
        /// <summary>
        /// 바이너리 데이타 레코드를 쓴다.
        /// </summary>
        /// <param name="bd">바이너리 데이타 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(BinDataInfo bd, CompoundStreamWriter sw)
        {
            RecordHeader(bd, sw);

            sw.WriteUInt2(bd.Property.Value);
            if (bd.Property.Type == BinDataType.Link)
            {
                sw.WriteUTF16LEString(bd.AbsolutePathForLink);
                sw.WriteUTF16LEString(bd.RelativePathForLink);
            }
            if (bd.Property.Type == BinDataType.Embedding || bd.Property.Type == BinDataType.Storage)
            {
                sw.WriteUInt2(bd.BinDataId);
                sw.WriteUTF16LEString(bd.ExtensionForEmbedding);
            }
        }

        /// <summary>
        /// 바이너리 데이타 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="bd">바이너리 데이타 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(BinDataInfo bd, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.BinData, GetSize(bd));
        }

        /// <summary>
        /// 바이너리 데이타 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="bd">바이너리 데이타 레코드</param>
        /// <returns>바이너리 데이타 레코드의 크기</returns>
        private static int GetSize(BinDataInfo bd)
        {
            int size = 0;
            size += 2;
            if (bd.Property.Type == BinDataType.Link)
            {
                size += StringUtil.GetUTF16LEStringSize(bd.AbsolutePathForLink);
                size += StringUtil.GetUTF16LEStringSize(bd.RelativePathForLink);
            }
            if (bd.Property.Type == BinDataType.Embedding || bd.Property.Type == BinDataType.Storage)
            {
                size += 2;
                size += StringUtil.GetUTF16LEStringSize(bd.ExtensionForEmbedding);
            }
            return size;
        }
    }
}

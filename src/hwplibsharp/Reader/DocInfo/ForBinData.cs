// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForBinData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.BinData;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 바이너리 데이터 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForBinData
    {
        /// <summary>
        /// 바이너리 데이터 레코드를 읽는다.
        /// </summary>
        /// <param name="bd">바이너리 데이터 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(BinDataInfo bd, CompoundStreamReader sr)
        {
            bd.Property.Value = sr.ReadUInt2();

            if (bd.Property.Type == BinDataType.Link)
            {
                bd.AbsolutePathForLink = sr.ReadUTF16LEString();
                bd.RelativePathForLink = sr.ReadUTF16LEString();
            }

            if (bd.Property.Type == BinDataType.Embedding ||
                bd.Property.Type == BinDataType.Storage)
            {
                bd.BinDataId = sr.ReadUInt2();
                bd.ExtensionForEmbedding = sr.ReadUTF16LEString();
            }
        }
    }
}

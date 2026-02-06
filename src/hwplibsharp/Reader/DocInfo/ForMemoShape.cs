// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForMemoShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.BorderFill;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 메모 모양 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForMemoShape
    {
        /// <summary>
        /// 메모 모양을 읽는다.
        /// </summary>
        /// <param name="ms">메모 모양 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(MemoShape ms, CompoundStreamReader sr)
        {
            ms.Width = sr.ReadUInt4();
            ms.LineType = BorderTypeExtensions.FromValue(sr.ReadUInt1());
            ms.LineWidth = BorderThicknessExtensions.FromValue(sr.ReadUInt1());
            ms.LineColor.Value = sr.ReadUInt4();
            ms.FillColor.Value = sr.ReadUInt4();
            ms.ActiveColor.Value = sr.ReadUInt4();
            ms.Unknown = sr.ReadUInt4();
        }
    }
}

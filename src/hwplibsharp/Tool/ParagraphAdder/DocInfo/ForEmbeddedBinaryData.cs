// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/ForEmbeddedBinaryData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BinData;
using System;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// EmbeddedBinaryData를 복사하는 기능을 포함하는 클래스
    /// </summary>
    public static class ForEmbeddedBinaryData
    {
        /// <summary>
        /// 소스 HWP 파일의 <see cref="EmbeddedBinaryData"/>를 찾아 타겟 HWP 파일에 복사하고,
        /// 새로 추가된 <see cref="EmbeddedBinaryData"/>의 인덱스를 반환합니다.
        /// </summary>
        /// <param name="sourceId">복사할 소스 <see cref="EmbeddedBinaryData"/>의 ID</param>
        /// <param name="imageFileExt">이미지 파일 확장자(예: "jpg", "png")</param>
        /// <param name="docInfoAdder">소스 및 타겟 HWP 파일 정보를 포함하는 <see cref="DocInfoAdder"/></param>
        /// <returns>추가된 <see cref="EmbeddedBinaryData"/>의 인덱스, 실패 시 -1</returns>
        public static int AddAndCopy(int sourceId, string? imageFileExt, DocInfoAdder docInfoAdder)
        {
            var source = FindByName(docInfoAdder.GetSourceHWPFile()?.BinData?.EmbeddedBinaryDataList, Name(sourceId, imageFileExt));
            if (source != null)
            {
                var target = docInfoAdder.GetTargetHWPFile()?.BinData?.AddNewEmbeddedBinaryData();
                if (target != null)
                {
                    var list = docInfoAdder.GetTargetHWPFile()?.BinData?.EmbeddedBinaryDataList;
                    int targetID = list?.Count ?? 0;
                    target.Name = Name(targetID, imageFileExt);
                    target.Data = source.Data;
                    target.CompressMethod = source.CompressMethod;
                    return list?.Count ?? -1;
                }
            }
            return -1;
        }

        private static EmbeddedBinaryData? FindByName(IReadOnlyList<EmbeddedBinaryData>? embeddedBinaryDataList, string name)
        {
            if (embeddedBinaryDataList == null) return null;

            foreach (var embeddedBinaryData in embeddedBinaryDataList)
            {
                if (string.Equals(embeddedBinaryData.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return embeddedBinaryData;
                }
            }
            return null;
        }

        private static string Name(int binDataID, string? imageFileExt)
        {
            return $"Bin{binDataID:X4}.{imageFileExt}";
        }
    }
}

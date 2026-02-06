// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/BinDataAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 BinData를 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class BinDataAdder
    {
        private readonly DocInfoAdder _docInfoAdder;

        /// <summary>
        /// <see cref="BinDataAdder"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">복사 작업에 사용할 <see cref="DocInfoAdder"/> 인스턴스입니다.</param>
        public BinDataAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
        }

        /// <summary>
        /// sourceID에 해당하는 BinData객체를 처리하여 target 한글 파일의 BinData ID를 반환한다.
        /// </summary>
        /// <param name="sourceId">source BinData ID</param>
        /// <returns>target 한글 파일의 BinData ID</returns>
        public int ProcessById(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            if (sourceId == 0)
            {
                return 0;
            }

            var binDataList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.BinDataList;
            if (binDataList == null || sourceId - 1 >= binDataList.Count || sourceId - 1 < 0)
            {
                return sourceId;
            }

            var source = binDataList[sourceId - 1];
            return AddAndCopy(source);
        }

        private int AddAndCopy(BinDataInfo source)
        {
            int binDataID = ForEmbeddedBinaryData.AddAndCopy(source.BinDataId, source.ExtensionForEmbedding, _docInfoAdder);
            if (binDataID > 0)
            {
                var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.AddNewBinData();
                if (target != null)
                {
                    if (source.Property != null && target.Property != null)
                        target.Property.Value = source.Property.Value;
                    target.AbsolutePathForLink = source.AbsolutePathForLink;
                    target.RelativePathForLink = source.RelativePathForLink;
                    target.BinDataId = binDataID;
                    target.ExtensionForEmbedding = source.ExtensionForEmbedding;

                    return _docInfoAdder.GetTargetHWPFile()?.DocInfo?.BinDataList?.Count ?? -1;
                }
            }
            return -1;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bindata/BinData.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BinData;
using System.Collections.Generic;

namespace HwpLib.Object.BinData
{
    /// <summary>
    /// 바이너리 데이터를 나타내는 객체
    /// HWP파일 내의 "BinData" storage에 저장된다.
    /// </summary>
    public class BinData
    {
        /// <summary>
        /// HWP 파일 속에 첨부된 바이너리 데이터(이미지 등)의 리스트
        /// </summary>
        private readonly List<EmbeddedBinaryData> _embeddedBinaryDataList;

        /// <summary>
        /// 생성자
        /// </summary>
        public BinData()
        {
            _embeddedBinaryDataList = new List<EmbeddedBinaryData>();
        }

        /// <summary>
        /// 새로운 첨부된 바이너리 데이터 객체를 생성하고 list에 추가합니다.
        /// </summary>
        /// <returns>새로 생성된 첨부된 바이너리 데이터 객체</returns>
        public EmbeddedBinaryData AddNewEmbeddedBinaryData()
        {
            var ebd = new EmbeddedBinaryData();
            _embeddedBinaryDataList.Add(ebd);
            return ebd;
        }

        /// <summary>
        /// 첨부된 바이너리 데이터의 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<EmbeddedBinaryData> EmbeddedBinaryDataList => _embeddedBinaryDataList;

        /// <summary>
        /// 새로운 첨부된 바이너리 데이터 객체를 생성하여 list에 추가합니다.
        /// </summary>
        /// <param name="name">새로운 첨부된 바이너리 데이터 객체의 이름</param>
        /// <param name="data">새로운 첨부된 바이너리 데이터 객체의 데이터</param>
        /// <param name="compressMethod">압축 방법</param>
        public void AddNewEmbeddedBinaryData(string name, byte[] data, BinDataCompress compressMethod)
        {
            var ebd = AddNewEmbeddedBinaryData();
            ebd.Name = name;
            ebd.Data = data;
            ebd.CompressMethod = compressMethod;
        }

        /// <summary>
        /// 다른 BinData 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        /// <param name="deepCopyImage">이미지 데이터를 깊은 복사할지 여부</param>
        public void Copy(BinData from, bool deepCopyImage)
        {
            _embeddedBinaryDataList.Clear();
            foreach (var embeddedBinaryData in from._embeddedBinaryDataList)
            {
                _embeddedBinaryDataList.Add(embeddedBinaryData.Clone(deepCopyImage));
            }
        }
    }
}
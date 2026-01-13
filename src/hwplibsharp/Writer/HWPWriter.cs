// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/HWPWriter.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object;
using HwpLib.Object.BinData;
using HwpLib.Object.BodyText;
using HwpLib.Object.DocInfo.BinData;
using HwpLib.Object.FileHeader;
using HwpLib.Writer.BodyText;
using HwpLib.Writer.DocInfo;
using System;
using System.IO;


namespace HwpLib.Writer
{

    /// <summary>
    /// 한글 파일을 쓰기 위한 객체
    /// </summary>
    public class HWPWriter : IDisposable
    {
        /// <summary>
        /// 한글 파일 객체를 파일로 쓴다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="filePath">파일 경로</param>
        public static void ToFile(HWPFile hwpFile, string filePath)
        {
            if (hwpFile.FileHeader.HasPassword)
            {
                throw new Exception("비밀번호가 설정된 파일은 지원하지 않습니다.");
            }

            using var writer = new HWPWriter(hwpFile);
            writer.AutoSet();
            writer.WriteFileHeader();
            writer.WriteDocInfo();
            writer.WriteBodyText();
            writer.WriteBinData();
            writer.WriteSummaryInformation();
            writer.WriteScripts();
            writer.WriteDocOptions();
            writer.WriteAndClose(filePath);
        }

        /// <summary>
        /// 한글 파일 객체를 스트림으로 쓴다.
        /// </summary>
        /// <param name="hwpFile">한글 파일 객체</param>
        /// <param name="outputStream">출력 스트림</param>
        public static void ToStream(HWPFile hwpFile, Stream outputStream)
        {
            if (hwpFile.FileHeader.HasPassword)
            {
                throw new Exception("비밀번호가 설정된 파일은 지원하지 않습니다.");
            }

            using var writer = new HWPWriter(hwpFile);
            writer.AutoSet();
            writer.WriteFileHeader();
            writer.WriteDocInfo();
            writer.WriteBodyText();
            writer.WriteBinData();
            writer.WriteSummaryInformation();
            writer.WriteScripts();
            writer.WriteDocOptions();
            writer.WriteAndClose(outputStream);
        }

        /// <summary>
        /// 한글 파일 객체
        /// </summary>
        private readonly HWPFile _hwpFile;

        /// <summary>
        /// MS Compound 파일을 쓰기 위한 라이터 객체
        /// </summary>
        private readonly CompoundFileWriter _cfw;

        /// <summary>
        /// 리소스 해제 여부
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="hwpFile">한글 파일</param>
        private HWPWriter(HWPFile hwpFile)
        {
            _hwpFile = hwpFile;
            _cfw = new CompoundFileWriter();
        }

        /// <summary>
        /// 파일을 쓰기 전에 자동으로 설정할 수 있는 값들을 설정한다.
        /// </summary>
        private void AutoSet()
        {
            var iid = new AutoSetter.InstanceID();
            AutoSetter.AutoSetter.AutoSet(_hwpFile, iid);
        }

        /// <summary>
        /// FileHeader 스트림을 쓴다.
        /// </summary>
        private void WriteFileHeader()
        {
            var sw = _cfw.OpenCurrentStream("FileHeader", false, GetVersion());
            ForFileHeader.Write(_hwpFile.FileHeader, sw);
            _cfw.CloseCurrentStream();
        }

        /// <summary>
        /// 파일 버전을 반환한다.
        /// </summary>
        /// <returns>파일 버전</returns>
        private FileVersion GetVersion()
        {
            return _hwpFile.FileHeader.Version;
        }

        /// <summary>
        /// DocInfo 스트림을 쓴다.
        /// </summary>
        private void WriteDocInfo()
        {
            var sw = _cfw.OpenCurrentStream("DocInfo", IsCompressed, GetVersion());
            sw.SetDocInfo(_hwpFile.DocInfo);
            ForDocInfo.Write(_hwpFile.DocInfo, sw);
            _cfw.CloseCurrentStream();
        }

        /// <summary>
        /// 압축된 파일인지 여부를 반환한다.
        /// </summary>
        private bool IsCompressed => _hwpFile.FileHeader.Compressed;

        /// <summary>
        /// BodyText 스토리지를 쓴다.
        /// </summary>
        private void WriteBodyText()
        {
            _cfw.OpenCurrentStorage("BodyText");

            int index = 0;
            foreach (var section in _hwpFile.BodyText.SectionList)
            {
                WriteSection(index, section);
                index++;
            }

            _cfw.CloseCurrentStorage();
        }

        /// <summary>
        /// Section 스트림을 쓴다.
        /// </summary>
        /// <param name="index">섹션 인덱스</param>
        /// <param name="section">구역 객체</param>
        private void WriteSection(int index, Section section)
        {
            var sw = _cfw.OpenCurrentStream("Section" + index, IsCompressed, GetVersion());
            sw.SetDocInfo(_hwpFile.DocInfo);

            ForSection.Write(section, sw);

            // 마지막 섹션에 메모 쓰기
            if (IsLastSection(index) && _hwpFile.BodyText.MemoList != null)
            {
                foreach (var memo in _hwpFile.BodyText.MemoList)
                {
                    // TODO: ForMemo.Write(memo, sw);
                }
            }

            _cfw.CloseCurrentStream();
        }

        /// <summary>
        /// 마지막 섹션인지 여부를 반환한다.
        /// </summary>
        /// <param name="index">섹션 인덱스</param>
        /// <returns>마지막 섹션이면 true</returns>
        private bool IsLastSection(int index)
        {
            return index + 1 == _hwpFile.BodyText.SectionList.Count;
        }

        /// <summary>
        /// BinData 스토리지를 쓴다.
        /// </summary>
        private void WriteBinData()
        {
            if (HasBinData())
            {
                _cfw.OpenCurrentStorage("BinData");

                foreach (var ebd in _hwpFile.BinData.EmbeddedBinaryDataList)
                {
                    WriteEmbeddedBinaryData(ebd);
                }

                _cfw.CloseCurrentStorage();
            }
        }

        /// <summary>
        /// 첨부된 바이너리 데이터가 있는지 여부를 반환한다.
        /// </summary>
        /// <returns>첨부된 바이너리 데이터가 있는지 여부</returns>
        private bool HasBinData()
        {
            return _hwpFile.BinData.EmbeddedBinaryDataList.Count > 0;
        }

        /// <summary>
        /// 첨부된 바이너리 데이터를 쓴다.
        /// </summary>
        /// <param name="ebd">첨부된 바이너리 데이터에 대한 정보</param>
        private void WriteEmbeddedBinaryData(EmbeddedBinaryData ebd)
        {
            var sw = _cfw.OpenCurrentStream(
                ebd.Name!,
                IsCompressBinData(ebd.CompressMethod),
                GetVersion());
            sw.WriteBytes(ebd.Data ?? Array.Empty<byte>());
            _cfw.CloseCurrentStream();
        }

        /// <summary>
        /// BinData의 압축 여부를 반환한다.
        /// </summary>
        /// <param name="compressMethod">압축 방법</param>
        /// <returns>BinData의 압축 여부</returns>
        private bool IsCompressBinData(BinDataCompress compressMethod)
        {
            return compressMethod switch
            {
                BinDataCompress.ByStorageDefault => IsCompressed,
                BinDataCompress.Compress => true,
                BinDataCompress.NoCompress => false,
                _ => false
            };
        }

        /// <summary>
        /// SummaryInformation을 쓴다.
        /// </summary>
        private void WriteSummaryInformation()
        {
            // TODO: SummaryInformation 쓰기 구현
            // if (_hwpFile.SummaryInformation != null)
            // {
            //     using var ms = new MemoryStream();
            //     _hwpFile.SummaryInformation.Write(ms);
            //     if (ms.Length > 0)
            //     {
            //         ms.Position = 0;
            //         _cfw.SaveToStream("\u0005HwpSummaryInformation", ms);
            //     }
            // }
        }

        /// <summary>
        /// Scripts 스토리지를 쓴다.
        /// </summary>
        private void WriteScripts()
        {
            _cfw.OpenCurrentStorage("Scripts");

            if (_hwpFile.Scripts?.DefaultJScript != null)
            {
                var sw = _cfw.OpenCurrentStream("DefaultJScript", IsCompressed, GetVersion());
                sw.WriteBytes(_hwpFile.Scripts.DefaultJScript);
                _cfw.CloseCurrentStream();
            }

            if (_hwpFile.Scripts?.JScriptVersion != null)
            {
                var sw = _cfw.OpenCurrentStream("JScriptVersion", IsCompressed, GetVersion());
                sw.WriteBytes(_hwpFile.Scripts.JScriptVersion);
                _cfw.CloseCurrentStream();
            }

            _cfw.CloseCurrentStorage();
        }

        /// <summary>
        /// DocOptions 스토리지를 쓴다.
        /// </summary>
        private void WriteDocOptions()
        {
            _cfw.OpenCurrentStorage("DocOptions");
            _cfw.CloseCurrentStorage();
        }

        /// <summary>
        /// 파일을 쓰고 닫는다.
        /// </summary>
        /// <param name="filePath">파일 경로</param>
        private void WriteAndClose(string filePath)
        {
            _cfw.Write(filePath);
            _cfw.Close();
        }

        /// <summary>
        /// 출력 스트림에 쓰고 닫는다.
        /// </summary>
        /// <param name="outputStream">출력 스트림</param>
        private void WriteAndClose(Stream outputStream)
        {
            _cfw.Write(outputStream);
            _cfw.Close();
        }

        /// <summary>
        /// 리소스를 해제한다.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 리소스를 해제한다.
        /// </summary>
        /// <param name="disposing">관리 리소스 해제 여부</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _cfw.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// 소멸자
        /// </summary>
        ~HWPWriter()
        {
            Dispose(false);
        }
    }

}
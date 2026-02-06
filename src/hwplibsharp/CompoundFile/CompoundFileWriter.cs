// =====================================================================
// Java Original: kr/dogfoot/hwplib/util/compoundFile/writer/CompoundFileWriter.java
// Repository: https://github.com/neolord0/hwplib
// Note: Adapted for OpenMcdf (C# uses OpenMcdf instead of Apache POI)
// =====================================================================

using HwpLib.Object.FileHeader;
using OpenMcdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace HwpLib.CompoundFile
{
    /// <summary>
    /// MS Compound File을 쓰기 위한 객체. OpenMcdf 라이브러리를 사용함
    /// </summary>
    public class CompoundFileWriter : IDisposable
    {
        /// <summary>
        /// 파일 시스템 (OpenMcdf)
        /// </summary>
        private RootStorage? _rootStorage;

        /// <summary>
        /// 현재 스토리지(디렉토리) 경로 스택
        /// </summary>
        private readonly Stack<Storage> _storageStack = new Stack<Storage>();

        /// <summary>
        /// 현재 스트림(파일)을 쓰기 위한 객체
        /// </summary>
        private CompoundStreamWriter? _currentStreamWriter;

        private bool _disposed;

        /// <summary>
        /// 생성자
        /// </summary>
        public CompoundFileWriter()
        {
            _rootStorage = RootStorage.CreateInMemory();
            _storageStack.Push(_rootStorage);
        }

        /// <summary>
        /// 현재 스토리지
        /// </summary>
        private Storage CurrentStorage => _storageStack.Peek();

        /// <summary>
        /// 파일 시스템에 저장하고 있는 내용을 파일로 저장한다.
        /// </summary>
        /// <param name="filePath">파일 경로</param>
        public void Write(string filePath)
        {
            if (_rootStorage == null)
                throw new InvalidOperationException("RootStorage is null.");

            using var fs = File.Create(filePath);
            Write(fs);
        }

        /// <summary>
        /// 파일 시스템에 저장하고 있는 내용을 스트림으로 저장한다.
        /// </summary>
        /// <param name="outputStream">출력 스트림</param>
        public void Write(Stream outputStream)
        {
            if (_rootStorage == null)
                throw new InvalidOperationException("RootStorage is null.");

            // SwitchTo를 사용하여 compound file 구조를 올바르게 완료하고 출력 스트림에 저장
            // SwitchTo는 내부적으로 현재 스토리지를 dispose하므로 이후 다시 dispose되지 않도록 null 처리
            _rootStorage.SwitchTo(outputStream);
            _rootStorage = null;
        }

        /// <summary>
        /// 파일 시스템을 닫는다.
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// 스토리지(디렉토리)를 생성한다.
        /// </summary>
        /// <param name="name">스토리지(디렉토리) 이름</param>
        public void OpenCurrentStorage(string name)
        {
            var newStorage = CurrentStorage.CreateStorage(name);
            _storageStack.Push(newStorage);
        }

        /// <summary>
        /// 현재 스토리지(디렉토리)를 닫는다.
        /// </summary>
        public void CloseCurrentStorage()
        {
            if (_storageStack.Count > 1)
            {
                _storageStack.Pop();
            }
        }

        /// <summary>
        /// 열려있는 스토리지(디렉토리)에 스트림(파일)을 생성하고 스트림을 쓰기 위한 객체를 반환한다.
        /// </summary>
        /// <param name="name">스트림(파일) 이름</param>
        /// <param name="compress">압축 여부</param>
        /// <param name="fileVersion">한글 파일의 버전</param>
        /// <returns>스트림을 쓰기 위한 객체</returns>
        public CompoundStreamWriter OpenCurrentStream(string name, bool compress, FileVersion fileVersion)
        {
            _currentStreamWriter = new CompoundStreamWriter(name, compress, fileVersion);
            return _currentStreamWriter;
        }

        /// <summary>
        /// 스트림 데이터를 직접 저장한다.
        /// </summary>
        /// <param name="name">스트림 이름</param>
        /// <param name="inputStream">입력 스트림</param>
        public void SaveToStream(string name, Stream inputStream)
        {
            using var cfbStream = CurrentStorage.CreateStream(name);
            inputStream.CopyTo(cfbStream);
        }

        /// <summary>
        /// 스트림 데이터를 직접 저장한다.
        /// </summary>
        /// <param name="name">스트림 이름</param>
        /// <param name="data">바이트 배열</param>
        public void SaveToStream(string name, byte[] data)
        {
            using var cfbStream = CurrentStorage.CreateStream(name);
            cfbStream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// 현재 스트림(파일)을 닫는다.
        /// </summary>
        public void CloseCurrentStream()
        {
            if (_currentStreamWriter == null)
                return;

            byte[] data = _currentStreamWriter.GetDataBytes();
            using var cfbStream = CurrentStorage.CreateStream(_currentStreamWriter.Name);
            cfbStream.Write(data, 0, data.Length);

            _currentStreamWriter.Close();
            _currentStreamWriter = null;
        }

        /// <summary>
        /// root 스토리지(디렉토리)로 이동한다.
        /// </summary>
        public void GotoRootStorage()
        {
            _storageStack.Clear();
            if (_rootStorage != null)
            {
                _storageStack.Push(_rootStorage);
            }
        }

        /// <summary>
        /// 리소스를 해제합니다.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 리소스를 해제합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 해제할지 여부</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _currentStreamWriter?.Close();
                    _currentStreamWriter = null;
                    _rootStorage?.Dispose();
                    _rootStorage = null;
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// 소멸자. 관리되지 않는 리소스를 정리합니다.
        /// </summary>
        ~CompoundFileWriter()
        {
            Dispose(false);
        }
    }
}
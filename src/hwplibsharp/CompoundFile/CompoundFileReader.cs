// =====================================================================
// Java Original: kr/dogfoot/hwplib/util/compoundFile/reader/CompoundFileReader.java
// Repository: https://github.com/neolord0/hwplib
// Note: Adapted for OpenMcdf (C# uses OpenMcdf instead of Apache POI)
// =====================================================================

using HwpLib.Object.FileHeader;
using System;
using System.Collections.Generic;
using System.IO;

namespace HwpLib.CompoundFile
{
    /// <summary>
    /// MS Compound File을 읽기 위한 객체. OpenMcdf 라이브러리를 사용함
    /// POI의 CompoundFileReader에 대응
    /// </summary>
    public class CompoundFileReader : IDisposable
    {
        /// <summary>
        /// 파일 시스템 (OpenMcdf)
        /// </summary>
        private CompoundFileSystem? _fs;

        /// <summary>
        /// 현재 스토리지(디렉토리) 경로 스택
        /// </summary>
        private readonly Stack<StorageWrapper> _storageStack = new Stack<StorageWrapper>();

        /// <summary>
        /// 리소스가 해제되었는지 여부
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// 생성자. MS Compound 파일을 열고, 현재 스토리지를 파일의 root 스토리지로 설정한다.
        /// </summary>
        /// <param name="filePath">읽을 파일 경로</param>
        public CompoundFileReader(string filePath)
        {
            _fs = new CompoundFileSystem(filePath);
            _storageStack.Push(_fs.Root);
        }

        /// <summary>
        /// 생성자. MS Compound 파일을 열고, 현재 스토리지를 파일의 root 스토리지로 설정한다.
        /// </summary>
        /// <param name="stream">Input Stream 객체</param>
        public CompoundFileReader(Stream stream)
        {
            _fs = new CompoundFileSystem(stream);
            _storageStack.Push(_fs.Root);
        }

        /// <summary>
        /// 생성자. MS Compound 파일을 열고, 현재 스토리지를 파일의 root 스토리지로 설정한다.
        /// </summary>
        /// <param name="data">바이트 배열</param>
        public CompoundFileReader(byte[] data)
        {
            _fs = new CompoundFileSystem(data);
            _storageStack.Push(_fs.Root);
        }

        /// <summary>
        /// 현재 스토리지
        /// </summary>
        private StorageWrapper CurrentStorage => _storageStack.Peek();

        /// <summary>
        /// 현재 스토리지(디렉토리)에 포함된 항목(스토리지와 스트림)들의 이름을 반환한다.
        /// </summary>
        /// <returns>현재 스토리지(디렉토리)에 포함된 항목들의 이름 집합</returns>
        public ISet<string> ListChildNames()
        {
            return CurrentStorage.GetEntryNames();
        }

        /// <summary>
        /// 현재 스토리지(디렉토리)에 이름이 name인 스토리지(디렉토리)가 있는지 여부를 반환한다.
        /// </summary>
        /// <param name="name">찾는 스토리지 이름</param>
        /// <returns>스토리지 존재 여부</returns>
        public bool IsChildStorage(string name)
        {
            if (!CurrentStorage.HasEntry(name))
                return false;

            return CurrentStorage.IsStorage(name);
        }

        /// <summary>
        /// 현재 스토리지(디렉토리)에 이름이 name인 스트림(파일)이 있는지 여부를 반환한다.
        /// </summary>
        /// <param name="name">찾는 스트림 이름</param>
        /// <returns>스트림 존재 여부</returns>
        public bool IsChildStream(string name)
        {
            if (!CurrentStorage.HasEntry(name))
                return false;

            return CurrentStorage.IsStream(name);
        }

        /// <summary>
        /// 이름이 name인 스토리지(디렉토리)로 이동한다.
        /// </summary>
        /// <param name="name">이동할 스토리지 이름</param>
        public void MoveChildStorage(string name)
        {
            if (CurrentStorage.IsStorage(name))
            {
                var subStorage = (StorageWrapper)CurrentStorage.GetStorage(name);
                _storageStack.Push(subStorage);
            }
            else
            {
                throw new InvalidOperationException("this is not storage.");
            }
        }

        /// <summary>
        /// 부모 스토리지(디렉토리)로 이동한다.
        /// </summary>
        public void MoveParentStorage()
        {
            if (_storageStack.Count > 1)
            {
                _storageStack.Pop();
            }
        }

        /// <summary>
        /// 이름이 name인 스트림을 읽을 수 있는 스트림 리더 객체를 반환한다.
        /// </summary>
        /// <param name="name">찾는 스트림 이름</param>
        /// <param name="compress">압축 여부</param>
        /// <param name="fileVersion">파일 버전 (null이면 기본 버전 사용)</param>
        /// <returns>스트림 리더 객체</returns>
        public CompoundStreamReader GetChildStreamReader(string name, bool compress, FileVersion? fileVersion)
        {
            if (CurrentStorage.IsStream(name))
            {
                var stream = (StreamWrapper)CurrentStorage.GetStream(name);
                return CompoundStreamReader.Create(stream, compress, false, fileVersion ?? new FileVersion());
            }
            throw new InvalidOperationException("this is not stream.");
        }

        /// <summary>
        /// 배포용 문서의 스트림 리더를 반환한다.
        /// </summary>
        /// <param name="name">찾는 스트림 이름</param>
        /// <param name="compress">압축 여부</param>
        /// <param name="fileVersion">파일 버전 (null이면 기본 버전 사용)</param>
        /// <returns>스트림 리더 객체</returns>
        public CompoundStreamReader GetChildStreamReaderForDistribution(string name, bool compress, FileVersion? fileVersion)
        {
            if (CurrentStorage.IsStream(name))
            {
                var stream = (StreamWrapper)CurrentStorage.GetStream(name);
                return CompoundStreamReader.Create(stream, compress, true, fileVersion ?? new FileVersion());
            }
            throw new InvalidOperationException($"{name} is not stream.");
        }

        /// <summary>
        /// 이름이 name인 스트림의 InputStream을 반환한다.
        /// </summary>
        /// <param name="name">스트림 이름</param>
        /// <returns>MemoryStream</returns>
        public MemoryStream? GetChildInputStream(string name)
        {
            if (CurrentStorage.IsStream(name))
            {
                var stream = (StreamWrapper)CurrentStorage.GetStream(name);
                return new MemoryStream(stream.GetData());
            }
            return null;
        }

        /// <summary>
        /// 현재 스토리지 디렉토리
        /// </summary>
        public IDirectoryEntry CurrentDirectory => CurrentStorage;

        /// <summary>
        /// 현재 열려진 MS Compound 파일을 닫고, 리소스를 해제합니다.
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
                    _fs?.Dispose();
                    _fs = null;
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// 소멸자. 관리되지 않는 리소스를 정리합니다.
        /// </summary>
        ~CompoundFileReader()
        {
            Dispose(false);
        }
    }
}
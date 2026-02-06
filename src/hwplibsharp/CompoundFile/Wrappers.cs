// =====================================================================
// C# Specific Implementation (no direct Java equivalent)
// Provides OpenMcdf wrappers (Java uses Apache POI)
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using OpenMcdf;
using System.Collections.Generic;
using System.IO;

namespace HwpLib.CompoundFile
{
    /// <summary>
    /// OpenMcdf 3.x의 Storage를 IDirectoryEntry로 래핑하는 클래스
    /// POI의 DirectoryNode에 대응
    /// </summary>
    public class StorageWrapper : IDirectoryEntry
    {
        private readonly Storage _storage;

        /// <summary>
        /// StorageWrapper를 생성합니다.
        /// </summary>
        /// <param name="storage">래핑할 Storage 객체</param>
        public StorageWrapper(Storage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// 스토리지 이름
        /// </summary>
        public string Name => _storage.EntryInfo.Name;

        /// <summary>
        /// 지정된 이름의 항목이 있는지 확인
        /// </summary>
        public bool HasEntry(string name)
        {
            foreach (var entry in _storage.EnumerateEntries())
            {
                if (entry.Name == name)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 지정된 이름의 항목이 스토리지인지 확인
        /// </summary>
        public bool IsStorage(string name)
        {
            foreach (var entry in _storage.EnumerateEntries())
            {
                if (entry.Name == name)
                    return entry.Type == EntryType.Storage;
            }
            return false;
        }

        /// <summary>
        /// 지정된 이름의 항목이 스트림인지 확인
        /// </summary>
        public bool IsStream(string name)
        {
            foreach (var entry in _storage.EnumerateEntries())
            {
                if (entry.Name == name)
                    return entry.Type == EntryType.Stream;
            }
            return false;
        }

        /// <summary>
        /// 지정된 이름의 스토리지를 반환한다.
        /// </summary>
        public IDirectoryEntry GetStorage(string name)
        {
            var subStorage = _storage.OpenStorage(name);
            return new StorageWrapper(subStorage);
        }

        /// <summary>
        /// 지정된 이름의 스트림을 반환한다.
        /// </summary>
        public IStreamEntry GetStream(string name)
        {
            var stream = _storage.OpenStream(name);
            return new StreamWrapper(stream);
        }

        /// <summary>
        /// 하위 항목들의 이름 집합을 반환한다.
        /// </summary>
        public ISet<string> GetEntryNames()
        {
            var names = new HashSet<string>();
            foreach (var entry in _storage.EnumerateEntries())
            {
                names.Add(entry.Name);
            }
            return names;
        }

        /// <summary>
        /// 내부 Storage 반환 (내부용)
        /// </summary>
        internal Storage InternalStorage => _storage;
    }

    /// <summary>
    /// OpenMcdf 3.x의 CfbStream을 IStreamEntry로 래핑하는 클래스
    /// POI의 DocumentNode에 대응
    /// </summary>
    public class StreamWrapper : IStreamEntry
    {
        private readonly CfbStream _stream;

        /// <summary>
        /// StreamWrapper를 생성합니다.
        /// </summary>
        /// <param name="stream">래핑할 CfbStream 객체</param>
        public StreamWrapper(CfbStream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// 스트림 이름
        /// </summary>
        public string Name => _stream.EntryInfo.Name;

        /// <summary>
        /// 스트림의 크기 (바이트)
        /// </summary>
        public long Size => _stream.Length;

        /// <summary>
        /// 스트림 데이터를 읽어서 반환한다.
        /// </summary>
        public byte[] GetData()
        {
            _stream.Position = 0;
            var data = new byte[_stream.Length];
            int offset = 0;
            while (offset < data.Length)
            {
                int read = _stream.Read(data, offset, data.Length - offset);
                if (read == 0)
                    throw new EndOfStreamException();
                offset += read;
            }
            return data;
        }

        /// <summary>
        /// 내부 CfbStream 반환 (내부용)
        /// </summary>
        internal CfbStream InternalStream => _stream;
    }
}
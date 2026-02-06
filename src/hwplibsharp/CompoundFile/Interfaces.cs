// =====================================================================
// C# Specific Implementation (no direct Java equivalent)
// Provides OpenMcdf abstractions (Java uses Apache POI)
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.CompoundFile
{
    /// <summary>
    /// 디렉토리(스토리지) 엔트리를 나타내는 인터페이스
    /// POI의 DirectoryEntry에 대응
    /// </summary>
    public interface IDirectoryEntry
    {
        /// <summary>
        /// Entry의 이름
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 지정된 이름의 항목이 있는지 확인
        /// </summary>
        /// <param name="name">항목 이름</param>
        /// <returns>존재 여부</returns>
        bool HasEntry(string name);

        /// <summary>
        /// 지정된 이름의 항목이 스토리지인지 확인
        /// </summary>
        /// <param name="name">항목 이름</param>
        /// <returns>스토리지 여부</returns>
        bool IsStorage(string name);

        /// <summary>
        /// 지정된 이름의 항목이 스트림인지 확인
        /// </summary>
        /// <param name="name">항목 이름</param>
        /// <returns>스트림 여부</returns>
        bool IsStream(string name);

        /// <summary>
        /// 지정된 이름의 스토리지를 반환한다.
        /// </summary>
        /// <param name="name">스토리지 이름</param>
        /// <returns>스토리지</returns>
        IDirectoryEntry GetStorage(string name);

        /// <summary>
        /// 지정된 이름의 스트림을 반환한다.
        /// </summary>
        /// <param name="name">스트림 이름</param>
        /// <returns>스트림</returns>
        IStreamEntry GetStream(string name);

        /// <summary>
        /// 하위 항목들의 이름 집합을 반환한다.
        /// </summary>
        ISet<string> GetEntryNames();
    }

    /// <summary>
    /// 스트림 엔트리를 나타내는 인터페이스
    /// POI의 DocumentEntry에 대응
    /// </summary>
    public interface IStreamEntry
    {
        /// <summary>
        /// Entry의 이름
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 스트림의 크기 (바이트)
        /// </summary>
        long Size { get; }

        /// <summary>
        /// 스트림 데이터를 읽어서 반환한다.
        /// </summary>
        /// <returns>스트림 데이터</returns>
        byte[] GetData();
    }
}
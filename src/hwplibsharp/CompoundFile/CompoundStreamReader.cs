// =====================================================================
// Java Original: kr/dogfoot/hwplib/util/compoundFile/reader/StreamReader.java
// Repository: https://github.com/neolord0/hwplib
// Note: Adapted for OpenMcdf (C# uses OpenMcdf instead of Apache POI)
// =====================================================================

using HwpLib.Binary;
using HwpLib.Object.FileHeader;
using HwpLib.Util.Binary;
using System;
using System.IO;
using System.Text;

namespace HwpLib.CompoundFile
{
    /// <summary>
    /// 레코드 헤더를 나타내는 클래스
    /// </summary>
    public sealed class RecordHeader
    {
        /// <summary>
        /// 태그 ID
        /// </summary>
        public ushort TagId { get; }

        /// <summary>
        /// 레벨
        /// </summary>
        public ushort Level { get; }

        /// <summary>
        /// 데이터 크기
        /// </summary>
        public uint Size { get; }

        /// <summary>
        /// 레코드 헤더를 생성합니다.
        /// </summary>
        /// <param name="tagId">태그 ID</param>
        /// <param name="level">레벨</param>
        /// <param name="size">데이터 크기</param>
        public RecordHeader(ushort tagId, ushort level, uint size)
        {
            TagId = tagId;
            Level = level;
            Size = size;
        }
    }

    /// <summary>
    /// 스트림을 읽기 위한 객체
    /// </summary>
    public class CompoundStreamReader : IDisposable
    {
        /// <summary>
        /// 입력 스트림
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// 읽은 바이트 수
        /// </summary>
        private long _readBytes;

        /// <summary>
        /// 파일 버전
        /// </summary>
        private readonly FileVersion _fileVersion;

        /// <summary>
        /// 현재 레코드 헤더
        /// </summary>
        private RecordHeader? _header;

        /// <summary>
        /// 현재 레코드 헤더를 읽은 직후 위치 (헤더 바로 다음 위치)
        /// </summary>
        private long _currentPositionAfterHeader;

        /// <summary>
        /// 레코드 헤더를 읽은 직후인지 여부
        /// </summary>
        private bool _immediatelyAfterReadingHeader;

        private bool _disposed;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="stream">읽을 스트림</param>
        /// <param name="fileVersion">파일 버전</param>
        private CompoundStreamReader(Stream stream, FileVersion fileVersion)
        {
            _stream = stream;
            _fileVersion = fileVersion;
            _readBytes = 0;
            _immediatelyAfterReadingHeader = false;
        }

        /// <summary>
        /// 스트림 리더를 생성한다.
        /// </summary>
        /// <param name="streamEntry">StreamWrapper 객체</param>
        /// <param name="compress">압축 여부</param>
        /// <param name="distribution">배포용 문서 여부</param>
        /// <param name="fileVersion">파일 버전</param>
        /// <returns>스트림 리더 객체</returns>
        public static CompoundStreamReader Create(StreamWrapper streamEntry, bool compress, bool distribution, FileVersion fileVersion)
        {
            if (distribution)
            {
                return CreateForDistribution(streamEntry, compress, fileVersion);
            }

            MemoryStream stream;

            if (compress)
            {
                // 압축 해제
                var data = streamEntry.GetData();
                var decompressed = Compressor.DecompressedBytes(data);
                stream = new MemoryStream(decompressed);
            }
            else
            {
                stream = new MemoryStream(streamEntry.GetData());
            }

            return new CompoundStreamReader(stream, fileVersion);
        }

        /// <summary>
        /// 배포용 문서를 위한 스트림 리더를 생성한다.
        /// </summary>
        /// <param name="streamEntry">StreamWrapper 객체</param>
        /// <param name="compress">압축 여부</param>
        /// <param name="fileVersion">파일 버전</param>
        /// <returns>스트림 리더 객체</returns>
        private static CompoundStreamReader CreateForDistribution(StreamWrapper streamEntry, bool compress, FileVersion fileVersion)
        {
            var inputStream = new MemoryStream(streamEntry.GetData());
            var decryptedStream = Obfuscation.DecryptStream(inputStream);

            MemoryStream stream;

            if (compress)
            {
                // 압축 해제
                var decompressed = Compressor.DecompressedBytes(decryptedStream.ToArray());
                stream = new MemoryStream(decompressed);
            }
            else
            {
                stream = decryptedStream;
            }

            return new CompoundStreamReader(stream, fileVersion);
        }

        /// <summary>
        /// 읽은 바이트 수를 증가시킨다.
        /// </summary>
        /// <param name="readBytes">읽은 바이트 수</param>
        private void ForwardPosition(int readBytes)
        {
            _readBytes += readBytes;
            _immediatelyAfterReadingHeader = false;
        }

        /// <summary>
        /// 1바이트 signed 정수를 읽는다.
        /// </summary>
        /// <returns>signed 정수</returns>
        public sbyte ReadSInt1()
        {
            ForwardPosition(1);
            return (sbyte)_stream.ReadByte();
        }

        /// <summary>
        /// 1바이트 unsigned 정수를 읽는다.
        /// </summary>
        /// <returns>unsigned 정수</returns>
        public byte ReadUInt1()
        {
            ForwardPosition(1);
            return (byte)_stream.ReadByte();
        }

        /// <summary>
        /// 스트림에서 정확히 지정된 바이트 수만큼 읽는다.
        /// </summary>
        /// <param name="stream">읽을 스트림</param>
        /// <param name="buffer">읽은 데이터를 저장할 버퍼</param>
        private static void ReadExactly(Stream stream, byte[] buffer)
        {
            int offset = 0;
            while (offset < buffer.Length)
            {
                int read = stream.Read(buffer, offset, buffer.Length - offset);
                if (read == 0)
                    throw new EndOfStreamException();
                offset += read;
            }
        }

        /// <summary>
        /// 2바이트 signed 정수를 읽는다. (Little Endian)
        /// </summary>
        /// <returns>signed 정수</returns>
        public short ReadSInt2()
        {
            ForwardPosition(2);
            byte[] buffer = new byte[2];
            ReadExactly(_stream, buffer);
            return (short)(buffer[0] | (buffer[1] << 8));
        }

        /// <summary>
        /// 2바이트 unsigned 정수를 읽는다. (Little Endian)
        /// </summary>
        /// <returns>unsigned 정수</returns>
        public ushort ReadUInt2()
        {
            ForwardPosition(2);
            byte[] buffer = new byte[2];
            ReadExactly(_stream, buffer);
            return (ushort)(buffer[0] | (buffer[1] << 8));
        }

        /// <summary>
        /// 4바이트 signed 정수를 읽는다. (Little Endian)
        /// </summary>
        /// <returns>signed 정수</returns>
        public int ReadSInt4()
        {
            ForwardPosition(4);
            byte[] buffer = new byte[4];
            ReadExactly(_stream, buffer);
            return buffer[0] | (buffer[1] << 8) | (buffer[2] << 16) | (buffer[3] << 24);
        }

        /// <summary>
        /// 4바이트 unsigned 정수를 읽는다. (Little Endian)
        /// </summary>
        /// <returns>unsigned 정수</returns>
        public uint ReadUInt4()
        {
            ForwardPosition(4);
            byte[] buffer = new byte[4];
            ReadExactly(_stream, buffer);
            return (uint)(buffer[0] | (buffer[1] << 8) | (buffer[2] << 16) | (buffer[3] << 24));
        }

        /// <summary>
        /// 8바이트 signed 정수를 읽는다. (Little Endian)
        /// </summary>
        /// <returns>signed 정수</returns>
        public long ReadSInt8()
        {
            ForwardPosition(8);
            byte[] buffer = new byte[8];
            ReadExactly(_stream, buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 8바이트 unsigned 정수를 읽는다. (Little Endian)
        /// </summary>
        /// <returns>unsigned 정수</returns>
        public ulong ReadUInt8()
        {
            ForwardPosition(8);
            byte[] buffer = new byte[8];
            ReadExactly(_stream, buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Double을 읽는다.
        /// </summary>
        /// <returns>double 값</returns>
        public double ReadDouble()
        {
            ForwardPosition(8);
            byte[] buffer = new byte[8];
            ReadExactly(_stream, buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        /// <summary>
        /// Float을 읽는다.
        /// </summary>
        /// <returns>float 값</returns>
        public float ReadFloat()
        {
            ForwardPosition(4);
            byte[] buffer = new byte[4];
            ReadExactly(_stream, buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        /// <summary>
        /// n 바이트 만큼 건너뛴다.
        /// </summary>
        /// <param name="n">건너뛸 바이트 수</param>
        public void Skip(int n)
        {
            ForwardPosition(n);
            _stream.Seek(n, SeekOrigin.Current);
        }

        /// <summary>
        /// 바이트 배열을 읽는다.
        /// </summary>
        /// <param name="size">읽을 바이트 수</param>
        /// <returns>바이트 배열</returns>
        public byte[] ReadBytes(int size)
        {
            ForwardPosition(size);
            var buffer = new byte[size];
            ReadExactly(_stream, buffer);
            return buffer;
        }

        /// <summary>
        /// 레코드 헤더를 읽는다.
        /// </summary>
        /// <returns>성공 여부</returns>
        public bool ReadRecordHeader()
        {
            if (IsEndOfStream())
            {
                return false;
            }

            // 레코드 헤더는 4바이트
            uint value = ReadUInt4();

            // tagID: 0-9 bits (10 bits)
            // level: 10-19 bits (10 bits)
            // size: 20-31 bits (12 bits)
            ushort tagId = (ushort)BitFlag.Get(value, 0, 9);
            ushort level = (ushort)BitFlag.Get(value, 10, 19);
            uint size = BitFlag.Get(value, 20, 31);

            // size가 0xFFF(4095)면, 추가 4바이트를 읽어서 실제 크기를 얻는다.
            if (size == 0xFFF)
            {
                size = ReadUInt4();
            }

            _header = new RecordHeader(tagId, level, size);
            _currentPositionAfterHeader = _readBytes;
            _immediatelyAfterReadingHeader = true;
            return true;
        }

        /// <summary>
        /// 현재 위치를 반환한다.
        /// </summary>
        public long CurrentPosition => _readBytes;

        /// <summary>
        /// 스트림 전체 크기를 반환한다.
        /// </summary>
        public long Size => _stream.Length;

        /// <summary>
        /// 스트림의 끝인지 여부
        /// </summary>
        /// <returns>스트림의 끝이면 true</returns>
        public bool IsEndOfStream()
        {
            return _stream.Position >= _stream.Length;
        }

        /// <summary>
        /// 현재 레코드 헤더
        /// </summary>
        public RecordHeader? CurrentRecordHeader => _header;

        /// <summary>
        /// 현재 헤더 이후 위치
        /// </summary>
        public long CurrentPositionAfterHeader => _currentPositionAfterHeader;

        /// <summary>
        /// 레코드 헤더를 읽은 직후인지 여부
        /// </summary>
        public bool IsImmediatelyAfterReadingHeader => _immediatelyAfterReadingHeader;

        /// <summary>
        /// 레코드의 끝인지 여부
        /// </summary>
        /// <returns>레코드의 끝이면 true</returns>
        public bool IsEndOfRecord()
        {
            if (_header == null)
                return true;

            return _readBytes >= _currentPositionAfterHeader + _header.Size;
        }

        /// <summary>
        /// 레코드 끝까지 건너뛴다.
        /// </summary>
        public void SkipToEndRecord()
        {
            if (_header == null)
                return;

            long remaining = (_currentPositionAfterHeader + _header.Size) - _readBytes;
            if (remaining > 0)
            {
                Skip((int)remaining);
            }
        }

        /// <summary>
        /// 파일 버전
        /// </summary>
        public FileVersion FileVersion => _fileVersion;

        /// <summary>
        /// UTF-16LE 문자열을 읽는다. (2바이트 길이 + UTF-16LE 문자열)
        /// </summary>
        /// <returns>문자열</returns>
        public string ReadUTF16LEString()
        {
            int len = ReadUInt2();
            if (len > 0)
            {
                byte[] bytes = ReadBytes(len * 2);
                return Encoding.Unicode.GetString(bytes);
            }
            return string.Empty;
        }

        /// <summary>
        /// HWP 문자열을 바이트 배열로 읽는다. (2바이트 길이 + UTF-16LE 문자열)
        /// </summary>
        /// <returns>바이트 배열 (null이면 빈 배열)</returns>
        public byte[] ReadHWPString()
        {
            int len = ReadUInt2();
            if (len > 0)
            {
                return ReadBytes(len * 2);
            }
            return Array.Empty<byte>();
        }

        /// <summary>
        /// 유니코드 문자 하나를 읽는다. (2바이트)
        /// </summary>
        /// <returns>바이트 배열 (2바이트)</returns>
        public byte[] ReadWChar()
        {
            return ReadBytes(2);
        }

        /// <summary>
        /// 한글 97 형식의 문자열을 읽는다.
        /// </summary>
        /// <returns>문자열</returns>
        public string ReadHWP97LEString()
        {
            int len = ReadUInt2();
            if (len > 0)
            {
                byte[] bytes = ReadBytes(len);
                return Encoding.GetEncoding("EUC-KR").GetString(bytes);
            }
            return string.Empty;
        }

        /// <summary>
        /// 파일 버전 5.0.2.4 이전 버전에서 ParaShape ID를 수정한다.
        /// </summary>
        /// <param name="id">원래 ID</param>
        /// <returns>수정된 ID</returns>
        public int CorrectParaShapeId(int id)
        {
            if (_fileVersion.IsOver(5, 0, 2, 4))
            {
                return id;
            }
            return id - 1;
        }

        /// <summary>
        /// 남은 레코드 바이트 수
        /// </summary>
        public long RemainingBytes
        {
            get
            {
                if (_header == null)
                    return 0;
                return (_currentPositionAfterHeader + _header.Size) - _readBytes;
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
                    _stream.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// 소멸자. 관리되지 않는 리소스를 정리합니다.
        /// </summary>
        ~CompoundStreamReader()
        {
            Dispose(false);
        }
    }
}
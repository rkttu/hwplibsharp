// =====================================================================
// Java Original: kr/dogfoot/hwplib/util/compoundFile/writer/StreamWriter.java
// Repository: https://github.com/neolord0/hwplib
// Note: Adapted for OpenMcdf (C# uses OpenMcdf instead of Apache POI)
// =====================================================================

using HwpLib.Binary;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;
using HwpLib.Util.Binary;
using System;
using System.IO;
using System.Text;

namespace HwpLib.CompoundFile
{
    /// <summary>
    /// MS Compound 파일의 스트림에 내용을 저장하기 위한 객체
    /// </summary>
    public class CompoundStreamWriter
    {
        /// <summary>
        /// 스트림(파일) 이름
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// 압축 여부
        /// </summary>
        private readonly bool _compress;

        /// <summary>
        /// 한글 파일 버전
        /// </summary>
        private readonly FileVersion _version;

        /// <summary>
        /// 임시로 쓰여진 저장될 MemoryStream 객체
        /// </summary>
        private readonly MemoryStream _os;

        /// <summary>
        /// 현재 레코드 레벨
        /// </summary>
        private int _currentRecordLevel;

        /// <summary>
        /// DocInfo 참조
        /// </summary>
        private DocInfo? _docInfo;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="name">스트림(파일) 이름</param>
        /// <param name="compress">압축 여부</param>
        /// <param name="version">한글 파일 버전</param>
        public CompoundStreamWriter(string name, bool compress, FileVersion version)
        {
            _name = name;
            _compress = compress;
            _version = version;

            _os = new MemoryStream();
            _currentRecordLevel = 0;

            _docInfo = null;
        }

        /// <summary>
        /// 스트림(파일)을 닫는다.
        /// </summary>
        public void Close()
        {
            _os.Close();
        }

        /// <summary>
        /// 스트림(파일) 이름을 반환한다.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// 한글 파일 버전을 반환한다.
        /// </summary>
        public FileVersion FileVersion => _version;

        /// <summary>
        /// 스트림(파일)에 저장된 데이터를 바이트 배열로 반환한다.
        /// </summary>
        /// <returns>스트림(파일)에 저장된 데이터</returns>
        public byte[] GetDataBytes()
        {
            byte[] bytes;

            if (!_compress)
            {
                bytes = _os.ToArray();
            }
            else
            {
                bytes = Compressor.Compress(_os.ToArray());
            }

            return bytes;
        }

        /// <summary>
        /// 스트림(파일)에 저장된 데이터를 읽을 수 있는 MemoryStream을 반환한다.
        /// </summary>
        /// <returns>스트림(파일)에 저장된 데이터를 읽을 수 있는 MemoryStream</returns>
        public MemoryStream GetDataStream()
        {
            return new MemoryStream(GetDataBytes());
        }

        /// <summary>
        /// byte 배열을 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">byte 배열</param>
        public void WriteBytes(byte[] value)
        {
            _os.Write(value, 0, value.Length);
        }

        /// <summary>
        /// byte 배열을 count에 맞춰 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">byte 배열</param>
        /// <param name="count">출력할 개수</param>
        public void WriteBytes(byte[] value, int count)
        {
            if (value.Length == count)
            {
                _os.Write(value, 0, value.Length);
            }
            else if (value.Length > count)
            {
                _os.Write(value, 0, count);
            }
            else // value.Length < count
            {
                _os.Write(value, 0, value.Length);
                WriteZero(count - value.Length);
            }
        }

        /// <summary>
        /// 부호있는 1 byte 정수를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">부호있는 1 byte 정수값</param>
        public void WriteSInt1(sbyte value)
        {
            _os.WriteByte((byte)value);
        }

        /// <summary>
        /// 부호있는 2 byte 정수를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">부호있는 2 byte 정수값</param>
        public void WriteSInt2(short value)
        {
            byte[] buffer = new byte[2];
            buffer[0] = (byte)(value & 0xFF);
            buffer[1] = (byte)((value >> 8) & 0xFF);
            _os.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 부호있는 4 byte 정수를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">부호있는 4 byte 정수값</param>
        public void WriteSInt4(int value)
        {
            byte[] buffer = new byte[4];
            buffer[0] = (byte)(value & 0xFF);
            buffer[1] = (byte)((value >> 8) & 0xFF);
            buffer[2] = (byte)((value >> 16) & 0xFF);
            buffer[3] = (byte)((value >> 24) & 0xFF);
            _os.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 부호없는 1 byte 정수를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">부호없는 1 byte 정수값</param>
        public void WriteUInt1(byte value)
        {
            _os.WriteByte(value);
        }

        /// <summary>
        /// 부호없는 1 byte 정수를 스트림(파일)에 저장한다. (short로 받음)
        /// </summary>
        /// <param name="value">부호없는 1 byte 정수값 (short)</param>
        public void WriteUInt1(short value)
        {
            _os.WriteByte((byte)(value & 0xFF));
        }

        /// <summary>
        /// 부호없는 2 byte 정수를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">부호없는 2 byte 정수값</param>
        public void WriteUInt2(ushort value)
        {
            byte[] buffer = new byte[2];
            buffer[0] = (byte)(value & 0xFF);
            buffer[1] = (byte)((value >> 8) & 0xFF);
            _os.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 부호없는 2 byte 정수를 스트림(파일)에 저장한다. (int로 받음)
        /// </summary>
        /// <param name="value">부호없는 2 byte 정수값 (int)</param>
        public void WriteUInt2(int value)
        {
            byte[] buffer = new byte[2];
            buffer[0] = (byte)(value & 0xFF);
            buffer[1] = (byte)((value >> 8) & 0xFF);
            _os.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 부호없는 4 byte 정수를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">부호없는 4 byte 정수값</param>
        public void WriteUInt4(uint value)
        {
            byte[] buffer = new byte[4];
            buffer[0] = (byte)(value & 0xFF);
            buffer[1] = (byte)((value >> 8) & 0xFF);
            buffer[2] = (byte)((value >> 16) & 0xFF);
            buffer[3] = (byte)((value >> 24) & 0xFF);
            _os.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 부호없는 4 byte 정수를 스트림(파일)에 저장한다. (long으로 받음)
        /// </summary>
        /// <param name="value">부호없는 4 byte 정수값 (long)</param>
        public void WriteUInt4(long value)
        {
            byte[] buffer = new byte[4];
            buffer[0] = (byte)(value & 0xFF);
            buffer[1] = (byte)((value >> 8) & 0xFF);
            buffer[2] = (byte)((value >> 16) & 0xFF);
            buffer[3] = (byte)((value >> 24) & 0xFF);
            _os.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 배정도 실수(double)를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">배정도 실수(double)값</param>
        public void WriteDouble(double value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }
            _os.Write(buffer, 0, 8);
        }

        /// <summary>
        /// 단정도 실수(float)를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">단정도 실수(float)값</param>
        public void WriteFloat(float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(buffer);
            }
            _os.Write(buffer, 0, 4);
        }

        /// <summary>
        /// 레코드 헤더를 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="tagId">레코드의 태그 아이디</param>
        /// <param name="size">레코드의 크기</param>
        public void WriteRecordHeader(int tagId, long size)
        {
            long header = 0;
            header = BitFlag.Set(header, 0, 9, tagId);
            header = BitFlag.Set(header, 10, 19, _currentRecordLevel);
            header = BitFlag.Set(header, 20, 31, (int)Math.Min(size, 4095));
            WriteUInt4(header);

            if (size >= 4095)
            {
                WriteUInt4(size);
            }
        }

        /// <summary>
        /// 문자열(UTF-16LE)을 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">문자열</param>
        public void WriteUTF16LEString(string? value)
        {
            if (value == null)
            {
                WriteUInt2(0);
            }
            else
            {
                WriteUInt2(value.Length);
                if (value.Length > 0)
                {
                    WriteBytes(Encoding.Unicode.GetBytes(value));
                }
            }
        }

        /// <summary>
        /// HWPString을 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">HWPString 객체</param>
        public void WriteHWPString(HWPString? value)
        {
            if (value == null || value.Bytes == null)
            {
                WriteUInt2(0);
            }
            else
            {
                WriteUInt2(value.Bytes.Length / 2);
                if (value.Bytes.Length > 0)
                {
                    WriteBytes(value.Bytes);
                }
            }
        }

        /// <summary>
        /// 한 문자(UTF-16LE)을 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="value">한 문자 (바이트 배열)</param>
        public void WriteWChar(byte[]? value)
        {
            if (value != null && value.Length >= 2)
            {
                _os.Write(value, 0, 2);
            }
            else
            {
                WriteZero(2);
            }
        }

        /// <summary>
        /// 0값의 byte을 지정된 개수만큼 스트림(파일)에 저장한다.
        /// </summary>
        /// <param name="number">0값의 개수</param>
        public void WriteZero(int number)
        {
            if (number > 0)
            {
                byte[] zero = new byte[number];
                _os.Write(zero, 0, zero.Length);
            }
        }

        /// <summary>
        /// 현재 레코드의 레벨을 한 단계 높인다.
        /// </summary>
        public void UpRecordLevel()
        {
            _currentRecordLevel++;
        }

        /// <summary>
        /// 현재 레코드의 레벨을 한 단계 낮춘다.
        /// </summary>
        public void DownRecordLevel()
        {
            _currentRecordLevel--;
        }

        /// <summary>
        /// DocInfo를 설정한다.
        /// </summary>
        /// <param name="docInfo">DocInfo 객체</param>
        public void SetDocInfo(DocInfo docInfo)
        {
            _docInfo = docInfo;
        }

        /// <summary>
        /// DocInfo 참조
        /// </summary>
        public DocInfo? DocInfo
        {
            get => _docInfo;
            set => _docInfo = value;
        }

        /// <summary>
        /// ParaShape ID를 수정한다.
        /// </summary>
        /// <param name="oldParaShapeId">이전 ParaShape ID</param>
        /// <returns>수정된 ParaShape ID</returns>
        public int CorrectParaShapeId(int oldParaShapeId)
        {
            if (_docInfo != null)
            {
                return oldParaShapeId + _docInfo.IdMappings.ParaShapeCount - _docInfo.ParaShapeList.Count;
            }
            else
            {
                return oldParaShapeId;
            }
        }

        /// <summary>
        /// 현재 레코드 레벨
        /// </summary>
        public int CurrentRecordLevel => _currentRecordLevel;

        /// <summary>
        /// 압축 여부
        /// </summary>
        public bool Compress => _compress;
    }
}
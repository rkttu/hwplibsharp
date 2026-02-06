// =====================================================================
// Java Original: kr/dogfoot/hwplib/util/compressors/Compressor.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;
using System.IO;
using System.IO.Compression;

namespace HwpLib.Binary
{
    /// <summary>
    /// 압축 및 압축 해제를 위한 유틸리티 클래스
    /// </summary>
    public static class Compressor
    {
        /// <summary>
        /// 데이터를 압축한다. (Deflate + 원본 길이 추가)
        /// </summary>
        /// <param name="original">원본 데이터</param>
        /// <returns>압축된 데이터</returns>
        public static byte[] Compress(byte[] original)
        {
            using var output = new MemoryStream();

            // raw deflate (no zlib/gzip header)
            using (var deflateStream = new DeflateStream(output, CompressionLevel.Optimal, leaveOpen: true))
            {
                deflateStream.Write(original, 0, original.Length);
            }

            // 4바이트 0 추가
            output.Write(new byte[4], 0, 4);

            // Little Endian으로 원본 길이 추가
            byte[] lengthBytes = BitConverter.GetBytes(original.Length);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(lengthBytes);
            }
            output.Write(lengthBytes, 0, 4);

            return output.ToArray();
        }

        /// <summary>
        /// 압축된 데이터를 해제한다.
        /// </summary>
        /// <param name="compressedData">압축된 데이터</param>
        /// <returns>해제된 데이터</returns>
        public static byte[] DecompressedBytes(byte[] compressedData)
        {
            // HWP 형식: deflate 데이터 + 4바이트 0 + 4바이트 원본 길이 (little-endian)
            // 마지막 4바이트에서 원본 길이를 읽어 0이면 빈 데이터
            if (compressedData.Length >= 8)
            {
                int originalLength = BitConverter.ToInt32(compressedData, compressedData.Length - 4);
                if (!BitConverter.IsLittleEndian)
                {
                    // Big-endian 시스템에서 바이트 순서 변환
                    byte[] lengthBytes = new byte[4];
                    Array.Copy(compressedData, compressedData.Length - 4, lengthBytes, 0, 4);
                    Array.Reverse(lengthBytes);
                    originalLength = BitConverter.ToInt32(lengthBytes, 0);
                }

                if (originalLength == 0)
                {
                    return Array.Empty<byte>();
                }
            }

            using var input = new MemoryStream(compressedData);
            return DecompressedBytes(input);
        }

        /// <summary>
        /// 압축된 스트림의 데이터를 해제한다.
        /// </summary>
        /// <param name="inputStream">압축된 데이터 스트림</param>
        /// <returns>해제된 데이터</returns>
        public static byte[] DecompressedBytes(Stream inputStream)
        {
            // raw deflate (no zlib/gzip header)
            using var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress, leaveOpen: true);
            using var output = new MemoryStream();

            byte[] buffer = new byte[16384];
            int nRead;
            while ((nRead = deflateStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, nRead);
            }

            return output.ToArray();
        }

        /// <summary>
        /// MemoryStream을 압축 해제한다.
        /// </summary>
        /// <param name="ms">압축된 MemoryStream</param>
        /// <returns>해제된 데이터</returns>
        public static byte[] DecompressedBytes(MemoryStream ms)
        {
            ms.Position = 0;
            return DecompressedBytes((Stream)ms);
        }
    }
}
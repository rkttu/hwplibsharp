// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/Obfuscation.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;
using System.IO;

namespace HwpLib.Binary
{
    /// <summary>
    /// 배포용 문서의 난독화/복호화를 위한 유틸리티 클래스
    /// </summary>
    public static class Obfuscation
    {
        /// <summary>
        /// 256바이트 데이터를 복호화한다.
        /// </summary>
        /// <param name="data">256바이트 데이터</param>
        public static void Transform(byte[] data)
        {
            if (data == null || data.Length != 256) return;

            // seed는 처음 4바이트 (Little Endian)
            int seed = data[0] | (data[1] << 8) | (data[2] << 16) | (data[3] << 24);

            var transformer = new ObfuscationTransformer(seed);

            byte value = 0;
            int number = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (number == 0)
                {
                    value = transformer.Value();
                    number = transformer.Number();
                }

                if (i >= 4)
                {
                    data[i] = (byte)(data[i] ^ value);
                }

                number--;
            }
        }

        /// <summary>
        /// 배포용 문서의 스트림을 복호화한다.
        /// </summary>
        /// <param name="inputStream">입력 스트림</param>
        /// <returns>복호화된 스트림</returns>
        public static MemoryStream DecryptStream(Stream inputStream)
        {
            // 처음 256바이트를 읽어서 복호화
            byte[] header = new byte[256];
            int bytesRead = inputStream.Read(header, 0, 256);
            if (bytesRead < 256)
            {
                throw new InvalidOperationException("배포용 문서의 헤더가 256바이트 미만입니다.");
            }

            // 헤더 복호화
            Transform(header);

            // 복호화된 헤더에서 AES 키를 추출 (offset 4부터 16바이트)
            byte[] aesKey = new byte[16];
            Array.Copy(header, 4, aesKey, 0, 16);

            // 나머지 데이터를 AES로 복호화
            using var remainingData = new MemoryStream();
            inputStream.CopyTo(remainingData);
            byte[] encryptedData = remainingData.ToArray();

            byte[] decryptedData = AesDecrypt(encryptedData, aesKey);

            return new MemoryStream(decryptedData);
        }

        /// <summary>
        /// AES/ECB/PKCS5Padding으로 복호화한다.
        /// </summary>
        /// <param name="data">암호화된 데이터</param>
        /// <param name="key">AES 키 (16바이트)</param>
        /// <returns>복호화된 데이터</returns>
        private static byte[] AesDecrypt(byte[] data, byte[] key)
        {
            using var aes = System.Security.Cryptography.Aes.Create();
            aes.Mode = System.Security.Cryptography.CipherMode.ECB;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7; // PKCS5 = PKCS7 in .NET
            aes.Key = key;

            using var decryptor = aes.CreateDecryptor();
            return decryptor.TransformFinalBlock(data, 0, data.Length);
        }

        /// <summary>
        /// 난독화 변환기
        /// </summary>
        private sealed class ObfuscationTransformer
        {
            private int _randomSeed;

            public ObfuscationTransformer(int seed)
            {
                _randomSeed = seed;
            }

            private int Rand()
            {
                _randomSeed = unchecked((_randomSeed * 214013 + 2531011) & 0x7FFFFFFF);
                return (_randomSeed >> 16) & 0x7FFF;
            }

            public byte Value()
            {
                return (byte)(Rand() & 0xFF);
            }

            public int Number()
            {
                return (Rand() & 0xF) + 1;
            }
        }
    }
}
// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/ForFileHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.FileHeader;
using HwpLib.Util.Binary;

namespace HwpLib.Writer
{
    /// <summary>
    /// 파일 헤더를 쓰기 위한 객체
    /// </summary>
    public static class ForFileHeader
    {
        /// <summary>
        /// 파일 헤더를 쓴다.
        /// </summary>
        /// <param name="fh">파일 헤더</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(FileHeader fh, CompoundStreamWriter sw)
        {
            Signature(sw);
            FileVersion(fh.Version, sw);
            Properties(fh, sw);
            Zero216(sw);
        }

        /// <summary>
        /// 파일 시그널을 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void Signature(CompoundStreamWriter sw)
        {
            byte[] signature = {
                0x48, 0x57, 0x50, 0x20, 0x44, 0x6F, 0x63, 0x75,
                0x6D, 0x65, 0x6E, 0x74, 0x20, 0x46, 0x69, 0x6C, 0x65, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00
            };
            sw.WriteBytes(signature);
        }

        /// <summary>
        /// 파일 버전을 쓴다.
        /// </summary>
        /// <param name="version">파일 버전</param>
        /// <param name="sw">스트림 라이터</param>
        private static void FileVersion(Object.FileHeader.FileVersion version, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(version.GetVersion());
        }

        /// <summary>
        /// 파일 속성을 쓴다.
        /// </summary>
        /// <param name="fh">파일 헤더</param>
        /// <param name="sw">스트림 라이터</param>
        private static void Properties(FileHeader fh, CompoundStreamWriter sw)
        {
            long properties = 0;
            properties = BitFlag.Set(properties, 0, fh.Compressed);
            properties = BitFlag.Set(properties, 1, fh.HasPassword);
            properties = BitFlag.Set(properties, 2, fh.IsDistribution);
            properties = BitFlag.Set(properties, 3, fh.SaveScript);
            properties = BitFlag.Set(properties, 4, fh.IsDrmDocument);
            properties = BitFlag.Set(properties, 5, fh.HasXmlTemplate);
            properties = BitFlag.Set(properties, 6, fh.HasDocumentHistory);
            properties = BitFlag.Set(properties, 7, fh.HasSignature);
            properties = BitFlag.Set(properties, 8, fh.EncryptPublicCertification);
            properties = BitFlag.Set(properties, 9, fh.SavePrepareSignature);
            properties = BitFlag.Set(properties, 10, fh.IsPublicCertificationDrmDocument);
            properties = BitFlag.Set(properties, 11, fh.IsCclDocument);
            sw.WriteUInt4(properties);
        }

        /// <summary>
        /// 나머지 부분(216 bytes)을 0으로 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void Zero216(CompoundStreamWriter sw)
        {
            sw.WriteZero(216);
        }
    }
}

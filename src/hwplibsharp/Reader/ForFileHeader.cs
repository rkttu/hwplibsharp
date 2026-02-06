// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/ForFileHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.FileHeader;
using HwpLib.Util.Binary;
using System;
using System.Linq;

namespace HwpLib.Reader
{
    /// <summary>
    /// 파일 헤더를 읽기 위한 객체
    /// </summary>
    public static class ForFileHeader
    {
        /// <summary>
        /// File Header 스트림을 읽는다.
        /// </summary>
        /// <param name="fh">파일 헤더 객체</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(FileHeader fh, CompoundStreamReader sr)
        {
            Signature(sr);
            FileVersionRead(fh.Version, sr);
            Properties(fh, sr);
        }

        /// <summary>
        /// 한글 파일 시그니처(이 파일이 한글 파일인지 확인하는 부분)을 읽는다.
        /// </summary>
        /// <param name="sr">스트림 리더</param>
        private static void Signature(CompoundStreamReader sr)
        {
            byte[] sign = sr.ReadBytes(32);

            if (!FileHeader.GetFileSignature().SequenceEqual(sign))
            {
                throw new InvalidOperationException("this is not hwp file.");
            }
        }

        /// <summary>
        /// 파일 버전 부분을 읽는다.
        /// </summary>
        /// <param name="fv">읽은 내용을 저장할 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void FileVersionRead(FileVersion fv, CompoundStreamReader sr)
        {
            fv.SetVersion(sr.ReadUInt4());
        }

        /// <summary>
        /// 속성 부분을 읽는다.
        /// </summary>
        /// <param name="fh">읽은 내용을 저장할 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void Properties(FileHeader fh, CompoundStreamReader sr)
        {
            uint flag = sr.ReadUInt4();
            fh.Compressed = BitFlag.Get(flag, 0);
            fh.HasPassword = BitFlag.Get(flag, 1);
            fh.IsDistribution = BitFlag.Get(flag, 2);
            fh.SaveScript = BitFlag.Get(flag, 3);
            fh.IsDrmDocument = BitFlag.Get(flag, 4);
            fh.HasXmlTemplate = BitFlag.Get(flag, 5);
            fh.HasDocumentHistory = BitFlag.Get(flag, 6);
            fh.HasSignature = BitFlag.Get(flag, 7);
            fh.EncryptPublicCertification = BitFlag.Get(flag, 8);
            fh.SavePrepareSignature = BitFlag.Get(flag, 9);
            fh.IsPublicCertificationDrmDocument = BitFlag.Get(flag, 10);
            fh.IsCclDocument = BitFlag.Get(flag, 11);
        }
    }
}

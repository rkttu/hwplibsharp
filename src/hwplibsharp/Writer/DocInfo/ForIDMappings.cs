// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForIDMappings.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 아이디 매핑 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForIDMappings
    {
        /// <summary>
        /// 아이디 매핑 레코드를 쓴다.
        /// </summary>
        /// <param name="im">아이디 매핑 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(IDMappings im, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            sw.WriteSInt4(im.BinDataCount); // 0
            sw.WriteSInt4(im.HangulFaceNameCount); // 1
            sw.WriteSInt4(im.EnglishFaceNameCount); // 2
            sw.WriteSInt4(im.HanjaFaceNameCount); // 3
            sw.WriteSInt4(im.JapaneseFaceNameCount); // 4
            sw.WriteSInt4(im.EtcFaceNameCount); // 5
            sw.WriteSInt4(im.SymbolFaceNameCount); // 6
            sw.WriteSInt4(im.UserFaceNameCount); // 7
            sw.WriteSInt4(im.BorderFillCount); // 8
            sw.WriteSInt4(im.CharShapeCount); // 9
            sw.WriteSInt4(im.TabDefCount); // 10
            sw.WriteSInt4(im.NumberingCount); // 11
            sw.WriteSInt4(im.BulletCount); // 12
            sw.WriteSInt4(im.ParaShapeCount); // 13
            sw.WriteSInt4(im.StyleCount); // 14

            if (sw.FileVersion.IsOver(5, 0, 2, 1))
            {
                sw.WriteSInt4(im.MemoShapeCount); // 15
            }
            if (sw.FileVersion.IsOver(5, 0, 3, 2))
            {
                sw.WriteSInt4(im.TrackChangeCount); // 16
                sw.WriteSInt4(im.TrackChangeAuthorCount); // 17
            }
        }

        /// <summary>
        /// 아이디 매핑 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.IdMappings, GetSize(sw.FileVersion));
        }

        /// <summary>
        /// 아이디 매핑 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="version">파일 버전</param>
        /// <returns>아이디 매핑 레코드의 크기</returns>
        private static int GetSize(FileVersion version)
        {
            if (version.IsOver(5, 0, 3, 2))
            {
                return 72;
            }
            else if (version.IsOver(5, 0, 2, 1))
            {
                return 64;
            }
            else
            {
                return 60;
            }
        }
    }
}

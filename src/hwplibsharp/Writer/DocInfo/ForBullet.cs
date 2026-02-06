// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForBullet.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;
using HwpLib.Writer.DocInfo.BorderFill;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 글머리표 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForBullet
    {
        /// <summary>
        /// 글머리표 레코드를 쓴다.
        /// </summary>
        /// <param name="b">글머리표 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(Bullet b, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            ForNumbering.ParagraphHeadInfo(b.ParagraphHeadInfo, sw);
            sw.WriteWChar(b.BulletChar.Bytes);

            if (b.ImageBullet)
            {
                sw.WriteUInt4(1);
            }
            else
            {
                sw.WriteUInt4(0);
            }

            ForFillInfo.PictureInfo(b.ImageBulletInfo, sw);
            sw.WriteWChar(b.CheckBulletChar.Bytes);
        }

        /// <summary>
        /// 글머리표 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.Bullet, 25);
        }
    }
}

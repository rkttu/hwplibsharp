// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForBullet.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Reader.DocInfo.BorderFill;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 글머리표 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForBullet
    {
        /// <summary>
        /// 글머리표 레코드를 읽는다.
        /// </summary>
        /// <param name="b">글머리표 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(Bullet b, CompoundStreamReader sr)
        {
            ForNumbering.ReadParagraphHeadInfo(b.ParagraphHeadInfo, sr);
            b.BulletChar.Bytes = sr.ReadWChar();

            if (sr.IsEndOfRecord()) return;

            uint imageBullet = sr.ReadUInt4();
            b.ImageBullet = (imageBullet == 1);

            ForFillInfo.ReadPictureInfo(b.ImageBulletInfo, sr);

            if (sr.IsEndOfRecord()) return;

            b.CheckBulletChar.Bytes = sr.ReadWChar();
        }
    }
}

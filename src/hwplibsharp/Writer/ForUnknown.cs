// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/ForUnknown.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.Etc;
using System;

namespace HwpLib.Writer
{
    /// <summary>
    /// 알수 없는 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForUnknown
    {
        /// <summary>
        /// 알수 없는 레코드를 쓴다.
        /// </summary>
        /// <param name="ur">알수 없는 레코드</param>
        /// <param name="tagId">태그 아이디</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(UnknownRecord ur, int tagId, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(tagId, ur.Body?.Length ?? 0);
            sw.WriteBytes(ur.Body ?? Array.Empty<byte>());
        }
    }
}

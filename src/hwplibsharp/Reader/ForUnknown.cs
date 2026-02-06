// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/ForUnknown.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.Etc;

namespace HwpLib.Reader
{
    /// <summary>
    /// 알수 없는 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForUnknown
    {
        /// <summary>
        /// 알수 없는 레코드를 읽는다.
        /// </summary>
        /// <param name="unknown">알 수 없는 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(UnknownRecord unknown, CompoundStreamReader sr)
        {
            if (unknown.Header == null) return;
            byte[] body = sr.ReadBytes((int)unknown.Header.Size);
            unknown.Body = body;
        }
    }
}

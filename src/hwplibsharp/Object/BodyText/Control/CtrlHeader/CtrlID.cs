// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlID.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 컨트롤 id을 생성하기 위한 객체
    /// </summary>
    public static class CtrlID
    {
        /// <summary>
        /// 컨트롤 아이디를 생성한다.
        /// </summary>
        /// <param name="a">24~31 bit값</param>
        /// <param name="b">16~23 bit값</param>
        /// <param name="c">8~15 bit값</param>
        /// <param name="d">0~7 bit값</param>
        /// <returns>컨트롤 아이디</returns>
        public static uint Make(char a, char b, char c, char d)
        {
            return (uint)(((byte)a << 24) | ((byte)b << 16) | ((byte)c << 8) | (byte)d);
        }

        /// <summary>
        /// 컨트롤 아이디로부터 4개의 문자 배열을 생성한다.
        /// </summary>
        /// <param name="id">컨트롤 아이디</param>
        /// <returns>4개의 문자 배열</returns>
        public static char[] Make(uint id)
        {
            char[] ret = new char[4];
            ret[0] = (char)BitFlag.Get(id, 0, 7);
            ret[1] = (char)BitFlag.Get(id, 8, 15);
            ret[2] = (char)BitFlag.Get(id, 16, 23);
            ret[3] = (char)BitFlag.Get(id, 24, 31);
            return ret;
        }
    }
}

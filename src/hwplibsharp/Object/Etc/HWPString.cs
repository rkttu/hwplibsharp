// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/etc/HWPString.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;
using System.Linq;
using System.Text;

namespace HwpLib.Object.Etc
{
    /// <summary>
    /// HWP 문자열을 나타내는 클래스
    /// </summary>
    public class HWPString
    {
        private byte[]? bytes;

        /// <summary>
        /// HWPString 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public HWPString()
        {
            bytes = null;
        }

        /// <summary>
        /// 지정된 바이트 배열로 HWPString 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="bytes">문자열을 나타내는 바이트 배열</param>
        public HWPString(byte[] bytes)
        {
            this.bytes = bytes;
        }

        /// <summary>
        /// 문자열을 나타내는 바이트 배열을 가져오거나 설정합니다.
        /// </summary>
        public byte[]? Bytes
        {
            get => bytes;
            set => bytes = value;
        }

        /// <summary>
        /// UTF-16LE 인코딩으로 문자열을 반환한다.
        /// </summary>
        /// <returns>문자열</returns>
        public string? ToUTF16LEString()
        {
            if (bytes == null)
            {
                return null;
            }
            return Encoding.Unicode.GetString(bytes);
        }

        /// <summary>
        /// UTF-16LE 인코딩으로 문자열을 설정한다.
        /// </summary>
        /// <param name="utf16LE">문자열</param>
        public void FromUTF16LEString(string? utf16LE)
        {
            if (utf16LE != null && utf16LE.Length > 0)
            {
                bytes = Encoding.Unicode.GetBytes(utf16LE);
            }
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="HWPString"/>의 새 인스턴스입니다.</returns>
        public HWPString Clone()
        {
            HWPString cloned = new HWPString();
            cloned.Copy(this);
            return cloned;
        }

        /// <summary>
        /// 다른 HWPString 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(HWPString from)
        {
            bytes = from.bytes;
        }

        /// <summary>
        /// 문자열을 나타내는 바이트 배열의 크기를 워드(2바이트) 단위로 반환합니다.
        /// </summary>
        /// <returns>워드 단위 크기 (2 + 바이트 배열의 길이)</returns>
        public int GetWCharsSize()
        {
            if (bytes != null)
            {
                return 2 + bytes.Length;
            }
            return 2;
        }

        /// <summary>
        /// 다른 <see cref="HWPString"/> 객체와 바이트 배열이 동일한지 비교합니다.
        /// </summary>
        /// <param name="other">비교할 <see cref="HWPString"/> 객체</param>
        /// <returns>동일하면 true, 그렇지 않으면 false</returns>
        public bool Equals(HWPString other)
        {
            if (bytes == null && other.bytes == null)
            {
                return true;
            }
            if (bytes == null || other.bytes == null)
            {
                return false;
            }
            return bytes.SequenceEqual(other.bytes);
        }
    }
}

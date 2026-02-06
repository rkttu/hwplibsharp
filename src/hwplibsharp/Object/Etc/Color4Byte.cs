// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/etc/Color4Byte.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.Etc
{
    /// <summary>
    /// 4byte 색상 객체. windows API의 COLORREF에 대응하는 객체
    /// </summary>
    public class Color4Byte
    {
        /// <summary>
        /// unsigned 4 byte color 값을 저장
        /// </summary>
        private uint value;

        /// <summary>
        /// 생성자
        /// </summary>
        public Color4Byte()
        {
        }

        /// <summary>
        /// 지정된 red, green, blue, alpha 값으로 Color4Byte 인스턴스를 생성합니다.
        /// </summary>
        /// <param name="r">Red 값 (0~255)</param>
        /// <param name="g">Green 값 (0~255)</param>
        /// <param name="b">Blue 값 (0~255)</param>
        /// <param name="a">Alpha 값 (0~255)</param>
        public Color4Byte(int r, int g, int b, int a)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            A = (byte)a;
        }

        /// <summary>
        /// 지정된 red, green, blue 값으로 Color4Byte 인스턴스를 생성합니다. Alpha 값은 0으로 설정됩니다.
        /// </summary>
        /// <param name="r">Red 값 (0~255)</param>
        /// <param name="g">Green 값 (0~255)</param>
        /// <param name="b">Blue 값 (0~255)</param>
        public Color4Byte(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            A = 0;
        }

        /// <summary>
        /// unsigned 4 byte color 값
        /// </summary>
        public uint Value
        {
            get => value;
            set => this.value = value;
        }

        /// <summary>
        /// 색상의 red 값 (0~255)
        /// </summary>
        public byte R
        {
            get => (byte)BitFlag.Get(value, 0, 7);
            set => this.value = (uint)BitFlag.Set(this.value, 0, 7, value);
        }

        /// <summary>
        /// 색상의 green 값 (0~255)
        /// </summary>
        public byte G
        {
            get => (byte)BitFlag.Get(value, 8, 15);
            set => this.value = (uint)BitFlag.Set(this.value, 8, 15, value);
        }

        /// <summary>
        /// 색상의 blue 값 (0~255)
        /// </summary>
        public byte B
        {
            get => (byte)BitFlag.Get(value, 16, 23);
            set => this.value = (uint)BitFlag.Set(this.value, 16, 23, value);
        }

        /// <summary>
        /// 색상의 alpha 값 (0~255)
        /// </summary>
        public byte A
        {
            get => (byte)BitFlag.Get(value, 24, 31);
            set => this.value = (uint)BitFlag.Set(this.value, 24, 31, value);
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="Color4Byte"/>의 새 인스턴스입니다.</returns>
        public Color4Byte Clone()
        {
            Color4Byte cloned = new Color4Byte();
            cloned.Copy(this);
            return cloned;
        }

        /// <summary>
        /// 다른 Color4Byte 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(Color4Byte from)
        {
            value = from.value;
        }
    }
}

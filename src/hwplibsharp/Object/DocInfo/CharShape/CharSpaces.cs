// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/CharSpaces.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 언어별 자간에 대한 객체
    /// </summary>
    public class CharSpaces
    {
        private readonly sbyte[] _array;

        /// <summary>
        /// <see cref="CharSpaces"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public CharSpaces()
        {
            _array = new sbyte[7];
        }

        /// <summary>
        /// 자간 배열을 가져옵니다.
        /// </summary>
        public sbyte[] Array => _array;

        /// <summary>
        /// 자간 배열을 설정합니다.
        /// </summary>
        /// <param name="array">길이가 7인 sbyte 배열</param>
        /// <exception cref="ArgumentException">배열 길이가 7이 아닌 경우</exception>
        public void SetArray(sbyte[] array)
        {
            if (array.Length != 7)
                throw new ArgumentException("array length must be 7");
            System.Array.Copy(array, _array, 7);
        }

        /// <summary>
        /// 한글 자간 값을 가져오거나 설정합니다.
        /// </summary>
        public sbyte Hangul
        {
            get => _array[0];
            set => _array[0] = value;
        }

        /// <summary>
        /// 라틴 자간 값을 가져오거나 설정합니다.
        /// </summary>
        public sbyte Latin
        {
            get => _array[1];
            set => _array[1] = value;
        }

        /// <summary>
        /// 한자 자간 값을 가져오거나 설정합니다.
        /// </summary>
        public sbyte Hanja
        {
            get => _array[2];
            set => _array[2] = value;
        }

        /// <summary>
        /// 일본어 자간 값을 가져오거나 설정합니다.
        /// </summary>
        public sbyte Japanese
        {
            get => _array[3];
            set => _array[3] = value;
        }

        /// <summary>
        /// 기타 언어 자간 값을 가져오거나 설정합니다.
        /// </summary>
        public sbyte Other
        {
            get => _array[4];
            set => _array[4] = value;
        }

        /// <summary>
        /// 기호 자간 값을 가져오거나 설정합니다.
        /// </summary>
        public sbyte Symbol
        {
            get => _array[5];
            set => _array[5] = value;
        }

        /// <summary>
        /// 사용자 정의 자간 값을 가져오거나 설정합니다.
        /// </summary>
        public sbyte User
        {
            get => _array[6];
            set => _array[6] = value;
        }

        /// <summary>
        /// 모든 언어의 자간 값을 동일하게 설정합니다.
        /// </summary>
        /// <param name="charSpace">설정할 자간 값</param>
        public void SetForAll(sbyte charSpace)
        {
            for (int i = 0; i < 7; i++)
                _array[i] = charSpace;
        }

        /// <summary>
        /// 다른 <see cref="CharSpaces"/> 인스턴스의 값을 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 인스턴스</param>
        public void Copy(CharSpaces from)
        {
            System.Array.Copy(from._array, _array, from._array.Length);
        }
    }
}

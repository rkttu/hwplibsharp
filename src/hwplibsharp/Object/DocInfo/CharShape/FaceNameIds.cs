// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/charshape/FaceNameIds.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;

namespace HwpLib.Object.DocInfo.CharShape
{
    /// <summary>
    /// 언어별 참조된 글꼴 ID(FaceID)
    /// </summary>
    public class FaceNameIds
    {
        private readonly int[] _array;

        /// <summary>
        /// FaceNameIds 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public FaceNameIds()
        {
            _array = new int[7];
        }

        /// <summary>
        /// 언어별 참조된 글꼴 ID 배열을 가져옵니다.
        /// </summary>
        public int[] Array => _array;

        /// <summary>
        /// 언어별 참조된 글꼴 ID 배열을 설정합니다.
        /// </summary>
        /// <param name="array">길이가 7인 글꼴 ID 배열</param>
        /// <exception cref="ArgumentException">배열 길이가 7이 아닌 경우 발생</exception>
        public void SetArray(int[] array)
        {
            if (array.Length != 7)
                throw new ArgumentException("array length must be 7");
            System.Array.Copy(array, _array, 7);
        }

        /// <summary>
        /// 한글 글꼴 ID를 가져오거나 설정합니다.
        /// </summary>
        public int Hangul
        {
            get => _array[0];
            set => _array[0] = value;
        }

        /// <summary>
        /// 라틴 글꼴 ID를 가져오거나 설정합니다.
        /// </summary>
        public int Latin
        {
            get => _array[1];
            set => _array[1] = value;
        }

        /// <summary>
        /// 한자 글꼴 ID를 가져오거나 설정합니다.
        /// </summary>
        public int Hanja
        {
            get => _array[2];
            set => _array[2] = value;
        }

        /// <summary>
        /// 일본어 글꼴 ID를 가져오거나 설정합니다.
        /// </summary>
        public int Japanese
        {
            get => _array[3];
            set => _array[3] = value;
        }

        /// <summary>
        /// 기타 글꼴 ID를 가져오거나 설정합니다.
        /// </summary>
        public int Other
        {
            get => _array[4];
            set => _array[4] = value;
        }

        /// <summary>
        /// 심볼 글꼴 ID를 가져오거나 설정합니다.
        /// </summary>
        public int Symbol
        {
            get => _array[5];
            set => _array[5] = value;
        }

        /// <summary>
        /// 사용자 정의 글꼴 ID를 가져오거나 설정합니다.
        /// </summary>
        public int User
        {
            get => _array[6];
            set => _array[6] = value;
        }

        /// <summary>
        /// 모든 언어에 대해 동일한 글꼴 ID를 설정합니다.
        /// </summary>
        /// <param name="faceNameId">설정할 글꼴 ID</param>
        public void SetForAll(int faceNameId)
        {
            for (int i = 0; i < 7; i++)
                _array[i] = faceNameId;
        }

        /// <summary>
        /// 다른 FaceNameIds 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FaceNameIds from)
        {
            System.Array.Copy(from._array, _array, from._array.Length);
        }
    }
}

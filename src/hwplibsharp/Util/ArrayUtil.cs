// =====================================================================
// Java Original: kr/dogfoot/hwplib/util/ArrayUtil.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;

namespace HwpLib.Util
{
    /// <summary>
    /// 배열 관련 유틸리티 클래스
    /// </summary>
    public static class ArrayUtil
    {
        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(bool[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(byte[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(char[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(double[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(float[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(int[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(long[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(object?[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty(short[]? array)
        {
            return GetLength(array) == 0;
        }

        /// <summary>
        /// 배열의 길이를 반환한다. null이면 0을 반환한다.
        /// </summary>
        /// <param name="array">배열</param>
        /// <returns>배열의 길이</returns>
        public static int GetLength(Array? array)
        {
            if (array == null)
            {
                return 0;
            }
            return array.Length;
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(bool[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(byte[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(char[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(double[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(float[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(int[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(long[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty(short[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 배열이 비어있지 않고 null이 아닌지 확인한다.
        /// </summary>
        /// <typeparam name="T">배열 요소 타입</typeparam>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있지 않고 null이 아니면 true</returns>
        public static bool IsNotEmpty<T>(T[]? array)
        {
            return !IsEmpty(array);
        }

        /// <summary>
        /// 제네릭 배열이 비어있거나 null인지 확인한다.
        /// </summary>
        /// <typeparam name="T">배열 요소 타입</typeparam>
        /// <param name="array">확인할 배열</param>
        /// <returns>배열이 비어있거나 null이면 true</returns>
        public static bool IsEmpty<T>(T[]? array)
        {
            return GetLength(array) == 0;
        }
    }
}

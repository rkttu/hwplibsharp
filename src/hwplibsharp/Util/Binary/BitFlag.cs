// =====================================================================
// Java Original: kr/dogfoot/hwplib/util/binary/BitFlag.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Util.Binary
{
    /// <summary>
    /// 이진 연산을 하는 클래스
    /// </summary>
    public static class BitFlag
    {
        /// <summary>
        /// mask에서 position번째 비트가 1인지 여부를 반환한다.
        /// </summary>
        /// <param name="mask">long 값</param>
        /// <param name="position">비트 위치</param>
        /// <returns>mask값에서 position번째 비트가 1인지 여부</returns>
        public static bool Get(long mask, int position)
        {
            long mask2 = 1L << position;
            return (mask & mask2) == mask2;
        }

        /// <summary>
        /// mask에서 position번째 비트가 1인지 여부를 반환한다.
        /// </summary>
        /// <param name="mask">int 값</param>
        /// <param name="position">비트 위치</param>
        /// <returns>mask값에서 position번째 비트가 1인지 여부</returns>
        public static bool Get(int mask, int position)
        {
            int mask2 = 1 << position;
            return (mask & mask2) == mask2;
        }

        /// <summary>
        /// mask에서 position번째 비트가 1인지 여부를 반환한다.
        /// </summary>
        /// <param name="mask">short 값</param>
        /// <param name="position">비트 위치</param>
        /// <returns>mask값에서 position번째 비트가 1인지 여부</returns>
        public static bool Get(short mask, int position)
        {
            short mask2 = (short)(1 << position);
            return (mask & mask2) == mask2;
        }

        /// <summary>
        /// mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 long 값</param>
        /// <param name="position">비트 위치</param>
        /// <param name="flag">bool 값</param>
        /// <returns>mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한 결과값</returns>
        public static long Set(long mask, int position, bool flag)
        {
            if (flag)
            {
                mask |= (0x1L << position);
            }
            else
            {
                if ((mask & (0x1L << position)) != 0)
                {
                    mask ^= (0x1L << position);
                }
            }
            return mask;
        }

        /// <summary>
        /// mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 int 값</param>
        /// <param name="position">비트 위치</param>
        /// <param name="flag">bool 값</param>
        /// <returns>mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한 결과값</returns>
        public static int Set(int mask, int position, bool flag)
        {
            if (flag)
            {
                mask |= (0x1 << position);
            }
            else
            {
                if ((mask & (0x1 << position)) != 0)
                {
                    mask ^= (0x1 << position);
                }
            }
            return mask;
        }

        /// <summary>
        /// mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 short 값</param>
        /// <param name="position">비트 위치</param>
        /// <param name="flag">bool 값</param>
        /// <returns>mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한 결과값</returns>
        public static short Set(short mask, int position, bool flag)
        {
            if (flag)
            {
                mask = (short)((ushort)mask | (0x1 << position));
            }
            else
            {
                if ((mask & (0x1 << position)) != 0)
                {
                    mask = (short)(mask ^ (0x1 << position));
                }
            }
            return mask;
        }

        /// <summary>
        /// mask 값에서 start부터 end까지의 비트의 값을 반환한다.
        /// </summary>
        /// <param name="mask">long 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <returns>mask 값에서 start부터 end까지 비트의 정수값</returns>
        public static long Get(long mask, int start, int end)
        {
            long ret = mask >> start;

            long temp = 0;
            for (int nIndex = 0; nIndex < end - start + 1; nIndex++)
            {
                temp <<= 1;
                temp += 1;
            }

            ret &= temp;

            return ret;
        }

        /// <summary>
        /// mask 값에서 start부터 end까지의 비트의 값을 반환한다.
        /// </summary>
        /// <param name="mask">int 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <returns>mask 값에서 start부터 end까지 비트의 정수값</returns>
        public static int Get(int mask, int start, int end)
        {
            int ret = mask >> start;

            int temp = 0;
            for (int nIndex = 0; nIndex < end - start + 1; nIndex++)
            {
                temp <<= 1;
                temp += 1;
            }

            ret &= temp;

            return ret;
        }

        /// <summary>
        /// mask 값에서 start부터 end까지의 비트의 값을 반환한다.
        /// </summary>
        /// <param name="mask">short 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <returns>mask 값에서 start부터 end까지 비트의 정수값</returns>
        public static short Get(short mask, int start, int end)
        {
            short ret = (short)(mask >> start);

            int temp = 0;
            for (int nIndex = 0; nIndex < end - start + 1; nIndex++)
            {
                temp <<= 1;
                temp += 1;
            }

            ret = (short)(ret & temp);

            return ret;
        }

        /// <summary>
        /// mask값에서 start부터 end까지의 비트를 value값으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 long 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <param name="value">설정값</param>
        /// <returns>mask값에서 start부터 end까지의 비트를 value값으로 설정한 결과값</returns>
        public static long Set(long mask, int start, int end, int value)
        {
            for (int position = start; position <= end; position++)
            {
                bool flag = Get(value, position - start);
                mask = Set(mask, position, flag);
            }
            return mask;
        }

        /// <summary>
        /// mask값에서 start부터 end까지의 비트를 value값으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 int 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <param name="value">설정값</param>
        /// <returns>mask값에서 start부터 end까지의 비트를 value값으로 설정한 결과값</returns>
        public static int Set(int mask, int start, int end, int value)
        {
            for (int position = start; position <= end; position++)
            {
                bool flag = Get(value, position - start);
                mask = Set(mask, position, flag);
            }
            return mask;
        }

        /// <summary>
        /// mask값에서 start부터 end까지의 비트를 value값으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 short 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <param name="value">설정값</param>
        /// <returns>mask값에서 start부터 end까지의 비트를 value값으로 설정한 결과값</returns>
        public static short Set(short mask, int start, int end, int value)
        {
            for (int position = start; position <= end; position++)
            {
                bool flag = Get(value, position - start);
                mask = Set(mask, position, flag);
            }
            return mask;
        }

        /// <summary>
        /// mask에서 position번째 비트가 1인지 여부를 반환한다.
        /// </summary>
        /// <param name="mask">uint 값</param>
        /// <param name="position">비트 위치</param>
        /// <returns>mask값에서 position번째 비트가 1인지 여부</returns>
        public static bool Get(uint mask, int position)
        {
            uint mask2 = 1u << position;
            return (mask & mask2) == mask2;
        }

        /// <summary>
        /// mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 uint 값</param>
        /// <param name="position">비트 위치</param>
        /// <param name="flag">bool 값</param>
        /// <returns>mask의 position번째 비트을 flag값이 true일때 1, false일때 0으로 설정한 결과값</returns>
        public static uint Set(uint mask, int position, bool flag)
        {
            if (flag)
            {
                mask |= (0x1u << position);
            }
            else
            {
                if ((mask & (0x1u << position)) != 0)
                {
                    mask ^= (0x1u << position);
                }
            }
            return mask;
        }

        /// <summary>
        /// mask 값에서 start부터 end까지의 비트의 값을 반환한다.
        /// </summary>
        /// <param name="mask">uint 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <returns>mask 값에서 start부터 end까지 비트의 정수값</returns>
        public static uint Get(uint mask, int start, int end)
        {
            uint ret = mask >> start;

            uint temp = 0;
            for (int nIndex = 0; nIndex < end - start + 1; nIndex++)
            {
                temp <<= 1;
                temp += 1;
            }

            ret &= temp;

            return ret;
        }

        /// <summary>
        /// mask값에서 start부터 end까지의 비트를 value값으로 설정한다.
        /// </summary>
        /// <param name="mask">이전 uint 값</param>
        /// <param name="start">비트 시작 위치</param>
        /// <param name="end">비트 끝 위치</param>
        /// <param name="value">설정값</param>
        /// <returns>mask값에서 start부터 end까지의 비트를 value값으로 설정한 결과값</returns>
        public static uint Set(uint mask, int start, int end, int value)
        {
            for (int position = start; position <= end; position++)
            {
                bool flag = Get(value, position - start);
                mask = Set(mask, position, flag);
            }
            return mask;
        }
    }
}

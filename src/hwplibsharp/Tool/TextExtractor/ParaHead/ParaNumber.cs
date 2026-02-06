// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/textextractor/parahead/ParaNumber.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Tool.TextExtractor.ParaHead
{
    /// <summary>
    /// 문단 번호 관리 클래스
    /// </summary>
    public class ParaNumber
    {
        private const int LevelCount = 10;

        private readonly int[] _levelNumbers;
        private int _currentHeadID;

        /// <summary>
        /// <see cref="ParaNumber"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public ParaNumber()
        {
            _levelNumbers = new int[LevelCount];
            _currentHeadID = -1;
        }

        /// <summary>
        /// 문단 머리글 ID가 변경되었는지 여부를 확인합니다.
        /// </summary>
        /// <param name="headID">확인할 머리글 ID</param>
        /// <returns>머리글 ID가 변경되었으면 true, 아니면 false를 반환합니다.</returns>
        public bool ChangedParaHead(int headID)
        {
            return _currentHeadID != headID;
        }

        /// <summary>
        /// 문단 번호를 초기화합니다.
        /// </summary>
        /// <param name="headID">머리글 ID</param>
        /// <param name="level">레벨</param>
        /// <param name="valueForLevel1">1레벨의 값</param>
        public void Reset(int headID, int level, int valueForLevel1)
        {
            _levelNumbers[0] = valueForLevel1;
            for (int level2 = 1; level2 < LevelCount; level2++)
            {
                if (level >= level2)
                {
                    _levelNumbers[level2] = 1;
                }
                else
                {
                    _levelNumbers[level2] = 0;
                }
            }
            _currentHeadID = headID;
        }

        /// <summary>
        /// 지정한 레벨의 문단 번호 값을 반환합니다.
        /// </summary>
        /// <param name="level">레벨</param>
        /// <returns>해당 레벨의 문단 번호 값</returns>
        public int Value(int level)
        {
            return _levelNumbers[level];
        }

        /// <summary>
        /// 지정한 레벨의 문단 번호를 증가시킵니다.
        /// </summary>
        /// <param name="level">증가시킬 레벨</param>
        public void Increase(int level)
        {
            for (int level2 = 0; level2 < LevelCount; level2++)
            {
                if (level2 < level)
                {
                    if (_levelNumbers[level2] == 0)
                    {
                        _levelNumbers[level2] = 1;
                    }
                }
                else if (level2 > level)
                {
                    _levelNumbers[level2] = 0;
                }
                else
                {
                    _levelNumbers[level2]++;
                }
            }
        }
    }
}

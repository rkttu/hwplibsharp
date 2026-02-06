// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/Numbering.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.Numbering;
using System;
using System.Collections.Generic;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 문단 번호 레코드
    /// </summary>
    public class NumberingInfo
    {
        private readonly List<LevelNumbering> _levelNumberingList;
        private int _startNumber;

        /// <summary>
        /// <see cref="NumberingInfo"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public NumberingInfo()
        {
            _levelNumberingList = new List<LevelNumbering>();
            CreateLevelNumberings();
        }

        /// <summary>
        /// 수준(1～10)에 해당하는 문단 번호 정보 객체를 생성한다.
        /// 5.0.2.5 이상 부터 8~10 추가됨
        /// </summary>
        private void CreateLevelNumberings()
        {
            for (int i = 0; i < 10; i++)
            {
                _levelNumberingList.Add(new LevelNumbering());
            }
        }

        /// <summary>
        /// level에 해당하는 문단 번호 정보 객체를 반환한다.
        /// </summary>
        /// <param name="level">문단 번호 정보 객체를 얻고자 하는 수준(1~10)</param>
        /// <returns>level에 해당하는 문단 번호 정보 객체</returns>
        public LevelNumbering GetLevelNumbering(int level)
        {
            if (level >= 1 && level <= 10)
            {
                return _levelNumberingList[level - 1];
            }
            throw new ArgumentException($"invalid level : {level}");
        }

        /// <summary>
        /// 수준별 문단 번호 정보의 읽기 전용 리스트를 가져옵니다.
        /// </summary>
        public IReadOnlyList<LevelNumbering> LevelNumberingList => _levelNumberingList;

        /// <summary>
        /// 문단 번호의 시작 번호를 가져오거나 설정합니다.
        /// </summary>
        public int StartNumber
        {
            get => _startNumber;
            set => _startNumber = value;
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="NumberingInfo"/>의 새 인스턴스입니다.</returns>
        public NumberingInfo Clone()
        {
            var cloned = new NumberingInfo();

            for (int i = 0; i < 10; i++)
            {
                cloned._levelNumberingList[i].Copy(_levelNumberingList[i]);
            }

            cloned._startNumber = _startNumber;
            return cloned;
        }
    }
}

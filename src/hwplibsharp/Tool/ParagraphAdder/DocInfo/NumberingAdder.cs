// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/NumberingAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.Numbering;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 Numbering을 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class NumberingAdder
    {
        private readonly DocInfoAdder _docInfoAdder;
        private readonly Dictionary<int, int> _idMatchingMap;

        /// <summary>
        /// NumberingAdder 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">DocInfoAdder 인스턴스</param>
        public NumberingAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
            _idMatchingMap = new Dictionary<int, int>();
        }

        /// <summary>
        /// 소스 ID를 기반으로 Numbering을 처리하고 대상 ID를 반환합니다.
        /// </summary>
        /// <param name="sourceId">소스 Numbering ID</param>
        /// <returns>대상 Numbering ID</returns>
        public int ProcessById(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            if (_idMatchingMap.TryGetValue(sourceId, out int cachedId))
            {
                return cachedId;
            }
            else
            {
                // id == index + 1
                NumberingInfo? source;
                try
                {
                    var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.NumberingList;
                    if (list == null || sourceId - 1 < 0 || sourceId - 1 >= list.Count)
                    {
                        return sourceId;
                    }
                    source = list[sourceId - 1];
                }
                catch
                {
                    return sourceId;
                }

                int id = FindFromTarget(source);
                if (id == -1)
                {
                    id = AddAndCopy(source);
                }
                _idMatchingMap[sourceId] = id;
                return id;
            }
        }

        private int FindFromTarget(NumberingInfo source)
        {
            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.NumberingList;
            if (list == null) return -1;

            int count = list.Count;
            for (int index = 0; index < count; index++)
            {
                var target = list[index];
                if (Equal(source, target))
                {
                    return index + 1;
                }
            }
            return -1;
        }

        private bool Equal(NumberingInfo? source, NumberingInfo? target)
        {
            if (source == null || target == null) return source == target;

            return EqualLevelNumberingList(source, target)
                && source.StartNumber == target.StartNumber;
        }

        private bool EqualLevelNumberingList(NumberingInfo source, NumberingInfo target)
        {
            for (int level = 0; level < 7; level++)
            {
                try
                {
                    if (!EqualLevelNumbering(source.GetLevelNumbering(level), target.GetLevelNumbering(level)))
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private bool EqualLevelNumbering(LevelNumbering? source, LevelNumbering? target)
        {
            if (source == null || target == null) return source == target;

            return EqualParagraphHeadInfo(source.ParagraphHeadInfo, target.ParagraphHeadInfo)
                && source.NumberFormat?.Equals(target.NumberFormat) == true
                && source.StartNumber == target.StartNumber;
        }

        private bool EqualParagraphHeadInfo(ParagraphHeadInfo? source, ParagraphHeadInfo? target)
        {
            if (source == null || target == null) return source == target;

            return source.Property?.Value == target.Property?.Value
                && source.CorrectionValueForWidth == target.CorrectionValueForWidth
                && source.DistanceFromBody == target.DistanceFromBody
                && _docInfoAdder.ForCharShapeInfo().EqualById((int)source.CharShapeID, (int)target.CharShapeID);
        }

        private int AddAndCopy(NumberingInfo source)
        {
            var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.AddNewNumbering();
            if (target == null) return -1;

            for (int level = 0; level < 10; level++)
            {
                try
                {
                    CopyLevelNumbering(source.GetLevelNumbering(level), target.GetLevelNumbering(level));
                }
                catch
                {
                    // Ignore
                }
            }
            target.StartNumber = source.StartNumber;

            return _docInfoAdder.GetTargetHWPFile()?.DocInfo?.NumberingList?.Count ?? -1;
        }

        private void CopyLevelNumbering(LevelNumbering? source, LevelNumbering? target)
        {
            if (source == null || target == null) return;

            CopyParagraphHeadInfo(source.ParagraphHeadInfo, target.ParagraphHeadInfo);
            target.NumberFormat?.Copy(source.NumberFormat);
            target.StartNumber = source.StartNumber;
        }

        private void CopyParagraphHeadInfo(ParagraphHeadInfo? source, ParagraphHeadInfo? target)
        {
            if (source == null || target == null) return;

            if (target.Property != null && source.Property != null)
            {
                target.Property.Value = source.Property.Value;
            }
            target.CorrectionValueForWidth = source.CorrectionValueForWidth;
            target.DistanceFromBody = source.DistanceFromBody;
            target.CharShapeID = (uint)_docInfoAdder.ForCharShapeInfo().ProcessById((int)source.CharShapeID);
        }

        /// <summary>
        /// 소스 ID와 대상 ID를 기반으로 두 Numbering이 동일한지 비교합니다.
        /// </summary>
        /// <param name="sourceId">소스 Numbering ID</param>
        /// <param name="targetId">대상 Numbering ID</param>
        /// <returns>두 Numbering이 동일하면 true, 그렇지 않으면 false</returns>
        public bool EqualById(int sourceId, int targetId)
        {
            try
            {
                var source = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.NumberingList?[sourceId - 1];
                var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.NumberingList?[targetId - 1];
                return Equal(source, target);
            }
            catch
            {
                return false;
            }
        }
    }
}

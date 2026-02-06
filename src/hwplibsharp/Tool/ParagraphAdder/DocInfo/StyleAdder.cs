// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/StyleAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 Style을 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class StyleAdder
    {
        private readonly DocInfoAdder _docInfoAdder;
        private readonly Dictionary<int, int> _idMatchingMap;

        /// <summary>
        /// <see cref="StyleAdder"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">DocInfo 복사 작업을 위한 <see cref="DocInfoAdder"/> 인스턴스</param>
        public StyleAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
            _idMatchingMap = new Dictionary<int, int>();
        }

        /// <summary>
        /// 원본 StyleInfo의 ID를 대상 문서에 맞게 변환하여 반환합니다.
        /// 이미 복사된 경우 매핑된 ID를 반환하며, 그렇지 않으면 복사 후 매핑합니다.
        /// </summary>
        /// <param name="sourceId">원본 StyleInfo의 ID</param>
        /// <returns>대상 문서의 StyleInfo ID</returns>
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
                // id == index
                StyleInfo? source;
                try
                {
                    var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.StyleList;
                    if (list == null || sourceId < 0 || sourceId >= list.Count)
                    {
                        return sourceId;
                    }
                    source = list[sourceId];
                }
                catch
                {
                    return sourceId;
                }

                int id = FindFromTarget(source, sourceId);
                if (id == -1)
                {
                    id = AddAndCopy(source, sourceId);
                }
                _idMatchingMap[sourceId] = id;
                return id;
            }
        }

        private int FindFromTarget(StyleInfo source, int sourceId)
        {
            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.StyleList;
            if (list == null) return -1;

            int count = list.Count;
            for (int index = 0; index < count; index++)
            {
                var target = list[index];
                if (Equal(source, target, sourceId, index))
                {
                    return index;
                }
            }
            return -1;
        }

        private bool Equal(StyleInfo? source, StyleInfo? target, int sourceId, int targetId)
        {
            if (source == null || target == null) return source == target;

            return source.HangulName == target.HangulName
                && source.EnglishName == target.EnglishName
                && source.Property.Value == target.Property.Value
                && EqualNextStyleId(source.NextStyleId, target.NextStyleId, sourceId, targetId)
                && source.LanguageId == target.LanguageId
                && _docInfoAdder.ForParaShapeInfo().EqualById(source.ParaShapeId, target.ParaShapeId)
                && _docInfoAdder.ForCharShapeInfo().EqualById(source.CharShapeId, target.CharShapeId);
        }

        private bool EqualNextStyleId(short sourceNextStyleId, short targetNextStyleId, int sourceId, int targetId)
        {
            if (sourceNextStyleId == sourceId && targetNextStyleId == targetId)
            {
                return true;
            }
            else if (sourceNextStyleId == sourceId || targetNextStyleId == targetId)
            {
                return false;
            }
            return EqualById(sourceNextStyleId, targetNextStyleId);
        }

        private int AddAndCopy(StyleInfo source, int sourceId)
        {
            var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.AddNewStyle();
            if (target == null) return -1;

            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.StyleList;
            int targetId = (list?.Count ?? 1) - 1;

            target.HangulName = source.HangulName;
            target.EnglishName = source.EnglishName;
            if (source.Property != null)
                target.Property.Value = source.Property.Value;

            if (source.NextStyleId == sourceId)
            {
                target.NextStyleId = (short)targetId;
            }
            else
            {
                target.NextStyleId = (short)ProcessById(source.NextStyleId);
            }

            target.LanguageId = source.LanguageId;
            target.ParaShapeId = _docInfoAdder.ForParaShapeInfo().ProcessById(source.ParaShapeId);
            target.CharShapeId = _docInfoAdder.ForCharShapeInfo().ProcessById(source.CharShapeId);

            return targetId;
        }

        /// <summary>
        /// sourceId와 targetId에 해당하는 StyleInfo가 동일한지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 StyleInfo의 ID</param>
        /// <param name="targetId">대상 StyleInfo의 ID</param>
        /// <returns>동일하면 true, 다르면 false</returns>
        public bool EqualById(short sourceId, short targetId)
        {
            try
            {
                var source = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.StyleList[sourceId];
                var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.StyleList[targetId];
                return Equal(source, target, sourceId, targetId);
            }
            catch
            {
                return false;
            }
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/ParaShapeAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.ParaShape;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 ParaShapeInfo을 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class ParaShapeInfoAdder
    {
        private readonly DocInfoAdder _docInfoAdder;
        private readonly Dictionary<int, int> _idMatchingMap;

        /// <summary>
        /// <see cref="ParaShapeInfoAdder"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">문서 정보 복사에 사용되는 <see cref="DocInfoAdder"/> 인스턴스입니다.</param>
        public ParaShapeInfoAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
            _idMatchingMap = new Dictionary<int, int>();
        }

        /// <summary>
        /// 소스 ParaShapeInfo의 ID를 기준으로 대상 문서에 복사하고, 매칭되는 대상 ID를 반환합니다.
        /// </summary>
        /// <param name="sourceId">소스 ParaShapeInfo의 ID(인덱스)</param>
        /// <returns>대상 문서의 ParaShapeInfo ID(인덱스)</returns>
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
                ParaShapeInfo? source;
                try
                {
                    var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.ParaShapeList;
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

                int id = FindFromTarget(source);
                if (id == -1)
                {
                    id = AddAndCopy(source);
                }
                _idMatchingMap[sourceId] = id;
                return id;
            }
        }

        private int FindFromTarget(ParaShapeInfo source)
        {
            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.ParaShapeList;
            if (list == null) return -1;

            int count = list.Count;
            for (int index = 0; index < count; index++)
            {
                var target = list[index];
                if (Equal(source, target))
                {
                    return index;
                }
            }
            return -1;
        }

        private bool Equal(ParaShapeInfo? source, ParaShapeInfo? target)
        {
            if (source == null || target == null) return source == target;

            return source.Property1?.Value == target.Property1?.Value
                && source.LeftMargin == target.LeftMargin
                && source.RightMargin == target.RightMargin
                && source.Indent == target.Indent
                && source.TopParaSpace == target.TopParaSpace
                && source.BottomParaSpace == target.BottomParaSpace
                && source.LineSpace == target.LineSpace
                && _docInfoAdder.ForTabDefInfo().EqualById(source.TabDefId, target.TabDefId)
                && EqualParaHead(source, target)
                && _docInfoAdder.ForBorderFillInfo().EqualById(source.BorderFillId, target.BorderFillId)
                && source.LeftBorderSpace == target.LeftBorderSpace
                && source.RightBorderSpace == target.RightBorderSpace
                && source.TopBorderSpace == target.TopBorderSpace
                && source.BottomBorderSpace == target.BottomBorderSpace
                && source.Property2?.Value == target.Property2?.Value
                && source.Property3?.Value == target.Property3?.Value
                && source.LineSpace2 == target.LineSpace2
                && source.ParaLevel == target.ParaLevel;
        }

        private bool EqualParaHead(ParaShapeInfo source, ParaShapeInfo target)
        {
            var sourceShape = source.Property1?.ParaHeadShape;
            var targetShape = target.Property1?.ParaHeadShape;

            if (sourceShape == targetShape)
            {
                switch (sourceShape)
                {
                    case ParaHeadShape.None:
                        return true;
                    case ParaHeadShape.Numbering:
                    case ParaHeadShape.Outline:
                        if (source.ParaHeadId > 0)
                        {
                            return _docInfoAdder.ForNumbering().EqualById(source.ParaHeadId, target.ParaHeadId);
                        }
                        else
                        {
                            return false;
                        }
                    case ParaHeadShape.Bullet:
                        return _docInfoAdder.ForBullet().EqualById(source.ParaHeadId, target.ParaHeadId);
                }
            }
            return false;
        }

        private int AddAndCopy(ParaShapeInfo source)
        {
            var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.AddNewParaShape();
            if (target == null) return -1;

            target.Property1.Value = source.Property1.Value;
            target.LeftMargin = source.LeftMargin;
            target.RightMargin = source.RightMargin;
            target.Indent = source.Indent;
            target.TopParaSpace = source.TopParaSpace;
            target.BottomParaSpace = source.BottomParaSpace;
            target.LineSpace = source.LineSpace;
            target.TabDefId = _docInfoAdder.ForTabDefInfo().ProcessById(source.TabDefId);
            SetParaHead(source, target);
            target.BorderFillId = _docInfoAdder.ForBorderFillInfo().ProcessById(source.BorderFillId);
            target.LeftBorderSpace = source.LeftBorderSpace;
            target.RightBorderSpace = source.RightBorderSpace;
            target.TopBorderSpace = source.TopBorderSpace;
            target.BottomBorderSpace = source.BottomBorderSpace;
            target.Property2.Value = source.Property2.Value;
            target.Property3.Value = source.Property3.Value;
            target.LineSpace2 = source.LineSpace2;
            target.ParaLevel = source.ParaLevel;

            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.ParaShapeList;
            return (list?.Count ?? 1) - 1;
        }

        private void SetParaHead(ParaShapeInfo source, ParaShapeInfo target)
        {
            var shape = source.Property1?.ParaHeadShape;
            switch (shape)
            {
                case ParaHeadShape.None:
                    target.ParaHeadId = 0;
                    break;
                case ParaHeadShape.Numbering:
                case ParaHeadShape.Outline:
                    if (source.ParaHeadId > 0)
                    {
                        target.ParaHeadId = _docInfoAdder.ForNumbering().ProcessById(source.ParaHeadId);
                    }
                    else
                    {
                        target.ParaHeadId = 0;
                    }
                    break;
                case ParaHeadShape.Bullet:
                    target.ParaHeadId = _docInfoAdder.ForBullet().ProcessById(source.ParaHeadId);
                    break;
            }
        }

        /// <summary>
        /// 소스 ParaShapeInfo와 대상 ParaShapeInfo의 ID(인덱스)를 기준으로 두 객체가 동일한지 비교합니다.
        /// </summary>
        /// <param name="sourceId">소스 ParaShapeInfo의 ID(인덱스)</param>
        /// <param name="targetId">대상 ParaShapeInfo의 ID(인덱스)</param>
        /// <returns>두 ParaShapeInfo가 동일하면 true, 그렇지 않으면 false를 반환합니다.</returns>
        public bool EqualById(int sourceId, int targetId)
        {
            try
            {
                var source = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.ParaShapeList?[sourceId];
                var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.ParaShapeList?[targetId];
                return Equal(source, target);
            }
            catch
            {
                return false;
            }
        }
    }
}

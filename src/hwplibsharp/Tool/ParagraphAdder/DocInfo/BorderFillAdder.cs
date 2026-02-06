// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/BorderFillAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.BorderFill;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 BorderFillInfo을 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class BorderFillInfoAdder
    {
        private readonly DocInfoAdder _docInfoAdder;
        private readonly Dictionary<int, int> _idMatchingMap;

        /// <summary>
        /// <see cref="BorderFillInfoAdder"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">복사 작업에 사용할 <see cref="DocInfoAdder"/> 인스턴스입니다.</param>
        public BorderFillInfoAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
            _idMatchingMap = new Dictionary<int, int>();
        }

        /// <summary>
        /// 소스 BorderFillInfo의 ID를 타겟 BorderFillInfo의 ID로 변환합니다.
        /// 이미 복사된 경우 매핑된 ID를 반환하고, 그렇지 않으면 복사 후 새 ID를 반환합니다.
        /// </summary>
        /// <param name="sourceId">소스 BorderFillInfo의 ID</param>
        /// <returns>타겟 BorderFillInfo의 ID</returns>
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
                BorderFillInfo? source = null;
                try
                {
                    var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.BorderFillList;
                    if (list != null && sourceId - 1 >= 0 && sourceId - 1 < list.Count)
                    {
                        source = list[sourceId - 1];
                    }
                }
                catch
                {
                    return sourceId;
                }

                if (source == null) return sourceId;

                int id = FindFromTarget(source);
                if (id == -1)
                {
                    id = AddAndCopy(source);
                }
                _idMatchingMap[sourceId] = id;
                return id;
            }
        }

        private int FindFromTarget(BorderFillInfo source)
        {
            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.BorderFillList;
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

        private static bool Equal(BorderFillInfo? source, BorderFillInfo? target)
        {
            if (source == null || target == null)
            {
                return source == target;
            }

            return source.Property?.Value == target.Property?.Value
                && EqualEachBorder(source.LeftBorder, target.LeftBorder)
                && EqualEachBorder(source.RightBorder, target.RightBorder)
                && EqualEachBorder(source.TopBorder, target.TopBorder)
                && EqualEachBorder(source.BottomBorder, target.BottomBorder)
                && EqualEachBorder(source.DiagonalBorder, target.DiagonalBorder)
                && ForFillInfo.Equal(source.FillInfo, target.FillInfo);
        }

        private static bool EqualEachBorder(EachBorder? source, EachBorder? target)
        {
            if (source == null || target == null) return source == target;

            return source.Type == target.Type
                && source.Thickness == target.Thickness
                && source.Color?.Value == target.Color?.Value;
        }

        private int AddAndCopy(BorderFillInfo source)
        {
            var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.AddNewBorderFill();
            if (target == null) return -1;

            if (target.Property != null && source.Property != null)
            {
                target.Property.Value = source.Property.Value;
            }
            CopyEachBorder(source.LeftBorder, target.LeftBorder);
            CopyEachBorder(source.RightBorder, target.RightBorder);
            CopyEachBorder(source.TopBorder, target.TopBorder);
            CopyEachBorder(source.BottomBorder, target.BottomBorder);
            CopyEachBorder(source.DiagonalBorder, target.DiagonalBorder);
            ForFillInfo.Copy(source.FillInfo, target.FillInfo, _docInfoAdder);

            return _docInfoAdder.GetTargetHWPFile()?.DocInfo?.BorderFillList?.Count ?? -1;
        }

        private static void CopyEachBorder(EachBorder? source, EachBorder? target)
        {
            if (source == null || target == null) return;

            target.Type = source.Type;
            target.Thickness = source.Thickness;
            if (target.Color != null && source.Color != null)
            {
                target.Color.Value = source.Color.Value;
            }
        }

        /// <summary>
        /// 소스와 타겟 BorderFillInfo의 ID를 비교하여 동일한 BorderFillInfo인지 여부를 반환합니다.
        /// </summary>
        /// <param name="sourceId">소스 BorderFillInfo의 ID</param>
        /// <param name="targetId">타겟 BorderFillInfo의 ID</param>
        /// <returns>두 BorderFillInfo가 동일하면 true, 그렇지 않으면 false를 반환합니다.</returns>
        public bool EqualById(int sourceId, int targetId)
        {
            if (sourceId == 0 || targetId == 0)
            {
                return sourceId == targetId;
            }

            var source = GetBorderFillInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.BorderFillList, sourceId - 1);
            var target = GetBorderFillInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.BorderFillList, targetId - 1);
            return Equal(source, target);
        }

        private static BorderFillInfo? GetBorderFillInfo(IReadOnlyList<BorderFillInfo>? borderFillList, int index)
        {
            if (borderFillList == null) return null;

            int count = borderFillList.Count;
            if (count == 0)
            {
                return null;
            }
            if (index >= count)
            {
                return borderFillList[count - 1];
            }
            else if (index < 0)
            {
                return borderFillList[0];
            }
            else
            {
                return borderFillList[index];
            }
        }
    }
}

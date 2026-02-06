// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/CharShapeAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.CharShape;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 CharShapeInfo을 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class CharShapeInfoAdder
    {
        private readonly DocInfoAdder _docInfoAdder;
        private readonly Dictionary<int, int> _idMatchingMap;

        /// <summary>
        /// CharShapeInfoAdder 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">DocInfoAdder 인스턴스</param>
        public CharShapeInfoAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
            _idMatchingMap = new Dictionary<int, int>();
        }

        /// <summary>
        /// 소스 ID를 기반으로 CharShapeInfo를 처리하고 대상 ID를 반환합니다.
        /// </summary>
        /// <param name="sourceId">소스 CharShapeInfo ID</param>
        /// <returns>대상 CharShapeInfo ID</returns>
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
                CharShapeInfo? source;
                try
                {
                    var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.CharShapeList;
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

        private int FindFromTarget(CharShapeInfo source)
        {
            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.CharShapeList;
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

        /// <summary>
        /// 두 CharShapeInfo 객체가 동일한지 비교합니다.
        /// </summary>
        /// <param name="source">소스 CharShapeInfo</param>
        /// <param name="target">대상 CharShapeInfo</param>
        /// <returns>두 객체가 동일하면 true, 그렇지 않으면 false</returns>
        public bool Equal(CharShapeInfo? source, CharShapeInfo? target)
        {
            if (source == null || target == null) return source == target;

            return EqualFaceNameIds(source.FaceNameIds, target.FaceNameIds)
                && EqualRatios(source.Ratios, target.Ratios)
                && EqualCharSpaces(source.CharSpaces, target.CharSpaces)
                && EqualRelativeSizes(source.RelativeSizes, target.RelativeSizes)
                && EqualCharOffsets(source.CharOffsets, target.CharOffsets)
                && source.BaseSize == target.BaseSize
                && source.Property?.Value == target.Property?.Value
                && source.ShadowGap1 == target.ShadowGap1
                && source.ShadowGap2 == target.ShadowGap2
                && source.CharColor?.Value == target.CharColor?.Value
                && source.UnderLineColor?.Value == target.UnderLineColor?.Value
                && source.ShadeColor?.Value == target.ShadeColor?.Value
                && source.ShadowColor?.Value == target.ShadowColor?.Value
                && _docInfoAdder.ForBorderFillInfo().EqualById(source.BorderFillId, target.BorderFillId)
                && source.StrikeLineColor?.Value == target.StrikeLineColor?.Value;
        }

        private bool EqualFaceNameIds(FaceNameIds? source, FaceNameIds? target)
        {
            if (source == null || target == null) return source == target;

            return _docInfoAdder.ForFaceNameInfo().EqualByHangulId(source.Hangul, target.Hangul)
                && _docInfoAdder.ForFaceNameInfo().EqualByLatinId(source.Latin, target.Latin)
                && _docInfoAdder.ForFaceNameInfo().EqualByHanjaId(source.Hanja, target.Hanja)
                && _docInfoAdder.ForFaceNameInfo().EqualByJapaneseId(source.Japanese, target.Japanese)
                && _docInfoAdder.ForFaceNameInfo().EqualByOtherId(source.Other, target.Other)
                && _docInfoAdder.ForFaceNameInfo().EqualBySymbolId(source.Symbol, target.Symbol)
                && _docInfoAdder.ForFaceNameInfo().EqualByUserId(source.User, target.User);
        }

        private static bool EqualRatios(Ratios? source, Ratios? target)
        {
            if (source == null || target == null) return source == target;

            var sourceArray = source.Array;
            var targetArray = target.Array;
            if (sourceArray == null || targetArray == null) return sourceArray == targetArray;
            if (sourceArray.Length != targetArray.Length) return false;

            for (int index = 0; index < 7 && index < sourceArray.Length; index++)
            {
                if (sourceArray[index] != targetArray[index])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool EqualCharSpaces(CharSpaces? source, CharSpaces? target)
        {
            if (source == null || target == null) return source == target;

            var sourceArray = source.Array;
            var targetArray = target.Array;
            if (sourceArray == null || targetArray == null) return sourceArray == targetArray;
            if (sourceArray.Length != targetArray.Length) return false;

            for (int index = 0; index < 7 && index < sourceArray.Length; index++)
            {
                if (sourceArray[index] != targetArray[index])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool EqualRelativeSizes(RelativeSizes? source, RelativeSizes? target)
        {
            if (source == null || target == null) return source == target;

            var sourceArray = source.Array;
            var targetArray = target.Array;
            if (sourceArray == null || targetArray == null) return sourceArray == targetArray;
            if (sourceArray.Length != targetArray.Length) return false;

            for (int index = 0; index < 7 && index < sourceArray.Length; index++)
            {
                if (sourceArray[index] != targetArray[index])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool EqualCharOffsets(CharOffsets? source, CharOffsets? target)
        {
            if (source == null || target == null) return source == target;

            var sourceArray = source.Array;
            var targetArray = target.Array;
            if (sourceArray == null || targetArray == null) return sourceArray == targetArray;
            if (sourceArray.Length != targetArray.Length) return false;

            for (int index = 0; index < 7 && index < sourceArray.Length; index++)
            {
                if (sourceArray[index] != targetArray[index])
                {
                    return false;
                }
            }
            return true;
        }

        private int AddAndCopy(CharShapeInfo source)
        {
            var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.AddNewCharShape();
            if (target == null) return -1;

            CopyFaceNameIds(source.FaceNameIds, target.FaceNameIds);
            CopyRatios(source.Ratios, target.Ratios);
            CopyCharSpaces(source.CharSpaces, target.CharSpaces);
            CopyRelativeSizes(source.RelativeSizes, target.RelativeSizes);
            CopyCharOffsets(source.CharOffsets, target.CharOffsets);
            target.BaseSize = source.BaseSize;
            if (target.Property != null && source.Property != null)
                target.Property.Value = source.Property.Value;
            target.ShadowGap1 = source.ShadowGap1;
            target.ShadowGap2 = source.ShadowGap2;
            if (target.CharColor != null && source.CharColor != null)
                target.CharColor.Value = source.CharColor.Value;
            if (target.UnderLineColor != null && source.UnderLineColor != null)
                target.UnderLineColor.Value = source.UnderLineColor.Value;
            if (target.ShadeColor != null && source.ShadeColor != null)
                target.ShadeColor.Value = source.ShadeColor.Value;
            if (target.ShadowColor != null && source.ShadowColor != null)
                target.ShadowColor.Value = source.ShadowColor.Value;
            if (source.BorderFillId == 0)
            {
                target.BorderFillId = 0;
            }
            else
            {
                target.BorderFillId = _docInfoAdder.ForBorderFillInfo().ProcessById(source.BorderFillId);
            }
            if (target.StrikeLineColor != null && source.StrikeLineColor != null)
                target.StrikeLineColor.Value = source.StrikeLineColor.Value;

            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.CharShapeList;
            return (list?.Count ?? 1) - 1;
        }

        private void CopyFaceNameIds(FaceNameIds? source, FaceNameIds? target)
        {
            if (source == null || target == null) return;

            target.Hangul = _docInfoAdder.ForFaceNameInfo().ProcessByHangulId(source.Hangul);
            target.Latin = _docInfoAdder.ForFaceNameInfo().ProcessByLatinId(source.Latin);
            target.Hanja = _docInfoAdder.ForFaceNameInfo().ProcessByHanjaId(source.Hanja);
            target.Japanese = _docInfoAdder.ForFaceNameInfo().ProcessByJapaneseId(source.Japanese);
            target.Other = _docInfoAdder.ForFaceNameInfo().ProcessByOtherId(source.Other);
            target.Symbol = _docInfoAdder.ForFaceNameInfo().ProcessBySymbolId(source.Symbol);
            target.User = _docInfoAdder.ForFaceNameInfo().ProcessByUserId(source.User);
        }

        private static void CopyRatios(Ratios? source, Ratios? target)
        {
            if (source == null || target == null) return;

            target.Hangul = source.Hangul;
            target.Latin = source.Latin;
            target.Hanja = source.Hanja;
            target.Japanese = source.Japanese;
            target.Other = source.Other;
            target.Symbol = source.Symbol;
            target.User = source.User;
        }

        private static void CopyCharSpaces(CharSpaces? source, CharSpaces? target)
        {
            if (source == null || target == null) return;

            target.Hangul = source.Hangul;
            target.Latin = source.Latin;
            target.Hanja = source.Hanja;
            target.Japanese = source.Japanese;
            target.Other = source.Other;
            target.Symbol = source.Symbol;
            target.User = source.User;
        }

        private static void CopyRelativeSizes(RelativeSizes? source, RelativeSizes? target)
        {
            if (source == null || target == null) return;

            target.Hangul = source.Hangul;
            target.Latin = source.Latin;
            target.Hanja = source.Hanja;
            target.Japanese = source.Japanese;
            target.Other = source.Other;
            target.Symbol = source.Symbol;
            target.User = source.User;
        }

        private static void CopyCharOffsets(CharOffsets? source, CharOffsets? target)
        {
            if (source == null || target == null) return;

            target.Hangul = source.Hangul;
            target.Latin = source.Latin;
            target.Hanja = source.Hanja;
            target.Japanese = source.Japanese;
            target.Other = source.Other;
            target.Symbol = source.Symbol;
            target.User = source.User;
        }

        /// <summary>
        /// 소스 ID와 대상 ID를 기반으로 두 CharShapeInfo가 동일한지 비교합니다.
        /// </summary>
        /// <param name="sourceId">소스 CharShapeInfo ID</param>
        /// <param name="targetId">대상 CharShapeInfo ID</param>
        /// <returns>두 CharShapeInfo가 동일하면 true, 그렇지 않으면 false</returns>
        public bool EqualById(int sourceId, int targetId)
        {
            CharShapeInfo? source = null;
            CharShapeInfo? target = null;

            try
            {
                var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.CharShapeList;
                if (list != null && sourceId - 1 >= 0 && sourceId - 1 < list.Count)
                {
                    source = list[sourceId - 1];
                }
            }
            catch { }

            try
            {
                var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.CharShapeList;
                if (list != null && targetId - 1 >= 0 && targetId - 1 < list.Count)
                {
                    target = list[targetId - 1];
                }
            }
            catch { }

            if (source == null && target == null)
            {
                return sourceId == targetId;
            }
            else if (source == null || target == null)
            {
                return false;
            }
            else
            {
                return Equal(source, target);
            }
        }
    }
}

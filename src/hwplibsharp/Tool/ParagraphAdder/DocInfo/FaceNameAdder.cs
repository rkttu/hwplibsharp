// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/FaceNameAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.FaceName;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 FaceNameInfo을 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class FaceNameInfoAdder
    {
        private readonly DocInfoAdder _docInfoAdder;

        /// <summary>
        /// FaceNameInfoAdder 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">DocInfoAdder 인스턴스</param>
        public FaceNameInfoAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
        }

        /// <summary>
        /// 한글 FaceNameInfo를 복사하고 대상에 추가합니다.
        /// </summary>
        /// <param name="sourceId">원본 FaceNameInfo의 인덱스</param>
        /// <returns>대상 FaceNameInfo의 인덱스</returns>
        public int ProcessByHangulId(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            var sourceList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.HangulFaceNameList;
            var targetDocInfo = _docInfoAdder.GetTargetHWPFile()?.DocInfo;
            if (sourceList == null || targetDocInfo == null) return sourceId;

            var source = GetFaceNameInfo(sourceList, sourceId);
            return Process(source, targetDocInfo.HangulFaceNameList, targetDocInfo.AddNewHangulFaceName);
        }

        private static FaceNameInfo? GetFaceNameInfo(IReadOnlyList<FaceNameInfo>? faceNameList, int index)
        {
            if (faceNameList == null) return null;

            int count = faceNameList.Count;
            if (count == 0) return null;
            if (index >= count)
            {
                return faceNameList[count - 1];
            }
            else if (index < 0)
            {
                return faceNameList[0];
            }
            else
            {
                return faceNameList[index];
            }
        }

        private static int Process(FaceNameInfo? source, IReadOnlyList<FaceNameInfo>? targetList, System.Func<FaceNameInfo>? addNewFunc)
        {
            if (source == null || targetList == null || addNewFunc == null) return 0;

            int index = Find(source, targetList);
            if (index == -1)
            {
                index = AddAndCopy(source, addNewFunc, targetList);
            }
            return index;
        }

        private static int Find(FaceNameInfo source, IReadOnlyList<FaceNameInfo> targetList)
        {
            int count = targetList.Count;
            for (int index = 0; index < count; index++)
            {
                var target = targetList[index];
                if (Equal(source, target))
                {
                    return index;
                }
            }
            return -1;
        }

        private static bool Equal(FaceNameInfo? source, FaceNameInfo? target)
        {
            if (source == null || target == null) return source == target;

            return source.Property?.Value == target.Property?.Value
                && source.Name == target.Name
                && source.SubstituteFontType == target.SubstituteFontType
                && EqualNullableString(source.SubstituteFontName, target.SubstituteFontName)
                && EqualFontTypeInfo(source.FontTypeInfo, target.FontTypeInfo)
                && source.BaseFontName == target.BaseFontName;
        }

        private static bool EqualNullableString(string? source, string? target)
        {
            if (source == null && target == null)
            {
                return true;
            }
            return source?.Equals(target) == true;
        }

        private static bool EqualFontTypeInfo(FontTypeInfo? source, FontTypeInfo? target)
        {
            if (source == null || target == null) return source == target;

            return source.FontType == target.FontType
                && source.SerifType == target.SerifType
                && source.Thickness == target.Thickness
                && source.Ratio == target.Ratio
                && source.Contrast == target.Contrast
                && source.StrokeDeviation == target.StrokeDeviation
                && source.CharacterStrokeType == target.CharacterStrokeType
                && source.CharacterShape == target.CharacterShape
                && source.MiddleLine == target.MiddleLine
                && source.XHeight == target.XHeight;
        }

        private static int AddAndCopy(FaceNameInfo source, System.Func<FaceNameInfo> addNewFunc, IReadOnlyList<FaceNameInfo> targetList)
        {
            var target = addNewFunc();

            if (source.Property != null && target.Property != null)
                target.Property.Value = source.Property.Value;
            target.Name = source.Name;
            target.SubstituteFontType = source.SubstituteFontType;
            target.SubstituteFontName = source.SubstituteFontName;
            CopyFontTypeInfo(source.FontTypeInfo, target.FontTypeInfo);
            target.BaseFontName = source.BaseFontName;

            return targetList.Count - 1;
        }

        private static void CopyFontTypeInfo(FontTypeInfo? source, FontTypeInfo? target)
        {
            if (source == null || target == null) return;

            target.FontType = source.FontType;
            target.SerifType = source.SerifType;
            target.Thickness = source.Thickness;
            target.Ratio = source.Ratio;
            target.Contrast = source.Contrast;
            target.StrokeDeviation = source.StrokeDeviation;
            target.CharacterStrokeType = source.CharacterStrokeType;
            target.CharacterShape = source.CharacterShape;
            target.MiddleLine = source.MiddleLine;
            target.XHeight = source.XHeight;
        }

        /// <summary>
        /// 라틴 FaceNameInfo를 복사하고 대상에 추가합니다.
        /// </summary>
        /// <param name="sourceId">원본 FaceNameInfo의 인덱스</param>
        /// <returns>대상 FaceNameInfo의 인덱스</returns>
        public int ProcessByLatinId(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            var sourceList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.EnglishFaceNameList;
            var targetDocInfo = _docInfoAdder.GetTargetHWPFile()?.DocInfo;
            if (sourceList == null || targetDocInfo == null) return sourceId;

            var source = GetFaceNameInfo(sourceList, sourceId);
            return Process(source, targetDocInfo.EnglishFaceNameList, targetDocInfo.AddNewEnglishFaceName);
        }

        /// <summary>
        /// 한자 FaceNameInfo를 복사하고 대상에 추가합니다.
        /// </summary>
        /// <param name="sourceId">원본 FaceNameInfo의 인덱스</param>
        /// <returns>대상 FaceNameInfo의 인덱스</returns>
        public int ProcessByHanjaId(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            var sourceList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.HanjaFaceNameList;
            var targetDocInfo = _docInfoAdder.GetTargetHWPFile()?.DocInfo;
            if (sourceList == null || targetDocInfo == null) return sourceId;

            var source = GetFaceNameInfo(sourceList, sourceId);
            return Process(source, targetDocInfo.HanjaFaceNameList, targetDocInfo.AddNewHanjaFaceName);
        }

        /// <summary>
        /// 일본어 FaceNameInfo를 복사하고 대상에 추가합니다.
        /// </summary>
        /// <param name="sourceId">원본 FaceNameInfo의 인덱스</param>
        /// <returns>대상 FaceNameInfo의 인덱스</returns>
        public int ProcessByJapaneseId(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            var sourceList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.JapaneseFaceNameList;
            var targetDocInfo = _docInfoAdder.GetTargetHWPFile()?.DocInfo;
            if (sourceList == null || targetDocInfo == null) return sourceId;

            var source = GetFaceNameInfo(sourceList, sourceId);
            return Process(source, targetDocInfo.JapaneseFaceNameList, targetDocInfo.AddNewJapaneseFaceName);
        }

        /// <summary>
        /// 기타 FaceNameInfo를 복사하고 대상에 추가합니다.
        /// </summary>
        /// <param name="sourceId">원본 FaceNameInfo의 인덱스</param>
        /// <returns>대상 FaceNameInfo의 인덱스</returns>
        public int ProcessByOtherId(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            var sourceList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.EtcFaceNameList;
            var targetDocInfo = _docInfoAdder.GetTargetHWPFile()?.DocInfo;
            if (sourceList == null || targetDocInfo == null) return sourceId;

            var source = GetFaceNameInfo(sourceList, sourceId);
            return Process(source, targetDocInfo.EtcFaceNameList, targetDocInfo.AddNewEtcFaceName);
        }

        /// <summary>
        /// 심볼 FaceNameInfo를 복사하고 대상에 추가합니다.
        /// </summary>
        /// <param name="sourceId">원본 FaceNameInfo의 인덱스</param>
        /// <returns>대상 FaceNameInfo의 인덱스</returns>
        public int ProcessBySymbolId(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            var sourceList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.SymbolFaceNameList;
            var targetDocInfo = _docInfoAdder.GetTargetHWPFile()?.DocInfo;
            if (sourceList == null || targetDocInfo == null) return sourceId;

            var source = GetFaceNameInfo(sourceList, sourceId);
            return Process(source, targetDocInfo.SymbolFaceNameList, targetDocInfo.AddNewSymbolFaceName);
        }

        /// <summary>
        /// 사용자 정의 FaceNameInfo를 복사하고 대상에 추가합니다.
        /// </summary>
        /// <param name="sourceId">원본 FaceNameInfo의 인덱스</param>
        /// <returns>대상 FaceNameInfo의 인덱스</returns>
        public int ProcessByUserId(int sourceId)
        {
            if (_docInfoAdder.GetSourceHWPFile() == _docInfoAdder.GetTargetHWPFile())
            {
                return sourceId;
            }

            var sourceList = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.UserFaceNameList;
            var targetDocInfo = _docInfoAdder.GetTargetHWPFile()?.DocInfo;
            if (sourceList == null || targetDocInfo == null) return sourceId;

            var source = GetFaceNameInfo(sourceList, sourceId);
            return Process(source, targetDocInfo.UserFaceNameList, targetDocInfo.AddNewUserFaceName);
        }

        /// <summary>
        /// 한글 FaceNameInfo의 두 인덱스가 같은지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 인덱스</param>
        /// <param name="targetId">대상 인덱스</param>
        /// <returns>동일하면 true, 아니면 false</returns>
        public bool EqualByHangulId(int sourceId, int targetId)
        {
            var source = GetFaceNameInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.HangulFaceNameList, sourceId);
            var target = GetFaceNameInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.HangulFaceNameList, targetId);
            return Equal(source, target);
        }

        /// <summary>
        /// 라틴 FaceNameInfo의 두 인덱스가 같은지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 인덱스</param>
        /// <param name="targetId">대상 인덱스</param>
        /// <returns>동일하면 true, 아니면 false</returns>
        public bool EqualByLatinId(int sourceId, int targetId)
        {
            var source = GetFaceNameInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.EnglishFaceNameList, sourceId);
            var target = GetFaceNameInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.EnglishFaceNameList, targetId);
            return Equal(source, target);
        }

        /// <summary>
        /// 한자 FaceNameInfo의 두 인덱스가 같은지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 인덱스</param>
        /// <param name="targetId">대상 인덱스</param>
        /// <returns>동일하면 true, 아니면 false</returns>
        public bool EqualByHanjaId(int sourceId, int targetId)
        {
            var source = GetFaceNameInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.HanjaFaceNameList, sourceId);
            var target = GetFaceNameInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.HanjaFaceNameList, targetId);
            return Equal(source, target);
        }

        /// <summary>
        /// 일본어 FaceNameInfo의 두 인덱스가 같은지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 인덱스</param>
        /// <param name="targetId">대상 인덱스</param>
        /// <returns>동일하면 true, 아니면 false</returns>
        public bool EqualByJapaneseId(int sourceId, int targetId)
        {
            var source = GetFaceNameInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.JapaneseFaceNameList, sourceId);
            var target = GetFaceNameInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.JapaneseFaceNameList, targetId);
            return Equal(source, target);
        }

        /// <summary>
        /// 기타 FaceNameInfo의 두 인덱스가 같은지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 인덱스</param>
        /// <param name="targetId">대상 인덱스</param>
        /// <returns>동일하면 true, 아니면 false</returns>
        public bool EqualByOtherId(int sourceId, int targetId)
        {
            var source = GetFaceNameInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.EtcFaceNameList, sourceId);
            var target = GetFaceNameInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.EtcFaceNameList, targetId);
            return Equal(source, target);
        }

        /// <summary>
        /// 심볼 FaceNameInfo의 두 인덱스가 같은지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 인덱스</param>
        /// <param name="targetId">대상 인덱스</param>
        /// <returns>동일하면 true, 아니면 false</returns>
        public bool EqualBySymbolId(int sourceId, int targetId)
        {
            var source = GetFaceNameInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.SymbolFaceNameList, sourceId);
            var target = GetFaceNameInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.SymbolFaceNameList, targetId);
            return Equal(source, target);
        }

        /// <summary>
        /// 사용자 정의 FaceNameInfo의 두 인덱스가 같은지 비교합니다.
        /// </summary>
        /// <param name="sourceId">원본 인덱스</param>
        /// <param name="targetId">대상 인덱스</param>
        /// <returns>동일하면 true, 아니면 false</returns>
        public bool EqualByUserId(int sourceId, int targetId)
        {
            var source = GetFaceNameInfo(_docInfoAdder.GetSourceHWPFile()?.DocInfo?.UserFaceNameList, sourceId);
            var target = GetFaceNameInfo(_docInfoAdder.GetTargetHWPFile()?.DocInfo?.UserFaceNameList, targetId);
            return Equal(source, target);
        }
    }
}

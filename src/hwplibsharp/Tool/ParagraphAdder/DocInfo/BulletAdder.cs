// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/BulletAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.Numbering;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// DocInfo에 Bullet을 복사하는 기능을 포함하는 클래스
    /// </summary>
    public class BulletAdder
    {
        private readonly DocInfoAdder _docInfoAdder;
        private readonly Dictionary<int, int> _idMatchingMap;

        /// <summary>
        /// <see cref="BulletAdder"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="docInfoAdder">문서 정보 복사에 사용되는 <see cref="DocInfoAdder"/> 인스턴스입니다.</param>
        public BulletAdder(DocInfoAdder docInfoAdder)
        {
            _docInfoAdder = docInfoAdder;
            _idMatchingMap = new Dictionary<int, int>();
        }

        /// <summary>
        /// 소스 Bullet ID를 타겟 Bullet ID로 변환하여 반환합니다.
        /// 동일한 파일이면 원본 ID를 반환합니다.
        /// </summary>
        /// <param name="sourceId">소스 Bullet의 ID</param>
        /// <returns>타겟 Bullet의 ID</returns>
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
                Bullet? source;
                try
                {
                    var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.BulletList;
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

        private int FindFromTarget(Bullet source)
        {
            var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.BulletList;
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

        private bool Equal(Bullet? source, Bullet? target)
        {
            if (source == null || target == null) return source == target;

            return EqualParagraphHeadInfo(source.ParagraphHeadInfo, target.ParagraphHeadInfo)
                && source.BulletChar?.Equals(target.BulletChar) == true
                && source.CheckBulletChar?.Equals(target.CheckBulletChar) == true
                && (source.ImageBullet == target.ImageBullet) == false;
            // imageBulletInfo.binDataID 비교 불가
        }

        private bool EqualParagraphHeadInfo(ParagraphHeadInfo? source, ParagraphHeadInfo? target)
        {
            if (source == null || target == null) return source == target;

            return source.Property?.Value == target.Property?.Value
                && source.CorrectionValueForWidth == target.CorrectionValueForWidth
                && source.DistanceFromBody == target.DistanceFromBody
                && _docInfoAdder.ForCharShapeInfo().EqualById((int)source.CharShapeID, (int)target.CharShapeID);
        }

        private int AddAndCopy(Bullet source)
        {
            var target = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.AddNewBullet();
            if (target == null) return -1;

            CopyParagraphHeadInfo(source.ParagraphHeadInfo, target.ParagraphHeadInfo);
            target.BulletChar?.Copy(source.BulletChar);
            target.ImageBullet = source.ImageBullet;
            ForFillInfo.CopyPictureInfo(source.ImageBulletInfo, target.ImageBulletInfo, _docInfoAdder);
            target.CheckBulletChar?.Copy(source.CheckBulletChar);

            return _docInfoAdder.GetTargetHWPFile()?.DocInfo?.BulletList?.Count ?? -1;
        }

        private void CopyParagraphHeadInfo(ParagraphHeadInfo? source, ParagraphHeadInfo? target)
        {
            if (source == null || target == null) return;

            if (source.Property != null && target.Property != null)
                target.Property.Value = source.Property.Value;
            target.CorrectionValueForWidth = source.CorrectionValueForWidth;
            target.DistanceFromBody = source.DistanceFromBody;
            target.CharShapeID = (uint)_docInfoAdder.ForCharShapeInfo().ProcessById((int)source.CharShapeID);
        }

        /// <summary>
        /// 소스 Bullet ID와 타겟 Bullet ID에 해당하는 Bullet이 동일한지 비교합니다.
        /// </summary>
        /// <param name="sourceId">소스 Bullet의 ID</param>
        /// <param name="targetId">타겟 Bullet의 ID</param>
        /// <returns>두 Bullet이 동일하면 true, 그렇지 않으면 false를 반환합니다.</returns>
        public bool EqualById(int sourceId, int targetId)
        {
            Bullet? source = null;
            Bullet? target = null;

            try
            {
                var list = _docInfoAdder.GetSourceHWPFile()?.DocInfo?.BulletList;
                if (list != null && sourceId - 1 >= 0 && sourceId - 1 < list.Count)
                {
                    source = list[sourceId - 1];
                }
            }
            catch { }

            try
            {
                var list = _docInfoAdder.GetTargetHWPFile()?.DocInfo?.BulletList;
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

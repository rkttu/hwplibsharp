// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/docinfo/ForFillInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Object.Etc;
using System.Collections.Generic;
using System.Linq;

namespace HwpLib.Tool.ParagraphAdder.DocInfo
{
    /// <summary>
    /// FillInfo 객체를 복사하는 기능을 포함하는 클래스
    /// </summary>
    public static class ForFillInfo
    {
        /// <summary>
        /// 두 <see cref="FillInfo"/> 객체가 동일한지 비교합니다.
        /// </summary>
        /// <param name="source">비교할 첫 번째 <see cref="FillInfo"/> 객체입니다.</param>
        /// <param name="target">비교할 두 번째 <see cref="FillInfo"/> 객체입니다.</param>
        /// <returns>두 객체가 동일하면 true, 그렇지 않으면 false를 반환합니다.</returns>
        public static bool Equal(FillInfo? source, FillInfo? target)
        {
            if (source == null || target == null)
            {
                return source == target;
            }

            if (source.Type?.Value == target.Type?.Value)
            {
                var fillType = source.Type;
                if (fillType != null)
                {
                    if (fillType.HasPatternFill && !EqualPatternFill(source.PatternFill, target.PatternFill))
                    {
                        return false;
                    }
                    if (fillType.HasGradientFill && !EqualGradientFill(source.GradientFill, target.GradientFill))
                    {
                        return false;
                    }
                    if (fillType.HasImageFill)
                    {
                        // 이미지 비교 불가
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private static bool EqualPatternFill(PatternFill? source, PatternFill? target)
        {
            if (source == null || target == null) return source == target;

            return source.BackColor?.Value == target.BackColor?.Value
                && source.PatternColor?.Value == target.PatternColor?.Value
                && source.PatternType == target.PatternType;
        }

        private static bool EqualGradientFill(GradientFill? source, GradientFill? target)
        {
            if (source == null || target == null) return source == target;

            return source.GradientType == target.GradientType
                && source.StartAngle == target.StartAngle
                && source.CenterX == target.CenterX
                && source.CenterY == target.CenterY
                && source.BlurringDegree == target.BlurringDegree
                && EqualArrayInteger(source.ChangePointList.ToList(), target.ChangePointList.ToList())
                && EqualArrayColor4Byte(source.ColorList.ToList(), target.ColorList.ToList())
                && source.BlurringCenter == target.BlurringCenter;
        }

        private static bool EqualArrayInteger(List<int>? source, List<int>? target)
        {
            if (source == null || target == null) return source == target;
            if (source.Count != target.Count) return false;

            for (int index = 0; index < source.Count; index++)
            {
                if (source[index] != target[index])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool EqualArrayColor4Byte(List<Color4Byte>? source, List<Color4Byte>? target)
        {
            if (source == null || target == null) return source == target;
            if (source.Count != target.Count) return false;

            for (int index = 0; index < source.Count; index++)
            {
                if (source[index].Value != target[index].Value)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool EqualImageFill(ImageFill? source, ImageFill? target)
        {
            if (source == null || target == null) return source == target;

            return source.ImageFillType == target.ImageFillType
                && EqualPictureInfo(source.PictureInfo, target.PictureInfo);
        }

        private static bool EqualPictureInfo(PictureInfo? source, PictureInfo? target)
        {
            if (source == null || target == null) return source == target;

            // BinItemID 비교 불가
            return source.Brightness == target.Brightness
                && source.Contrast == target.Contrast
                && source.Effect == target.Effect;
        }

        /// <summary>
        /// <see cref="FillInfo"/>의 내용을 다른 <see cref="FillInfo"/> 객체에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="FillInfo"/> 객체입니다.</param>
        /// <param name="target">복사 대상 <see cref="FillInfo"/> 객체입니다.</param>
        /// <param name="docInfoAdder">BinData 등 참조 정보를 처리할 <see cref="DocInfoAdder"/> 객체입니다.</param>
        public static void Copy(FillInfo? source, FillInfo? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.Type?.Copy(source.Type);
            var fillType = source.Type;
            if (fillType != null)
            {
                if (fillType.HasPatternFill && source.PatternFill != null)
                {
                    target.CreatePatternFill();
                    CopyPatternFill(source.PatternFill, target.PatternFill);
                }
                if (fillType.HasGradientFill && source.GradientFill != null)
                {
                    target.CreateGradientFill();
                    CopyGradientFill(source.GradientFill, target.GradientFill);
                }
                if (fillType.HasImageFill && source.ImageFill != null)
                {
                    target.CreateImageFill();
                    CopyImageFill(source.ImageFill, target.ImageFill, docInfoAdder);
                }
            }
        }

        private static void CopyPatternFill(PatternFill? source, PatternFill? target)
        {
            if (source == null || target == null) return;

            if (source.BackColor != null && target.BackColor != null)
                target.BackColor.Value = source.BackColor.Value;
            if (source.PatternColor != null && target.PatternColor != null)
                target.PatternColor.Value = source.PatternColor.Value;
            target.PatternType = source.PatternType;
        }

        private static void CopyGradientFill(GradientFill? source, GradientFill? target)
        {
            if (source == null || target == null) return;

            target.GradientType = source.GradientType;
            target.StartAngle = source.StartAngle;
            target.CenterX = source.CenterX;
            target.CenterY = source.CenterY;
            target.BlurringDegree = source.BlurringDegree;

            var sourceChangePointList = source.ChangePointList;
            if (sourceChangePointList != null)
            {
                foreach (var changePoint in sourceChangePointList)
                {
                    target.AddChangePoint(changePoint);
                }
            }

            var sourceColorList = source.ColorList;
            if (sourceColorList != null)
            {
                foreach (var color in sourceColorList)
                {
                    var newColor = target.AddNewColor();
                    newColor.Value = color.Value;
                }
            }

            target.BlurringCenter = source.BlurringCenter;
        }

        private static void CopyImageFill(ImageFill? source, ImageFill? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.ImageFillType = source.ImageFillType;
            CopyPictureInfo(source.PictureInfo, target.PictureInfo, docInfoAdder);
        }

        /// <summary>
        /// <see cref="PictureInfo"/>의 내용을 다른 <see cref="PictureInfo"/> 객체에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="PictureInfo"/> 객체입니다.</param>
        /// <param name="target">복사 대상 <see cref="PictureInfo"/> 객체입니다.</param>
        /// <param name="docInfoAdder">BinData 등 참조 정보를 처리할 <see cref="DocInfoAdder"/> 객체입니다.</param>
        public static void CopyPictureInfo(PictureInfo? source, PictureInfo? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.Brightness = source.Brightness;
            target.Contrast = source.Contrast;
            target.Effect = source.Effect;
            target.BinItemID = docInfoAdder?.ForBinData().ProcessById(source.BinItemID) ?? source.BinItemID;
        }
    }
}

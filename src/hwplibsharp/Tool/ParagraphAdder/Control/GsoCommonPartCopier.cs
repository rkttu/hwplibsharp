// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/GsoCommonPartCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 그리기 개체의 공통 부분을 복사하는 클래스
    /// </summary>
    public class GsoCommonPartCopier
    {
        /// <summary>
        /// 소스 <see cref="GsoControl"/>의 공통 부분을 대상 <see cref="GsoControl"/>에 복사합니다.
        /// <paramref name="docInfoAdder"/>가 제공되면 문서 정보 항목도 적절히 변환하여 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="GsoControl"/> 인스턴스입니다.</param>
        /// <param name="target">복사 대상 <see cref="GsoControl"/> 인스턴스입니다.</param>
        /// <param name="docInfoAdder">문서 정보 변환을 위한 <see cref="DocInfoAdder"/> 인스턴스입니다. 필요 없으면 null을 전달할 수 있습니다.</param>
        public static void Copy(GsoControl source, GsoControl target, DocInfoAdder? docInfoAdder)
        {
            // in container == null
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }

            CtrlDataCopier.Copy(source, target, docInfoAdder);
            CopyCaption(source, target, docInfoAdder);

            if (source.GsoType == GsoControlType.Container)
            {
                var targetComp = target.ShapeComponent as ShapeComponentContainer;
                if (source.ShapeComponent is ShapeComponentContainer sourceComp)
                {
                    targetComp?.Copy(sourceComp);
                }
            }
            else
            {
                var sourceComp = source.ShapeComponent as ShapeComponentNormal;
                var targetComp = target.ShapeComponent as ShapeComponentNormal;
                CopyShapeComponentNormal(sourceComp, targetComp, docInfoAdder);
            }
        }

        private static void CopyCaption(GsoControl source, GsoControl target, DocInfoAdder? docInfoAdder)
        {
            if (source.Caption != null)
            {
                target.CreateCaption();
                CaptionCopier.Copy(source.Caption!, target.Caption!, docInfoAdder);
            }
            else
            {
                target.DeleteCaption();
            }
        }

        private static void CopyShapeComponentNormal(ShapeComponentNormal? source, ShapeComponentNormal? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.Copy(source);

            if (source.LineInfo != null)
            {
                target.CreateLineInfo();
                target.LineInfo?.Copy(source.LineInfo);
            }

            if (source.FillInfo != null)
            {
                target.CreateFillInfo();
                CopyFillInfo(source.FillInfo!, target.FillInfo!, docInfoAdder);
            }

            if (source.ShadowInfo != null)
            {
                target.CreateShadowInfo();
                target.ShadowInfo?.Copy(source.ShadowInfo);
            }
        }

        private static void CopyFillInfo(FillInfo source, FillInfo target, DocInfoAdder? docInfoAdder)
        {
            if (source.Type != null && target.Type != null)
            {
                target.Type.Value = source.Type.Value;
            }

            if (source.Type?.HasPatternFill == true && source.PatternFill != null)
            {
                target.CreatePatternFill();
                target.PatternFill?.Copy(source.PatternFill);
            }

            if (source.Type?.HasGradientFill == true && source.GradientFill != null)
            {
                target.CreateGradientFill();
                target.GradientFill?.Copy(source.GradientFill);
            }

            if (source.Type?.HasImageFill == true)
            {
                target.CreateImageFill();
                var sourceIF = source.ImageFill;
                var targetIF = target.ImageFill;

                if (sourceIF != null && targetIF != null)
                {
                    targetIF.ImageFillType = sourceIF.ImageFillType;
                    CopyPictureInfo(sourceIF.PictureInfo, targetIF.PictureInfo, docInfoAdder);
                }
            }
        }

        /// <summary>
        /// <para>소스 <see cref="PictureInfo"/>의 정보를 대상 <see cref="PictureInfo"/>에 복사합니다.</para>
        /// <para><paramref name="docInfoAdder"/>가 제공되면 BinItemID를 변환하여 복사합니다.</para>
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="PictureInfo"/> 인스턴스입니다.</param>
        /// <param name="target">복사 대상 <see cref="PictureInfo"/> 인스턴스입니다.</param>
        /// <param name="docInfoAdder">문서 정보 변환을 위한 <see cref="DocInfoAdder"/> 인스턴스입니다. 필요 없으면 null을 전달할 수 있습니다.</param>
        public static void CopyPictureInfo(PictureInfo? source, PictureInfo? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.Brightness = source.Brightness;
            target.Contrast = source.Contrast;
            target.Effect = source.Effect;
            target.BinItemID = docInfoAdder == null ? source.BinItemID : docInfoAdder.ForBinData().ProcessById(source.BinItemID);
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/CharShapeAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 문자 모양 정보를 추가하는 클래스
    /// </summary>
    public static class CharShapeInfoAdder
    {
        /// <summary>
        /// 문자 모양 정보를 추가한다.
        /// </summary>
        /// <param name="docInfo">문서 정보</param>
        public static void Add(DocInfo docInfo)
        {
            CharShapeInfo1(docInfo.AddNewCharShape());
            CharShapeInfo2(docInfo.AddNewCharShape());
            CharShapeInfo3(docInfo.AddNewCharShape());
            CharShapeInfo4(docInfo.AddNewCharShape());
            CharShapeInfo5(docInfo.AddNewCharShape());
        }

        private static void CharShapeInfo1(CharShapeInfo charShape)
        {
            charShape.FaceNameIds.SetForAll(1);
            charShape.Ratios.SetForAll(100);
            charShape.CharSpaces.SetForAll(0);
            charShape.RelativeSizes.SetForAll(100);
            charShape.CharOffsets.SetForAll(0);
            charShape.BaseSize = 1000;
            charShape.Property.Value = 0;
            charShape.ShadowGap1 = 10;
            charShape.ShadowGap2 = 10;
            charShape.CharColor.Value = 0;
            charShape.UnderLineColor.Value = 0;
            charShape.ShadeColor.Value = 0xFFFFFFFF; // -1 in unsigned
            charShape.ShadowColor.Value = 11711154;
            charShape.BorderFillId = 2;
            charShape.StrikeLineColor.Value = 0;
        }

        private static void CharShapeInfo2(CharShapeInfo charShape)
        {
            charShape.FaceNameIds.SetForAll(0);
            charShape.Ratios.SetForAll(100);
            charShape.CharSpaces.SetForAll(0);
            charShape.RelativeSizes.SetForAll(100);
            charShape.CharOffsets.SetForAll(0);
            charShape.BaseSize = 1000;
            charShape.Property.Value = 0;
            charShape.ShadowGap1 = 10;
            charShape.ShadowGap2 = 10;
            charShape.CharColor.Value = 0;
            charShape.UnderLineColor.Value = 0;
            charShape.ShadeColor.Value = 0xFFFFFFFF;
            charShape.ShadowColor.Value = 11711154;
            charShape.BorderFillId = 2;
            charShape.StrikeLineColor.Value = 0;
        }

        private static void CharShapeInfo3(CharShapeInfo charShape)
        {
            charShape.FaceNameIds.SetForAll(0);
            charShape.Ratios.SetForAll(100);
            charShape.CharSpaces.SetForAll(0);
            charShape.RelativeSizes.SetForAll(100);
            charShape.CharOffsets.SetForAll(0);
            charShape.BaseSize = 900;
            charShape.Property.Value = 0;
            charShape.ShadowGap1 = 10;
            charShape.ShadowGap2 = 10;
            charShape.CharColor.Value = 0;
            charShape.UnderLineColor.Value = 0;
            charShape.ShadeColor.Value = 0xFFFFFFFF;
            charShape.ShadowColor.Value = 11711154;
            charShape.BorderFillId = 2;
            charShape.StrikeLineColor.Value = 0;
        }

        private static void CharShapeInfo4(CharShapeInfo charShape)
        {
            charShape.FaceNameIds.SetForAll(1);
            charShape.Ratios.SetForAll(100);
            charShape.CharSpaces.SetForAll(0);
            charShape.RelativeSizes.SetForAll(100);
            charShape.CharOffsets.SetForAll(0);
            charShape.BaseSize = 900;
            charShape.Property.Value = 0;
            charShape.ShadowGap1 = 10;
            charShape.ShadowGap2 = 10;
            charShape.CharColor.Value = 0;
            charShape.UnderLineColor.Value = 0;
            charShape.ShadeColor.Value = 0xFFFFFFFF;
            charShape.ShadowColor.Value = 11711154;
            charShape.BorderFillId = 2;
            charShape.StrikeLineColor.Value = 0;
        }

        private static void CharShapeInfo5(CharShapeInfo charShape)
        {
            charShape.FaceNameIds.SetForAll(0);
            charShape.Ratios.SetForAll(100);
            charShape.CharSpaces.SetForAll(unchecked((sbyte)-5));
            charShape.RelativeSizes.SetForAll(100);
            charShape.CharOffsets.SetForAll(0);
            charShape.BaseSize = 900;
            charShape.Property.Value = 0;
            charShape.ShadowGap1 = 10;
            charShape.ShadowGap2 = 10;
            charShape.CharColor.Value = 0;
            charShape.UnderLineColor.Value = 0;
            charShape.ShadeColor.Value = 0xFFFFFFFF;
            charShape.ShadowColor.Value = 11711154;
            charShape.BorderFillId = 2;
            charShape.StrikeLineColor.Value = 0;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/blankfilemaker/ParaShapeAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo;

namespace HwpLib.Tool.BlankFileMaker
{
    /// <summary>
    /// 빈 HWP 파일 생성 시 문단 모양 정보를 추가하는 클래스
    /// </summary>
    public static class ParaShapeInfoAdder
    {
        /// <summary>
        /// 문단 모양 정보를 추가한다.
        /// </summary>
        /// <param name="docInfo">문서 정보</param>
        public static void Add(DocInfo docInfo)
        {
            ParaShapeInfo1(docInfo.AddNewParaShape());
            ParaShapeInfo2(docInfo.AddNewParaShape());
            ParaShapeInfo3(docInfo.AddNewParaShape());
            ParaShapeInfo4(docInfo.AddNewParaShape());
            ParaShapeInfo5(docInfo.AddNewParaShape());
            ParaShapeInfo6(docInfo.AddNewParaShape());
            ParaShapeInfo7(docInfo.AddNewParaShape());
            ParaShapeInfo8(docInfo.AddNewParaShape());
            ParaShapeInfo9(docInfo.AddNewParaShape());
            ParaShapeInfo10(docInfo.AddNewParaShape());
            ParaShapeInfo11(docInfo.AddNewParaShape());
            ParaShapeInfo12(docInfo.AddNewParaShape());
        }

        private static void ParaShapeInfo1(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 260;
            paraShape.LeftMargin = 0;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 130;
            paraShape.TabDefId = 0;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 130;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo2(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 384;
            paraShape.LeftMargin = 0;
            paraShape.RightMargin = 0;
            paraShape.Indent = -2620;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 130;
            paraShape.TabDefId = 0;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 130;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo3(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 256;
            paraShape.LeftMargin = 0;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 150;
            paraShape.TabDefId = 0;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 150;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo4(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 384;
            paraShape.LeftMargin = 0;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 0;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo5(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 209725824;
            paraShape.LeftMargin = 14000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 1;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo6(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 176171392;
            paraShape.LeftMargin = 12000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 1;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo7(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 142616960;
            paraShape.LeftMargin = 10000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 1;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo8(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 109062528;
            paraShape.LeftMargin = 8000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 1;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo9(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 75508096;
            paraShape.LeftMargin = 6000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 1;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo10(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 41953664;
            paraShape.LeftMargin = 4000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 1;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo11(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 8399232;
            paraShape.LeftMargin = 2000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 1;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }

        private static void ParaShapeInfo12(ParaShapeInfo paraShape)
        {
            paraShape.Property1.Value = 384;
            paraShape.LeftMargin = 3000;
            paraShape.RightMargin = 0;
            paraShape.Indent = 0;
            paraShape.TopParaSpace = 0;
            paraShape.BottomParaSpace = 0;
            paraShape.LineSpace = 160;
            paraShape.TabDefId = 0;
            paraShape.ParaHeadId = 0;
            paraShape.BorderFillId = 2;
            paraShape.LeftBorderSpace = 0;
            paraShape.RightBorderSpace = 0;
            paraShape.TopBorderSpace = 0;
            paraShape.BottomBorderSpace = 0;
            paraShape.Property2.Value = 0;
            paraShape.Property3.Value = 0;
            paraShape.LineSpace2 = 160;
            paraShape.ParaLevel = paraShape.Property1.ParaLevel;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/part/shapecomponent/CommonPart.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;

namespace HwpLib.Writer.BodyText.Control.Gso.Part.ShapeComponent
{
    /// <summary>
    /// 그리기 개체의 객체 공통 속성 레코드의 공통 부분을 쓰기 위한 객체
    /// </summary>
    public static class CommonPart
    {
        /// <summary>
        /// 그리기 개체의 객체 공통 속성 레코드의 공통 부분을 쓴다.
        /// </summary>
        public static void Write(Object.BodyText.Control.Gso.ShapeComponent.ShapeComponent sc, CompoundStreamWriter sw)
        {
            sw.WriteSInt4(sc.OffsetX);
            sw.WriteSInt4(sc.OffsetY);
            sw.WriteUInt2(sc.GroupingCount);
            sw.WriteUInt2(sc.LocalFileVersion);
            sw.WriteSInt4(sc.WidthAtCreate);
            sw.WriteSInt4(sc.HeightAtCreate);
            sw.WriteSInt4(sc.WidthAtCurrent);
            sw.WriteSInt4(sc.HeightAtCurrent);
            sw.WriteUInt4(sc.Property.Value);
            sw.WriteUInt2(sc.RotateAngle);
            sw.WriteSInt4(sc.RotateXCenter);
            sw.WriteSInt4(sc.RotateYCenter);

            RenderingInfo(sc.RenderingInfo, sw);
        }

        /// <summary>
        /// Rendering 정보를 쓴다.
        /// </summary>
        private static void RenderingInfo(Object.BodyText.Control.Gso.ShapeComponent.RenderingInfo.RenderingInfo ri, CompoundStreamWriter sw)
        {
            int scaleRotateMatrixCount = ri.ScaleRotateMatrixPairList.Count;
            sw.WriteUInt2((ushort)scaleRotateMatrixCount);
            Matrix(ri.TranslationMatrix, sw);
            foreach (var srmp in ri.ScaleRotateMatrixPairList)
            {
                Matrix(srmp.ScaleMatrix, sw);
                Matrix(srmp.RotateMatrix, sw);
            }
        }

        /// <summary>
        /// 행렬 객체를 쓴다.
        /// </summary>
        private static void Matrix(Object.BodyText.Control.Gso.ShapeComponent.RenderingInfo.Matrix m, CompoundStreamWriter sw)
        {
            for (int index = 0; index < 6; index++)
            {
                sw.WriteDouble(m.GetValue(index));
            }
        }

        /// <summary>
        /// 그리기 개체의 객체 공통 속성 레코드의 공통 부분의 크기를 반환한다.
        /// </summary>
        public static int GetSize(Object.BodyText.Control.Gso.ShapeComponent.ShapeComponent sc)
        {
            int size = 0;
            size += 42;

            size += 2;
            size += 48;
            size += 48 * 2 * sc.RenderingInfo.ScaleRotateMatrixPairList.Count;
            return size;
        }
    }
}

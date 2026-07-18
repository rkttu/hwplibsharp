// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/borderfill/ForFillInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;

namespace HwpLib.Writer.DocInfo.BorderFill
{
    /// <summary>
    /// 테두리/배경 레코드의 채우기 정보를 쓰기 위한 객체
    /// </summary>
    public static class ForFillInfo
    {
        /// <summary>
        /// 테두리/배경 레코드의 채우기 정보를 쓴다.
        /// </summary>
        /// <param name="fi">테두리/배경 레코드의 채우기 정보</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(FillInfo fi, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(fi.Type.Value);

            if (fi.Type.Value != 0)
            {
                if (fi.Type.HasPatternFill)
                {
                    WritePatternFill(fi.PatternFill!, sw);
                }

                if (fi.Type.HasGradientFill)
                {
                    WriteGradientFill(fi.GradientFill!, sw);
                }

                if (fi.Type.HasImageFill)
                {
                    WriteImageFill(fi.ImageFill!, sw);
                }

                AdditionalProperty(fi, sw);
                UnknownBytes(fi, sw);
            }
            else
            {
                sw.WriteZero(4);
            }
        }

        /// <summary>
        /// 패턴 채움 정보를 쓴다.
        /// </summary>
        /// <param name="pf">패턴 채움 정보</param>
        /// <param name="sw">스트림 라이터</param>
        private static void WritePatternFill(PatternFill pf, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(pf.BackColor.Value);
            sw.WriteUInt4(pf.PatternColor.Value);
            sw.WriteUInt4((uint)(sbyte)pf.PatternType);
        }

        /// <summary>
        /// 그라데이션 채움 정보를 쓴다.
        /// </summary>
        /// <param name="gf">그라데이션 채움 정보</param>
        /// <param name="sw">스트림 라이터</param>
        private static void WriteGradientFill(GradientFill gf, CompoundStreamWriter sw)
        {
            sw.WriteSInt1((sbyte)(byte)gf.GradientType);
            sw.WriteUInt4(gf.StartAngle);
            sw.WriteUInt4(gf.CenterX);
            sw.WriteUInt4(gf.CenterY);
            sw.WriteUInt4(gf.BlurringDegree);

            long colorCount = gf.ColorList.Count;
            sw.WriteUInt4(colorCount);

            if (colorCount > 2)
            {
                foreach (var cp in gf.ChangePointList)
                {
                    sw.WriteSInt4(cp);
                }
            }

            foreach (var c in gf.ColorList)
            {
                sw.WriteUInt4(c.Value);
            }
        }

        /// <summary>
        /// 이미지 채움 정보를 쓴다.
        /// </summary>
        /// <param name="imf">이미지 채움 정보</param>
        /// <param name="sw">스트림 라이터</param>
        private static void WriteImageFill(ImageFill imf, CompoundStreamWriter sw)
        {
            sw.WriteUInt1((byte)imf.ImageFillType);
            PictureInfo(imf.PictureInfo, sw);
        }

        /// <summary>
        /// 그림 정보를 쓴다.
        /// </summary>
        /// <param name="pi">그림 정보</param>
        /// <param name="sw">스트림 라이터</param>
        public static void PictureInfo(PictureInfo pi, CompoundStreamWriter sw)
        {
            sw.WriteSInt1(pi.Contrast);
            sw.WriteSInt1(pi.Brightness);
            sw.WriteUInt1((byte)pi.Effect);
            sw.WriteUInt2(pi.BinItemID);
        }

        /// <summary>
        /// 추가적인 속성을 쓴다.
        /// </summary>
        /// <param name="fi">테두리/배경 레코드의 채우기 정보</param>
        /// <param name="sw">스트림 라이터</param>
        private static void AdditionalProperty(FillInfo fi, CompoundStreamWriter sw)
        {
            if (fi.Type.HasGradientFill)
            {
                sw.WriteUInt4(1);
                sw.WriteUInt1(fi.GradientFill!.BlurringCenter);
            }
            else
            {
                sw.WriteUInt4(0);
            }
        }

        /// <summary>
        /// 알려지지 않은 바이트를 쓴다.
        /// </summary>
        /// <param name="fi">테두리/배경 레코드의 채우기 정보</param>
        /// <param name="sw">스트림 라이터</param>
        private static void UnknownBytes(FillInfo fi, CompoundStreamWriter sw)
        {
            if (fi.Type.HasPatternFill)
            {
                sw.WriteZero(1);
            }

            if (fi.Type.HasGradientFill)
            {
                sw.WriteZero(1);
            }

            if (fi.Type.HasImageFill)
            {
                sw.WriteZero(1);
            }
        }

        /// <summary>
        /// 테두리/배경 레코드의 채우기 정보의 크기를 반환한다.
        /// </summary>
        /// <param name="fi">테두리/배경 레코드의 채우기 정보</param>
        /// <returns>테두리/배경 레코드의 채우기 정보의 크기</returns>
        public static int GetSize(FillInfo fi)
        {
            int size = 0;
            size += 4;

            if (fi.Type.Value != 0)
            {
                if (fi.Type.HasPatternFill)
                {
                    size += 12;
                }

                if (fi.Type.HasGradientFill)
                {
                    size += 17;
                    size += 4;
                    long colorCount = fi.GradientFill!.ColorList.Count;
                    if (colorCount > 2)
                    {
                        size += (int)(colorCount * 4);
                    }
                    size += (int)(colorCount * 4);
                }

                if (fi.Type.HasImageFill)
                {
                    size += 6;
                }

                // additionalProperty
                if (fi.Type.HasGradientFill)
                {
                    size += 4;
                    size += 1;
                }
                else
                {
                    size += 4;
                }

                // unknownBytes
                if (fi.Type.HasPatternFill)
                {
                    size += 1;
                }
                if (fi.Type.HasGradientFill)
                {
                    size += 1;
                }
                if (fi.Type.HasImageFill)
                {
                    size += 1;
                }
            }
            else
            {
                size += 4;
            }

            return size;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/borderfill/ForFillInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;

namespace HwpLib.Reader.DocInfo.BorderFill
{
    /// <summary>
    /// 테두리/배경 레코드의 채우기 정보를 읽기 위한 객체
    /// </summary>
    public static class ForFillInfo
    {
        /// <summary>
        /// 테두리/배경 레코드의 채우기 정보를 읽는다.
        /// </summary>
        /// <param name="fi">테두리/배경 레코드의 채우기 정보</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(FillInfo fi, CompoundStreamReader sr)
        {
            fi.Type.Value = sr.ReadUInt4();
            if (fi.Type.Value != 0)
            {
                if (fi.Type.HasPatternFill)
                {
                    fi.CreatePatternFill();
                    ReadPatternFill(fi.PatternFill!, sr);
                }

                if (fi.Type.HasGradientFill)
                {
                    fi.CreateGradientFill();
                    ReadGradientFill(fi.GradientFill!, sr);
                }

                if (fi.Type.HasImageFill)
                {
                    fi.CreateImageFill();
                    ReadImageFill(fi.ImageFill!, sr);
                }
                ReadAdditionalProperty(fi, sr);

                if (sr.IsEndOfRecord()) return;

                ReadUnknownBytes(fi, sr);
            }
            else
            {
                sr.Skip(4);
            }
        }

        /// <summary>
        /// 패턴 채움 정보를 읽는다.
        /// </summary>
        /// <param name="pf">패턴 채움 정보</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadPatternFill(PatternFill pf, CompoundStreamReader sr)
        {
            pf.BackColor.Value = sr.ReadUInt4();
            pf.PatternColor.Value = sr.ReadUInt4();
            pf.PatternType = PatternTypeExtensions.FromValue((sbyte)sr.ReadSInt4());
        }

        /// <summary>
        /// 그라데이션 채움 정보를 읽는다.
        /// </summary>
        /// <param name="gf">그라데이션 정보</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadGradientFill(GradientFill gf, CompoundStreamReader sr)
        {
            gf.GradientType = GradientTypeExtensions.FromValue(sr.ReadUInt1()); // 문서오류 2byte -> 1 byte
            gf.StartAngle = sr.ReadUInt4(); // 문서오류 2byte -> 4 byte
            gf.CenterX = sr.ReadUInt4(); // 문서오류 2byte -> 4 byte
            gf.CenterY = sr.ReadUInt4(); // 문서오류 2byte -> 4 byte
            gf.BlurringDegree = sr.ReadUInt4(); // 문서오류 2byte -> 4 byte

            uint colorCount = sr.ReadUInt4(); // 문서오류 2byte -> 4 byte
            if (colorCount > 2)
            {
                for (int index = 0; index < (int)colorCount; index++)
                {
                    gf.AddChangePoint(sr.ReadSInt4());
                }
            }
            for (int index = 0; index < (int)colorCount; index++)
            {
                gf.AddNewColor().Value = sr.ReadUInt4();
            }
        }

        /// <summary>
        /// 이미지 채움 정보을 읽는다.
        /// </summary>
        /// <param name="imf">이미지 채움 정보</param>
        /// <param name="sr">스트림 러더</param>
        private static void ReadImageFill(ImageFill imf, CompoundStreamReader sr)
        {
            imf.ImageFillType = ImageFillTypeExtensions.FromValue(sr.ReadUInt1());
            ReadPictureInfo(imf.PictureInfo, sr);
        }

        /// <summary>
        /// 그림 정보을 읽는다.
        /// </summary>
        /// <param name="pi">그림 정보</param>
        /// <param name="sr">스트림 리더</param>
        public static void ReadPictureInfo(PictureInfo pi, CompoundStreamReader sr)
        {
            pi.Brightness = sr.ReadSInt1();
            pi.Contrast = sr.ReadSInt1();
            pi.Effect = PictureEffectExtensions.FromValue(sr.ReadUInt1());
            pi.BinItemID = sr.ReadUInt2();
        }

        /// <summary>
        /// 추가적인 속성을 읽는다.
        /// </summary>
        /// <param name="fi">채우기 정보</param>
        /// <param name="sr">스트림 러더</param>
        private static void ReadAdditionalProperty(FillInfo fi, CompoundStreamReader sr)
        {
            uint size = sr.ReadUInt4();
            if (size == 1)
            {
                if (fi.Type.HasGradientFill && fi.GradientFill != null)
                {
                    fi.GradientFill.BlurringCenter = sr.ReadUInt1();
                }
            }
            else
            {
                sr.Skip((int)size);
            }
        }

        /// <summary>
        /// 알려지지 않은 바이트를 읽는다.
        /// </summary>
        /// <param name="fi">채우기 정보</param>
        /// <param name="sr">스트림 러더</param>
        private static void ReadUnknownBytes(FillInfo fi, CompoundStreamReader sr)
        {
            if (fi.Type.HasPatternFill)
            {
                sr.Skip(1);
            }
            if (fi.Type.HasGradientFill)
            {
                sr.Skip(1);
            }
            if (fi.Type.HasImageFill)
            {
                sr.Skip(1);
            }
        }
    }
}

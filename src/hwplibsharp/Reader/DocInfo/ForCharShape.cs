// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForCharShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.CharShape;

namespace HwpLib.Reader.DocInfo
{
    /// <summary>
    /// 글자 모양 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForCharShape
    {
        /// <summary>
        /// 글자 모양을 읽는다.
        /// </summary>
        /// <param name="cs">글자 모양 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(CharShapeInfo cs, CompoundStreamReader sr)
        {
            ReadFaceNameIds(cs.FaceNameIds, sr);
            ReadRatios(cs.Ratios, sr);
            ReadCharSpaces(cs.CharSpaces, sr);
            ReadRelativeSizes(cs.RelativeSizes, sr);
            ReadCharPositions(cs.CharOffsets, sr);

            cs.BaseSize = sr.ReadSInt4();
            cs.Property.Value = sr.ReadUInt4();
            cs.ShadowGap1 = sr.ReadSInt1();
            cs.ShadowGap2 = sr.ReadSInt1();
            cs.CharColor.Value = sr.ReadUInt4();
            cs.UnderLineColor.Value = sr.ReadUInt4();
            cs.ShadeColor.Value = sr.ReadUInt4();
            cs.ShadowColor.Value = sr.ReadUInt4();

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 2, 1))
            {
                cs.BorderFillId = sr.ReadUInt2();
            }

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 3, 0))
            {
                cs.StrikeLineColor.Value = sr.ReadUInt4();
            }
        }

        /// <summary>
        /// 언어별 글꼴ID 부분을 읽는다.
        /// </summary>
        /// <param name="fnis">언어별 글꼴ID 부분을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadFaceNameIds(FaceNameIds fnis, CompoundStreamReader sr)
        {
            int[] array = new int[7];
            for (int index = 0; index < 7; index++)
            {
                array[index] = sr.ReadUInt2();
            }
            fnis.SetArray(array);
        }

        /// <summary>
        /// 언어별 장평 부분을 읽는다.
        /// </summary>
        /// <param name="rs">언어별 장평 부분을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadRatios(Ratios rs, CompoundStreamReader sr)
        {
            short[] array = new short[7];
            for (int index = 0; index < 7; index++)
            {
                array[index] = (short)sr.ReadUInt1();
            }
            rs.SetArray(array);
        }

        /// <summary>
        /// 언어별 자간 부분을 읽는다.
        /// </summary>
        /// <param name="css">언어별 자간 부분을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadCharSpaces(CharSpaces css, CompoundStreamReader sr)
        {
            sbyte[] array = new sbyte[7];
            for (int index = 0; index < 7; index++)
            {
                array[index] = sr.ReadSInt1();
            }
            css.SetArray(array);
        }

        /// <summary>
        /// 언어별 상대 크기 부분을 읽는다.
        /// </summary>
        /// <param name="rss">언어별 상대 크기을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadRelativeSizes(RelativeSizes rss, CompoundStreamReader sr)
        {
            short[] array = new short[7];
            for (int index = 0; index < 7; index++)
            {
                array[index] = (short)sr.ReadUInt1();
            }
            rss.SetArray(array);
        }

        /// <summary>
        /// 언어별 글자 위치 부분을 읽는다.
        /// </summary>
        /// <param name="cos">언어별 글자 위치을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        private static void ReadCharPositions(CharOffsets cos, CompoundStreamReader sr)
        {
            sbyte[] array = new sbyte[7];
            for (int index = 0; index < 7; index++)
            {
                array[index] = sr.ReadSInt1();
            }
            cos.SetArray(array);
        }
    }
}

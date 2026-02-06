// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForCharShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.DocInfo.CharShape;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 글자 모양 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForCharShape
    {
        /// <summary>
        /// 글자 모양 레코드를 쓴다.
        /// </summary>
        /// <param name="cs">글자 모양 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(CharShapeInfo cs, CompoundStreamWriter sw)
        {
            RecordHeader(sw);

            FaceNameIds(cs.FaceNameIds, sw);
            Ratios(cs.Ratios, sw);
            CharSpaces(cs.CharSpaces, sw);
            RelativeSizes(cs.RelativeSizes, sw);
            CharPositions(cs.CharOffsets, sw);

            sw.WriteSInt4(cs.BaseSize);
            sw.WriteUInt4(cs.Property.Value);
            sw.WriteSInt1(cs.ShadowGap1);
            sw.WriteSInt1(cs.ShadowGap2);
            sw.WriteUInt4(cs.CharColor.Value);
            sw.WriteUInt4(cs.UnderLineColor.Value);
            sw.WriteUInt4(cs.ShadeColor.Value);
            sw.WriteUInt4(cs.ShadowColor.Value);

            if (sw.FileVersion.IsOver(5, 0, 2, 1))
            {
                sw.WriteUInt2(cs.BorderFillId);
            }

            if (sw.FileVersion.IsOver(5, 0, 3, 0))
            {
                sw.WriteUInt4(cs.StrikeLineColor.Value);
            }
        }

        /// <summary>
        /// 글자 모양 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        /// <param name="sw">스트림 라이터</param>
        private static void RecordHeader(CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.CharShape, GetSize(sw.FileVersion));
        }

        /// <summary>
        /// 글자 모양 레코드의 크기를 반환한다.
        /// </summary>
        /// <param name="version">파일 버전</param>
        /// <returns>글자 모양 레코드의 크기</returns>
        private static int GetSize(FileVersion version)
        {
            int size = 0;
            size += 14 + 7 + 7 + 7 + 7;
            size += 26;
            if (version.IsOver(5, 0, 2, 1))
            {
                size += 2;
            }
            if (version.IsOver(5, 0, 3, 0))
            {
                size += 4;
            }
            return size;
        }

        private static void FaceNameIds(FaceNameIds fni, CompoundStreamWriter sw)
        {
            foreach (var faceNameId in fni.Array)
            {
                sw.WriteUInt2(faceNameId);
            }
        }

        private static void Ratios(Ratios ratios, CompoundStreamWriter sw)
        {
            foreach (var ratio in ratios.Array)
            {
                sw.WriteUInt1((byte)ratio);
            }
        }

        private static void CharSpaces(CharSpaces charSpaces, CompoundStreamWriter sw)
        {
            foreach (var charSpace in charSpaces.Array)
            {
                sw.WriteSInt1(charSpace);
            }
        }

        private static void RelativeSizes(RelativeSizes rss, CompoundStreamWriter sw)
        {
            foreach (var rs in rss.Array)
            {
                sw.WriteUInt1((byte)rs);
            }
        }

        private static void CharPositions(CharOffsets cos, CompoundStreamWriter sw)
        {
            foreach (var co in cos.Array)
            {
                sw.WriteSInt1(co);
            }
        }
    }
}

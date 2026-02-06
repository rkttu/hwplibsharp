// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/ForParaCharShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Paragraph.CharShape;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Paragraph
{
    /// <summary>
    /// 문단의 글자 모양 레코드를 쓰기 위한 객체
    /// </summary>
    public static class ForParaCharShape
    {
        /// <summary>
        /// 문단의 글자 모양 레코드를 쓴다.
        /// </summary>
        /// <param name="pcs">문단의 글자 모양 레코드</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(ParaCharShape? pcs, CompoundStreamWriter sw)
        {
            if (pcs == null)
            {
                return;
            }

            RecordHeader(pcs, sw);

            foreach (var cpsip in pcs.PositionShapeIdPairList)
            {
                CharPositionShapeIdPair(cpsip, sw);
            }
        }

        /// <summary>
        /// 문단의 글자 모양 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ParaCharShape pcs, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ParaCharShape, GetSize(pcs));
        }

        /// <summary>
        /// 문단 글자 모양 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ParaCharShape pcs)
        {
            return pcs.PositionShapeIdPairList.Count * 8;
        }

        /// <summary>
        /// 글자 모양 위치/글자 모양 아이디의 쌍을 쓴다.
        /// </summary>
        private static void CharPositionShapeIdPair(CharPositionShapeIdPair cpsip, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(cpsip.Position);
            sw.WriteUInt4(cpsip.ShapeId);
        }
    }
}

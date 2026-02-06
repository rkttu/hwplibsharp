// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/ForParaCharShape.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;

namespace HwpLib.Reader.BodyText.Paragraph
{
    /// <summary>
    /// 문단의 글자 모양 레코드를 읽기 위한 객체
    /// </summary>
    public static class ForParaCharShape
    {
        /// <summary>
        /// 문단의 글자 모양 레코드를 읽는다.
        /// </summary>
        /// <param name="pcs">문단 글자 모양</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(HwpLib.Object.BodyText.Paragraph.CharShape.ParaCharShape pcs, CompoundStreamReader sr)
        {
            // 레코드 크기 / 8 = 쌍의 수 (position 4바이트 + charShapeId 4바이트)
            int count = (int)(sr.CurrentRecordHeader!.Size / 8);

            for (int i = 0; i < count; i++)
            {
                uint position = sr.ReadUInt4();
                uint charShapeId = sr.ReadUInt4();
                pcs.AddParaCharShape(position, charShapeId);
            }
        }
    }
}

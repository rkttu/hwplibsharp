// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/ForParaHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;

namespace HwpLib.Reader.BodyText.Paragraph
{
    /// <summary>
    /// 문단 헤더 레코드를 읽는 객체
    /// </summary>
    public static class ForParaHeader
    {
        /// <summary>
        /// 문단 헤더 레코드를 읽는다.
        /// </summary>
        /// <param name="ph">문단 헤더 레코드</param>
        /// <param name="sr">스트림 리더</param>
        public static void Read(HwpLib.Object.BodyText.Paragraph.Header.ParaHeader ph, CompoundStreamReader sr)
        {
            // 현재 문단Ʈ현재 문단�� ���ܿ��ο� ���ڼ��� �д´�.
            uint value = sr.ReadUInt4();
            ph.LastInList = (value & 0x80000000) != 0;
            ph.CharacterCount = value & 0x7fffffff;

            ph.ControlMask.Value = sr.ReadUInt4();
            ph.ParaShapeId = sr.ReadUInt2();
            ph.StyleId = sr.ReadUInt1();
            ph.DivideSort.Value = sr.ReadUInt1();
            ph.CharShapeCount = sr.ReadUInt2();
            ph.RangeTagCount = sr.ReadUInt2();
            ph.LineAlignCount = sr.ReadUInt2();
            ph.InstanceID = sr.ReadUInt4();

            if (!sr.IsEndOfRecord() && sr.FileVersion.IsOver(5, 0, 3, 2))
            {
                ph.IsMergedByTrack = sr.ReadUInt2();
            }

            // 현재 문단Ʈ�� 생성자 �ǳʶڴ�
            sr.SkipToEndRecord();
        }
    }
}

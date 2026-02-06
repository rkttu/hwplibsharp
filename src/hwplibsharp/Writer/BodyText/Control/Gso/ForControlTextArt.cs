// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlTextArt.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;
using HwpLib.Object.Etc;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// TextArt 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlTextArt
    {
        /// <summary>
        /// TextArt 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlTextArt textArt, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            ShapeComponentTextArt(textArt.ShapeComponentTextArt, sw);

            sw.DownRecordLevel();
        }

        private static void ShapeComponentTextArt(ShapeComponentTextArt scta, CompoundStreamWriter sw)
        {
            RecordHeader(scta, sw);
            sw.WriteSInt4(scta.X1);
            sw.WriteSInt4(scta.Y1);
            sw.WriteSInt4(scta.X2);
            sw.WriteSInt4(scta.Y2);
            sw.WriteSInt4(scta.X3);
            sw.WriteSInt4(scta.Y3);
            sw.WriteSInt4(scta.X4);
            sw.WriteSInt4(scta.Y4);
            sw.WriteHWPString(scta.Content);
            sw.WriteHWPString(scta.FontName);
            sw.WriteHWPString(scta.FontStyle);
            sw.WriteSInt4((int)scta.FontType);
            sw.WriteSInt4((int)scta.TextArtShape);
            sw.WriteSInt4(scta.LineSpace);
            sw.WriteSInt4(scta.CharSpace);
            sw.WriteSInt4((int)scta.ParaAlignment);
            sw.WriteSInt4(scta.ShadowType);
            sw.WriteSInt4(scta.ShadowOffsetX);
            sw.WriteSInt4(scta.ShadowOffsetY);
            sw.WriteUInt4(scta.ShadowColor.Value);
            sw.WriteSInt4(scta.OutlinePointList.Count);
            foreach (var positionXY in scta.OutlinePointList)
            {
                sw.WriteUInt4((uint)positionXY.X);
                sw.WriteUInt4((uint)positionXY.Y);
            }
        }

        private static void RecordHeader(ShapeComponentTextArt scta, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentTextArt, GetSize(scta));
        }

        private static long GetSize(ShapeComponentTextArt scta)
        {
            int size = 0;
            size += 32;
            size += scta.Content.GetWCharsSize();
            size += scta.FontName.GetWCharsSize();
            size += scta.FontStyle.GetWCharsSize();
            size += 40;
            size += scta.OutlinePointList.Count * 8;
            return size;
        }
    }
}

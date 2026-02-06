// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/ForControlPicture.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture;
using HwpLib.Object.Etc;
using HwpLib.Writer.BodyText.Control.Bookmark;
using HwpLib.Writer.BodyText.Control.Gso.Part;
using HwpLib.Writer.DocInfo.BorderFill;

namespace HwpLib.Writer.BodyText.Control.Gso
{
    /// <summary>
    /// 그림 컨트롤의 나머지 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForControlPicture
    {
        /// <summary>
        /// 그림 컨트롤의 나머지 부분을 쓴다.
        /// </summary>
        public static void WriteRest(ControlPicture pic, CompoundStreamWriter sw)
        {
            sw.UpRecordLevel();

            CtrlData(pic, sw);
            ShapeComponentPicture(pic.ShapeComponentPicture, sw);

            sw.DownRecordLevel();
        }

        private static void CtrlData(ControlPicture pic, CompoundStreamWriter sw)
        {
            if (pic.GetCtrlData() != null)
            {
                ForCtrlData.Write(pic.GetCtrlData(), sw);
            }
        }

        /// <summary>
        /// 그림 개체 속성 레코드를 쓴다.
        /// </summary>
        private static void ShapeComponentPicture(ShapeComponentPicture scp, CompoundStreamWriter sw)
        {
            RecordHeader(scp, sw);

            sw.WriteUInt4(scp.BorderColor.Value);
            sw.WriteSInt4(scp.BorderThickness);
            sw.WriteUInt4(scp.BorderProperty.Value);
            sw.WriteSInt4((int)scp.LeftTop.X);
            sw.WriteSInt4((int)scp.LeftTop.Y);
            sw.WriteSInt4((int)scp.RightTop.X);
            sw.WriteSInt4((int)scp.RightTop.Y);
            sw.WriteSInt4((int)scp.RightBottom.X);
            sw.WriteSInt4((int)scp.RightBottom.Y);
            sw.WriteSInt4((int)scp.LeftBottom.X);
            sw.WriteSInt4((int)scp.LeftBottom.Y);
            sw.WriteSInt4(scp.LeftAfterCutting);
            sw.WriteSInt4(scp.TopAfterCutting);
            sw.WriteSInt4(scp.RightAfterCutting);
            sw.WriteSInt4(scp.BottomAfterCutting);
            InnerMargin(scp.InnerMargin, sw);
            ForFillInfo.PictureInfo(scp.PictureInfo, sw);
            sw.WriteUInt1(scp.BorderTransparency);
            sw.WriteUInt4(scp.InstanceId);
            ForPictureEffect.Write(scp.PictureEffect, sw);
            sw.WriteUInt4(scp.ImageWidth);
            sw.WriteUInt4(scp.ImageHeight);
        }

        /// <summary>
        /// 그림 개체 속성 레코드의 레코드 헤더를 쓴다.
        /// </summary>
        private static void RecordHeader(ShapeComponentPicture scp, CompoundStreamWriter sw)
        {
            sw.WriteRecordHeader(HWPTag.ShapeComponentPicture, GetSize(scp));
        }

        /// <summary>
        /// 그림 개체 속성 레코드의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ShapeComponentPicture scp)
        {
            int size = 0;
            size += 60;
            size += 8; // inner margin;
            size += 5; // pictureInfo;
            size += 5;
            size += ForPictureEffect.GetSize(scp.PictureEffect);
            size += 8;
            return size;
        }

        /// <summary>
        /// 내부 여백 부분을 쓴다.
        /// </summary>
        private static void InnerMargin(InnerMargin im, CompoundStreamWriter sw)
        {
            sw.WriteUInt2(im.Left);
            sw.WriteUInt2(im.Right);
            sw.WriteUInt2(im.Top);
            sw.WriteUInt2(im.Bottom);
        }
    }
}

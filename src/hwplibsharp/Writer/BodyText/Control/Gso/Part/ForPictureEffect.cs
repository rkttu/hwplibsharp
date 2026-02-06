// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/gso/part/ForPictureEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture;
using System;

namespace HwpLib.Writer.BodyText.Control.Gso.Part
{
    /// <summary>
    /// 그림 개체 속성 레코드의 그림 효과 부분을 쓰기 위한 객체
    /// </summary>
    public static class ForPictureEffect
    {
        /// <summary>
        /// 그림 개체 속성 레코드의 그림 효과 부분을 쓴다.
        /// </summary>
        public static void Write(PictureEffect pe, CompoundStreamWriter sw)
        {
            sw.WriteUInt4(pe.Property.Value);

            ShadowEffect(pe.ShadowEffect, sw);
            NeonEffect(pe.NeonEffect, sw);
            SoftEdgeEffect(pe.SoftEdgeEffect, sw);
            ReflectionEffect(pe.ReflectionEffect, sw);
        }

        /// <summary>
        /// 그림자 효과 부분을 쓴다.
        /// </summary>
        private static void ShadowEffect(ShadowEffect? se, CompoundStreamWriter sw)
        {
            if (se == null)
            {
                return;
            }
            sw.WriteSInt4(se.Style);
            sw.WriteFloat(se.Transparency);
            sw.WriteFloat(se.Cloudy);
            sw.WriteFloat(se.Direction);
            sw.WriteFloat(se.Distance);
            sw.WriteSInt4(se.Sort);
            sw.WriteFloat(se.TiltAngleX);
            sw.WriteFloat(se.TiltAngleY);
            sw.WriteFloat(se.ZoomRateX);
            sw.WriteFloat(se.ZoomRateY);
            sw.WriteSInt4(se.RotateWithShape);
            ColorProperty(se.Color, sw);
        }

        /// <summary>
        /// 색상 속성 부분을 쓴다.
        /// </summary>
        private static void ColorProperty(ColorWithEffect cp, CompoundStreamWriter sw)
        {
            sw.WriteSInt4(cp.Type);
            if (cp.Type == 0)
            {
                sw.WriteBytes(cp.Color);
            }
            else
            {
                throw new InvalidOperationException("not supported color type !!!");
            }

            int colorEffectCount = cp.ColorEffectList.Count;
            sw.WriteUInt4((uint)colorEffectCount);

            foreach (var ce in cp.ColorEffectList)
            {
                sw.WriteSInt4((int)ce.Sort);
                sw.WriteFloat(ce.Value);
            }
        }

        /// <summary>
        /// 네온 효과 부분을 쓴다.
        /// </summary>
        private static void NeonEffect(NeonEffect? ne, CompoundStreamWriter sw)
        {
            if (ne == null)
            {
                return;
            }
            sw.WriteFloat(ne.Transparency);
            sw.WriteFloat(ne.Radius);
            ColorProperty(ne.Color, sw);
        }

        /// <summary>
        /// 부드러운 가장자리 효과 부분을 쓴다.
        /// </summary>
        private static void SoftEdgeEffect(SoftEdgeEffect? see, CompoundStreamWriter sw)
        {
            if (see == null)
            {
                return;
            }
            sw.WriteFloat(see.Radius);
        }

        /// <summary>
        /// 반사 효과 부분을 쓴다.
        /// </summary>
        private static void ReflectionEffect(ReflectionEffect? re, CompoundStreamWriter sw)
        {
            if (re == null)
            {
                return;
            }
            sw.WriteSInt4(re.Style);
            sw.WriteFloat(re.Radius);
            sw.WriteFloat(re.Direction);
            sw.WriteFloat(re.Distance);
            sw.WriteFloat(re.TiltAngleX);
            sw.WriteFloat(re.TiltAngleY);
            sw.WriteFloat(re.ZoomRateX);
            sw.WriteFloat(re.ZoomRateY);
            sw.WriteSInt4(re.RotationStyle);
            sw.WriteFloat(re.StartTransparency);
            sw.WriteFloat(re.StartPosition);
            sw.WriteFloat(re.EndTransparency);
            sw.WriteFloat(re.EndPosition);
            sw.WriteFloat(re.OffsetDirection);
        }

        /// <summary>
        /// 그림 개체 속성 레코드의 그림 효과 부분의 크기를 반환한다.
        /// </summary>
        public static int GetSize(PictureEffect pe)
        {
            int size = 0;
            size += 4;
            if (pe.ShadowEffect != null)
            {
                size += 44;
                size += GetSize(pe.ShadowEffect.Color);
            }
            if (pe.NeonEffect != null)
            {
                size += 8;
                size += GetSize(pe.NeonEffect.Color);
            }
            if (pe.SoftEdgeEffect != null)
            {
                size += 4;
            }
            if (pe.ReflectionEffect != null)
            {
                size += 56;
            }
            return size;
        }

        /// <summary>
        /// 색상 속성을 나타내는 객체의 크기를 반환한다.
        /// </summary>
        private static int GetSize(ColorWithEffect color)
        {
            int size = 0;
            size += 8;
            size += 4;
            size += 8 * color.ColorEffectList.Count;
            return size;
        }
    }
}

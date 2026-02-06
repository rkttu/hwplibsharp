// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponenteach/picture/ColorWithEffect.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponentEach.Picture
{
    /// <summary>
    /// 색상 효과가 포함된 색상
    /// </summary>
    public class ColorWithEffect
    {
        /// <summary>
        /// 색상 타입 (정보 없음)
        /// </summary>
        private int _type;

        /// <summary>
        /// 타입에 따른 색상 값 (정보 없음)
        /// </summary>
        private byte[] _color = Array.Empty<byte>();

        /// <summary>
        /// 색상 효과의 리스트
        /// </summary>
        private readonly List<ColorEffect> _colorEffectList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ColorWithEffect()
        {
            _colorEffectList = new List<ColorEffect>();
        }

        /// <summary>
        /// 색상 타입을 반환하거나 설정한다. (정보 없음)
        /// </summary>
        public int Type
        {
            get => _type;
            set => _type = value;
        }

        /// <summary>
        /// 타입에 따른 색상 값을 반환하거나 설정한다. (정보 없음)
        /// </summary>
        public byte[] Color
        {
            get => _color;
            set => _color = value;
        }

        /// <summary>
        /// 색상 효과의 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<ColorEffect> ColorEffectList => _colorEffectList;

        /// <summary>
        /// 새로운 색상 효과 객체를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 색상 효과 객체</returns>
        public ColorEffect AddNewColorEffect()
        {
            var ce = new ColorEffect();
            _colorEffectList.Add(ce);
            return ce;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ColorWithEffect from)
        {
            _type = from._type;
            _color = (byte[])from._color.Clone();

            _colorEffectList.Clear();
            foreach (var colorEffect in from._colorEffectList)
            {
                _colorEffectList.Add(colorEffect.Clone());
            }
        }
    }
}

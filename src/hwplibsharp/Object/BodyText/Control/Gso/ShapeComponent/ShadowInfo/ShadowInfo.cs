// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/shadowinfo/ShadowInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent.ShadowInfo
{
    /// <summary>
    /// 그림자 정보
    /// </summary>
    public class ShadowInfo
    {
        /// <summary>
        /// 그림자 종류
        /// </summary>
        private ShadowType _type;

        /// <summary>
        /// 그림자 색
        /// </summary>
        private readonly Color4Byte _color;

        /// <summary>
        /// 가로 방향 이동 거리
        /// </summary>
        private int _offsetX;

        /// <summary>
        /// 세로 방향 이동 거리
        /// </summary>
        private int _offsetY;

        /// <summary>
        /// 투명도
        /// </summary>
        private short _transparent;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShadowInfo()
        {
            _color = new Color4Byte();
        }

        /// <summary>
        /// 그림자 종류를 반환하거나 설정한다.
        /// </summary>
        public ShadowType Type
        {
            get => _type;
            set => _type = value;
        }

        /// <summary>
        /// 그림자 색상 객체를 반환한다.
        /// </summary>
        public Color4Byte Color => _color;

        /// <summary>
        /// 가로 방향 이동 거리를 반환하거나 설정한다.
        /// </summary>
        public int OffsetX
        {
            get => _offsetX;
            set => _offsetX = value;
        }

        /// <summary>
        /// 세로 방향 이동 거리를 반환하거나 설정한다.
        /// </summary>
        public int OffsetY
        {
            get => _offsetY;
            set => _offsetY = value;
        }

        /// <summary>
        /// 투명도를 반환하거나 설정한다.
        /// </summary>
        public short Transparent
        {
            get => _transparent;
            set => _transparent = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ShadowInfo from)
        {
            _type = from._type;
            _color.Copy(from._color);
            _offsetX = from._offsetX;
            _offsetY = from._offsetY;
            _transparent = from._transparent;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/caption/ListHeaderForCaption.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Gso.TextBox;

namespace HwpLib.Object.BodyText.Control.Gso.Caption
{
    /// <summary>
    /// 캡션을 위한 문단 리스트 헤더 레코드
    /// </summary>
    public class ListHeaderForCaption
    {
        /// <summary>
        /// 문단 개수
        /// </summary>
        private int _paraCount;

        /// <summary>
        /// 속성
        /// </summary>
        private readonly ListHeaderProperty _property;

        /// <summary>
        /// caption 속성
        /// </summary>
        private readonly ListHeaderCaptionProperty _captionProperty;

        /// <summary>
        /// 캡션 폭(세로 방향일 때만 사용)
        /// </summary>
        private uint _captionWidth;

        /// <summary>
        /// 캡션과 틀 사이 간격
        /// </summary>
        private int _spaceBetweenCaptionAndFrame;

        /// <summary>
        /// 텍스트의 최대 길이(=객체 폭)
        /// </summary>
        private uint _textWidth;

        /// <summary>
        /// 생성자
        /// </summary>
        public ListHeaderForCaption()
        {
            _property = new ListHeaderProperty();
            _captionProperty = new ListHeaderCaptionProperty();
        }

        /// <summary>
        /// 문단 개수를 반환하거나 설정한다.
        /// </summary>
        public int ParaCount
        {
            get => _paraCount;
            set => _paraCount = value;
        }

        /// <summary>
        /// 속성 객체를 반환한다.
        /// </summary>
        public ListHeaderProperty Property => _property;

        /// <summary>
        /// caption 속성 객체를 반환한다.
        /// </summary>
        public ListHeaderCaptionProperty CaptionProperty => _captionProperty;

        /// <summary>
        /// 캡션 폭을 반환하거나 설정한다. (세로 방향일 때만 사용)
        /// </summary>
        public uint CaptionWidth
        {
            get => _captionWidth;
            set => _captionWidth = value;
        }

        /// <summary>
        /// 캡션과 틀 사이 간격의 크기를 반환하거나 설정한다.
        /// </summary>
        public int SpaceBetweenCaptionAndFrame
        {
            get => _spaceBetweenCaptionAndFrame;
            set => _spaceBetweenCaptionAndFrame = value;
        }

        /// <summary>
        /// 텍스트의 폭를 반환하거나 설정한다.
        /// </summary>
        public uint TextWidth
        {
            get => _textWidth;
            set => _textWidth = value;
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ListHeaderForCaption from)
        {
            _paraCount = from._paraCount;
            _property.Copy(from._property);
            _captionProperty.Copy(from._captionProperty);
            _captionWidth = from._captionWidth;
            _spaceBetweenCaptionAndFrame = from._spaceBetweenCaptionAndFrame;
            _textWidth = from._textWidth;
        }
    }
}

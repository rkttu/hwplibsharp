// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/tabdef/TabDefProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.DocInfo.TabDef
{
    /// <summary>
    /// 탭 정의의 속성 객체
    /// </summary>
    public class TabDefProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값 (unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public TabDefProperty()
        {
        }

        /// <summary>
        /// 문단 왼쪽 끝 자동 탭(내어 쓰기용 자동 탭) 유무 (0 bit)
        /// </summary>
        public bool IsAutoTabAtParagraphLeftEnd
        {
            get => BitFlag.Get(Value, 0);
            set => Value = (uint)BitFlag.Set(Value, 0, value);
        }

        /// <summary>
        /// 문단 오른쪽 끝 자동 탭 유무 (1 bit)
        /// </summary>
        public bool IsAutoTabAtParagraphRightEnd
        {
            get => BitFlag.Get(Value, 1);
            set => Value = (uint)BitFlag.Set(Value, 1, value);
        }

        /// <summary>
        /// 다른 TabDefProperty 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(TabDefProperty from)
        {
            Value = from.Value;
        }
    }
}

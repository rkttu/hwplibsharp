// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/header/ParaHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Paragraph.Header
{
    /// <summary>
    /// 문단 헤더 레코드
    /// </summary>
    public class ParaHeader
    {
        /// <summary>
        /// 문단 리스트에서 이 문단이 마지막 문단인지 여부
        /// </summary>
        public bool LastInList { get; set; }

        /// <summary>
        /// 텍스트가 가지고 있는 문자의 개수
        /// </summary>
        public long CharacterCount { get; set; }

        /// <summary>
        /// control mask
        /// </summary>
        public ControlMask ControlMask { get; }

        /// <summary>
        /// 참조된 문단 모양 id
        /// </summary>
        public int ParaShapeId { get; set; }

        /// <summary>
        /// 참조된 스타일 id
        /// </summary>
        public short StyleId { get; set; }

        /// <summary>
        /// 단 나누기 종류
        /// </summary>
        public DivideSort DivideSort { get; }

        /// <summary>
        /// 글자 모양 정보의 개수. ParaCharShape에 글자 위치-글자 모양 쌍의 개수
        /// </summary>
        public int CharShapeCount { get; set; }

        /// <summary>
        /// range tag 정보의 개수. ParaRangeTag의 영역 태그의 개수
        /// </summary>
        public int RangeTagCount { get; set; }

        /// <summary>
        /// 각 줄에 대한 align에 대한 정보의 개수. ParaLineSeg의 정보의 개수
        /// </summary>
        public int LineAlignCount { get; set; }

        /// <summary>
        /// 문단 Instance ID (unique ID)
        /// </summary>
        public long InstanceID { get; set; }

        /// <summary>
        /// 변경추적 병합 문단여부 (5.0.3.2 버전 이상)
        /// </summary>
        public int IsMergedByTrack { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ParaHeader()
        {
            ControlMask = new ControlMask();
            DivideSort = new DivideSort();
        }

        /// <summary>
        /// 다른 ParaHeader 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParaHeader from)
        {
            LastInList = from.LastInList;
            CharacterCount = from.CharacterCount;
            ControlMask.Copy(from.ControlMask);
            ParaShapeId = from.ParaShapeId;
            StyleId = from.StyleId;
            DivideSort.Copy(from.DivideSort);
            CharShapeCount = from.CharShapeCount;
            RangeTagCount = from.RangeTagCount;
            LineAlignCount = from.LineAlignCount;
            InstanceID = from.InstanceID;
            IsMergedByTrack = from.IsMergedByTrack;
        }
    }
}

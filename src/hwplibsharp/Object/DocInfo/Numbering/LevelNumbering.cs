// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/numbering/LevelNumbering.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.Etc;

namespace HwpLib.Object.DocInfo.Numbering
{
    /// <summary>
    /// 각 수준(1~7)에 해당하는 문단 번호 정보
    /// </summary>
    public class LevelNumbering
    {
        /// <summary>
        /// 문단 머리 정보
        /// </summary>
        private readonly ParagraphHeadInfo _paragraphHeadInfo;

        /// <summary>
        /// 번호 형식
        /// </summary>
        private readonly HWPString _numberFormat;

        /// <summary>
        /// 수준별 시작번호 (5.0.2.5 이상)
        /// </summary>
        public uint StartNumber { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public LevelNumbering()
        {
            _paragraphHeadInfo = new ParagraphHeadInfo();
            _numberFormat = new HWPString();
        }

        /// <summary>
        /// 문단 머리 정보에 대한 객체를 반환한다.
        /// </summary>
        public ParagraphHeadInfo ParagraphHeadInfo => _paragraphHeadInfo;

        /// <summary>
        /// 번호 형식을 반환한다.
        /// </summary>
        public HWPString NumberFormat => _numberFormat;

        /// <summary>
        /// 다른 LevelNumbering 객체에서 데이터를 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(LevelNumbering from)
        {
            _paragraphHeadInfo.Copy(from._paragraphHeadInfo);
            _numberFormat.Copy(from._numberFormat);
            StartNumber = from.StartNumber;
        }
    }
}

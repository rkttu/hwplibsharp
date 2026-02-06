// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/Bullet.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Object.DocInfo.Numbering;
using HwpLib.Object.Etc;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 글머리표에 대한 레코드
    /// </summary>
    public class Bullet
    {
        private readonly ParagraphHeadInfo _paragraphHeadInfo;
        private readonly HWPString _bulletChar;
        private bool _imageBullet;
        private readonly PictureInfo _imageBulletInfo;
        private readonly HWPString _checkBulletChar;

        /// <summary>
        /// <see cref="Bullet"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public Bullet()
        {
            _paragraphHeadInfo = new ParagraphHeadInfo();
            _bulletChar = new HWPString();
            _imageBullet = false;
            _imageBulletInfo = new PictureInfo();
            _checkBulletChar = new HWPString();
        }

        /// <summary>
        /// 문단 머리 정보입니다.
        /// </summary>
        public ParagraphHeadInfo ParagraphHeadInfo => _paragraphHeadInfo;

        /// <summary>
        /// 글머리표 문자입니다.
        /// </summary>
        public HWPString BulletChar => _bulletChar;

        /// <summary>
        /// 이미지 글머리표 사용 여부입니다.
        /// </summary>
        public bool ImageBullet
        {
            get => _imageBullet;
            set => _imageBullet = value;
        }

        /// <summary>
        /// 이미지 글머리표 정보입니다.
        /// </summary>
        public PictureInfo ImageBulletInfo => _imageBulletInfo;

        /// <summary>
        /// 체크 글머리표 문자입니다.
        /// </summary>
        public HWPString CheckBulletChar => _checkBulletChar;

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="Bullet"/>의 새 인스턴스입니다.</returns>
        public Bullet Clone()
        {
            var cloned = new Bullet();
            cloned._paragraphHeadInfo.Copy(_paragraphHeadInfo);
            cloned._bulletChar.Copy(_bulletChar);
            cloned._imageBullet = _imageBullet;
            cloned._imageBulletInfo.Copy(_imageBulletInfo);
            cloned._checkBulletChar.Copy(_checkBulletChar);
            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/Control.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Bookmark;

namespace HwpLib.Object.BodyText.Control
{
    /// <summary>
    /// 컨트롤에 대한 추상 객체
    /// </summary>
    public abstract class Control
    {
        /// <summary>
        /// 컨트롤 헤더 객체
        /// </summary>
        protected CtrlHeader.CtrlHeader? Header;

        /// <summary>
        /// 컨트롤 데이터
        /// </summary>
        protected CtrlData? CtrlData;

        /// <summary>
        /// 컨트롤 헤더 객체를 반환한다.
        /// </summary>
        public CtrlHeader.CtrlHeader? GetHeader() => Header;

        /// <summary>
        /// 컨트롤 데이터를 반환한다.
        /// </summary>
        public CtrlData? GetControlData() => CtrlData;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">컨트롤 헤더 객체</param>
        protected Control(CtrlHeader.CtrlHeader header)
        {
            Header = header;
            CtrlData = null;
        }

        /// <summary>
        /// 컨트롤 타입을 반환한다.
        /// </summary>
        public ControlType Type => ControlTypeExtensions.CtrlIdOf(Header?.CtrlId ?? 0);

        /// <summary>
        /// 헤더가 null인지 여부를 반환한다.
        /// </summary>
        public bool IsNullHeader => Header == null;

        /// <summary>
        /// 필드 컨트롤인지 여부를 반환한다.
        /// </summary>
        public bool IsField => ControlTypeExtensions.IsField(Header?.CtrlId ?? 0);

        /// <summary>
        /// 컨트롤 데이터를 생성한다.
        /// </summary>
        public void CreateCtrlData()
        {
            CtrlData = new CtrlData();
        }

        /// <summary>
        /// 컨트롤 데이터를 삭제한다.
        /// </summary>
        public void DeleteCtrlData()
        {
            CtrlData = null;
        }

        /// <summary>
        /// 컨트롤 데이터를 반환하거나 설정한다.
        /// </summary>
        public CtrlData? GetCtrlData()
        {
            return CtrlData;
        }

        /// <summary>
        /// 컨트롤 데이터를 설정한다.
        /// </summary>
        /// <param name="ctrlData">컨트롤 데이터</param>
        public void SetCtrlData(CtrlData? ctrlData)
        {
            CtrlData = ctrlData;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public abstract Control Clone();

        /// <summary>
        /// 컨트롤 부분을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void CopyControlPart(Control from)
        {
            if (from.Header != null)
            {
                Header?.Copy(from.Header);
            }
            else
            {
                Header = null;
            }

            if (from.CtrlData != null)
            {
                CreateCtrlData();
                CtrlData?.Copy(from.CtrlData);
            }
            else
            {
                CtrlData = null;
            }
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/CtrlHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.CtrlHeader
{
    /// <summary>
    /// 컨트롤 헤더 객체들을 위한 부모 클래스
    /// </summary>
    public abstract class CtrlHeader
    {
        /// <summary>
        /// 컨트롤 아이디
        /// </summary>
        protected uint ctrlId;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="ctrlId">컨트롤 아이디</param>
        public CtrlHeader(uint ctrlId)
        {
            this.ctrlId = ctrlId;
        }

        /// <summary>
        /// 컨트롤 아이디를 반환한다.
        /// </summary>
        public uint CtrlId => ctrlId;

        /// <summary>
        /// 다른 <see cref="CtrlHeader"/> 인스턴스의 값을 이 인스턴스에 복사합니다.
        /// </summary>
        /// <param name="from">복사할 원본 <see cref="CtrlHeader"/> 인스턴스입니다.</param>
        public abstract void Copy(CtrlHeader from);
    }
}

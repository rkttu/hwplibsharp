// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/autonumber/AutoNumberHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.SectionDefine;
using HwpLib.Util.Binary;


namespace HwpLib.Object.BodyText.Control.CtrlHeader.AutoNumber
{
    /// <summary>
    /// 자동번호 컨트롤의 속성 객체
    /// </summary>
    public class AutoNumberHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public AutoNumberHeaderProperty()
        {
        }

        /// <summary>
        /// 번호 종류를 반환한다. (0~3 bit)
        /// </summary>
        /// <returns>번호 종류</returns>
        public NumberSort GetNumberSort()
        {
            return NumberSortExtensions.FromValue((byte)BitFlag.Get((long)Value, 0, 3));
        }

        /// <summary>
        /// 번호 종류를 설정한다. (0~3 bit)
        /// </summary>
        /// <param name="numberSort">번호 종류</param>
        public void SetNumberSort(NumberSort numberSort)
        {
            Value = (uint)BitFlag.Set((long)Value, 0, 3, numberSort.GetValue());
        }

        /// <summary>
        /// 번호 모양을 반환한다. (4~11 bit)
        /// </summary>
        /// <returns>번호 모양</returns>
        public NumberShape GetNumberShape()
        {
            return NumberShapeExtensions.FromValue((short)BitFlag.Get((long)Value, 4, 11));
        }

        /// <summary>
        /// 번호 모양을 설정한다. (4~11 bit)
        /// </summary>
        /// <param name="numberShape">번호 모양</param>
        public void SetNumberShape(NumberShape numberShape)
        {
            Value = (uint)BitFlag.Set((long)Value, 4, 11, numberShape.GetValue());
        }

        /// <summary>
        /// 각주 내용 중 번호 코드의 모양을 윗 첨자 형식으로 할지 여부를 반환한다. (12 bit)
        /// </summary>
        /// <returns>각주 내용 중 번호 코드의 모양을 윗 첨자 형식으로 할지 여부</returns>
        public bool IsSuperScript()
        {
            return BitFlag.Get((long)Value, 12);
        }

        /// <summary>
        /// 각주 내용 중 번호 코드의 모양을 윗 첨자 형식으로 할지 여부를 설정한다. (12 bit)
        /// </summary>
        /// <param name="superScript">각주 내용 중 번호 코드의 모양을 윗 첨자 형식으로 할지 여부</param>
        public void SetSuperScript(bool superScript)
        {
            Value = (uint)BitFlag.Set((long)Value, 12, superScript);
        }

        /// <summary>
        /// 다른 AutoNumberHeaderProperty 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(AutoNumberHeaderProperty from)
        {
            Value = from.Value;
        }
    }

}
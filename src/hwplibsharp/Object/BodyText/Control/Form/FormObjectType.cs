using System;


namespace HwpLib.Object.BodyText.Control.Form
{

    /// <summary>
    /// 양식 개체 타입
    /// </summary>
    public enum FormObjectType : uint
    {
        /// <summary>
        /// 양식개체_명령단추
        /// </summary>
        PushButton = 0x2B706274, // CtrlID.Make('+', 'p', 'b', 't')

        /// <summary>
        /// 양식개체_선택상자
        /// </summary>
        CheckBox = 0x2B636274, // CtrlID.Make('+', 'c', 'b', 't')

        /// <summary>
        /// 양식개체_목록상자
        /// </summary>
        ComboBox = 0x2B636F62, // CtrlID.Make('+', 'c', 'o', 'b')

        /// <summary>
        /// 양식개체_라디오단추
        /// </summary>
        RadioButton = 0x2B726274, // CtrlID.Make('+', 'r', 'b', 't')

        /// <summary>
        /// 양식개체_입력상자
        /// </summary>
        EditorBox = 0x2B656474, // CtrlID.Make('+', 'e', 'd', 't')
    }

    /// <summary>
    /// FormObjectType 열거형에 대한 확장 메서드
    /// </summary>
    public static class FormObjectTypeExtensions
    {
        /// <summary>
        /// 컨트롤 id를 반환한다.
        /// </summary>
        /// <param name="type">FormObjectType 값</param>
        /// <returns>컨트롤 id</returns>
        public static uint GetId(this FormObjectType type) => (uint)type;

        /// <summary>
        /// id에서 FormObjectType을 반환한다.
        /// </summary>
        /// <param name="id">컨트롤 id</param>
        /// <returns>FormObjectType 값 또는 null</returns>
        public static FormObjectType? FromUint4(uint id)
        {
#if NET5_0_OR_GREATER
            // .NET 5+ uses AOT-compatible Enum.GetValues<T>()
            foreach (FormObjectType fot in System.Enum.GetValues<FormObjectType>())
#else
            // .NET Framework / .NET Standard uses reflection-based approach (AOT not applicable)
            foreach (FormObjectType fot in (FormObjectType[])System.Enum.GetValues(typeof(FormObjectType)))
#endif
            {
                if ((uint)fot == id)
                {
                    return fot;
                }
            }
            return null;
        }
    }

}
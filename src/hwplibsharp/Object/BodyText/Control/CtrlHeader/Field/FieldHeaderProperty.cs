// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/ctrlheader/field/FieldHeaderProperty.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Util.Binary;

namespace HwpLib.Object.BodyText.Control.CtrlHeader.Field
{
    /// <summary>
    /// 필드 컨트롤의 속성을 나타내는 객체
    /// </summary>
    public class FieldHeaderProperty
    {
        /// <summary>
        /// 파일에 저장되는 정수값(unsigned 4 byte)
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public FieldHeaderProperty()
        {
        }

        /// <summary>
        /// 읽기 전용 상태에서도 수정 가능한지 여부를 반환한다. (0 bit)
        /// </summary>
        /// <returns>읽기 전용 상태에서도 수정 가능한지 여부</returns>
        public bool CanModifyInReadOnlyState()
        {
            return BitFlag.Get((long)Value, 0);
        }

        /// <summary>
        /// 읽기 전용 상태에서도 수정 가능한지 여부를 설정한다. (0 bit)
        /// </summary>
        /// <param name="canModifyInReadOnlyState">읽기 전용 상태에서도 수정 가능한지 여부</param>
        public void SetCanModifyInReadOnlyState(bool canModifyInReadOnlyState)
        {
            Value = (uint)BitFlag.Set((long)Value, 0, canModifyInReadOnlyState);
        }

        /// <summary>
        /// 열어보지 않은 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부를 반환한다. (11 bit)
        /// </summary>
        /// <returns>열어보지 않은 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부</returns>
        public bool IsUpdateTextPropertyAtUpdatingHyperlinkNotOpened()
        {
            return BitFlag.Get((long)Value, 11);
        }

        /// <summary>
        /// 열어보지 않은 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부를 설정한다. (11 bit)
        /// </summary>
        /// <param name="updateTextPropertyAtUpdatingHyperlinkNotOpened">열어보지 않은 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부</param>
        public void SetUpdateTextPropertyAtUpdatingHyperlinkNotOpened(bool updateTextPropertyAtUpdatingHyperlinkNotOpened)
        {
            Value = (uint)BitFlag.Set((long)Value, 11, updateTextPropertyAtUpdatingHyperlinkNotOpened);
        }

        /// <summary>
        /// 열어본 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부를 반환한다. (12 bit)
        /// </summary>
        /// <returns>열어본 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부</returns>
        public bool IsUpdateTextPropertyAtUpdatingHyperlinkOpened()
        {
            return BitFlag.Get((long)Value, 12);
        }

        /// <summary>
        /// 열어본 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부를 설정한다. (12 bit)
        /// </summary>
        /// <param name="updateTextPropertyAtUpdatingHyperlinkOpened">열어본 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부</param>
        public void SetUpdateTextPropertyAtUpdatingHyperlinkOpened(bool updateTextPropertyAtUpdatingHyperlinkOpened)
        {
            Value = (uint)BitFlag.Set((long)Value, 12, updateTextPropertyAtUpdatingHyperlinkOpened);
        }

        /// <summary>
        /// 생성된 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부를 반환한다. (13 bit)
        /// </summary>
        /// <returns>생성된 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부</returns>
        public bool IsUpdateTextPropertyAtUpdatingHyperlinkCreating()
        {
            return BitFlag.Get((long)Value, 13);
        }

        /// <summary>
        /// 생성된 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부를 설정한다. (13 bit)
        /// </summary>
        /// <param name="updateTextPropertyAtUpdatingHyperlinkCreating">생성된 하이퍼링크 필드 업데이트 시 글자 속성 업데이트 여부</param>
        public void SetUpdateTextPropertyAtUpdatingHyperlinkCreating(bool updateTextPropertyAtUpdatingHyperlinkCreating)
        {
            Value = (uint)BitFlag.Set((long)Value, 13, updateTextPropertyAtUpdatingHyperlinkCreating);
        }

        /// <summary>
        /// 필드 내용이 수정되었는지 여부를 반환한다. (15 bit)
        /// </summary>
        /// <returns>필드 내용이 수정되었는지 여부</returns>
        public bool IsModifiedContent()
        {
            return BitFlag.Get((long)Value, 15);
        }

        /// <summary>
        /// 필드 내용이 수정되었는지 여부를 설정한다. (15 bit)
        /// </summary>
        /// <param name="modifiedContent">필드 내용이 수정되었는지 여부</param>
        public void SetModifiedContent(bool modifiedContent)
        {
            Value = (uint)BitFlag.Set((long)Value, 15, modifiedContent);
        }

        /// <summary>
        /// 다른 FieldHeaderProperty 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(FieldHeaderProperty from)
        {
            Value = from.Value;
        }
    }
}

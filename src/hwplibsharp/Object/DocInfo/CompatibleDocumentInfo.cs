// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/docinfo/CompatibleDocument.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.DocInfo.CompatibleDocument;

namespace HwpLib.Object.DocInfo
{
    /// <summary>
    /// 호환 문서에 대한 레코드
    /// </summary>
    public class CompatibleDocumentInfo
    {
        private CompatibleDocumentSort _targetProgram;

        /// <summary>
        /// <see cref="CompatibleDocumentInfo"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public CompatibleDocumentInfo()
        {
        }

        /// <summary>
        /// 호환 문서의 대상 프로그램을 가져오거나 설정합니다.
        /// </summary>
        public CompatibleDocumentSort TargetProgram
        {
            get => _targetProgram;
            set => _targetProgram = value;
        }

        /// <summary>
        /// 이 인스턴스의 복사본을 생성합니다.
        /// </summary>
        /// <returns>멤버 값이 동일한 <see cref="CompatibleDocumentInfo"/>의 새 인스턴스입니다.</returns>
        public CompatibleDocumentInfo Clone()
        {
            var cloned = new CompatibleDocumentInfo
            {
                _targetProgram = _targetProgram
            };
            return cloned;
        }
    }
}

// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/Scripts.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object
{
    /// <summary>
    /// 스크립트 정보
    /// </summary>
    public class Scripts
    {
        private byte[]? _defaultJScript;
        private byte[]? _jScriptVersion;

        /// <summary>
        /// 생성자
        /// </summary>
        public Scripts()
        {
            _defaultJScript = null;
            _jScriptVersion = null;
        }

        /// <summary>
        /// 기본 JScript
        /// </summary>
        public byte[]? DefaultJScript
        {
            get => _defaultJScript;
            set => _defaultJScript = value;
        }

        /// <summary>
        /// JScript 버전
        /// </summary>
        public byte[]? JScriptVersion
        {
            get => _jScriptVersion;
            set => _jScriptVersion = value;
        }

        /// <summary>
        /// 다른 Scripts 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">원본 Scripts 객체</param>
        public void Copy(Scripts from)
        {
            _defaultJScript = from._defaultJScript;
            _jScriptVersion = from._jScriptVersion;
        }
    }
}

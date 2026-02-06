// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/fileheader/FileHeader.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.FileHeader
{
    /// <summary>
    /// 파일 인식 정보를 나타내는 객체. HWP 파일내의 "FileHeader" stream에 저장된다.
    /// </summary>
    public class FileHeader
    {
        /// <summary>
        /// 파일 버전
        /// </summary>
        private readonly FileVersion _version;

        /// <summary>
        /// 압축 여부
        /// </summary>
        private bool _compressed;

        /// <summary>
        /// 암호 설정 여부
        /// </summary>
        private bool _hasPassword;

        /// <summary>
        /// 배포용 문서 여부
        /// </summary>
        private bool _isDistribution;

        /// <summary>
        /// 스크립트 저장 여부
        /// </summary>
        private bool _saveScript;

        /// <summary>
        /// DRM 보안 문서 여부
        /// </summary>
        private bool _isDrmDocument;

        /// <summary>
        /// XMLTemplate 스토리지 존재 여부
        /// </summary>
        private bool _hasXmlTemplate;

        /// <summary>
        /// 문서 이력 관리 존재 여부
        /// </summary>
        private bool _hasDocumentHistory;

        /// <summary>
        /// 전자 서명 정보 존재 여부
        /// </summary>
        private bool _hasSignature;

        /// <summary>
        /// 공인 인증서 암호화 여부
        /// </summary>
        private bool _encryptPublicCertification;

        /// <summary>
        /// 전자 서명 예비 저장 여부
        /// </summary>
        private bool _savePrepareSignature;

        /// <summary>
        /// 공인 인증서 DRM 보안 문서 여부
        /// </summary>
        private bool _isPublicCertificationDrmDocument;

        /// <summary>
        /// CCL 문서 여부
        /// </summary>
        private bool _isCclDocument;

        /// <summary>
        /// 생성자
        /// </summary>
        public FileHeader()
        {
            _version = new FileVersion();
        }

        /// <summary>
        /// HWP 파일의 signature를 반환한다. signature은 파일이 HWP파일인지 여부를 체크하는데 사용됨.
        /// </summary>
        /// <returns>HWP 파일의 signature</returns>
        public static byte[] GetFileSignature()
        {
            return new byte[]
            {
                0x48, 0x57, 0x50, 0x20, 0x44, 0x6f, 0x63, 0x75,
                0x6d, 0x65, 0x6e, 0x74, 0x20, 0x46, 0x69, 0x6c,
                0x65, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            };
        }

        /// <summary>
        /// 버전 정보 객체
        /// </summary>
        public FileVersion Version => _version;

        /// <summary>
        /// 압축 여부
        /// </summary>
        public bool Compressed
        {
            get => _compressed;
            set => _compressed = value;
        }

        /// <summary>
        /// 암호 설정 여부
        /// </summary>
        public bool HasPassword
        {
            get => _hasPassword;
            set => _hasPassword = value;
        }

        /// <summary>
        /// 배포용 문서 여부
        /// </summary>
        public bool IsDistribution
        {
            get => _isDistribution;
            set => _isDistribution = value;
        }

        /// <summary>
        /// 스크립트 저장 여부
        /// </summary>
        public bool SaveScript
        {
            get => _saveScript;
            set => _saveScript = value;
        }

        /// <summary>
        /// DRM 보안 문서 여부
        /// </summary>
        public bool IsDrmDocument
        {
            get => _isDrmDocument;
            set => _isDrmDocument = value;
        }

        /// <summary>
        /// XMLTemplate 스토리지 존재 여부
        /// </summary>
        public bool HasXmlTemplate
        {
            get => _hasXmlTemplate;
            set => _hasXmlTemplate = value;
        }

        /// <summary>
        /// 문서 이력 관리 존재 여부
        /// </summary>
        public bool HasDocumentHistory
        {
            get => _hasDocumentHistory;
            set => _hasDocumentHistory = value;
        }

        /// <summary>
        /// 전자 서명 정보 존재 여부
        /// </summary>
        public bool HasSignature
        {
            get => _hasSignature;
            set => _hasSignature = value;
        }

        /// <summary>
        /// 공인 인증서 암호화 여부
        /// </summary>
        public bool EncryptPublicCertification
        {
            get => _encryptPublicCertification;
            set => _encryptPublicCertification = value;
        }

        /// <summary>
        /// 전자 서명 예비 저장 여부
        /// </summary>
        public bool SavePrepareSignature
        {
            get => _savePrepareSignature;
            set => _savePrepareSignature = value;
        }

        /// <summary>
        /// 공인 인증서 DRM 보안 문서 여부
        /// </summary>
        public bool IsPublicCertificationDrmDocument
        {
            get => _isPublicCertificationDrmDocument;
            set => _isPublicCertificationDrmDocument = value;
        }

        /// <summary>
        /// CCL 문서 여부
        /// </summary>
        public bool IsCclDocument
        {
            get => _isCclDocument;
            set => _isCclDocument = value;
        }

        /// <summary>
        /// 다른 FileHeader의 값을 복사한다.
        /// </summary>
        /// <param name="from">원본 FileHeader</param>
        public void Copy(FileHeader from)
        {
            _version.Copy(from._version);
            _compressed = from._compressed;
            _hasPassword = from._hasPassword;
            _isDistribution = from._isDistribution;
            _saveScript = from._saveScript;
            _isDrmDocument = from._isDrmDocument;
            _hasXmlTemplate = from._hasXmlTemplate;
            _hasDocumentHistory = from._hasDocumentHistory;
            _hasSignature = from._hasSignature;
            _encryptPublicCertification = from._encryptPublicCertification;
            _savePrepareSignature = from._savePrepareSignature;
            _isPublicCertificationDrmDocument = from._isPublicCertificationDrmDocument;
            _isCclDocument = from._isCclDocument;
        }
    }
}

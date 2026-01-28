// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/fileheader/FileVersion.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.FileHeader
{

    /// <summary>
    /// 파일 버전를 나타내는 객체
    /// </summary>
    public class FileVersion
    {
        /// <summary>
        /// 파일 버전 - MM
        /// </summary>
        private short _mm;

        /// <summary>
        /// 파일 버전 - nn
        /// </summary>
        private short _nn;

        /// <summary>
        /// 파일 버전 - PP
        /// </summary>
        private short _pp;

        /// <summary>
        /// 파일 버전 - rr
        /// </summary>
        private short _rr;

        /// <summary>
        /// 생성자
        /// </summary>
        public FileVersion()
        {
        }

        /// <summary>
        /// 버전을 설정한다.
        /// </summary>
        /// <param name="version">버전(unsigned 4 bytes)</param>
        public void SetVersion(long version)
        {
            _mm = (short)((version & 0xff000000) >> 24);
            _nn = (short)((version & 0xff0000) >> 16);
            _pp = (short)((version & 0xff00) >> 8);
            _rr = (short)(version & 0xff);
        }

        /// <summary>
        /// 버전을 설정한다.
        /// </summary>
        public void SetVersion(short mm, short nn, short pp, short rr)
        {
            _mm = mm;
            _nn = nn;
            _pp = pp;
            _rr = rr;
        }

        /// <summary>
        /// 버전 값을 반환한다.
        /// </summary>
        public long GetVersion()
        {
            long version = 0;
            version += (_mm & 0xff) << 24;
            version += (_nn & 0xff) << 16;
            version += (_pp & 0xff) << 8;
            version += (_rr & 0xff);
            return version;
        }

        /// <summary>
        /// 파일 버전 - MM
        /// </summary>
        public short MM
        {
            get => _mm;
            set => _mm = value;
        }

        /// <summary>
        /// 파일 버전 - nn
        /// </summary>
        public short NN
        {
            get => _nn;
            set => _nn = value;
        }

        /// <summary>
        /// 파일 버전 - PP
        /// </summary>
        public short PP
        {
            get => _pp;
            set => _pp = value;
        }

        /// <summary>
        /// 파일 버전 - rr
        /// </summary>
        public short RR
        {
            get => _rr;
            set => _rr = value;
        }

        /// <summary>
        /// 현재 버전이 비교 버전(mm2,nn2,pp2,rr2)보다 상위 버전인지 여부를 반환한다.
        /// </summary>
        /// <param name="mm2">비교 버전 - MM</param>
        /// <param name="nn2">비교 버전 - nn</param>
        /// <param name="pp2">비교 버전 - PP</param>
        /// <param name="rr2">비교 버전 - rr</param>
        /// <returns>현재 버전이 비교 버전보다 상위 버전이거나 같은지 여부</returns>
        public bool IsOver(int mm2, int nn2, int pp2, int rr2)
        {
            return (_mm > mm2) || (_mm == mm2 && _nn > nn2) || (_mm == mm2 && _nn == nn2 && _pp > pp2)
                   || (_mm == mm2 && _nn == nn2 && _pp == pp2 && _rr > rr2)
                   || (_mm == mm2 && _nn == nn2 && _pp == pp2 && _rr == rr2);
        }

        /// <summary>
        /// 버젼 문자열로 반환한다.
        /// </summary>
        public override string ToString()
        {
            return $"{_mm}.{_nn}.{_pp}.{_rr}.";
        }

        /// <summary>
        /// 다른 FileVersion의 값을 복사한다.
        /// </summary>
        /// <param name="from">원본 FileVersion</param>
        public void Copy(FileVersion from)
        {
            _mm = from._mm;
            _nn = from._nn;
            _pp = from._pp;
            _rr = from._rr;
        }
    }

}
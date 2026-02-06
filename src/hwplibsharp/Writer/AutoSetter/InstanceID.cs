// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/autosetter/InstanceID.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Writer.AutoSetter
{
    /// <summary>
    /// 인스턴스 ID를 구하기 위한 객체
    /// </summary>
    public class InstanceID
    {
        private const uint StartObjectId = 0x5bb840e1;

        private long _id;

        /// <summary>
        /// 생성자
        /// </summary>
        public InstanceID()
        {
            _id = StartObjectId;
        }

        /// <summary>
        /// 인스턴스 ID를 반환한다.
        /// </summary>
        /// <returns>인스턴스 ID</returns>
        public long Get()
        {
            return _id++;
        }
    }
}

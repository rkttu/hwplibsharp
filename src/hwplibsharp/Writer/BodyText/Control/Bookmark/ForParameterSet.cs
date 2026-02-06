// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/bodytext/bookmark/ForParameterSet.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Bookmark;

namespace HwpLib.Writer.BodyText.Control.Bookmark
{
    /// <summary>
    /// 파라미터 셋을 쓰기 위한 객체
    /// </summary>
    public static class ForParameterSet
    {
        /// <summary>
        /// 파라미터 셋의 크기를 반환한다.
        /// </summary>
        public static int GetSize(ParameterSet? ps)
        {
            if (ps == null)
            {
                return 0;
            }

            int size = 6;
            foreach (var pi in ps.ParameterItemList)
            {
                size += GetSizeForParameterItem(pi);
            }
            return size;
        }

        /// <summary>
        /// 파라미터 아이탬의 크기를 반환한다.
        /// </summary>
        private static int GetSizeForParameterItem(ParameterItem pi)
        {
            int size = 4;
            switch (pi.Type)
            {
                case ParameterType.Null:
                    break;
                case ParameterType.String:
                    size += GetUtf16LEStringSize(pi.Value_BSTR);
                    break;
                case ParameterType.Integer1:
                case ParameterType.Integer2:
                case ParameterType.Integer4:
                case ParameterType.Integer:
                case ParameterType.UnsignedInteger1:
                case ParameterType.UnsignedInteger2:
                case ParameterType.UnsignedInteger4:
                case ParameterType.UnsignedInteger:
                    size += 4;
                    break;
                case ParameterType.ParameterSet:
                    size += GetSize(pi.Value_ParameterSet);
                    break;
                case ParameterType.Array:
                    size += GetSizeForParameterArray(pi);
                    break;
                case ParameterType.BinDataId:
                    size += 2;
                    break;
            }
            return size;
        }

        /// <summary>
        /// UTF-16LE 문자열 크기를 반환한다.
        /// </summary>
        private static int GetUtf16LEStringSize(string? s)
        {
            if (s == null)
            {
                return 2;
            }
            return 2 + s.Length * 2;
        }

        /// <summary>
        /// 배열 파라미터 아이탬의 크기를 반환한다.
        /// </summary>
        private static int GetSizeForParameterArray(ParameterItem pi)
        {
            int size = 4;
            int count = pi.GetValue_ParameterArrayCount();
            for (int index = 0; index < count; index++)
            {
                size += GetSizeForParameterItem(pi.GetValue_ParameterArray(index)!) - 2;
            }
            return size;
        }

        /// <summary>
        /// 파라미터 셋을 쓴다.
        /// </summary>
        public static void Write(ParameterSet? ps, CompoundStreamWriter sw)
        {
            if (ps == null)
            {
                return;
            }

            sw.WriteUInt2(ps.Id);
            short parameterCount = (short)ps.ParameterItemList.Count;
            sw.WriteSInt2(parameterCount);
            sw.WriteZero(2);
            foreach (var pi in ps.ParameterItemList)
            {
                ParameterItem(pi, sw);
            }
        }

        /// <summary>
        /// 파라미터 아이탬을 쓴다.
        /// </summary>
        private static void ParameterItem(ParameterItem pi, CompoundStreamWriter sw)
        {
            sw.WriteUInt2((int)pi.Id);
            sw.WriteUInt2((int)pi.Type);
            ParameterValue(pi, sw);
        }

        /// <summary>
        /// 파라미터 아이탬의 값을 쓴다.
        /// </summary>
        private static void ParameterValue(ParameterItem pi, CompoundStreamWriter sw)
        {
            switch (pi.Type)
            {
                case ParameterType.Null:
                    break;
                case ParameterType.String:
                    sw.WriteUTF16LEString(pi.Value_BSTR);
                    break;
                case ParameterType.Integer1:
                    sw.WriteSInt4(pi.Value_I1);
                    break;
                case ParameterType.Integer2:
                    sw.WriteSInt4(pi.Value_I2);
                    break;
                case ParameterType.Integer4:
                    sw.WriteSInt4(pi.Value_I4);
                    break;
                case ParameterType.Integer:
                    sw.WriteSInt4(pi.Value_I);
                    break;
                case ParameterType.UnsignedInteger1:
                    sw.WriteUInt4(pi.Value_UI1);
                    break;
                case ParameterType.UnsignedInteger2:
                    sw.WriteUInt4(pi.Value_UI2);
                    break;
                case ParameterType.UnsignedInteger4:
                    sw.WriteUInt4(pi.Value_UI4);
                    break;
                case ParameterType.UnsignedInteger:
                    sw.WriteUInt4(pi.Value_UI);
                    break;
                case ParameterType.ParameterSet:
                    Write(pi.Value_ParameterSet, sw);
                    break;
                case ParameterType.Array:
                    ParameterArray(pi, sw);
                    break;
                case ParameterType.BinDataId:
                    sw.WriteUInt2(pi.Value_BinData);
                    break;
            }
        }

        /// <summary>
        /// 배열 파라미터 아이탬의 값을 쓴다.
        /// </summary>
        private static void ParameterArray(ParameterItem pi, CompoundStreamWriter sw)
        {
            short count = (short)pi.GetValue_ParameterArrayCount();
            sw.WriteSInt2(count);
            if (count > 0)
            {
                sw.WriteUInt2((int)pi.GetValue_ParameterArray(0)!.Id);
                for (int index = 0; index < count; index++)
                {
                    ParameterValue(pi.GetValue_ParameterArray(index)!, sw);
                }
            }
        }
    }
}

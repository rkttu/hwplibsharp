// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/bookmark/ParameterItem.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

namespace HwpLib.Object.BodyText.Control.Bookmark
{
    /// <summary>
    /// 파라미터 아이탬 객체
    /// </summary>
    public class ParameterItem
    {
        /// <summary>
        /// 파라미터 아이탬 id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 파라미터 아이템 종류
        /// </summary>
        public ParameterType Type { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(문자열)
        /// </summary>
        public string? Value_BSTR { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(1byte 정수)
        /// </summary>
        public sbyte Value_I1 { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(2byte 정수)
        /// </summary>
        public short Value_I2 { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(4byte 정수)
        /// </summary>
        public int Value_I4 { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(정수)
        /// </summary>
        public int Value_I { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(1byte 부호없는 정수)
        /// </summary>
        public byte Value_UI1 { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(2byte 부호없는 정수)
        /// </summary>
        public ushort Value_UI2 { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(4byte 부호없는 정수)
        /// </summary>
        public uint Value_UI4 { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(부호없는 정수)
        /// </summary>
        public uint Value_UI { get; set; }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 셋)
        /// </summary>
        public ParameterSet? Value_ParameterSet { get; private set; }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 배열)
        /// </summary>
        public ParameterItem[]? Value_ParameterArray { get; private set; }

        /// <summary>
        /// 파라미터 아이템 값(binData id)
        /// </summary>
        public int Value_BinData { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ParameterItem()
        {
            Id = 0;
            Type = ParameterType.Null;
            Value_BSTR = null;
            Value_I1 = 0;
            Value_I2 = 0;
            Value_I4 = 0;
            Value_I = 0;
            Value_UI1 = 0;
            Value_UI2 = 0;
            Value_UI4 = 0;
            Value_UI = 0;
            Value_ParameterSet = null;
            Value_ParameterArray = null;
            Value_BinData = -1;
        }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 셋) 객체를 생성한다.
        /// </summary>
        public void CreateValue_ParameterSet()
        {
            Value_ParameterSet = new ParameterSet();
        }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 셋) 객체를 삭제한다.
        /// </summary>
        public void DeleteValue_ParameterSet()
        {
            Value_ParameterSet = null;
        }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 배열)의 원소 개수를 반환한다.
        /// </summary>
        /// <returns>파라미터 아이템 값(파라미터 배열)의 원소 개수</returns>
        public int GetValue_ParameterArrayCount()
        {
            return Value_ParameterArray?.Length ?? 0;
        }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 배열)의 원소를 반환한다.
        /// </summary>
        /// <param name="index">파라미터 아이템 값(파라미터 배열)의 원소 인덱스</param>
        /// <returns>파라미터 아이템 값(파라미터 배열)의 원소</returns>
        public ParameterItem? GetValue_ParameterArray(int index)
        {
            return Value_ParameterArray?[index];
        }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 배열)을 생성한다.
        /// </summary>
        /// <param name="count">파라미터 아이템 값(파라미터 배열)의 원소 개수</param>
        public void CreateValue_ParameterArray(int count)
        {
            Value_ParameterArray = new ParameterItem[count];
            for (int index = 0; index < count; index++)
            {
                Value_ParameterArray[index] = new ParameterItem();
            }
        }

        /// <summary>
        /// 파라미터 아이템 값(파라미터 배열)을 삭제한다.
        /// </summary>
        public void DeleteValue_ParameterArray()
        {
            Value_ParameterArray = null;
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public ParameterItem Clone()
        {
            var cloned = new ParameterItem();
            cloned.Copy(this);
            return cloned;
        }

        /// <summary>
        /// 다른 ParameterItem 객체로부터 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public void Copy(ParameterItem from)
        {
            Id = from.Id;
            Type = from.Type;
            Value_BSTR = from.Value_BSTR;
            Value_I1 = from.Value_I1;
            Value_I2 = from.Value_I2;
            Value_I4 = from.Value_I4;
            Value_I = from.Value_I;
            Value_UI1 = from.Value_UI1;
            Value_UI2 = from.Value_UI2;
            Value_UI4 = from.Value_UI4;
            Value_UI = from.Value_UI;

            if (from.Value_ParameterSet != null)
            {
                CreateValue_ParameterSet();
                Value_ParameterSet!.Copy(from.Value_ParameterSet);
            }
            else
            {
                Value_ParameterSet = null;
            }

            if (from.Value_ParameterArray != null)
            {
                int count = from.Value_ParameterArray.Length;
                CreateValue_ParameterArray(count);
                for (int index = 0; index < count; index++)
                {
                    Value_ParameterArray![index].Copy(from.Value_ParameterArray[index]);
                }
            }

            Value_BinData = from.Value_BinData;
        }
    }
}

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control.Bookmark;

namespace HwpLib.Reader.BodyText.Control;

/// <summary>
/// 파라미터 셋을 읽기 위한 객체
/// </summary>
public static class ForParameterSet
{
    /// <summary>
    /// 파라미터 셋을 읽는다.
    /// </summary>
    public static void Read(ParameterSet ps, CompoundStreamReader sr)
    {
        ps.Id = sr.ReadUInt2();
        short parameterCount = sr.ReadSInt2();
        sr.Skip(2); // reserved

        for (int i = 0; i < parameterCount; i++)
        {
            var pi = ps.AddNewParameterItem();
            ReadParameterItem(pi, sr);
        }
    }

    /// <summary>
    /// 파라미터 아이템을 읽는다.
    /// </summary>
    private static void ReadParameterItem(ParameterItem pi, CompoundStreamReader sr)
    {
        pi.Id = sr.ReadUInt2();
        pi.Type = (ParameterType)sr.ReadUInt2();
        ReadParameterValue(pi, sr);
    }

    /// <summary>
    /// 파라미터 아이템의 값을 읽는다.
    /// </summary>
    private static void ReadParameterValue(ParameterItem pi, CompoundStreamReader sr)
    {
        switch (pi.Type)
        {
            case ParameterType.Null:
                break;
            case ParameterType.String:
                pi.Value_BSTR = sr.ReadUTF16LEString();
                break;
            case ParameterType.Integer1:
                pi.Value_I1 = (sbyte)sr.ReadSInt4();
                break;
            case ParameterType.Integer2:
                pi.Value_I2 = (short)sr.ReadSInt4();
                break;
            case ParameterType.Integer4:
                pi.Value_I4 = sr.ReadSInt4();
                break;
            case ParameterType.Integer:
                pi.Value_I = sr.ReadSInt4();
                break;
            case ParameterType.UnsignedInteger1:
                pi.Value_UI1 = (byte)sr.ReadUInt4();
                break;
            case ParameterType.UnsignedInteger2:
                pi.Value_UI2 = (ushort)sr.ReadUInt4();
                break;
            case ParameterType.UnsignedInteger4:
                pi.Value_UI4 = sr.ReadUInt4();
                break;
            case ParameterType.UnsignedInteger:
                pi.Value_UI = sr.ReadUInt4();
                break;
            case ParameterType.ParameterSet:
                pi.CreateValue_ParameterSet();
                Read(pi.Value_ParameterSet!, sr);
                break;
            case ParameterType.Array:
                ReadParameterArray(pi, sr);
                break;
            case ParameterType.BinDataId:
                pi.Value_BinData = sr.ReadUInt2();
                break;
        }
    }

    /// <summary>
    /// 배열 파라미터 아이템을 읽는다.
    /// </summary>
    private static void ReadParameterArray(ParameterItem pi, CompoundStreamReader sr)
    {
        short count = sr.ReadSInt2();
        if (count > 0)
        {
            int arrayItemId = sr.ReadUInt2();
            pi.CreateValue_ParameterArray(count);
            for (int i = 0; i < count; i++)
            {
                var arrayItem = pi.GetValue_ParameterArray(i)!;
                arrayItem.Id = arrayItemId;
                arrayItem.Type = pi.Type;
                ReadParameterValue(arrayItem, sr);
            }
        }
    }
}

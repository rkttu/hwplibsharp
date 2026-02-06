// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/ParameterSetCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.Bookmark;
using HwpLib.Tool.ParagraphAdder.DocInfo;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// ParameterSet을 복사하는 클래스
    /// </summary>
    public class ParameterSetCopier
    {
        /// <summary>
        /// <para>source의 <see cref="ParameterSet"/> 내용을 target에 복사합니다.</para>
        /// <para>필요시 <paramref name="docInfoAdder"/>를 사용하여 BinData 등 부가 정보를 처리합니다.</para>
        /// </summary>
        /// <param name="source">복사할 원본 <see cref="ParameterSet"/></param>
        /// <param name="target">복사 대상 <see cref="ParameterSet"/></param>
        /// <param name="docInfoAdder">부가 정보 처리를 위한 <see cref="DocInfoAdder"/> 인스턴스 (null 허용)</param>
        public static void Copy(ParameterSet? source, ParameterSet? target, DocInfoAdder? docInfoAdder)
        {
            if (source == null || target == null) return;

            target.Id = source.Id;

            foreach (var item in source.ParameterItemList)
            {
                CopyItem(item, target.AddNewParameterItem(), docInfoAdder);
            }
        }

        private static void CopyItem(ParameterItem source, ParameterItem target, DocInfoAdder? docInfoAdder)
        {
            target.Id = source.Id;
            target.Type = source.Type;

            switch (source.Type)
            {
                case ParameterType.Null:
                    break;
                case ParameterType.String:
                    target.Value_BSTR = source.Value_BSTR;
                    break;
                case ParameterType.Integer1:
                    target.Value_I1 = source.Value_I1;
                    break;
                case ParameterType.Integer2:
                    target.Value_I2 = source.Value_I2;
                    break;
                case ParameterType.Integer4:
                    target.Value_I4 = source.Value_I4;
                    break;
                case ParameterType.Integer:
                    target.Value_I = source.Value_I;
                    break;
                case ParameterType.UnsignedInteger1:
                    target.Value_UI1 = source.Value_UI1;
                    break;
                case ParameterType.UnsignedInteger2:
                    target.Value_UI2 = source.Value_UI2;
                    break;
                case ParameterType.UnsignedInteger4:
                    target.Value_UI4 = source.Value_UI4;
                    break;
                case ParameterType.UnsignedInteger:
                    target.Value_UI = source.Value_UI;
                    break;
                case ParameterType.ParameterSet:
                    CopyParameterSet(source, target, docInfoAdder);
                    break;
                case ParameterType.Array:
                    CopyArray(source, target, docInfoAdder);
                    break;
                case ParameterType.BinDataId:
                    if (source.Value_BinData > 0)
                    {
                        target.Value_BinData = docInfoAdder == null ? source.Value_BinData : docInfoAdder.ForBinData().ProcessById(source.Value_BinData);
                    }
                    break;
            }
        }

        private static void CopyArray(ParameterItem source, ParameterItem target, DocInfoAdder? docInfoAdder)
        {
            int count = source.GetValue_ParameterArrayCount();
            if (count == 0) return;

            target.CreateValue_ParameterArray(count);
            for (int index = 0; index < count; index++)
            {
                CopyItem(source.GetValue_ParameterArray(index)!, target.GetValue_ParameterArray(index)!, docInfoAdder);
            }
        }

        private static void CopyParameterSet(ParameterItem source, ParameterItem target, DocInfoAdder? docInfoAdder)
        {
            if (source.Value_ParameterSet == null) return;

            target.CreateValue_ParameterSet();
            Copy(source.Value_ParameterSet, target.Value_ParameterSet, docInfoAdder);
        }
    }
}

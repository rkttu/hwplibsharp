// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/control/ETCControlCopier.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Tool.ParagraphAdder.DocInfo;
using System.Text;

namespace HwpLib.Tool.ParagraphAdder.Control
{
    /// <summary>
    /// 기타 컨트롤을 복사하는 클래스
    /// </summary>
    public class ETCControlCopier
    {
        /// <summary>
        /// ControlAutoNumber의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlAutoNumber</param>
        /// <param name="target">복사 대상 ControlAutoNumber</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyAutoNumber(ControlAutoNumber source, ControlAutoNumber target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlColumnDefine의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlColumnDefine</param>
        /// <param name="target">복사 대상 ControlColumnDefine</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyColumnDefine(ControlColumnDefine source, ControlColumnDefine target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlEndnote의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlEndnote</param>
        /// <param name="target">복사 대상 ControlEndnote</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyEndnote(ControlEndnote source, ControlEndnote target, DocInfoAdder? docInfoAdder)
        {
            target.Header.Copy(source.Header);
            CtrlDataCopier.Copy(source, target, docInfoAdder);
            target.ListHeader?.Copy(source.ListHeader);
            ParagraphCopier.ListCopy(source.ParagraphList, target.ParagraphList, docInfoAdder);
        }

        /// <summary>
        /// ControlField의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlField</param>
        /// <param name="target">복사 대상 ControlField</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyField(ControlField source, ControlField target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);

            if (IsMemo(source) && docInfoAdder != null)
            {
                var sourceFieldHeader = source.GetHeader();
                if (sourceFieldHeader != null)
                {
                    var sourceMemo = GetSourceMemo(sourceFieldHeader.MemoIndex, docInfoAdder);
                    if (sourceMemo != null)
                    {
                        long newMemoIndex = AddMemoToTarget(sourceMemo, docInfoAdder);
                        var targetFieldHeader = target.GetHeader();
                        if (targetFieldHeader != null)
                        {
                            SetNewMemoIndex(targetFieldHeader, newMemoIndex);
                        }
                    }
                }
            }
        }

        private static bool IsMemo(ControlField source)
        {
            var command = source.GetHeader()?.Command;
            if (command?.Bytes == null) return false;
            return command.ToUTF16LEString()?.StartsWith("MEMO") == true;
        }

        private static HwpLib.Object.BodyText.Paragraph.Memo.Memo? GetSourceMemo(int memoIndex, DocInfoAdder docInfoAdder)
        {
            var memoList = docInfoAdder.GetSourceHWPFile()?.BodyText?.MemoList;
            if (memoList == null) return null;

            foreach (var memo in memoList)
            {
                if (memo.MemoList?.MemoIndex == memoIndex)
                {
                    return memo;
                }
            }
            return null;
        }

        private static long AddMemoToTarget(HwpLib.Object.BodyText.Paragraph.Memo.Memo sourceMemo, DocInfoAdder docInfoAdder)
        {
            long maxMemoIndex = 0;
            var memoList = docInfoAdder.GetTargetHWPFile()?.BodyText?.MemoList;
            if (memoList != null)
            {
                foreach (var memo in memoList)
                {
                    var index = memo.MemoList?.MemoIndex ?? 0;
                    if (index > maxMemoIndex) maxMemoIndex = index;
                }
            }
            maxMemoIndex += 1;

            var clonedMemo = sourceMemo.Clone();
            if (clonedMemo.MemoList != null)
                clonedMemo.MemoList.MemoIndex = maxMemoIndex;

            var targetMemo = docInfoAdder.GetTargetHWPFile()?.BodyText?.AddNewMemo();
            if (targetMemo != null)
            {
                var clonedMemoList = clonedMemo.MemoList;
                if (clonedMemoList != null)
                {
                    targetMemo.MemoList?.Copy(clonedMemoList);
                }
                ParagraphCopier.ListCopy(clonedMemo.ParagraphList, targetMemo.ParagraphList, docInfoAdder);
            }
            return maxMemoIndex;
        }

        private static void SetNewMemoIndex(CtrlHeaderField targetH, long newMemoIndex)
        {
            var command = targetH.Command;
            if (command?.Bytes == null) return;

            var commandStr = command.ToUTF16LEString();
            if (commandStr == null) return;

            string[] commands = commandStr.Split('/');
            if (commands.Length > 2)
            {
                commands[2] = newMemoIndex.ToString();
                command.Bytes = Encoding.Unicode.GetBytes(string.Join("/", commands));
                targetH.MemoIndex = (int)newMemoIndex;
            }
        }

        /// <summary>
        /// ControlFooter의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlFooter</param>
        /// <param name="target">복사 대상 ControlFooter</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyFooter(ControlFooter source, ControlFooter target, DocInfoAdder? docInfoAdder)
        {
            target.Header.Copy(source.Header);
            CtrlDataCopier.Copy(source, target, docInfoAdder);
            target.ListHeader?.Copy(source.ListHeader);
            ParagraphCopier.ListCopy(source.ParagraphList, target.ParagraphList, docInfoAdder);
        }

        /// <summary>
        /// ControlFootnote의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlFootnote</param>
        /// <param name="target">복사 대상 ControlFootnote</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyFootnote(ControlFootnote source, ControlFootnote target, DocInfoAdder? docInfoAdder)
        {
            target.Header.Copy(source.Header);
            CtrlDataCopier.Copy(source, target, docInfoAdder);
            target.ListHeader?.Copy(source.ListHeader);
            ParagraphCopier.ListCopy(source.ParagraphList, target.ParagraphList, docInfoAdder);
        }

        /// <summary>
        /// ControlHeader의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlHeader</param>
        /// <param name="target">복사 대상 ControlHeader</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyHeader(ControlHeader source, ControlHeader target, DocInfoAdder? docInfoAdder)
        {
            target.Header.Copy(source.Header);
            CtrlDataCopier.Copy(source, target, docInfoAdder);
            target.ListHeader?.Copy(source.ListHeader);
            ParagraphCopier.ListCopy(source.ParagraphList, target.ParagraphList, docInfoAdder);
        }

        /// <summary>
        /// ControlIndexMark의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlIndexMark</param>
        /// <param name="target">복사 대상 ControlIndexMark</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyIndexMark(ControlIndexMark source, ControlIndexMark target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlNewNumber의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlNewNumber</param>
        /// <param name="target">복사 대상 ControlNewNumber</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyNewNumber(ControlNewNumber source, ControlNewNumber target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlPageHide의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlPageHide</param>
        /// <param name="target">복사 대상 ControlPageHide</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyPageHide(ControlPageHide source, ControlPageHide target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlPageNumberPosition의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlPageNumberPosition</param>
        /// <param name="target">복사 대상 ControlPageNumberPosition</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyPageNumberPosition(ControlPageNumberPosition source, ControlPageNumberPosition target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlPageOddEvenAdjust의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlPageOddEvenAdjust</param>
        /// <param name="target">복사 대상 ControlPageOddEvenAdjust</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyPageOddEvenAdjust(ControlPageOddEvenAdjust source, ControlPageOddEvenAdjust target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlBookmark의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlBookmark</param>
        /// <param name="target">복사 대상 ControlBookmark</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyBookmark(ControlBookmark source, ControlBookmark target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
        }

        /// <summary>
        /// ControlHiddenComment의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlHiddenComment</param>
        /// <param name="target">복사 대상 ControlHiddenComment</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyHiddenComment(ControlHiddenComment source, ControlHiddenComment target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
            target.ListHeader?.Copy(source.ListHeader);
            ParagraphCopier.ListCopy(source.ParagraphList, target.ParagraphList, docInfoAdder);
        }

        /// <summary>
        /// ControlForm의 내용을 target에 복사합니다.
        /// </summary>
        /// <param name="source">복사할 원본 ControlForm</param>
        /// <param name="target">복사 대상 ControlForm</param>
        /// <param name="docInfoAdder">문서 정보 추가자</param>
        public static void CopyForm(ControlForm source, ControlForm target, DocInfoAdder? docInfoAdder)
        {
            var sourceHeader = source.GetHeader();
            if (sourceHeader != null)
            {
                target.GetHeader()?.Copy(sourceHeader);
            }
            CtrlDataCopier.Copy(source, target, docInfoAdder);
            var sourceFormObject = source.FormObject;
            if (sourceFormObject != null)
            {
                target.FormObject?.Copy(sourceFormObject);
            }
        }
    }
}

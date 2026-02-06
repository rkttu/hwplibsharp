// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/paragraphadder/ParagraphAdder.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object;
using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Tool.ParagraphAdder.DocInfo;
using System.Collections.Generic;

namespace HwpLib.Tool.ParagraphAdder
{
    /// <summary>
    /// 파일에 문단을 추가하는 기능을 포함하는 클래스
    /// </summary>
    public class ParagraphAdder
    {
        /// <summary>
        /// target 한글 파일
        /// </summary>
        private readonly HWPFile _targetHWPFile;

        /// <summary>
        /// target 문단 리스트
        /// </summary>
        private readonly IParagraphList _targetParaList;

        /// <summary>
        /// 삽입할 곳의 문단 인덱스
        /// </summary>
        private int _indexToInsert;

        /// <summary>
        /// 문단 복사기
        /// </summary>
        private ParagraphCopier? _paraCopier;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="targetHWPFile">문단을 추가할 한글 파일(target)</param>
        /// <param name="targetParaList">문단을 추가할 문단 리스트(target)</param>
        public ParagraphAdder(HWPFile targetHWPFile, IParagraphList targetParaList)
        {
            _targetHWPFile = targetHWPFile;
            _targetParaList = targetParaList;
            _indexToInsert = -1;
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="targetHWPFile">문단을 추가할 한글 파일(target)</param>
        /// <param name="targetParaList">문단을 추가할 문단 리스트(target)</param>
        /// <param name="indexToInsert">삽입할 위치의 인덱스</param>
        public ParagraphAdder(HWPFile targetHWPFile, IParagraphList targetParaList, int indexToInsert)
        {
            _targetHWPFile = targetHWPFile;
            _targetParaList = targetParaList;
            _indexToInsert = indexToInsert;
        }

        /// <summary>
        /// target 한글 파일의 target 문단 리스트에 문단을 추가한다.
        /// </summary>
        /// <param name="hwpFile">추가될 문단을 포함하는 한글 파일</param>
        /// <param name="p">추가될 문단</param>
        public void Add(HWPFile hwpFile, Paragraph p)
        {
            _paraCopier = new ParagraphCopier(new DocInfoAdder(hwpFile, _targetHWPFile));
            CopyAndAdd(p);
        }

        private void CopyAndAdd(Paragraph p)
        {
            if (_paraCopier == null) return;

            if (_indexToInsert == -1)
            {
                _paraCopier.Copy(p, _targetParaList.AddNewParagraph());
            }
            else
            {
                _paraCopier.Copy(p, _targetParaList.InsertNewParagraph(_indexToInsert));
                _indexToInsert++;
            }
        }

        /// <summary>
        /// target 한글 파일의 target 문단 리스트에 문단 리스트를 추가한다.
        /// </summary>
        /// <param name="hwpFile">추가될 문단을 포함하는 한글 파일</param>
        /// <param name="list">문단 리스트</param>
        public void Add(HWPFile hwpFile, List<Paragraph> list)
        {
            _paraCopier = new ParagraphCopier(new DocInfoAdder(hwpFile, _targetHWPFile));
            foreach (var p in list)
            {
                CopyAndAdd(p);
            }
        }

        /// <summary>
        /// target 한글 파일의 target 문단 리스트에 문단 리스트 인터페이스를 추가한다.
        /// </summary>
        /// <param name="hwpFile">추가될 문단을 포함하는 한글 파일</param>
        /// <param name="paragraphListInterface">문단 리스트 인터페이스</param>
        public void Add(HWPFile hwpFile, IParagraphList paragraphListInterface)
        {
            _paraCopier = new ParagraphCopier(new DocInfoAdder(hwpFile, _targetHWPFile));
            int count = paragraphListInterface.ParagraphCount;
            for (int i = 0; i < count; i++)
            {
                CopyAndAdd(paragraphListInterface.GetParagraph(i));
            }
        }

        /// <summary>
        /// 구역 정보를 포함하여 문단을 추가한다.
        /// </summary>
        /// <param name="hwpFile">추가될 문단을 포함하는 한글 파일</param>
        /// <param name="paragraphListInterface">문단 리스트 인터페이스</param>
        public void AddIncludingSectionInfo(HWPFile hwpFile, IParagraphList paragraphListInterface)
        {
            _paraCopier = new ParagraphCopier(new DocInfoAdder(hwpFile, _targetHWPFile));

            int count = paragraphListInterface.ParagraphCount;
            for (int i = 0; i < count; i++)
            {
                _paraCopier.CopyIncludingSectionInfo(paragraphListInterface.GetParagraph(i), _targetParaList.AddNewParagraph());
            }
        }

        /// <summary>
        /// 대상 문단에 source 문단을 병합한다.
        /// </summary>
        /// <param name="targetParagraph">대상 문단</param>
        /// <param name="hwpFile">source 한글 파일</param>
        /// <param name="p">source 문단</param>
        public void Merge(Paragraph targetParagraph, HWPFile hwpFile, Paragraph p)
        {
            var merger = new ParagraphMerger(new DocInfoAdder(hwpFile, _targetHWPFile));
            merger.Merge(p, targetParagraph);
        }
    }
}

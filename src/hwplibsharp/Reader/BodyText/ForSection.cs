// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/ForSection.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.Etc;
using HwpLib.Reader.BodyText.Control;
using HwpLib.Reader.BodyText.Control.Gso;
using HwpLib.Reader.BodyText.Paragraph;
using ControlNS = HwpLib.Object.BodyText.Control;


namespace HwpLib.Reader.BodyText
{

    /// <summary>
    /// ����(Section)�� �б� ���� ��ü
    /// </summary>
    public class ForSection
    {
        /// <summary>
        /// ���� ��ü
        /// </summary>
        private Section? _section;

        /// <summary>
        /// ��Ʈ�� ����
        /// </summary>
        private CompoundStreamReader? _sr;

        /// <summary>
        /// ���� ����
        /// </summary>
        private Object.BodyText.Paragraph.Paragraph? _currentParagraph;

        /// <summary>
        /// ���������� ���� ��Ʈ��
        /// </summary>
        private ControlNS.Control? _lastControl;

        /// <summary>
        /// ������
        /// </summary>
        public ForSection()
        {
        }

        /// <summary>
        /// ������ �д´�.
        /// </summary>
        /// <param name="section">���� ��ü</param>
        /// <param name="sr">��Ʈ�� ����</param>
        public void Read(Section section, CompoundStreamReader sr)
        {
            _section = section;
            _sr = sr;

            // Java 원본과 동일한 구조: ForParagraphList를 사용하여 문단 읽기
            ForParagraphList.Read(section, sr);

            // 마지막 바탕쪽 정보 처리
            if (sr.IsEndOfStream() || sr.CurrentRecordHeader?.TagId != HWPTag.ListHeader)
            {
                return;
            }
            section.CreateLastBatangPageInfo();
            Control.Secd.ForBatangPageInfo.Read(section.LastBatangPageInfo!, sr);

            // 임의의 바탕쪽 정보 처리
            if (!sr.IsImmediatelyAfterReadingHeader)
            {
                if (!sr.ReadRecordHeader())
                    return;
            }
            if (sr.IsEndOfStream() || sr.CurrentRecordHeader?.TagId != HWPTag.ListHeader)
            {
                return;
            }
            section.CreateAnyBatangPageInfo();
            Control.Secd.ForBatangPageInfo.Read(section.AnyBatangPageInfo!, sr);
        }

        /// <summary>
        /// �̹� ���� ���ڵ� ����� ���� ���ڵ� ������ �д´�.
        /// </summary>
        private void ReadRecordBody()
        {
            if (_sr == null || _section == null || _sr.CurrentRecordHeader == null)
                return;

            var tagId = (short)_sr.CurrentRecordHeader.TagId;

            if (tagId == HWPTag.ParaHeader)
            {
                ReadParaHeader();
            }
            else if (tagId == HWPTag.ParaText)
            {
                ReadParaText();
            }
            else if (tagId == HWPTag.ParaCharShape)
            {
                ReadParaCharShape();
            }
            else if (tagId == HWPTag.ParaLineSeg)
            {
                ReadParaLineSeg();
            }
            else if (tagId == HWPTag.ParaRangeTag)
            {
                ReadParaRangeTag();
            }
            else if (tagId == HWPTag.CtrlHeader)
            {
                ReadCtrlHeader();
            }
            else if (tagId == HWPTag.CtrlData)
            {
                ReadCtrlData();
            }
            else
            {
                // �� �� ���� �±״� �ǳʶڴ�
                _sr.SkipToEndRecord();
            }
        }

        /// <summary>
        /// ���� ��� ���ڵ带 �д´�.
        /// </summary>
        private void ReadParaHeader()
        {
            _currentParagraph = _section!.AddNewParagraph();
            ForParaHeader.Read(_currentParagraph.Header, _sr!);
        }

        /// <summary>
        /// ���� �ؽ�Ʈ ���ڵ带 �д´�.
        /// </summary>
        private void ReadParaText()
        {
            if (_currentParagraph == null) return;
            ForParaText.Read(_currentParagraph, _sr!);
        }

        /// <summary>
        /// ���� ���� ��� ���ڵ带 �д´�.
        /// </summary>
        private void ReadParaCharShape()
        {
            if (_currentParagraph == null) return;
            if (_currentParagraph.CharShape == null)
            {
                _currentParagraph.CreateCharShape();
            }
            ForParaCharShape.Read(_currentParagraph.CharShape!, _sr!);
        }

        /// <summary>
        /// ���� ���̾ƿ� ���ڵ带 �д´�.
        /// </summary>
        private void ReadParaLineSeg()
        {
            if (_currentParagraph == null) return;
            ForParaLineSeg.Read(_currentParagraph, _sr!);
        }

        /// <summary>
        /// ���� ���� �±� ���ڵ带 �д´�.
        /// </summary>
        private void ReadParaRangeTag()
        {
            if (_currentParagraph == null) return;
            if (_currentParagraph.RangeTag == null)
            {
                _currentParagraph.CreateRangeTag();
            }
            ForParaRangeTag.Read(_currentParagraph.RangeTag!, _sr!);
        }

        /// <summary>
        /// ��Ʈ�� ��� ���ڵ带 �д´�.
        /// </summary>
        private void ReadCtrlHeader()
        {
            if (_currentParagraph == null || _sr == null)
            {
                _sr!.SkipToEndRecord();
                return;
            }

            // ��Ʈ�� ID�� �д´� (4����Ʈ)
            uint ctrlId = _sr.ReadUInt4();

            // �ʵ� ��Ʈ���� ���
            if (ControlTypeExtensions.IsField(ctrlId))
            {
                var field = new ControlField(ctrlId);
                ForControlField.Read(field, _sr);
                _currentParagraph.AddControl(field);
                _lastControl = field;
            }
            // ǥ ��Ʈ���� ���
            else if (ctrlId == ControlType.Table.GetCtrlId())
            {
                var table = new ControlTable();
                var fct = new ForControlTable();
                fct.Read(table, _sr);
                _currentParagraph.AddControl(table);
                _lastControl = table;
            }
            // ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.Equation.GetCtrlId())
            {
                var eqed = new ControlEquation();
                var fce = new ForControlEquation();
                fce.Read(eqed, _sr);
                _currentParagraph.AddControl(eqed);
                _lastControl = eqed;
            }
            // Gso ��Ʈ���� ���
            else if (ctrlId == ControlType.Gso.GetCtrlId())
            {
                var fgc = new ForGsoControl();
                fgc.Read(_currentParagraph, _sr);
                // ForGsoControl.Read() �޼��� ���ο��� _currentParagraph.AddNewGsoControl()�� ȣ���Ͽ�
                // ��Ʈ���� �߰��ϹǷ� ���⼭�� ������ AddControl()�� ȣ������ �ʽ��ϴ�.
                // ControlList�� ������ �׸��� _lastControl�� �����մϴ�.
                if (_currentParagraph.ControlList != null && _currentParagraph.ControlList.Count > 0)
                {
                    _lastControl = _currentParagraph.ControlList[_currentParagraph.ControlList.Count - 1];
                }
                else
                {
                    _lastControl = null;
                }
            }
            // Form ��Ʈ���� ��� (���� �������� ���� - ��ŵ)
            else if (ctrlId == ControlType.Form.GetCtrlId())
            {
                SkipControlWithSubRecords();
                _lastControl = null;
            }
            // ���� ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.SectionDefine.GetCtrlId())
            {
                var secd = new ControlSectionDefine();
                var fcsd = new ForControlSectionDefine();
                fcsd.Read(secd, _sr);
                _currentParagraph.AddControl(secd);
                _lastControl = secd;
            }
            // �� ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.ColumnDefine.GetCtrlId())
            {
                var cold = new ControlColumnDefine();
                ForControlColumnDefine.Read(cold, _sr);
                _currentParagraph.AddControl(cold);
                _lastControl = cold;
            }
            // �Ӹ��� ��Ʈ���� ���
            else if (ctrlId == ControlType.Header.GetCtrlId())
            {
                var head = new ControlHeader();
                var fch = new ForControlHeader();
                fch.Read(head, _sr);
                _currentParagraph.AddControl(head);
                _lastControl = head;
            }
            // ������ ��Ʈ���� ���
            else if (ctrlId == ControlType.Footer.GetCtrlId())
            {
                var foot = new ControlFooter();
                var fcf = new ForControlFooter();
                fcf.Read(foot, _sr);
                _currentParagraph.AddControl(foot);
                _lastControl = foot;
            }
            // ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.Footnote.GetCtrlId())
            {
                var fn = new ControlFootnote();
                var fcfn = new ForControlFootnote();
                fcfn.Read(fn, _sr);
                _currentParagraph.AddControl(fn);
                _lastControl = fn;
            }
            // ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.Endnote.GetCtrlId())
            {
                var en = new ControlEndnote();
                var fcen = new ForControlEndnote();
                fcen.Read(en, _sr);
                _currentParagraph.AddControl(en);
                _lastControl = en;
            }
            // �ڵ� ��ȣ ��Ʈ���� ���
            else if (ctrlId == ControlType.AutoNumber.GetCtrlId())
            {
                var an = new ControlAutoNumber();
                ForControlAutoNumber.Read(an, _sr);
                _currentParagraph.AddControl(an);
                _lastControl = an;
            }
            // �� ��ȣ ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.NewNumber.GetCtrlId())
            {
                var nwno = new ControlNewNumber();
                ForControlNewNumber.Read(nwno, _sr);
                _currentParagraph.AddControl(nwno);
                _lastControl = nwno;
            }
            // ���߱� ��Ʈ���� ���
            else if (ctrlId == ControlType.PageHide.GetCtrlId())
            {
                var pghd = new ControlPageHide();
                ForControlPageHide.Read(pghd, _sr);
                _currentParagraph.AddControl(pghd);
                _lastControl = pghd;
            }
            // Ȧ/¦�� ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.PageOddEvenAdjust.GetCtrlId())
            {
                var pgoea = new ControlPageOddEvenAdjust();
                ForControlPageOddEvenAdjust.Read(pgoea, _sr);
                _currentParagraph.AddControl(pgoea);
                _lastControl = pgoea;
            }
            // �� ��ȣ ��ġ ��Ʈ���� ���
            else if (ctrlId == ControlType.PageNumberPosition.GetCtrlId())
            {
                var pgnp = new ControlPageNumberPosition();
                ForControlPageNumberPosition.Read(pgnp, _sr);
                _currentParagraph.AddControl(pgnp);
                _lastControl = pgnp;
            }
            // ã�ƺ��� ǥ�� ��Ʈ���� ���
            else if (ctrlId == ControlType.IndexMark.GetCtrlId())
            {
                var idxm = new ControlIndexMark();
                ForControlIndexMark.Read(idxm, _sr);
                _currentParagraph.AddControl(idxm);
                _lastControl = idxm;
            }
            // å���� ��Ʈ���� ���
            else if (ctrlId == ControlType.Bookmark.GetCtrlId())
            {
                var bkmk = new ControlBookmark();
                ForControlBookmark.Read(bkmk, _sr);
                _currentParagraph.AddControl(bkmk);
                _lastControl = bkmk;
            }
            // ���� ��ħ ��Ʈ���� ���
            else if (ctrlId == ControlType.OverlappingLetter.GetCtrlId())
            {
                var tcps = new ControlOverlappingLetter();
                ForControlOverlappingLetter.Read(tcps, _sr);
                _currentParagraph.AddControl(tcps);
                _lastControl = tcps;
            }
            // ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.AdditionalText.GetCtrlId())
            {
                var at = new ControlAdditionalText();
                ForControlAdditionalText.Read(at, _sr);
                _currentParagraph.AddControl(at);
                _lastControl = at;
            }
            // ���� ���� ��Ʈ���� ���
            else if (ctrlId == ControlType.HiddenComment.GetCtrlId())
            {
                var tcmt = new ControlHiddenComment();
                var fchc = new ForControlHiddenComment();
                fchc.Read(tcmt, _sr);
                _currentParagraph.AddControl(tcmt);
                _lastControl = tcmt;
            }
            else
            {
                // �ٸ� ������ ��Ʈ���� ���� �������� ����
                _sr.SkipToEndRecord();
                _lastControl = null;
            }
        }

        /// <summary>
        /// ���� ���ڵ带 ���� ��Ʈ���� �ǳʶڴ�.
        /// </summary>
        private void SkipControlWithSubRecords()
        {
            var ctrlHeaderLevel = _sr!.CurrentRecordHeader!.Level;
            _sr.SkipToEndRecord();

            while (!_sr.IsEndOfStream())
            {
                if (!_sr.IsImmediatelyAfterReadingHeader)
                {
                    if (!_sr.ReadRecordHeader())
                        break;
                }
                if (ctrlHeaderLevel >= _sr.CurrentRecordHeader!.Level)
                {
                    break;
                }
                _sr.SkipToEndRecord();
            }
        }

        /// <summary>
        /// ��Ʈ�� ������ ���ڵ带 �д´�.
        /// </summary>
        private void ReadCtrlData()
        {
            if (_lastControl == null || _sr == null)
            {
                _sr!.SkipToEndRecord();
                return;
            }

            var ctrlData = ForCtrlData.Read(_sr);
            _lastControl.SetCtrlData(ctrlData);
            _sr.SkipToEndRecord();
        }
    }

}
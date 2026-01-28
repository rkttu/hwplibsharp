// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/ForParagraphList.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.Etc;
using HwpLib.Reader.BodyText.Control.Gso;
using HwpLib.Reader.BodyText.Paragraph;
using System;


namespace HwpLib.Reader.BodyText.Control
{

    /// <summary>
    /// ���� ����Ʈ�� �д� ��ü (ĸ��, ǥ, �Ӹ���/������, ����/���� ��� ��)
    /// </summary>
    public static class ForParagraphList
    {
        /// <summary>
        /// ���� ����Ʈ�� �д´�.
        /// </summary>
        /// <param name="pli">���� ����Ʈ ��ü</param>
        /// <param name="sr">��Ʈ�� ����</param>
        public static void Read(IParagraphList pli, CompoundStreamReader sr)
        {
            var fp = new ForParagraph();
            if (!sr.ReadRecordHeader())
            {
                return;
            }

            while (!sr.IsEndOfStream())
            {
                // ParaHeader가 아닌 경우 루프 종료 (무한 루프 방지)
                if (sr.CurrentRecordHeader?.TagId != HWPTag.ParaHeader)
                {
                    break;
                }

                var para = pli.AddNewParagraph();
                fp.Read(para, sr);
                if (para.Header.LastInList)
                {
                    break;
                }
            }
        }
    }

    /// <summary>
    /// �ϳ��� ������ �б� ���� ��ü
    /// </summary>
    public class ForParagraph
    {
        /// <summary>
        /// ��Ʈ�� ����
        /// </summary>
        private CompoundStreamReader? _sr;

        /// <summary>
        /// ���� ����� level
        /// </summary>
        private short _paraHeaderLevel;

        /// <summary>
        /// ���� ��ü
        /// </summary>
        private Object.BodyText.Paragraph.Paragraph? _paragraph;

        /// <summary>
        /// ������
        /// </summary>
        public ForParagraph()
        {
        }

        /// <summary>
        /// �ϳ��� ������ �д´�.
        /// </summary>
        /// <param name="paragraph">���� ��ü</param>
        /// <param name="sr">��Ʈ�� ����</param>
        public void Read(Object.BodyText.Paragraph.Paragraph paragraph, CompoundStreamReader sr)
        {
            if (sr.CurrentRecordHeader?.TagId != HWPTag.ParaHeader)
            {
                throw new InvalidOperationException("This is not paragraph.");
            }

            _sr = sr;
            _paragraph = paragraph;
            _paraHeaderLevel = (short)sr.CurrentRecordHeader.Level;

            ParaHeaderBody();
            ParaText();
            ParaCharShape();
            ParaLineSeg();
            ParaRangeTag();

            while (!sr.IsEndOfStream())
            {
                if (!sr.IsImmediatelyAfterReadingHeader)
                {
                    sr.ReadRecordHeader();
                }
                if (IsOutOfParagraph() || IsFollowLastBatangPageInfo() || IsFollowMemo())
                {
                    break;
                }
                if (sr.CurrentRecordHeader?.TagId == HWPTag.CtrlHeader)
                {
                    Control();
                }
                else
                {
                    SkipETCRecord();
                }
            }
        }

        /// <summary>
        /// ���� ��� ���ڵ带 �д´�.
        /// </summary>
        private void ParaHeaderBody()
        {
            ForParaHeader.Read(_paragraph!.Header, _sr!);
        }

        /// <summary>
        /// ������ �ؽ�Ʈ ���ڵ带 �д´�.
        /// </summary>
        private void ParaText()
        {
            if (_sr!.IsEndOfStream()) return;

            if (!_sr.IsImmediatelyAfterReadingHeader)
            {
                _sr.ReadRecordHeader();
            }
            if (_sr.CurrentRecordHeader?.TagId == HWPTag.ParaText)
            {
                ForParaText.Read(_paragraph!, _sr);
            }
        }

        /// <summary>
        /// ������ ���� ��� ���ڵ带 �д´�.
        /// </summary>
        private void ParaCharShape()
        {
            if (_sr!.IsEndOfStream()) return;

            if (!_sr.IsImmediatelyAfterReadingHeader)
            {
                _sr.ReadRecordHeader();
            }
            if (_sr.CurrentRecordHeader?.TagId == HWPTag.ParaCharShape)
            {
                if (_paragraph!.CharShape == null) _paragraph.CreateCharShape();
                ForParaCharShape.Read(_paragraph.CharShape!, _sr);
            }
        }

        /// <summary>
        /// ������ ���̾ƿ� ���ڵ带 �д´�.
        /// </summary>
        private void ParaLineSeg()
        {
            if (_sr!.IsEndOfStream()) return;

            if (!_sr.IsImmediatelyAfterReadingHeader)
            {
                _sr.ReadRecordHeader();
            }
            if (_sr.CurrentRecordHeader?.TagId == HWPTag.ParaLineSeg)
            {
                ForParaLineSeg.Read(_paragraph!, _sr);
            }
        }

        /// <summary>
        /// ������ ���� �±� ���ڵ带 �д´�.
        /// </summary>
        private void ParaRangeTag()
        {
            if (_sr!.IsEndOfStream()) return;

            if (!_sr.IsImmediatelyAfterReadingHeader)
            {
                _sr.ReadRecordHeader();
            }
            if (_sr.CurrentRecordHeader?.TagId == HWPTag.ParaRangeTag)
            {
                if (_paragraph!.RangeTag == null) _paragraph.CreateRangeTag();
                ForParaRangeTag.Read(_paragraph.RangeTag!, _sr);
            }
        }

        /// <summary>
        /// ���� ���ڵ� ����� ���� �ٱ������� ���θ� ��ȯ�Ѵ�.
        /// </summary>
        private bool IsOutOfParagraph()
        {
            return _paraHeaderLevel >= _sr!.CurrentRecordHeader!.Level;
        }

        /// <summary>
        /// ������ ������ ������ �ڿ� �پ� �ִ��� ���θ� ��ȯ�Ѵ�.
        /// </summary>
        private bool IsFollowLastBatangPageInfo()
        {
            return _paraHeaderLevel == 0
                && _sr!.CurrentRecordHeader?.TagId == HWPTag.ListHeader
                && _sr.CurrentRecordHeader.Level == 1;
        }

        /// <summary>
        /// �޸� ������ �ڿ� �پ� �ִ��� ���θ� ��ȯ�Ѵ�.
        /// </summary>
        private bool IsFollowMemo()
        {
            return _paraHeaderLevel == 0
                && _sr!.CurrentRecordHeader?.TagId == HWPTag.MemoList
                && _sr.CurrentRecordHeader.Level == 1;
        }

        /// <summary>
        /// ���ܿ� ���Ե� ��Ʈ���� �д´�.
        /// </summary>
        private void Control()
        {
            uint id = _sr!.ReadUInt4();

            // Gso 컨트롤의 경우 - ForGsoControl로 읽음
            if (id == ControlType.Gso.GetCtrlId())
            {
                var forGso = new ForGsoControl();
                forGso.Read(_paragraph!, _sr);
                return;
            }

            // Form ��Ʈ���� ��� (���� �������� ����)
            if (id == ControlType.Form.GetCtrlId())
            {
                SkipControlWithSubRecords();
                return;
            }

            // �ٸ� ��Ʈ���� ForControl�� ���� �д´�
            var c = _paragraph!.AddNewControl(id);
            if (c != null)
            {
                ForControl.Read(c, _sr);
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
                    _sr.ReadRecordHeader();
                }
                if (ctrlHeaderLevel >= _sr.CurrentRecordHeader!.Level)
                {
                    break;
                }
                _sr.SkipToEndRecord();
            }
        }

        /// <summary>
        /// ��Ÿ ���ڵ带 ��ŵ�Ѵ�.
        /// </summary>
        private void SkipETCRecord()
        {
            _sr!.SkipToEndRecord();
        }
    }

}
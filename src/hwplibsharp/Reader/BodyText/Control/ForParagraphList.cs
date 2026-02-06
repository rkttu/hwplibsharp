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
    /// 문단 리스트를 읽는 객체
    /// </summary>
    public static class ForParagraphList
    {
        /// <summary>
        /// 문단 리스트을 읽는다.
        /// </summary>
        /// <param name="pli">문단 리스트 객체</param>
        /// <param name="sr">스트림 리더</param>
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
    /// 하나의 문단을 읽기 위한 객체
    /// </summary>
    public class ForParagraph
    {
        /// <summary>
        /// 스트림 리더
        /// </summary>
        private CompoundStreamReader? _sr;

        /// <summary>
        /// 문단 헤더의 level
        /// </summary>
        private short _paraHeaderLevel;

        /// <summary>
        /// 구역 객체
        /// </summary>
        private Object.BodyText.Paragraph.Paragraph? _paragraph;

        /// <summary>
        /// 생성자
        /// </summary>
        public ForParagraph()
        {
        }

        /// <summary>
        /// 문단 리스트을 읽는다.
        /// </summary>
        /// <param name="paragraph">문단 리스트 객체</param>
        /// <param name="sr">스트림 리더</param>
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
        /// 문단 헤더 레코드를 읽는다.
        /// </summary>
        private void ParaHeaderBody()
        {
            ForParaHeader.Read(_paragraph!.Header, _sr!);
        }

        /// <summary>
        /// 문단의 텍스트 레코드를 읽는다.
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
        /// 문단의 글자 모양 레코드를 읽는다.
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
        /// 문단의 레이아웃 레코드를 읽는다.
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
        /// 문단의 범위 태그 레코드를 읽는다.
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
        /// 현재 레코드 다음에 다른 문단데이터의 여부를 반환한다.
        /// </summary>
        private bool IsOutOfParagraph()
        {
            return _paraHeaderLevel >= _sr!.CurrentRecordHeader!.Level;
        }

        /// <summary>
        /// 문단의 마지막 문단의 뒤에 붙어 있는지 여부를 반환한다.
        /// </summary>
        private bool IsFollowLastBatangPageInfo()
        {
            return _paraHeaderLevel == 0
                && _sr!.CurrentRecordHeader?.TagId == HWPTag.ListHeader
                && _sr.CurrentRecordHeader.Level == 1;
        }

        /// <summary>
        /// 메모 문단의 뒤에 붙어 있는지 여부를 반환한다.
        /// </summary>
        private bool IsFollowMemo()
        {
            return _paraHeaderLevel == 0
                && _sr!.CurrentRecordHeader?.TagId == HWPTag.MemoList
                && _sr.CurrentRecordHeader.Level == 1;
        }

        /// <summary>
        /// 문단에 포함된 컨트롤을 읽는다.
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

            // Form ��Ʈ���� ��� (현재 문단현재 문단)
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
        /// 하위 레코드를 가진 컨트롤을 건너뛴다.
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
        /// 기타 레코드를 스킵한다.
        /// </summary>
        private void SkipETCRecord()
        {
            _sr!.SkipToEndRecord();
        }
    }
}

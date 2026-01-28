// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/bodytext/gso/ForGsoControl.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.Bookmark;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Control.Gso.Caption;
using HwpLib.Object.Etc;
using HwpLib.Reader.BodyText.Control.Gso.Part;
using System;


namespace HwpLib.Reader.BodyText.Control.Gso
{

    /// <summary>
    /// �׸��� ��ü ��Ʈ�ѵ��� �д´�.
    /// </summary>
    public class ForGsoControl
    {
        /// <summary>
        /// ���� ��ü
        /// </summary>
        private Object.BodyText.Paragraph.Paragraph? _paragraph;

        /// <summary>
        /// ��Ʈ�� ����
        /// </summary>
        private CompoundStreamReader? _sr;

        /// <summary>
        /// ������ �׸��� ��ü ��Ʈ��
        /// </summary>
        private GsoControl? _gsoControl;

        private CtrlHeaderGso? _header;
        private Caption? _caption;
        private CtrlData? _ctrlData;

        /// <summary>
        /// ������
        /// </summary>
        public ForGsoControl()
        {
        }

        /// <summary>
        /// �׸��� ��ü ��Ʈ���� �д´�.
        /// </summary>
        /// <param name="paragraph">���� ��ü</param>
        /// <param name="sr">��Ʈ�� ����</param>
        public void Read(Object.BodyText.Paragraph.Paragraph paragraph, CompoundStreamReader sr)
        {
            _paragraph = paragraph;
            _sr = sr;

            CtrlHeader();
            CaptionAndCtrlData();

            long gsoId = GsoIDFromShapeComponent();
            _gsoControl = CreateGsoControl(gsoId);
            RestPartOfShapeComponent();
            RestPartOfControl();
        }

        /// <summary>
        /// �׸��� ��ü�� ��Ʈ�� ��� ���ڵ带 �д´�.
        /// </summary>
        private void CtrlHeader()
        {
            _header = new CtrlHeaderGso();
            ForCtrlHeaderGso.Read(_header, _sr!);
        }

        /// <summary>
        /// ĸ�ǰ� ��Ʈ�� �����͸� �д´�.
        /// </summary>
        private void CaptionAndCtrlData()
        {
            _caption = null;
            _ctrlData = null;

            _sr!.ReadRecordHeader();
            while (_sr.CurrentRecordHeader?.TagId != HWPTag.ShapeComponent)
            {
                if (_sr.IsEndOfStream())
                {
                    break;
                }

                if (_sr.CurrentRecordHeader?.TagId == HWPTag.ListHeader)
                {
                    _caption = new Caption();
                    ForCaption.Read(_caption, _sr);
                    if (!_sr.IsImmediatelyAfterReadingHeader)
                    {
                        _sr.ReadRecordHeader();
                    }
                }
                else if (_sr.CurrentRecordHeader?.TagId == HWPTag.CtrlData)
                {
                    _ctrlData = ForCtrlData.Read(_sr);
                    if (!_sr.IsImmediatelyAfterReadingHeader)
                    {
                        _sr.ReadRecordHeader();
                    }
                }
                else
                {
                    // 예상치 못한 태그가 나온 경우, 해당 레코드를 스킵하고 다음 레코드 헤더를 읽음
                    _sr.SkipToEndRecord();
                    if (_sr.IsEndOfStream())
                    {
                        break;
                    }
                    _sr.ReadRecordHeader();
                }
            }
        }

        /// <summary>
        /// ��ü ���� �Ӽ� ���ڵ�κ��� �׸��� ��ü�� id�� �д´�.
        /// </summary>
        /// <returns>�׸��� ��ü�� id</returns>
        private long GsoIDFromShapeComponent()
        {
            if (!_sr!.IsImmediatelyAfterReadingHeader)
            {
                _sr.ReadRecordHeader();
            }
            if (_sr.CurrentRecordHeader?.TagId == HWPTag.ShapeComponent)
            {
                long id = _sr.ReadUInt4();
                _sr.Skip(4); // id2
                return id;
            }
            else
            {
                throw new InvalidOperationException("Shape Component must come after CtrlHeader for gso control.");
            }
        }

        /// <summary>
        /// �׸��� ��ü ��Ʈ���� �����Ѵ�.
        /// </summary>
        /// <param name="gsoId">�׸��� ��ü ���̵�</param>
        /// <returns>������ �׸��� ��ü ��Ʈ��</returns>
        private GsoControl CreateGsoControl(long gsoId)
        {
            var gc = _paragraph!.AddNewGsoControl((uint)gsoId, _header!);
            gc?.SetCaption(_caption);
            gc?.SetCtrlData(_ctrlData);
            return gc!;
        }

        /// <summary>
        /// ��ü ���� �Ӽ� ���ڵ��� ������ �κ��� �д´�.
        /// </summary>
        private void RestPartOfShapeComponent()
        {
            ForShapeComponent.Read(_gsoControl!, _sr!);
        }

        /// <summary>
        /// ��Ʈ���� ������ �κ��� �д´�.
        /// </summary>
        private void RestPartOfControl()
        {
            switch (_gsoControl!.GsoType)
            {
                case GsoControlType.Line:
                    ForControlLine.ReadRest((ControlLine)_gsoControl, _sr!);
                    break;
                case GsoControlType.Rectangle:
                    ForControlRectangle.ReadRest((ControlRectangle)_gsoControl, _sr!);
                    break;
                case GsoControlType.Ellipse:
                    ForControlEllipse.ReadRest((ControlEllipse)_gsoControl, _sr!);
                    break;
                case GsoControlType.Arc:
                    ForControlArc.ReadRest((ControlArc)_gsoControl, _sr!);
                    break;
                case GsoControlType.Polygon:
                    ForControlPolygon.ReadRest((ControlPolygon)_gsoControl, _sr!);
                    break;
                case GsoControlType.Curve:
                    ForControlCurve.ReadRest((ControlCurve)_gsoControl, _sr!);
                    break;
                case GsoControlType.Picture:
                    ForControlPicture.ReadRest((ControlPicture)_gsoControl, _sr!);
                    break;
                case GsoControlType.OLE:
                    ForControlOLE.ReadRest((ControlOLE)_gsoControl, _sr!);
                    break;
                case GsoControlType.Container:
                    ForControlContainer.ReadRest((ControlContainer)_gsoControl, _sr!);
                    break;
                case GsoControlType.ObjectLinkLine:
                    ForControlObjectLinkLine.ReadRest((ControlObjectLinkLine)_gsoControl, _sr!);
                    break;
                case GsoControlType.TextArt:
                    ForControlTextArt.ReadRest((ControlTextArt)_gsoControl, _sr!);
                    break;
            }
        }

        /// <summary>
        /// ���� ��Ʈ�� �ȿ� ���Ե� ��Ʈ���� �д´�.
        /// </summary>
        /// <param name="sr">��Ʈ�� ����</param>
        /// <returns>���� ��Ʈ�� �ȿ� ���Ե� ��Ʈ��</returns>
        public GsoControl ReadInContainer(CompoundStreamReader sr)
        {
            _sr = sr;
            ShapeComponentInContainer();
            RestPartOfControl();
            return _gsoControl!;
        }

        /// <summary>
        /// ���� ��Ʈ�� �ȿ� ���Ե� ��Ʈ���� ���� �׸��� ��ü ��Ʈ�� ��� ���ڵ带 �д´�.
        /// </summary>
        private void ShapeComponentInContainer()
        {
            _sr!.ReadRecordHeader();
            if (_sr.CurrentRecordHeader?.TagId == HWPTag.ShapeComponent)
            {
                long id = _sr.ReadUInt4();
                _gsoControl = FactoryForControl.CreateGso((uint)id, null!);
                ForShapeComponent.Read(_gsoControl!, _sr);
            }
            else
            {
                throw new InvalidOperationException("Shape Component must come after CtrlHeader for gso control.");
            }
        }
    }

}
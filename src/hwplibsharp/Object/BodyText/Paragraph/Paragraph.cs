// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/paragraph/Paragraph.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso;
using HwpLib.Object.BodyText.Paragraph.CharShape;
using HwpLib.Object.BodyText.Paragraph.Header;
using HwpLib.Object.BodyText.Paragraph.LineSeg;
using HwpLib.Object.BodyText.Paragraph.RangeTag;
using HwpLib.Object.BodyText.Paragraph.Text;
using ControlNS = HwpLib.Object.BodyText.Control;
using System;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Paragraph
{
    /// <summary>
    /// 하나의 문단을 나타내는 객체
    /// </summary>
    public class Paragraph
    {
        /// <summary>
        /// 비어 있는 <see cref="Paragraph"/> 배열입니다.
        /// </summary>
        public static readonly Paragraph[] Zero_Array = Array.Empty<Paragraph>();

        /// <summary>
        /// 헤더
        /// </summary>
        private readonly ParaHeader header;

        /// <summary>
        /// 텍스트
        /// </summary>
        private ParaText? text;

        /// <summary>
        /// 글자 모양
        /// </summary>
        private ParaCharShape? charShape;

        /// <summary>
        /// 레이아웃
        /// </summary>
        private ParaLineSeg? lineSeg;

        /// <summary>
        /// 영역 태그
        /// </summary>
        private ParaRangeTag? rangeTag;

        /// <summary>
        /// 컨트롤 리스트
        /// </summary>
        private List<ControlNS.Control>? controlList;

        /// <summary>
        /// 메모 리스트
        /// </summary>
        private List<Memo.Memo>? memoList;

        /// <summary>
        /// 생성자
        /// </summary>
        public Paragraph()
        {
            header = new ParaHeader();
        }

        /// <summary>
        /// 헤더에 대한 객체를 반환한다.
        /// </summary>
        public ParaHeader Header => header;

        /// <summary>
        /// 문단 텍스트에 대한 객체를 생성한다.
        /// </summary>
        public void CreateText()
        {
            text = new ParaText();
        }

        /// <summary>
        /// 문단 텍스트에 대한 객체를 삭제한다.
        /// </summary>
        public void DeleteText()
        {
            text = null;
        }

        /// <summary>
        /// 문단 텍스트에 대한 객체를 반환한다.
        /// </summary>
        public ParaText? Text => text;

        /// <summary>
        /// 문단의 글자 모양에 대한 객체를 생성한다.
        /// </summary>
        public void CreateCharShape()
        {
            charShape = new ParaCharShape();
        }

        /// <summary>
        /// 문단의 글자 모양에 대한 객체를 삭제한다.
        /// </summary>
        public void DeleteCharShape()
        {
            charShape = null;
        }

        /// <summary>
        /// 문단의 글자 모양에 대한 객체를 반환한다.
        /// </summary>
        public ParaCharShape? CharShape => charShape;

        /// <summary>
        /// 문단의 레이아웃에 대한 객체를 생성한다.
        /// </summary>
        public void CreateLineSeg()
        {
            lineSeg = new ParaLineSeg();
        }

        /// <summary>
        /// 문단의 레이아웃에 대한 객체를 삭제한다.
        /// </summary>
        public void DeleteLineSeg()
        {
            lineSeg = null;
        }

        /// <summary>
        /// 문단의 레이아웃에 대한 객체를 반환한다.
        /// </summary>
        public ParaLineSeg? LineSeg => lineSeg;

        /// <summary>
        /// 문단의 영역 태그에 대한 객체를 생성한다.
        /// </summary>
        public void CreateRangeTag()
        {
            rangeTag = new ParaRangeTag();
        }

        /// <summary>
        /// 문단의 영역 태그에 대한 객체를 삭제한다.
        /// </summary>
        public void DeleteRangeTag()
        {
            rangeTag = null;
        }

        /// <summary>
        /// 문단의 영역 태그에 대한 객체를 반환한다.
        /// </summary>
        public ParaRangeTag? RangeTag => rangeTag;

        /// <summary>
        /// type에 해당하는 새로운 컨트롤을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="type">컨트롤 타입</param>
        /// <returns>새로 생성된 컨트롤 객체</returns>
        public ControlNS.Control? AddNewControl(ControlNS.ControlType type)
        {
            return AddNewControl(ControlNS.ControlTypeExtensions.GetCtrlId(type));
        }

        /// <summary>
        /// id에 해당하는 새로운 컨트롤을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="id">컨트롤 id값</param>
        /// <returns>새로 생성된 컨트롤 객체</returns>
        public ControlNS.Control? AddNewControl(uint id)
        {
            controlList ??= new List<ControlNS.Control>();
            ControlNS.Control? c = ControlNS.FactoryForControl.Create(id);
            if (c != null)
            {
                controlList.Add(c);
            }
            return c;
        }

        /// <summary>
        /// gsoType에 해당하는 새로운 GSO 컨트롤(그리기 객체)를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="gsoType">GSO 컨트롤(그리기 객체) 타입</param>
        /// <returns>새로 생성한 GSO 컨트롤</returns>
        public GsoControl? AddNewGsoControl(ControlNS.Gso.GsoControlType gsoType)
        {
            return AddNewGsoControl((uint)ControlNS.Gso.GsoControlTypeExtensions.GetId(gsoType), new CtrlHeaderGso());
        }

        /// <summary>
        /// gsoType에 해당하는 새로운 GSO 컨트롤(그리기 객체)를 생성하고 리스트에 추가한다.
        /// 새로 생성한 GSO 컨트롤의 헤더를 header로 설정한다.
        /// </summary>
        /// <param name="gsoType">GSO 컨트롤(그리기 객체) 타입</param>
        /// <param name="header">컨트롤 헤더 객체</param>
        /// <returns>새로 생성한 GSO 컨트롤</returns>
        public GsoControl? AddNewGsoControl(ControlNS.Gso.GsoControlType gsoType, CtrlHeaderGso header)
        {
            return AddNewGsoControl((uint)ControlNS.Gso.GsoControlTypeExtensions.GetId(gsoType), header);
        }

        /// <summary>
        /// 양식 컨트롤을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="header">컨트롤 헤더 객체</param>
        /// <returns>새로 생성한 양식 컨트롤</returns>
        public ControlNS.ControlForm AddNewFormControl(CtrlHeaderGso header)
        {
            controlList ??= new List<ControlNS.Control>();
            ControlNS.ControlForm fc = ControlNS.FactoryForControl.CreateFormControl(header);
            controlList.Add(fc);
            return fc;
        }

        /// <summary>
        /// gsoid에 해당하는 새로운 GSO 컨트롤(그리기 객체)를 생성하고 리스트에 추가한다.
        /// 새로 생성한 GSO 컨트롤의 헤더를 header로 설정한다.
        /// </summary>
        /// <param name="gsoId">GSO 컨트롤(그리기 객체)의 id</param>
        /// <param name="header">컨트롤 헤더 객체</param>
        /// <returns>새로 생성한 GSO 컨트롤</returns>
        public GsoControl? AddNewGsoControl(uint gsoId, CtrlHeaderGso header)
        {
            controlList ??= new List<ControlNS.Control>();
            GsoControl? gc = ControlNS.FactoryForControl.CreateGso(gsoId, header);
            if (gc != null)
            {
                controlList.Add(gc);
            }
            return gc;
        }

        /// <summary>
        /// 컨트롤 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<ControlNS.Control>? ControlList => controlList;

        /// <summary>
        /// 컨트롤 리스트를 생성한다.
        /// </summary>
        public void CreateControlList()
        {
            controlList = new List<ControlNS.Control>();
        }

        /// <summary>
        /// 컨트롤 리스트에 컨트롤을 추가한다.
        /// </summary>
        /// <param name="c">추가할 컨트롤</param>
        public void AddControl(ControlNS.Control c)
        {
            controlList ??= new List<ControlNS.Control>();
            controlList.Add(c);
        }

        /// <summary>
        /// 컨트롤 리스트에서 지정된 위치의 컨트롤을 제거한다.
        /// </summary>
        /// <param name="index">제거할 위치</param>
        public void RemoveControlAt(int index)
        {
            controlList?.RemoveAt(index);
        }

        /// <summary>
        /// 컨트롤 리스트에서 컨트롤의 순번을 반환한다.
        /// </summary>
        /// <param name="c">컨트롤</param>
        /// <returns>컨트롤의 순번</returns>
        public int GetControlIndex(ControlNS.Control c)
        {
            return controlList?.IndexOf(c) ?? -1;
        }

        /// <summary>
        /// 새로운 메모를 생성하고 리스트에 추가한다.
        /// </summary>
        /// <returns>새로 생성된 메모</returns>
        public Memo.Memo AddNewMemo()
        {
            memoList ??= new List<Memo.Memo>();
            var memo = new Memo.Memo();
            memoList.Add(memo);
            return memo;
        }

        /// <summary>
        /// 메모 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<Memo.Memo>? MemoList => memoList;

        /// <summary>
        /// 문단 내의 일반 문자열을 반환한다.
        /// </summary>
        /// <returns>문단 내의 일반 문자열</returns>
        public string GetNormalString()
        {
            if (text != null)
            {
                return text.GetNormalString(0);
            }
            return "";
        }

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public Paragraph Clone()
        {
            Paragraph cloned = new Paragraph();

            cloned.header.Copy(header);

            if (text != null)
            {
                cloned.text = text.Clone();
            }
            else
            {
                cloned.text = null;
            }

            if (charShape != null)
            {
                cloned.charShape = charShape.Clone();
            }
            else
            {
                cloned.charShape = null;
            }

            if (lineSeg != null)
            {
                cloned.lineSeg = lineSeg.Clone();
            }
            else
            {
                cloned.lineSeg = null;
            }

            if (rangeTag != null)
            {
                cloned.rangeTag = rangeTag.Clone();
            }
            else
            {
                cloned.rangeTag = null;
            }

            if (controlList != null)
            {
                cloned.controlList = new List<ControlNS.Control>();
                foreach (var control in controlList)
                {
                    cloned.controlList.Add(control.Clone());
                }
            }
            else
            {
                cloned.controlList = null;
            }

            if (memoList != null)
            {
                cloned.memoList = new List<Memo.Memo>();
                foreach (var memo in memoList)
                {
                    cloned.memoList.Add(memo.Clone());
                }
            }
            else
            {
                cloned.memoList = null;
            }

            return cloned;
        }
    }
}

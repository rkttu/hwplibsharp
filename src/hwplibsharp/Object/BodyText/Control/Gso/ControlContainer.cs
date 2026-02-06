// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/ControlContainer.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.BodyText.Control.Gso.ShapeComponent;
using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso
{
    /// <summary>
    /// 묶음 개체 컨트롤
    /// </summary>
    public class ControlContainer : GsoControl
    {
        /// <summary>
        /// 차일드 컨트롤 리스트
        /// </summary>
        private readonly List<GsoControl> _childControlList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ControlContainer()
            : this(new CtrlHeaderGso())
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="header">그리기 개체를 위한 컨트롤 헤더</param>
        public ControlContainer(CtrlHeaderGso header)
            : base(header)
        {
            ShapeComponentInternal = new ShapeComponentContainer();
            SetGsoId((uint)GsoControlType.Container.GetId());
            _childControlList = new List<GsoControl>();
        }

        /// <summary>
        /// 새로운 자식 컨트롤을 생성하고 리스트에 추가한다.
        /// </summary>
        /// <param name="gsoType">그리기 개체 타입</param>
        /// <returns>새로 생성된 자식 컨트롤</returns>
        public GsoControl? AddNewChildControl(GsoControlType gsoType)
        {
            var gc = FactoryForControl.CreateGso((uint)gsoType.GetId(), null!);
            if (gc != null)
            {
                _childControlList.Add(gc);
            }
            return gc;
        }

        /// <summary>
        /// 차일드 컨트롤을 리스트에 추가한다.
        /// </summary>
        /// <param name="childControl">차일드 컨트롤</param>
        public void AddChildControl(GsoControl childControl)
        {
            _childControlList.Add(childControl);
        }

        /// <summary>
        /// 차일드 컨트롤의 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<GsoControl> ChildControlList => _childControlList;

        /// <summary>
        /// 객체를 복제한다.
        /// </summary>
        /// <returns>복제된 객체</returns>
        public override Control Clone()
        {
            var cloned = new ControlContainer();
            cloned.CopyGsoControlPart(this);

            foreach (var childControl in _childControlList)
            {
                cloned._childControlList.Add((GsoControl)childControl.Clone());
            }

            return cloned;
        }
    }
}

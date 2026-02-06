// =====================================================================
// Java Original: kr/dogfoot/hwplib/object/bodytext/control/gso/shapecomponent/ShapeComponentContainer.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Object.BodyText.Control.Gso.ShapeComponent
{
    /// <summary>
    /// 컨테이너 컨트롤을 위한 객체 공통 속성 레코드
    /// </summary>
    public class ShapeComponentContainer : ShapeComponent
    {
        /// <summary>
        /// 컨테이너에 포함된 컨트롤의 id 리스트
        /// </summary>
        private readonly List<uint> _childControlIdList;

        /// <summary>
        /// 생성자
        /// </summary>
        public ShapeComponentContainer()
        {
            _childControlIdList = new List<uint>();
        }

        /// <summary>
        /// 컨테이너에 포함된 컨트롤의 id 리스트를 반환한다.
        /// </summary>
        public IReadOnlyList<uint> ChildControlIdList => _childControlIdList;

        /// <summary>
        /// 컨테이너에 포함된 컨트롤의 id 리스트를 지운다.
        /// </summary>
        public void ClearChildControlIdList()
        {
            _childControlIdList.Clear();
        }

        /// <summary>
        /// 컨테이너에 포함된 컨트롤의 id를 리스트 추가한다.
        /// </summary>
        /// <param name="id">컨테이너에 포함된 컨트롤의 id</param>
        public void AddChildControlId(uint id)
        {
            _childControlIdList.Add(id);
        }

        /// <summary>
        /// 다른 객체에서 값을 복사한다.
        /// </summary>
        /// <param name="from">복사할 원본 객체</param>
        public override void Copy(ShapeComponent from)
        {
            CopyShapeComponent(from);
            var from2 = (ShapeComponentContainer)from;

            _childControlIdList.Clear();
            foreach (var childControlId in from2._childControlIdList)
            {
                _childControlIdList.Add(childControlId);
            }
        }
    }
}

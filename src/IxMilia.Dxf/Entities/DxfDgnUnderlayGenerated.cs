// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfDgnUnderlay class
    /// </summary>
    public partial class DxfDgnUnderlay : DxfUnderlay
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.DgnUnderlay; } }

        public DxfDgnUnderlay()
            : base()
        {
        }

        internal DxfDgnUnderlay(DxfUnderlay other)
            : base(other)
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        protected override IEnumerable<DxfPoint> GetExtentsPoints()
        {
            return null;
        }
    }
}

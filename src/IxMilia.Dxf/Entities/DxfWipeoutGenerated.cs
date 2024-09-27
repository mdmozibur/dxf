// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfWipeout class
    /// </summary>
    public partial class DxfWipeout : DxfImage
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.WipeOut; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2000; } }

        public DxfWipeout()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbWipeout"));
            }
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

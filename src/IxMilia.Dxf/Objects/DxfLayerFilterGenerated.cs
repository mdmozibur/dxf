// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Entities;

namespace IxMilia.Dxf.Objects
{
    /// <summary>
    /// DxfLayerFilter class
    /// </summary>
    public partial class DxfLayerFilter : DxfObject
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.LayerFilter; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2004; } }
        public IList<string> LayerNames { get; private set; }

        public DxfLayerFilter()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.LayerNames = new ListNonNull<string>();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            pairs.Add(new DxfCodePair(100, "AcDbFilter"));
            pairs.Add(new DxfCodePair(100, "AcDbLayerFilter"));
            pairs.AddRange(this.LayerNames.Select(p => new DxfCodePair(8, p)));
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 8:
                    this.LayerNames.Add(pair.StringValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}

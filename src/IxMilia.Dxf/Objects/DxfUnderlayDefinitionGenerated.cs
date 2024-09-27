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
    /// DxfUnderlayDefinition class
    /// </summary>
    public partial class DxfUnderlayDefinition : DxfObject
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.UnderlayDefinition; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2007; } }
        public string FileName { get; set; }
        public string Name { get; set; }

        public DxfUnderlayDefinition()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.FileName = null;
            this.Name = null;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbUnderlayDefinition"));
            }
            pairs.Add(new DxfCodePair(1, this.FileName));
            pairs.Add(new DxfCodePair(2, this.Name));
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 1:
                    this.FileName = pair.StringValue;
                    break;
                case 2:
                    this.Name = pair.StringValue;
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}
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
    /// DxfWipeoutVariables class
    /// </summary>
    public partial class DxfWipeoutVariables : DxfObject
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.WipeoutVariables; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2004; } }
        public int ClassVersion { get; set; }
        public bool DisplayImageFrame { get; set; }

        public DxfWipeoutVariables()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.ClassVersion = 0;
            this.DisplayImageFrame = false;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbRasterVariables"));
            }
            pairs.Add(new DxfCodePair(90, this.ClassVersion));
            pairs.Add(new DxfCodePair(70, BoolShort(this.DisplayImageFrame)));
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 70:
                    this.DisplayImageFrame = BoolShort(pair.ShortValue);
                    break;
                case 90:
                    this.ClassVersion = pair.IntegerValue;
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}

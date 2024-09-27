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
    /// DxfPlaceHolder class
    /// </summary>
    public partial class DxfPlaceHolder : DxfObject
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.AcdbPlaceHolder; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2000; } }

        public DxfPlaceHolder()
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
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }
    }
}

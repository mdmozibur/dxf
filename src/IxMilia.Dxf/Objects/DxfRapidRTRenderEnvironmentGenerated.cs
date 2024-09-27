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
    /// DxfRapidRTRenderEnvironment class
    /// </summary>
    public partial class DxfRapidRTRenderEnvironment : DxfObject, IDxfItemInternal
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.RapidRTRenderEnvironment; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2018; } }

        IEnumerable<DxfPointer> IDxfItemInternal.GetPointers()
        {
            yield return CustomBackgroundPointer;
        }

        IEnumerable<IDxfItemInternal> IDxfItemInternal.GetChildItems()
        {
            return ((IDxfItemInternal)this).GetPointers().Select(p => (IDxfItemInternal)p.Item);
        }

        internal DxfPointer CustomBackgroundPointer { get; } = new DxfPointer();
        public int SubclassVersion { get; set; }
        public bool IsEnabled { get; set; }
        public string ImageBasedLightingMapFileName { get; set; }
        /// <summary>
        /// Rotation angle in degrees.
        /// </summary>
        public double RotationAngle { get; set; }
        public bool IsMapAsBackground { get; set; }
        public IDxfItem CustomBackground { get { return CustomBackgroundPointer.Item as IDxfItem; } set { CustomBackgroundPointer.Item = value; } }

        public DxfRapidRTRenderEnvironment()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.SubclassVersion = 0;
            this.IsEnabled = true;
            this.ImageBasedLightingMapFileName = null;
            this.RotationAngle = 0.0;
            this.IsMapAsBackground = true;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbIBLBackground"));
            }
            pairs.Add(new DxfCodePair(90, this.SubclassVersion));
            pairs.Add(new DxfCodePair(290, this.IsEnabled));
            pairs.Add(new DxfCodePair(1, this.ImageBasedLightingMapFileName));
            pairs.Add(new DxfCodePair(40, this.RotationAngle));
            pairs.Add(new DxfCodePair(290, this.IsMapAsBackground));
            if (this.CustomBackgroundPointer.Handle.Value != 0)
            {
                pairs.Add(new DxfCodePair(340, DxfCommonConverters.HandleString(this.CustomBackgroundPointer.Handle)));
            }

            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        // This object has vales that share codes between properties and these counters are used to know which property to
        // assign to in TrySetPair() below.
        private int _code_290_index = 0; // shared by properties IsEnabled, IsMapAsBackground

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 1:
                    this.ImageBasedLightingMapFileName = pair.StringValue;
                    break;
                case 40:
                    this.RotationAngle = pair.DoubleValue;
                    break;
                case 90:
                    this.SubclassVersion = pair.IntegerValue;
                    break;
                case 290:
                    switch (_code_290_index)
                    {
                        case 0:
                            this.IsEnabled = pair.BoolValue;
                            _code_290_index++;
                            break;
                        case 1:
                            this.IsMapAsBackground = pair.BoolValue;
                            _code_290_index++;
                            break;
                        default:
                            Debug.Assert(false, "Unexpected extra values for code 290");
                            break;
                    }
                    break;
                case 340:
                    this.CustomBackgroundPointer.Handle = DxfCommonConverters.HandleString(pair.StringValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}
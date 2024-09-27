// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfModelPoint class
    /// </summary>
    public partial class DxfModelPoint : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Point; } }
        public DxfPoint Location { get; set; }
        public double Thickness { get; set; }
        public DxfVector ExtrusionDirection { get; set; }
        public double Angle { get; set; }

        public DxfModelPoint()
            : base()
        {
        }

        public DxfModelPoint(DxfPoint location)
            : this()
        {
            this.Location = location;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.Location = DxfPoint.Origin;
            this.Thickness = 0.0;
            this.ExtrusionDirection = DxfVector.ZAxis;
            this.Angle = 0.0;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbPoint"));
            }
            pairs.Add(new DxfCodePair(10, Location.X));
            pairs.Add(new DxfCodePair(20, Location.Y));
            pairs.Add(new DxfCodePair(30, Location.Z));
            if (this.Thickness != 0.0)
            {
                pairs.Add(new DxfCodePair(39, this.Thickness));
            }

            if (this.ExtrusionDirection != DxfVector.ZAxis)
            {
                pairs.Add(new DxfCodePair(210, ExtrusionDirection.X));
                pairs.Add(new DxfCodePair(220, ExtrusionDirection.Y));
                pairs.Add(new DxfCodePair(230, ExtrusionDirection.Z));
            }

            if (this.Angle != 0.0)
            {
                pairs.Add(new DxfCodePair(50, this.Angle));
            }

            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 10:
                    this.Location = this.Location.WithUpdatedX(pair.DoubleValue);
                    break;
                case 20:
                    this.Location = this.Location.WithUpdatedY(pair.DoubleValue);
                    break;
                case 30:
                    this.Location = this.Location.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 39:
                    this.Thickness = pair.DoubleValue;
                    break;
                case 50:
                    this.Angle = pair.DoubleValue;
                    break;
                case 210:
                    this.ExtrusionDirection = this.ExtrusionDirection.WithUpdatedX(pair.DoubleValue);
                    break;
                case 220:
                    this.ExtrusionDirection = this.ExtrusionDirection.WithUpdatedY(pair.DoubleValue);
                    break;
                case 230:
                    this.ExtrusionDirection = this.ExtrusionDirection.WithUpdatedZ(pair.DoubleValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }

        protected override IEnumerable<DxfPoint> GetExtentsPoints()
        {
            yield return Location;
        }
    }
}

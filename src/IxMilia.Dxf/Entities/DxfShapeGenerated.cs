// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfShape class
    /// </summary>
    public partial class DxfShape : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Shape; } }
        public double Thickness { get; set; }
        public DxfPoint Location { get; set; }
        public double Size { get; set; }
        public string Name { get; set; }
        public double RotationAngle { get; set; }
        public double RelativeXScaleFactor { get; set; }
        public double ObliqueAngle { get; set; }
        public DxfVector ExtrusionDirection { get; set; }

        public DxfShape()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.Thickness = 0.0;
            this.Location = DxfPoint.Origin;
            this.Size = 0.0;
            this.Name = null;
            this.RotationAngle = 0.0;
            this.RelativeXScaleFactor = 1.0;
            this.ObliqueAngle = 0.0;
            this.ExtrusionDirection = DxfVector.ZAxis;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbShape"));
            }
            if (this.Thickness != 0.0)
            {
                pairs.Add(new DxfCodePair(39, this.Thickness));
            }

            pairs.Add(new DxfCodePair(10, Location.X));
            pairs.Add(new DxfCodePair(20, Location.Y));
            pairs.Add(new DxfCodePair(30, Location.Z));
            pairs.Add(new DxfCodePair(40, this.Size));
            pairs.Add(new DxfCodePair(2, this.Name));
            if (this.RotationAngle != 0.0)
            {
                pairs.Add(new DxfCodePair(50, this.RotationAngle));
            }

            if (this.RelativeXScaleFactor != 1.0)
            {
                pairs.Add(new DxfCodePair(41, this.RelativeXScaleFactor));
            }

            if (this.ObliqueAngle != 0.0)
            {
                pairs.Add(new DxfCodePair(51, this.ObliqueAngle));
            }

            if (this.ExtrusionDirection != DxfVector.ZAxis)
            {
                pairs.Add(new DxfCodePair(210, ExtrusionDirection.X));
                pairs.Add(new DxfCodePair(220, ExtrusionDirection.Y));
                pairs.Add(new DxfCodePair(230, ExtrusionDirection.Z));
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
                case 2:
                    this.Name = pair.StringValue;
                    break;
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
                case 40:
                    this.Size = pair.DoubleValue;
                    break;
                case 41:
                    this.RelativeXScaleFactor = pair.DoubleValue;
                    break;
                case 50:
                    this.RotationAngle = pair.DoubleValue;
                    break;
                case 51:
                    this.ObliqueAngle = pair.DoubleValue;
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
            yield return Location + new DxfPoint(Size, Size, Size);
        }
    }
}

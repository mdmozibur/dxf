// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfLine class
    /// </summary>
    public partial class DxfLine : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Line; } }
        public double Thickness { get; set; }
        public DxfPoint P1 { get; set; }
        public DxfPoint P2 { get; set; }
        public DxfVector ExtrusionDirection { get; set; }

        public DxfLine()
            : base()
        {
        }

        public DxfLine(DxfPoint p1, DxfPoint p2)
            : this()
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.Thickness = 0.0;
            this.P1 = DxfPoint.Origin;
            this.P2 = DxfPoint.Origin;
            this.ExtrusionDirection = DxfVector.ZAxis;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbLine"));
            }
            if (this.Thickness != 0.0)
            {
                pairs.Add(new DxfCodePair(39, this.Thickness));
            }

            pairs.Add(new DxfCodePair(10, P1.X));
            pairs.Add(new DxfCodePair(20, P1.Y));
            pairs.Add(new DxfCodePair(30, P1.Z));
            pairs.Add(new DxfCodePair(11, P2.X));
            pairs.Add(new DxfCodePair(21, P2.Y));
            pairs.Add(new DxfCodePair(31, P2.Z));
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
                case 10:
                    this.P1 = this.P1.WithUpdatedX(pair.DoubleValue);
                    break;
                case 20:
                    this.P1 = this.P1.WithUpdatedY(pair.DoubleValue);
                    break;
                case 30:
                    this.P1 = this.P1.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 11:
                    this.P2 = this.P2.WithUpdatedX(pair.DoubleValue);
                    break;
                case 21:
                    this.P2 = this.P2.WithUpdatedY(pair.DoubleValue);
                    break;
                case 31:
                    this.P2 = this.P2.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 39:
                    this.Thickness = pair.DoubleValue;
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
            yield return P1;
            yield return P2;
        }
    }
}

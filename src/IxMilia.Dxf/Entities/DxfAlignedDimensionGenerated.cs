// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfAlignedDimension class
    /// </summary>
    public partial class DxfAlignedDimension : DxfDimensionBase
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Dimension; } }
        public DxfPoint InsertionPoint { get; set; }
        public DxfPoint DefinitionPoint2 { get; set; }
        public DxfPoint DefinitionPoint3 { get; set; }

        public DxfAlignedDimension()
            : base()
        {
        }

        internal DxfAlignedDimension(DxfDimensionBase other)
            : base(other)
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.DimensionType = DxfDimensionType.Aligned;
            this.InsertionPoint = DxfPoint.Origin;
            this.DefinitionPoint2 = DxfPoint.Origin;
            this.DefinitionPoint3 = DxfPoint.Origin;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbAlignedDimension"));
            }
            if (IsBaselineAndContinue)
            {
                pairs.Add(new DxfCodePair(12, InsertionPoint.X));
                pairs.Add(new DxfCodePair(22, InsertionPoint.Y));
                pairs.Add(new DxfCodePair(32, InsertionPoint.Z));
            }

            pairs.Add(new DxfCodePair(13, DefinitionPoint2.X));
            pairs.Add(new DxfCodePair(23, DefinitionPoint2.Y));
            pairs.Add(new DxfCodePair(33, DefinitionPoint2.Z));
            pairs.Add(new DxfCodePair(14, DefinitionPoint3.X));
            pairs.Add(new DxfCodePair(24, DefinitionPoint3.Y));
            pairs.Add(new DxfCodePair(34, DefinitionPoint3.Z));
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 12:
                    this.InsertionPoint = this.InsertionPoint.WithUpdatedX(pair.DoubleValue);
                    break;
                case 22:
                    this.InsertionPoint = this.InsertionPoint.WithUpdatedY(pair.DoubleValue);
                    break;
                case 32:
                    this.InsertionPoint = this.InsertionPoint.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 13:
                    this.DefinitionPoint2 = this.DefinitionPoint2.WithUpdatedX(pair.DoubleValue);
                    break;
                case 23:
                    this.DefinitionPoint2 = this.DefinitionPoint2.WithUpdatedY(pair.DoubleValue);
                    break;
                case 33:
                    this.DefinitionPoint2 = this.DefinitionPoint2.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 14:
                    this.DefinitionPoint3 = this.DefinitionPoint3.WithUpdatedX(pair.DoubleValue);
                    break;
                case 24:
                    this.DefinitionPoint3 = this.DefinitionPoint3.WithUpdatedY(pair.DoubleValue);
                    break;
                case 34:
                    this.DefinitionPoint3 = this.DefinitionPoint3.WithUpdatedZ(pair.DoubleValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }

        protected override IEnumerable<DxfPoint> GetExtentsPoints()
        {
            yield return DefinitionPoint1;
            yield return TextMidPoint;
            yield return DefinitionPoint2;
            yield return DefinitionPoint3;
        }
    }
}

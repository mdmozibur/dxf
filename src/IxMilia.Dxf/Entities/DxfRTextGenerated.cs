// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfRText class
    /// </summary>
    public partial class DxfRText : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.RText; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2000; } }
        protected override DxfAcadVersion MaxVersion { get { return DxfAcadVersion.R2000; } }
        public DxfPoint InsertionPoint { get; set; }
        public DxfVector ExtrusionDirection { get; set; }
        public double RotationAngle { get; set; }
        public double TextHeight { get; set; }
        public string TextStyle { get; set; }
        public int TypeFlags { get; set; }
        public string Contents { get; set; }

        // TypeFlags flags

        public bool IsExpression
        {
            get { return DxfHelpers.GetFlag(TypeFlags, 1); }
            set
            {
                var flags = TypeFlags;
                DxfHelpers.SetFlag(value, ref flags, 1);
                TypeFlags = flags;
            }
        }

        public bool IsInlineMTextSequencesEnabled
        {
            get { return DxfHelpers.GetFlag(TypeFlags, 2); }
            set
            {
                var flags = TypeFlags;
                DxfHelpers.SetFlag(value, ref flags, 2);
                TypeFlags = flags;
            }
        }

        public DxfRText()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.InsertionPoint = DxfPoint.Origin;
            this.ExtrusionDirection = DxfVector.ZAxis;
            this.RotationAngle = 0.0;
            this.TextHeight = 0.0;
            this.TextStyle = "STANDARD";
            this.TypeFlags = 0;
            this.Contents = null;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "RText"));
            }
            pairs.Add(new DxfCodePair(10, InsertionPoint.X));
            pairs.Add(new DxfCodePair(20, InsertionPoint.Y));
            pairs.Add(new DxfCodePair(30, InsertionPoint.Z));
            if (this.ExtrusionDirection != DxfVector.ZAxis)
            {
                pairs.Add(new DxfCodePair(210, ExtrusionDirection.X));
                pairs.Add(new DxfCodePair(220, ExtrusionDirection.Y));
                pairs.Add(new DxfCodePair(230, ExtrusionDirection.Z));
            }

            pairs.Add(new DxfCodePair(50, this.RotationAngle));
            pairs.Add(new DxfCodePair(40, this.TextHeight));
            pairs.Add(new DxfCodePair(7, this.TextStyle));
            pairs.Add(new DxfCodePair(70, (short)this.TypeFlags));
            pairs.Add(new DxfCodePair(1, this.Contents));
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
                    this.Contents = pair.StringValue;
                    break;
                case 7:
                    this.TextStyle = pair.StringValue;
                    break;
                case 10:
                    this.InsertionPoint = this.InsertionPoint.WithUpdatedX(pair.DoubleValue);
                    break;
                case 20:
                    this.InsertionPoint = this.InsertionPoint.WithUpdatedY(pair.DoubleValue);
                    break;
                case 30:
                    this.InsertionPoint = this.InsertionPoint.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 40:
                    this.TextHeight = pair.DoubleValue;
                    break;
                case 50:
                    this.RotationAngle = pair.DoubleValue;
                    break;
                case 70:
                    this.TypeFlags = (int)pair.ShortValue;
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
            yield return InsertionPoint;
            yield return new DxfPoint(InsertionPoint.X + (Contents?.Length ?? 0) * TextHeight * 7.0 / 12.0, InsertionPoint.Y + TextHeight, InsertionPoint.Z);
        }
    }
}
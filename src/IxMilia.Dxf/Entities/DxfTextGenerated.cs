// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfText class
    /// </summary>
    public partial class DxfText : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Text; } }
        public double Thickness { get; set; }
        public DxfPoint Location { get; set; }
        public double TextHeight { get; set; }
        public string Value { get; set; }
        public double Rotation { get; set; }
        public double RelativeXScaleFactor { get; set; }
        public double ObliqueAngle { get; set; }
        public string TextStyleName { get; set; }
        public int TextGenerationFlags { get; set; }
        public DxfHorizontalTextJustification HorizontalTextJustification { get; set; }
        public DxfPoint SecondAlignmentPoint { get; set; }
        public DxfVector Normal { get; set; }
        public DxfVerticalTextJustification VerticalTextJustification { get; set; }

        // TextGenerationFlags flags

        public bool IsTextBackward
        {
            get { return DxfHelpers.GetFlag(TextGenerationFlags, 2); }
            set
            {
                var flags = TextGenerationFlags;
                DxfHelpers.SetFlag(value, ref flags, 2);
                TextGenerationFlags = flags;
            }
        }

        public bool IsTextUpsideDown
        {
            get { return DxfHelpers.GetFlag(TextGenerationFlags, 4); }
            set
            {
                var flags = TextGenerationFlags;
                DxfHelpers.SetFlag(value, ref flags, 4);
                TextGenerationFlags = flags;
            }
        }

        public DxfText()
            : base()
        {
        }

        public DxfText(DxfPoint location, double textHeight, string value)
            : this()
        {
            this.Location = location;
            this.TextHeight = textHeight;
            this.Value = value;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.Thickness = 0.0;
            this.Location = DxfPoint.Origin;
            this.TextHeight = 1.0;
            this.Value = null;
            this.Rotation = 0;
            this.RelativeXScaleFactor = 1.0;
            this.ObliqueAngle = 0.0;
            this.TextStyleName = "STANDARD";
            this.TextGenerationFlags = 0;
            this.HorizontalTextJustification = DxfHorizontalTextJustification.Left;
            this.SecondAlignmentPoint = DxfPoint.Origin;
            this.Normal = DxfVector.ZAxis;
            this.VerticalTextJustification = DxfVerticalTextJustification.Baseline;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            pairs.Add(new DxfCodePair(100, "AcDbText"));
            if (this.Thickness != 0.0)
            {
                pairs.Add(new DxfCodePair(39, this.Thickness));
            }

            pairs.Add(new DxfCodePair(10, Location.X));
            pairs.Add(new DxfCodePair(20, Location.Y));
            pairs.Add(new DxfCodePair(30, Location.Z));
            pairs.Add(new DxfCodePair(40, this.TextHeight));
            pairs.Add(new DxfCodePair(1, this.Value));
            if (this.Rotation != 0)
            {
                pairs.Add(new DxfCodePair(50, this.Rotation));
            }

            if (this.RelativeXScaleFactor != 1.0)
            {
                pairs.Add(new DxfCodePair(41, this.RelativeXScaleFactor));
            }

            if (this.ObliqueAngle != 0.0)
            {
                pairs.Add(new DxfCodePair(51, this.ObliqueAngle));
            }

            if (this.TextStyleName != "STANDARD")
            {
                pairs.Add(new DxfCodePair(7, this.TextStyleName));
            }

            if (this.TextGenerationFlags != 0)
            {
                pairs.Add(new DxfCodePair(71, (short)this.TextGenerationFlags));
            }

            if (this.HorizontalTextJustification != DxfHorizontalTextJustification.Left)
            {
                pairs.Add(new DxfCodePair(72, (short)this.HorizontalTextJustification));
            }

            if (((int)HorizontalTextJustification != 0) || ((VerticalTextJustification) != 0))
            {
                pairs.Add(new DxfCodePair(11, SecondAlignmentPoint.X));
                pairs.Add(new DxfCodePair(21, SecondAlignmentPoint.Y));
                pairs.Add(new DxfCodePair(31, SecondAlignmentPoint.Z));
            }

            if (this.Normal != DxfVector.ZAxis)
            {
                pairs.Add(new DxfCodePair(210, Normal.X));
                pairs.Add(new DxfCodePair(220, Normal.Y));
                pairs.Add(new DxfCodePair(230, Normal.Z));
            }

            pairs.Add(new DxfCodePair(100, "AcDbText"));
            if (this.VerticalTextJustification != DxfVerticalTextJustification.Baseline)
            {
                pairs.Add(new DxfCodePair(73, (short)this.VerticalTextJustification));
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
                case 1:
                    this.Value = pair.StringValue;
                    break;
                case 7:
                    this.TextStyleName = pair.StringValue;
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
                case 11:
                    this.SecondAlignmentPoint = this.SecondAlignmentPoint.WithUpdatedX(pair.DoubleValue);
                    break;
                case 21:
                    this.SecondAlignmentPoint = this.SecondAlignmentPoint.WithUpdatedY(pair.DoubleValue);
                    break;
                case 31:
                    this.SecondAlignmentPoint = this.SecondAlignmentPoint.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 39:
                    this.Thickness = pair.DoubleValue;
                    break;
                case 40:
                    this.TextHeight = pair.DoubleValue;
                    break;
                case 41:
                    this.RelativeXScaleFactor = pair.DoubleValue;
                    break;
                case 50:
                    this.Rotation = pair.DoubleValue;
                    break;
                case 51:
                    this.ObliqueAngle = pair.DoubleValue;
                    break;
                case 71:
                    this.TextGenerationFlags = (int)pair.ShortValue;
                    break;
                case 72:
                    this.HorizontalTextJustification = (DxfHorizontalTextJustification)pair.ShortValue;
                    break;
                case 73:
                    this.VerticalTextJustification = (DxfVerticalTextJustification)pair.ShortValue;
                    break;
                case 210:
                    this.Normal = this.Normal.WithUpdatedX(pair.DoubleValue);
                    break;
                case 220:
                    this.Normal = this.Normal.WithUpdatedY(pair.DoubleValue);
                    break;
                case 230:
                    this.Normal = this.Normal.WithUpdatedZ(pair.DoubleValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }

        protected override IEnumerable<DxfPoint> GetExtentsPoints()
        {
            yield return Location;
            yield return new DxfPoint(Location.X + (Value?.Length ?? 0) * TextHeight * 7.0 / 12.0, Location.Y + TextHeight, Location.Z);
        }
    }
}

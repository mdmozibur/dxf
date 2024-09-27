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
    /// DxfImageDefinition class
    /// </summary>
    public partial class DxfImageDefinition : DxfObject
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.ImageDefinition; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R14; } }
        public int ClassVersion { get; set; }
        public string FilePath { get; set; }
        /// <summary>
        /// Image width in pixels.
        /// </summary>
        public int ImageWidth { get; set; }
        /// <summary>
        /// Image height in pixels.
        /// </summary>
        public int ImageHeight { get; set; }
        /// <summary>
        /// Default size of one pixel.
        /// </summary>
        public double PixelWidth { get; set; }
        /// <summary>
        /// Default size of one pixel.
        /// </summary>
        public double PixelHeight { get; set; }
        public bool IsImageLoaded { get; set; }
        public DxfImageResolutionUnits ResolutionUnits { get; set; }

        public DxfImageDefinition()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.ClassVersion = 0;
            this.FilePath = null;
            this.ImageWidth = 0;
            this.ImageHeight = 0;
            this.PixelWidth = 1.0;
            this.PixelHeight = 1.0;
            this.IsImageLoaded = true;
            this.ResolutionUnits = DxfImageResolutionUnits.NoUnits;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbRasterImageDef"));
            }
            pairs.Add(new DxfCodePair(90, this.ClassVersion));
            pairs.Add(new DxfCodePair(1, this.FilePath));
            pairs.Add(new DxfCodePair(10, (double)this.ImageWidth));
            pairs.Add(new DxfCodePair(20, (double)this.ImageHeight));
            pairs.Add(new DxfCodePair(11, this.PixelWidth));
            pairs.Add(new DxfCodePair(21, this.PixelHeight));
            pairs.Add(new DxfCodePair(280, BoolShort(this.IsImageLoaded)));
            pairs.Add(new DxfCodePair(281, (short)this.ResolutionUnits));
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
                    this.FilePath = pair.StringValue;
                    break;
                case 10:
                    this.ImageWidth = (int)pair.DoubleValue;
                    break;
                case 11:
                    this.PixelWidth = pair.DoubleValue;
                    break;
                case 20:
                    this.ImageHeight = (int)pair.DoubleValue;
                    break;
                case 21:
                    this.PixelHeight = pair.DoubleValue;
                    break;
                case 90:
                    this.ClassVersion = pair.IntegerValue;
                    break;
                case 280:
                    this.IsImageLoaded = BoolShort(pair.ShortValue);
                    break;
                case 281:
                    this.ResolutionUnits = (DxfImageResolutionUnits)pair.ShortValue;
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}
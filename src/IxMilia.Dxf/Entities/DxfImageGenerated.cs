// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfImage class
    /// </summary>
    public partial class DxfImage : DxfEntity, IDxfItemInternal
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Image; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R14; } }

        IEnumerable<DxfPointer> IDxfItemInternal.GetPointers()
        {
            yield return ImageDefinitionPointer;
            yield return ImageDefinitionReactorPointer;
        }

        IEnumerable<IDxfItemInternal> IDxfItemInternal.GetChildItems()
        {
            return ((IDxfItemInternal)this).GetPointers().Select(p => (IDxfItemInternal)p.Item);
        }

        internal DxfPointer ImageDefinitionPointer { get; } = new DxfPointer();
        internal DxfPointer ImageDefinitionReactorPointer { get; } = new DxfPointer();
        public int ClassVersion { get; set; }
        /// <summary>
        /// The location of the bottom-left corner of the image
        /// </summary>
        public DxfPoint Location { get; set; }
        public DxfVector UVector { get; set; }
        public DxfVector VVector { get; set; }
        /// <summary>
        /// Image size in pixels
        /// </summary>
        public DxfVector ImageSize { get; set; }
        public DxfImageDefinition ImageDefinition { get { return ImageDefinitionPointer.Item as DxfImageDefinition; } set { ImageDefinitionPointer.Item = value; } }
        public int DisplayOptionsFlags { get; set; }
        public bool UseClipping { get; set; }
        public short Brightness { get; set; }
        public short Contrast { get; set; }
        public short Fade { get; set; }
        public DxfImageDefinitionReactor ImageDefinitionReactor { get { return ImageDefinitionReactorPointer.Item as DxfImageDefinitionReactor; } set { ImageDefinitionReactorPointer.Item = value; } }
        public DxfImageClippingBoundaryType ClippingType { get; set; }
        public int ClippingVertexCount { get; set; }
        private IList<double> _clippingVerticesX { get; set; }
        private IList<double> _clippingVerticesY { get; set; }
        public bool IsInsideClipping { get; set; }

        // DisplayOptionsFlags flags

        public bool ShowImage
        {
            get { return DxfHelpers.GetFlag(DisplayOptionsFlags, 1); }
            set
            {
                var flags = DisplayOptionsFlags;
                DxfHelpers.SetFlag(value, ref flags, 1);
                DisplayOptionsFlags = flags;
            }
        }

        public bool ShowImageWhenNotAligned
        {
            get { return DxfHelpers.GetFlag(DisplayOptionsFlags, 2); }
            set
            {
                var flags = DisplayOptionsFlags;
                DxfHelpers.SetFlag(value, ref flags, 2);
                DisplayOptionsFlags = flags;
            }
        }

        public bool UseClippingBoundary
        {
            get { return DxfHelpers.GetFlag(DisplayOptionsFlags, 4); }
            set
            {
                var flags = DisplayOptionsFlags;
                DxfHelpers.SetFlag(value, ref flags, 4);
                DisplayOptionsFlags = flags;
            }
        }

        public bool UseTransparency
        {
            get { return DxfHelpers.GetFlag(DisplayOptionsFlags, 8); }
            set
            {
                var flags = DisplayOptionsFlags;
                DxfHelpers.SetFlag(value, ref flags, 8);
                DisplayOptionsFlags = flags;
            }
        }

        public DxfImage()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.ClassVersion = 0;
            this.Location = DxfPoint.Origin;
            this.UVector = DxfVector.XAxis;
            this.VVector = DxfVector.YAxis;
            this.ImageSize = DxfVector.Zero;
            this.DisplayOptionsFlags = 1;
            this.UseClipping = true;
            this.Brightness = 50;
            this.Contrast = 50;
            this.Fade = 0;
            this.ClippingType = DxfImageClippingBoundaryType.Rectangular;
            this.ClippingVertexCount = 0;
            this._clippingVerticesX = new ListNonNull<double>();
            this._clippingVerticesY = new ListNonNull<double>();
            this.IsInsideClipping = false;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            pairs.Add(new DxfCodePair(100, "AcDbRasterImage"));
            pairs.Add(new DxfCodePair(90, this.ClassVersion));
            pairs.Add(new DxfCodePair(10, Location.X));
            pairs.Add(new DxfCodePair(20, Location.Y));
            pairs.Add(new DxfCodePair(30, Location.Z));
            pairs.Add(new DxfCodePair(11, UVector.X));
            pairs.Add(new DxfCodePair(21, UVector.Y));
            pairs.Add(new DxfCodePair(31, UVector.Z));
            pairs.Add(new DxfCodePair(12, VVector.X));
            pairs.Add(new DxfCodePair(22, VVector.Y));
            pairs.Add(new DxfCodePair(32, VVector.Z));
            pairs.Add(new DxfCodePair(13, ImageSize.X));
            pairs.Add(new DxfCodePair(23, ImageSize.Y));
            if (this.ImageDefinitionPointer.Handle.Value != 0)
            {
                pairs.Add(new DxfCodePair(340, DxfCommonConverters.HandleString(this.ImageDefinitionPointer.Handle)));
            }

            pairs.Add(new DxfCodePair(70, (short)this.DisplayOptionsFlags));
            pairs.Add(new DxfCodePair(280, BoolShort(this.UseClipping)));
            pairs.Add(new DxfCodePair(281, this.Brightness));
            pairs.Add(new DxfCodePair(282, this.Contrast));
            pairs.Add(new DxfCodePair(283, this.Fade));
            if (this.ImageDefinitionReactorPointer.Handle.Value != 0)
            {
                pairs.Add(new DxfCodePair(360, DxfCommonConverters.HandleString(this.ImageDefinitionReactorPointer.Handle)));
            }

            pairs.Add(new DxfCodePair(71, (short)this.ClippingType));
            pairs.Add(new DxfCodePair(91, ClippingVertices.Count));
            foreach (var item in ClippingVertices)
            {
                pairs.Add(new DxfCodePair(14, item.X));
                pairs.Add(new DxfCodePair(24, item.Y));
            }

            if (version >= DxfAcadVersion.R2010)
            {
                pairs.Add(new DxfCodePair(290, this.IsInsideClipping));
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
                case 11:
                    this.UVector = this.UVector.WithUpdatedX(pair.DoubleValue);
                    break;
                case 21:
                    this.UVector = this.UVector.WithUpdatedY(pair.DoubleValue);
                    break;
                case 31:
                    this.UVector = this.UVector.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 12:
                    this.VVector = this.VVector.WithUpdatedX(pair.DoubleValue);
                    break;
                case 22:
                    this.VVector = this.VVector.WithUpdatedY(pair.DoubleValue);
                    break;
                case 32:
                    this.VVector = this.VVector.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 13:
                    this.ImageSize = this.ImageSize.WithUpdatedX(pair.DoubleValue);
                    break;
                case 23:
                    this.ImageSize = this.ImageSize.WithUpdatedY(pair.DoubleValue);
                    break;
                case 14:
                    this._clippingVerticesX.Add(pair.DoubleValue);
                    break;
                case 24:
                    this._clippingVerticesY.Add(pair.DoubleValue);
                    break;
                case 70:
                    this.DisplayOptionsFlags = (int)pair.ShortValue;
                    break;
                case 71:
                    this.ClippingType = (DxfImageClippingBoundaryType)pair.ShortValue;
                    break;
                case 90:
                    this.ClassVersion = pair.IntegerValue;
                    break;
                case 91:
                    this.ClippingVertexCount = pair.IntegerValue;
                    break;
                case 280:
                    this.UseClipping = BoolShort(pair.ShortValue);
                    break;
                case 281:
                    this.Brightness = pair.ShortValue;
                    break;
                case 282:
                    this.Contrast = pair.ShortValue;
                    break;
                case 283:
                    this.Fade = pair.ShortValue;
                    break;
                case 290:
                    this.IsInsideClipping = pair.BoolValue;
                    break;
                case 340:
                    this.ImageDefinitionPointer.Handle = DxfCommonConverters.HandleString(pair.StringValue);
                    break;
                case 360:
                    this.ImageDefinitionReactorPointer.Handle = DxfCommonConverters.HandleString(pair.StringValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }

        protected override IEnumerable<DxfPoint> GetExtentsPoints()
        {
            yield return Location;
            yield return Location + ImageSize;
        }
    }
}

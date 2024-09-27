// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfLight class
    /// </summary>
    public partial class DxfLight : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Light; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2007; } }
        public int VersionNumber { get; set; }
        public string Name { get; set; }
        public DxfLightType LightType { get; set; }
        public bool IsActive { get; set; }
        public bool PlotGlyph { get; set; }
        public double Intensity { get; set; }
        public DxfPoint Position { get; set; }
        public DxfPoint TargetLocation { get; set; }
        public DxfLightAttenuationType AttenuationType { get; set; }
        public bool UseAttenuationLimits { get; set; }
        public double AttenuationStartLimit { get; set; }
        public double AttenuationEndLimit { get; set; }
        public double HotspotAngle { get; set; }
        public double FalloffAngle { get; set; }
        public bool CastShadows { get; set; }
        public DxfShadowType ShadowType { get; set; }
        public int ShadowMapSize { get; set; }
        public short ShadowMapSoftness { get; set; }

        public DxfLight()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.VersionNumber = 0;
            this.Name = null;
            this.LightType = DxfLightType.Distant;
            this.IsActive = true;
            this.PlotGlyph = true;
            this.Intensity = 1.0;
            this.Position = DxfPoint.Origin;
            this.TargetLocation = DxfPoint.Origin;
            this.AttenuationType = DxfLightAttenuationType.None;
            this.UseAttenuationLimits = true;
            this.AttenuationStartLimit = 0.0;
            this.AttenuationEndLimit = 1.0;
            this.HotspotAngle = 0.0;
            this.FalloffAngle = 0.0;
            this.CastShadows = true;
            this.ShadowType = DxfShadowType.RayTraced;
            this.ShadowMapSize = 0;
            this.ShadowMapSoftness = 0;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbLight"));
            }
            pairs.Add(new DxfCodePair(90, this.VersionNumber));
            pairs.Add(new DxfCodePair(1, this.Name));
            pairs.Add(new DxfCodePair(70, (short)this.LightType));
            pairs.Add(new DxfCodePair(290, this.IsActive));
            pairs.Add(new DxfCodePair(291, this.PlotGlyph));
            pairs.Add(new DxfCodePair(40, this.Intensity));
            pairs.Add(new DxfCodePair(10, Position.X));
            pairs.Add(new DxfCodePair(20, Position.Y));
            pairs.Add(new DxfCodePair(30, Position.Z));
            pairs.Add(new DxfCodePair(11, TargetLocation.X));
            pairs.Add(new DxfCodePair(21, TargetLocation.Y));
            pairs.Add(new DxfCodePair(31, TargetLocation.Z));
            pairs.Add(new DxfCodePair(72, (short)this.AttenuationType));
            pairs.Add(new DxfCodePair(292, this.UseAttenuationLimits));
            pairs.Add(new DxfCodePair(41, this.AttenuationStartLimit));
            pairs.Add(new DxfCodePair(42, this.AttenuationEndLimit));
            pairs.Add(new DxfCodePair(50, this.HotspotAngle));
            pairs.Add(new DxfCodePair(51, this.FalloffAngle));
            pairs.Add(new DxfCodePair(293, this.CastShadows));
            pairs.Add(new DxfCodePair(73, (short)this.ShadowType));
            pairs.Add(new DxfCodePair(91, this.ShadowMapSize));
            pairs.Add(new DxfCodePair(280, this.ShadowMapSoftness));
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
                    this.Name = pair.StringValue;
                    break;
                case 10:
                    this.Position = this.Position.WithUpdatedX(pair.DoubleValue);
                    break;
                case 20:
                    this.Position = this.Position.WithUpdatedY(pair.DoubleValue);
                    break;
                case 30:
                    this.Position = this.Position.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 11:
                    this.TargetLocation = this.TargetLocation.WithUpdatedX(pair.DoubleValue);
                    break;
                case 21:
                    this.TargetLocation = this.TargetLocation.WithUpdatedY(pair.DoubleValue);
                    break;
                case 31:
                    this.TargetLocation = this.TargetLocation.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 40:
                    this.Intensity = pair.DoubleValue;
                    break;
                case 41:
                    this.AttenuationStartLimit = pair.DoubleValue;
                    break;
                case 42:
                    this.AttenuationEndLimit = pair.DoubleValue;
                    break;
                case 50:
                    this.HotspotAngle = pair.DoubleValue;
                    break;
                case 51:
                    this.FalloffAngle = pair.DoubleValue;
                    break;
                case 70:
                    this.LightType = (DxfLightType)pair.ShortValue;
                    break;
                case 72:
                    this.AttenuationType = (DxfLightAttenuationType)pair.ShortValue;
                    break;
                case 73:
                    this.ShadowType = (DxfShadowType)pair.ShortValue;
                    break;
                case 90:
                    this.VersionNumber = pair.IntegerValue;
                    break;
                case 91:
                    this.ShadowMapSize = pair.IntegerValue;
                    break;
                case 280:
                    this.ShadowMapSoftness = pair.ShortValue;
                    break;
                case 290:
                    this.IsActive = pair.BoolValue;
                    break;
                case 291:
                    this.PlotGlyph = pair.BoolValue;
                    break;
                case 292:
                    this.UseAttenuationLimits = pair.BoolValue;
                    break;
                case 293:
                    this.CastShadows = pair.BoolValue;
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }

        protected override IEnumerable<DxfPoint> GetExtentsPoints()
        {
            yield return Position;
        }
    }
}
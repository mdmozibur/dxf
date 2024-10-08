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
    /// DxfMentalRayRenderSettings class
    /// </summary>
    public partial class DxfMentalRayRenderSettings : DxfObject
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.MentalRayRenderSettings; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2007; } }
        public int ClassVersion { get; set; }
        public int MinimumSamplingRate { get; set; }
        public int MaximumSamplingRate { get; set; }
        public DxfSamplingFilterType SamplingFilterType { get; set; }
        public double FilterWidth { get; set; }
        public double FilterHeight { get; set; }
        public double SamplingContrastColor_Red { get; set; }
        public double SamplingContrastColor_Green { get; set; }
        public double SamplingContrastColor_Blue { get; set; }
        public double SamplingContrastColor_Alpha { get; set; }
        public DxfRenderShadowMode ShadowMode { get; set; }
        public bool MapShadows { get; set; }
        public bool RayTracing { get; set; }
        public int RayTracingDepth_Reflections { get; set; }
        public int RayTracingDepth_Refractions { get; set; }
        public int RayTracingDepth_Maximum { get; set; }
        public bool UseGlobalIllumination { get; set; }
        public int SampleCount { get; set; }
        public bool UseGlobalIlluminationRadius { get; set; }
        public double GlobalIlluminationRadius { get; set; }
        public int PhotonsPerLight { get; set; }
        public int GlobalIlluminationDepth_Reflections { get; set; }
        public int GlobalIlluminationDepth_Refractions { get; set; }
        public int GlobalIlluminationDepth_Maximum { get; set; }
        public bool UseFinalGather { get; set; }
        public int FinalGatherRayCount { get; set; }
        public bool UseFinalGatherMinimumRadius { get; set; }
        public bool UseFinalGatherMaximumRadius { get; set; }
        public bool UseFinalGatherPixels { get; set; }
        public double FinalGatherSampleRadius_Minimum { get; set; }
        public double FinalGatherSampleRadius_Maximum { get; set; }
        public double LuminanceScale { get; set; }
        public DxfRenderDiagnosticMode DiagnosticMode { get; set; }
        public DxfRenderDiagnosticGridMode DiagnosticGridMode { get; set; }
        public double GridSize { get; set; }
        public DxfDiagnosticPhotonMode DiagnosticPhotonMode { get; set; }
        public DxfDiagnosticBSPMode DiagnosticBSPMode { get; set; }
        public bool ExportMIStatistics { get; set; }
        public string MIStatisticsFileName { get; set; }
        public int TileSize { get; set; }
        public DxfTileOrder TileOrder { get; set; }
        public int MemoryLimit { get; set; }
        public bool _unknown_code_290 { get; set; }
        public double _unknown_code_40 { get; set; }

        public DxfMentalRayRenderSettings()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.ClassVersion = 1;
            this.MinimumSamplingRate = 0;
            this.MaximumSamplingRate = 0;
            this.SamplingFilterType = DxfSamplingFilterType.Box;
            this.FilterWidth = 0.0;
            this.FilterHeight = 0.0;
            this.SamplingContrastColor_Red = 0.0;
            this.SamplingContrastColor_Green = 0.0;
            this.SamplingContrastColor_Blue = 0.0;
            this.SamplingContrastColor_Alpha = 0.0;
            this.ShadowMode = DxfRenderShadowMode.Simple;
            this.MapShadows = false;
            this.RayTracing = false;
            this.RayTracingDepth_Reflections = 0;
            this.RayTracingDepth_Refractions = 0;
            this.RayTracingDepth_Maximum = 0;
            this.UseGlobalIllumination = false;
            this.SampleCount = 0;
            this.UseGlobalIlluminationRadius = false;
            this.GlobalIlluminationRadius = 0.0;
            this.PhotonsPerLight = 0;
            this.GlobalIlluminationDepth_Reflections = 0;
            this.GlobalIlluminationDepth_Refractions = 0;
            this.GlobalIlluminationDepth_Maximum = 0;
            this.UseFinalGather = false;
            this.FinalGatherRayCount = 0;
            this.UseFinalGatherMinimumRadius = false;
            this.UseFinalGatherMaximumRadius = false;
            this.UseFinalGatherPixels = false;
            this.FinalGatherSampleRadius_Minimum = 0.0;
            this.FinalGatherSampleRadius_Maximum = 0.0;
            this.LuminanceScale = 1.0;
            this.DiagnosticMode = DxfRenderDiagnosticMode.Off;
            this.DiagnosticGridMode = DxfRenderDiagnosticGridMode.Object;
            this.GridSize = 1.0;
            this.DiagnosticPhotonMode = DxfDiagnosticPhotonMode.Density;
            this.DiagnosticBSPMode = DxfDiagnosticBSPMode.Depth;
            this.ExportMIStatistics = false;
            this.MIStatisticsFileName = null;
            this.TileSize = 0;
            this.TileOrder = DxfTileOrder.Hilbert;
            this.MemoryLimit = 0;
            this._unknown_code_290 = false;
            this._unknown_code_40 = 0.0;
        }
    }
}

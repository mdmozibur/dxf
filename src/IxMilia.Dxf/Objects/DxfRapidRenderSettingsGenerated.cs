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
    /// DxfRapidRenderSettings class
    /// </summary>
    public partial class DxfRapidRenderSettings : DxfObject
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.RapidRenderSettings; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R2018; } }
        public int SubclassVersion { get; set; }
        public string RenderPresetName { get; set; }
        public bool AreMaterialsEnabled { get; set; }
        public bool IsTextureSamplingEnabled { get; set; }
        public bool AreBackFacesEnabled { get; set; }
        public bool AreShadowsEnabled { get; set; }
        public string PreviewImageFileName { get; set; }
        public string RenderPresetDescription { get; set; }
        public int DisplayIndex { get; set; }
        public bool IsPredefinedRenderPreset { get; set; }
        private int _duplicateSubclassVersion { get; set; }
        public DxfRenderDuration RenderDuration { get; set; }
        public int RenderLevelCountLimit { get; set; }
        public int RenderTimeLimit { get; set; }
        public DxfRenderAccuracy RenderAccuracy { get; set; }
        public DxfSamplingFilter SamplingFilter { get; set; }
        public double FilterWidth { get; set; }
        public double FilterHeight { get; set; }

        public DxfRapidRenderSettings()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.SubclassVersion = 0;
            this.RenderPresetName = null;
            this.AreMaterialsEnabled = true;
            this.IsTextureSamplingEnabled = true;
            this.AreBackFacesEnabled = true;
            this.AreShadowsEnabled = true;
            this.PreviewImageFileName = null;
            this.RenderPresetDescription = null;
            this.DisplayIndex = 0;
            this.IsPredefinedRenderPreset = true;
            this._duplicateSubclassVersion = 90;
            this.RenderDuration = DxfRenderDuration.RenderByTime;
            this.RenderLevelCountLimit = 0;
            this.RenderTimeLimit = 0;
            this.RenderAccuracy = DxfRenderAccuracy.Low;
            this.SamplingFilter = DxfSamplingFilter.Box;
            this.FilterWidth = 1.0;
            this.FilterHeight = 1.0;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            pairs.Add(new DxfCodePair(100, "AcDbRenderSettings"));
            pairs.Add(new DxfCodePair(90, this.SubclassVersion));
            pairs.Add(new DxfCodePair(1, this.RenderPresetName));
            pairs.Add(new DxfCodePair(290, this.AreMaterialsEnabled));
            pairs.Add(new DxfCodePair(290, this.IsTextureSamplingEnabled));
            pairs.Add(new DxfCodePair(290, this.AreBackFacesEnabled));
            pairs.Add(new DxfCodePair(290, this.AreShadowsEnabled));
            pairs.Add(new DxfCodePair(1, this.PreviewImageFileName));
            pairs.Add(new DxfCodePair(1, this.RenderPresetDescription));
            pairs.Add(new DxfCodePair(90, this.DisplayIndex));
            pairs.Add(new DxfCodePair(290, this.IsPredefinedRenderPreset));
            pairs.Add(new DxfCodePair(100, "AcDbRapidRTRenderSettings"));
            pairs.Add(new DxfCodePair(90, this.SubclassVersion));
            pairs.Add(new DxfCodePair(70, (short)this.RenderDuration));
            pairs.Add(new DxfCodePair(90, this.RenderLevelCountLimit));
            pairs.Add(new DxfCodePair(90, this.RenderTimeLimit));
            pairs.Add(new DxfCodePair(70, (short)this.RenderAccuracy));
            pairs.Add(new DxfCodePair(70, (short)this.SamplingFilter));
            pairs.Add(new DxfCodePair(40, this.FilterWidth));
            pairs.Add(new DxfCodePair(40, this.FilterHeight));
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        // This object has vales that share codes between properties and these counters are used to know which property to
        // assign to in TrySetPair() below.
        private int _code_1_index = 0; // shared by properties RenderPresetName, PreviewImageFileName, RenderPresetDescription
        private int _code_40_index = 0; // shared by properties FilterWidth, FilterHeight
        private int _code_70_index = 0; // shared by properties RenderDuration, RenderAccuracy, SamplingFilter
        private int _code_90_index = 0; // shared by properties SubclassVersion, DisplayIndex, _duplicateSubclassVersion, RenderLevelCountLimit, RenderTimeLimit
        private int _code_290_index = 0; // shared by properties AreMaterialsEnabled, IsTextureSamplingEnabled, AreBackFacesEnabled, AreShadowsEnabled, IsPredefinedRenderPreset

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 1:
                    switch (_code_1_index)
                    {
                        case 0:
                            this.RenderPresetName = pair.StringValue;
                            _code_1_index++;
                            break;
                        case 1:
                            this.PreviewImageFileName = pair.StringValue;
                            _code_1_index++;
                            break;
                        case 2:
                            this.RenderPresetDescription = pair.StringValue;
                            _code_1_index++;
                            break;
                        default:
                            Debug.Assert(false, "Unexpected extra values for code 1");
                            break;
                    }
                    break;
                case 40:
                    switch (_code_40_index)
                    {
                        case 0:
                            this.FilterWidth = pair.DoubleValue;
                            _code_40_index++;
                            break;
                        case 1:
                            this.FilterHeight = pair.DoubleValue;
                            _code_40_index++;
                            break;
                        default:
                            Debug.Assert(false, "Unexpected extra values for code 40");
                            break;
                    }
                    break;
                case 70:
                    switch (_code_70_index)
                    {
                        case 0:
                            this.RenderDuration = (DxfRenderDuration)pair.ShortValue;
                            _code_70_index++;
                            break;
                        case 1:
                            this.RenderAccuracy = (DxfRenderAccuracy)pair.ShortValue;
                            _code_70_index++;
                            break;
                        case 2:
                            this.SamplingFilter = (DxfSamplingFilter)pair.ShortValue;
                            _code_70_index++;
                            break;
                        default:
                            Debug.Assert(false, "Unexpected extra values for code 70");
                            break;
                    }
                    break;
                case 90:
                    switch (_code_90_index)
                    {
                        case 0:
                            this.SubclassVersion = pair.IntegerValue;
                            _code_90_index++;
                            break;
                        case 1:
                            this.DisplayIndex = pair.IntegerValue;
                            _code_90_index++;
                            break;
                        case 2:
                            this._duplicateSubclassVersion = pair.IntegerValue;
                            _code_90_index++;
                            break;
                        case 3:
                            this.RenderLevelCountLimit = pair.IntegerValue;
                            _code_90_index++;
                            break;
                        case 4:
                            this.RenderTimeLimit = pair.IntegerValue;
                            _code_90_index++;
                            break;
                        default:
                            Debug.Assert(false, "Unexpected extra values for code 90");
                            break;
                    }
                    break;
                case 290:
                    switch (_code_290_index)
                    {
                        case 0:
                            this.AreMaterialsEnabled = pair.BoolValue;
                            _code_290_index++;
                            break;
                        case 1:
                            this.IsTextureSamplingEnabled = pair.BoolValue;
                            _code_290_index++;
                            break;
                        case 2:
                            this.AreBackFacesEnabled = pair.BoolValue;
                            _code_290_index++;
                            break;
                        case 3:
                            this.AreShadowsEnabled = pair.BoolValue;
                            _code_290_index++;
                            break;
                        case 4:
                            this.IsPredefinedRenderPreset = pair.BoolValue;
                            _code_290_index++;
                            break;
                        default:
                            Debug.Assert(false, "Unexpected extra values for code 290");
                            break;
                    }
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}

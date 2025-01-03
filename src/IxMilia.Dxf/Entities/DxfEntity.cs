using System;
using System.Collections.Generic;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    public enum DxfHorizontalTextJustification
    {
        Left = 0,
        Center = 1,
        Right = 2,
        Aligned = 3,
        Middle = 4,
        Fit = 5
    }

    public enum DxfVerticalTextJustification
    {
        Baseline = 0,
        Bottom = 1,
        Middle = 2,
        Top = 3
    }

    public enum DxfPolylineCurvedAndSmoothSurfaceType
    {
        None = 0,
        QuadraticBSpline = 5,
        CubicBSpline = 6,
        Bezier = 8
    }

    /// <summary>
    /// Values specific to the CLO software.
    /// </summary>
    public enum DxfPolylineType
    {
        /// <summary>
        /// Baseline polyline not editable by CLO.
        /// </summary>
        Baseline = 0,

        /// <summary>
        /// Internal line in CLO.
        /// </summary>
        Internal = 1,

        /// <summary>
        /// Outline pattern in CLO.
        /// </summary>
        Outline = 2
    }

    public enum DxfGradientColorMode
    {
        TwoColorGradient = 0,
        SingleColorGradient = 1
    }

    public enum DxfHatchPatternFillMode
    {
        PatternFill = 0,
        SolidFill = 1
    }

    public enum DxfHatchPatternType
    {
        UserDefined = 0,
        Predefined = 1,
        Custom = 2
    }

    public enum DxfHatchStyle
    {
        OddParity = 0,
        OutermostAreaOnly = 1,
        EntireArea = 2
    }

    public enum DxfImageClippingBoundaryType
    {
        Rectangular = 1,
        Polygonal = 2
    }

    public enum DxfLeaderPathType
    {
        StraightLineSegments = 0,
        Spline = 1
    }

    public enum DxfLeaderCreationAnnotationType
    {
        WithTextAnnotation = 0,
        WithToleranceAnnotation = 1,
        WithBlockReferenceAnnotation = 2,
        NoAnnotation = 3
    }

    public enum DxfLeaderHooklineDirection
    {
        OppositeFromHorizontalVector = 0,
        SameAsHorizontalVector = 1
    }

    public enum DxfOleObjectType
    {
        Link = 1,
        Embedded = 2,
        Static = 3
    }

    public enum DxfTileModeDescriptor
    {
        InTiledViewport = 0,
        InNonTiledViewport = 1
    }

    public enum DxfFontType
    {
        TTF = 0,
        SHX = 1
    }

    public enum DxfDimensionType
    {
        RotatedHorizontalOrVertical = 0,
        Aligned = 1,
        Angular = 2,
        Diameter = 3,
        Radius = 4,
        AngularThreePoint = 5,
        Ordinate = 6
    }

    public enum DxfAttachmentPoint
    {
        TopLeft = 1,
        TopCenter = 2,
        TopRight = 3,
        MiddleLeft = 4,
        MiddleCenter = 5,
        MiddleRight = 6,
        BottomLeft = 7,
        BottomCenter = 8,
        BottomRight = 9
    }

    public enum DxfTextLineSpacingStyle
    {
        AtLeast = 1,
        Exact = 2
    }

    public enum DxfHelixConstraint
    {
        ConstrainTurnHeight = 0,
        ConstrainTurns = 1,
        ConstrainHeight = 2
    }

    public enum DxfLightType
    {
        Distant = 1,
        Point = 2,
        Spot = 3
    }

    public enum DxfLightAttenuationType
    {
        None = 0,
        InverseLinear = 1,
        InverseSquare = 2
    }

    public enum DxfTextAttachmentDirection
    {
        Horizontal = 0,
        Vertical = 1
    }

    public enum DxfBottomTextAttachmentDirection
    {
        Center = 9,
        UnderlineAndCenter = 10
    }

    public enum DxfTopTextAttachmentDirection
    {
        Center = 9,
        OverlineAndCenter = 10
    }

    public enum DxfDrawingDirection
    {
        LeftToRight = 1,
        TopToBottom = 3,
        ByStyle = 5
    }

    public enum DxfMTextLineSpacingStyle
    {
        AtLeast = 1,
        Exact = 2
    }

    public enum DxfBackgroundFillSetting
    {
        Off = 0,
        UseBackgroundFillColor = 1,
        UseDrawingWindowColor = 2
    }

    public enum DxfMTextFlag
    {
        MultilineAttribute = 2,
        ConstantMultilineAttributeDefinition = 4
    }

    public abstract partial class DxfEntity : IDxfHasXData
    {
        internal List<DxfCodePair> InternalExcessCodePairs { get; } = new List<DxfCodePair>();

        public IReadOnlyList<DxfCodePair> ExcessCodePairs => InternalExcessCodePairs;

        public IList<DxfCodePairGroup> ExtensionDataGroups { get; } = new ListNonNull<DxfCodePairGroup>();

        public IDictionary<string, DxfXDataApplicationItemCollection> XData { get; } = new DictionaryWithPredicate<string, DxfXDataApplicationItemCollection>((_key, value) => value != null);

        public abstract DxfEntityType EntityType { get; }
        internal DxfPointer ReactorsPointer { get; set; } = new DxfPointer();

        protected virtual DxfAcadVersion MinVersion
        {
            get { return DxfAcadVersion.Min; }
        }

        protected virtual DxfAcadVersion MaxVersion
        {
            get { return DxfAcadVersion.Max; }
        }

        public byte[] PreviewImageData { get; set; }

        protected DxfEntity()
        {
            Initialize();
            ExtensionDataGroups = new ListNonNull<DxfCodePairGroup>();
        }

        protected virtual void AddTrailingCodePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles)
        {
        }

        internal virtual void AddObjectsToOutput(List<DxfObject> objects)
        {
        }

        protected virtual void CopyManualValues(DxfEntity other)
        {
        }

        protected virtual void AppliedCodePair(DxfCodePair pair)
        {
        }

        protected void PostParseBaseEntity()
        {
            PreviewImageData = BinaryHelpers.CombineBytes(_previewImageDataBytes);
            _previewImageDataBytes.Clear();
        }

        protected virtual DxfEntity PostParse()
        {
            return this;
        }

        protected abstract IEnumerable<DxfPoint> GetExtentsPoints();

        public DxfBoundingBox? GetBoundingBox()
        {
            return DxfBoundingBox.FromPoints(GetExtentsPoints());
        }

        public bool ApplyCodePair(DxfCodePair pair)
        {
            var success = TrySetPair(pair);
            if (success)
            {
                AppliedCodePair(pair);
            }

            return success;
        }

        public IEnumerable<DxfCodePair> GetValuePairs(DxfAcadVersion version, bool outputHandles)
        {
            var pairs = new List<DxfCodePair>();
            if (version >= MinVersion && version <= MaxVersion)
            {
                AddValuePairs(pairs, version, outputHandles, writeXData: true);
                AddTrailingCodePairs(pairs, version, outputHandles);
            }

            return pairs;
        }

        private void AddExtensionValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles)
        {
            foreach (var group in ExtensionDataGroups)
            {
                group.AddValuePairs(pairs, version, outputHandles);
            }
        }

        internal virtual DxfEntity PopulateFromBuffer(DxfCodePairBufferReader buffer)
        {
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                if (pair.Code == 0)
                {
                    break;
                }

                if (ApplyCodePair(pair))
                {
                    // pair was successfully applied; consume it
                    buffer.Advance();
                }
                else if (pair.Code == DxfCodePairGroup.GroupCodeNumber && !string.IsNullOrEmpty(pair.StringValue) && pair.StringValue == "{ACAD_REACTORS")
                {
                    buffer.Advance();
                    var groupName = DxfCodePairGroup.GetGroupName(pair.StringValue);
                    var val = DxfCodePairGroup.FromBuffer(buffer, groupName);
                    if(val.Items.Count > 0 && val.Items[0] is DxfCodePair cp && cp.Code == 330 && !string.IsNullOrEmpty(cp.StringValue))
                    {
                        this.ReactorsPointer.Handle = HandleString(cp.StringValue);
                    }
                    //this.ReactorsHandle = HandleString(val.)
                    //this.ReactorsHandle.Add();
                }
                else if (this.TrySetExtensionData(pair, buffer))
                {
                }
                else
                {
                    // track it for later use and consume it
                    InternalExcessCodePairs.Add(pair);
                    buffer.Advance();
                }
            }

            return PostParse();
        }

        protected static bool BoolInt(int i)
        {
            return DxfCommonConverters.BoolInt(i);
        }

        protected static int BoolInt(bool b)
        {
            return DxfCommonConverters.BoolInt(b);
        }

        protected static bool BoolShort(short s)
        {
            return DxfCommonConverters.BoolShort(s);
        }

        protected static short BoolShort(bool b)
        {
            return DxfCommonConverters.BoolShort(b);
        }

        protected static DxfHandle HandleString(string s)
        {
            return DxfCommonConverters.HandleString(s);
        }

        protected static string HandleString(DxfHandle handle)
        {
            return DxfCommonConverters.HandleString(handle);
        }

        protected static string DefaultIfNullOrEmpty(string value, string defaultValue)
        {
            return DxfCommonConverters.DefaultIfNullOrEmpty(value, defaultValue);
        }

        private static void SwallowEntity(DxfCodePairBufferReader buffer)
        {
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                if (pair.Code == 0)
                    break;
                buffer.Advance();
            }
        }
    }
}

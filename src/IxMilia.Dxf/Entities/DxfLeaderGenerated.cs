// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfLeader class
    /// </summary>
    public partial class DxfLeader : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Leader; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R13; } }
        public string DimensionStyleName { get; set; }
        public bool UseArrowheads { get; set; }
        public DxfLeaderPathType PathType { get; set; }
        public DxfLeaderCreationAnnotationType AnnotationType { get; set; }
        public DxfLeaderHooklineDirection HooklineDirection { get; set; }
        public bool UseHookline { get; set; }
        public double TextAnnotationHeight { get; set; }
        public double TextAnnotationWidth { get; set; }
        private int _vertexCount { get; set; }
        public DxfColor OverrideColor { get; set; }
        public string AssociatedAnnotationReference { get; set; }
        public DxfVector Normal { get; set; }
        public DxfVector Right { get; set; }
        public DxfVector BlockOffset { get; set; }
        public DxfVector AnnotationOffset { get; set; }

        internal DxfLeader()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.DimensionStyleName = null;
            this.UseArrowheads = true;
            this.PathType = DxfLeaderPathType.StraightLineSegments;
            this.AnnotationType = DxfLeaderCreationAnnotationType.NoAnnotation;
            this.HooklineDirection = DxfLeaderHooklineDirection.OppositeFromHorizontalVector;
            this.UseHookline = true;
            this.TextAnnotationHeight = 1.0;
            this.TextAnnotationWidth = 1.0;
            this._vertexCount = 0;
            this.OverrideColor = DxfColor.ByBlock;
            this.AssociatedAnnotationReference = null;
            this.Normal = DxfVector.ZAxis;
            this.Right = DxfVector.XAxis;
            this.BlockOffset = DxfVector.Zero;
            this.AnnotationOffset = DxfVector.XAxis;
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            pairs.Add(new DxfCodePair(100, "AcDbLeader"));
            pairs.Add(new DxfCodePair(3, this.DimensionStyleName));
            pairs.Add(new DxfCodePair(71, BoolShort(this.UseArrowheads)));
            pairs.Add(new DxfCodePair(72, (short)this.PathType));
            pairs.Add(new DxfCodePair(73, (short)this.AnnotationType));
            pairs.Add(new DxfCodePair(74, (short)this.HooklineDirection));
            pairs.Add(new DxfCodePair(75, BoolShort(this.UseHookline)));
            pairs.Add(new DxfCodePair(40, this.TextAnnotationHeight));
            pairs.Add(new DxfCodePair(41, this.TextAnnotationWidth));
            pairs.Add(new DxfCodePair(76, (short)Vertices.Count));
            foreach (var item in Vertices)
            {
                pairs.Add(new DxfCodePair(10, item.X));
                pairs.Add(new DxfCodePair(20, item.Y));
                pairs.Add(new DxfCodePair(30, item.Z));
            }

            if (this.OverrideColor != DxfColor.ByBlock)
            {
                pairs.Add(new DxfCodePair(77, DxfColor.GetRawValue(this.OverrideColor)));
            }

            pairs.Add(new DxfCodePair(340, this.AssociatedAnnotationReference));
            pairs.Add(new DxfCodePair(210, Normal.X));
            pairs.Add(new DxfCodePair(220, Normal.Y));
            pairs.Add(new DxfCodePair(230, Normal.Z));
            pairs.Add(new DxfCodePair(211, Right.X));
            pairs.Add(new DxfCodePair(221, Right.Y));
            pairs.Add(new DxfCodePair(231, Right.Z));
            pairs.Add(new DxfCodePair(212, BlockOffset.X));
            pairs.Add(new DxfCodePair(222, BlockOffset.Y));
            pairs.Add(new DxfCodePair(232, BlockOffset.Z));
            if (version >= DxfAcadVersion.R14)
            {
                pairs.Add(new DxfCodePair(213, AnnotationOffset.X));
                pairs.Add(new DxfCodePair(223, AnnotationOffset.Y));
                pairs.Add(new DxfCodePair(233, AnnotationOffset.Z));
            }

            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }
    }
}
// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfOle2Frame class
    /// </summary>
    public partial class DxfOle2Frame : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Ole2Frame; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R14; } }
        public int VersionNumber { get; set; }
        public string Description { get; set; }
        public DxfPoint UpperLeftCorner { get; set; }
        public DxfPoint LowerRightCorner { get; set; }
        public DxfOleObjectType ObjectType { get; set; }
        public DxfTileModeDescriptor TileMode { get; set; }
        private int _binaryDataLength { get; set; }
        private IList<byte[]> _binaryDataStrings { get; set; }

        public DxfOle2Frame()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.VersionNumber = 0;
            this.Description = null;
            this.UpperLeftCorner = DxfPoint.Origin;
            this.LowerRightCorner = DxfPoint.Origin;
            this.ObjectType = DxfOleObjectType.Static;
            this.TileMode = DxfTileModeDescriptor.InTiledViewport;
            this._binaryDataLength = 0;
            this._binaryDataStrings = new ListNonNull<byte[]>();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            pairs.Add(new DxfCodePair(100, "AcDbOle2Frame"));
            pairs.Add(new DxfCodePair(70, (short)this.VersionNumber));
            pairs.Add(new DxfCodePair(3, this.Description));
            pairs.Add(new DxfCodePair(10, UpperLeftCorner.X));
            pairs.Add(new DxfCodePair(20, UpperLeftCorner.Y));
            pairs.Add(new DxfCodePair(30, UpperLeftCorner.Z));
            pairs.Add(new DxfCodePair(11, LowerRightCorner.X));
            pairs.Add(new DxfCodePair(21, LowerRightCorner.Y));
            pairs.Add(new DxfCodePair(31, LowerRightCorner.Z));
            pairs.Add(new DxfCodePair(71, (short)this.ObjectType));
            pairs.Add(new DxfCodePair(72, (short)this.TileMode));
            if ((Data?.Length ?? 0) > 0)
            {
                pairs.Add(new DxfCodePair(90, Data.Length));
                foreach (var chunk in BinaryHelpers.ChunkBytes(Data))
                {
                    pairs.Add(new DxfCodePair(310, chunk));
                }
            }

            pairs.Add(new DxfCodePair(1, "OLE"));
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 3:
                    this.Description = pair.StringValue;
                    break;
                case 10:
                    this.UpperLeftCorner = this.UpperLeftCorner.WithUpdatedX(pair.DoubleValue);
                    break;
                case 20:
                    this.UpperLeftCorner = this.UpperLeftCorner.WithUpdatedY(pair.DoubleValue);
                    break;
                case 30:
                    this.UpperLeftCorner = this.UpperLeftCorner.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 11:
                    this.LowerRightCorner = this.LowerRightCorner.WithUpdatedX(pair.DoubleValue);
                    break;
                case 21:
                    this.LowerRightCorner = this.LowerRightCorner.WithUpdatedY(pair.DoubleValue);
                    break;
                case 31:
                    this.LowerRightCorner = this.LowerRightCorner.WithUpdatedZ(pair.DoubleValue);
                    break;
                case 70:
                    this.VersionNumber = (int)pair.ShortValue;
                    break;
                case 71:
                    this.ObjectType = (DxfOleObjectType)pair.ShortValue;
                    break;
                case 72:
                    this.TileMode = (DxfTileModeDescriptor)pair.ShortValue;
                    break;
                case 90:
                    this._binaryDataLength = pair.IntegerValue;
                    break;
                case 310:
                    this._binaryDataStrings.Add(pair.BinaryValue);
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }

        protected override IEnumerable<DxfPoint> GetExtentsPoints()
        {
            return null;
        }
    }
}

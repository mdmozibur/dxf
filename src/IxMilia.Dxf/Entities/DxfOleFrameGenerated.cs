// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Objects;

namespace IxMilia.Dxf.Entities
{
    /// <summary>
    /// DxfOleFrame class
    /// </summary>
    public partial class DxfOleFrame : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.OleFrame; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R13; } }
        public int VersionNumber { get; set; }
        private int _binaryDataLength { get; set; }
        private IList<byte[]> _binaryDataStrings { get; set; }

        public DxfOleFrame()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.VersionNumber = 0;
            this._binaryDataLength = 0;
            this._binaryDataStrings = new ListNonNull<byte[]>();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            pairs.Add(new DxfCodePair(100, "AcDbOleFrame"));
            pairs.Add(new DxfCodePair(70, (short)this.VersionNumber));
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
                case 70:
                    this.VersionNumber = (int)pair.ShortValue;
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

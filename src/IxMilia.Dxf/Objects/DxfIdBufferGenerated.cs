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
    /// DxfIdBuffer class
    /// </summary>
    public partial class DxfIdBuffer : DxfObject, IDxfItemInternal
    {
        public override DxfObjectType ObjectType { get { return DxfObjectType.IdBuffer; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R14; } }

        IEnumerable<DxfPointer> IDxfItemInternal.GetPointers()
        {
            foreach (var pointer in EntitiesPointers.Pointers)
            {
                yield return pointer;
            }
        }

        IEnumerable<IDxfItemInternal> IDxfItemInternal.GetChildItems()
        {
            return ((IDxfItemInternal)this).GetPointers().Select(p => (IDxfItemInternal)p.Item);
        }

        internal DxfPointerList<DxfEntity> EntitiesPointers { get; } = new DxfPointerList<DxfEntity>();
        public IList<DxfEntity> Entities { get { return EntitiesPointers; } }

        public DxfIdBuffer()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles, bool writeXData)
        {
            base.AddValuePairs(pairs, version, outputHandles, writeXData: false);
            if (version >= DxfAcadVersion.R13)
            {
                pairs.Add(new DxfCodePair(100, "AcDbIdBuffer"));
            }
            pairs.AddRange(this.EntitiesPointers.Pointers.Where(p => p.Handle.Value != 0).Select(p => new DxfCodePair(330, DxfCommonConverters.HandleString(p.Handle))));
            if (writeXData)
            {
                DxfXData.AddValuePairs(XData, pairs, version, outputHandles);
            }
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 330:
                    this.EntitiesPointers.Pointers.Add(new DxfPointer(DxfCommonConverters.HandleString(pair.StringValue)));
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Entities;
using IxMilia.Dxf.Sections;

namespace IxMilia.Dxf.Blocks
{
    public partial class DxfBlock : IDxfItemInternal, IDxfHasXData
    {
        internal const string BlockText = "BLOCK";
        internal const string EndBlockText = "ENDBLK";
        internal const string AcDbEntityText = "AcDbEntity";
        internal const string AcDbBlockBeginText = "AcDbBlockBegin";
        internal const string AcDbBlockEndText = "AcDbBlockEnd";

        private int Flags = 0;

        public DxfHandle Handle { get; internal set; }
        public IDxfItem Owner { get; private set; }
        DxfHandle IDxfItemInternal.OwnerHandle { get; set; }
        void IDxfItemInternal.SetOwner(IDxfItem owner)
        {
            Owner = owner;
        }
        IEnumerable<DxfPointer> IDxfItemInternal.GetPointers()
        {
            yield return _endBlockPointer;
        }
        IEnumerable<IDxfItemInternal> IDxfItemInternal.GetChildItems()
        {
            foreach (var entity in Entities)
            {
                yield return entity;
            }
            foreach (var pointer in ((IDxfItemInternal)this).GetPointers())
            {
                yield return (IDxfItemInternal)pointer.Item;
            }
        }

        private DxfPointer _endBlockPointer { get; } = new DxfPointer();

        public bool IsInPaperSpace { get; set; }
        public string Layer { get; set; }
        public string Name { get; set; }
        public DxfPoint BasePoint { get; set; }
        public string XrefName { get; set; }
        public IList<DxfEntity> Entities { get; }
        public string Description { get; set; }
        public IDictionary<string, DxfXDataApplicationItemCollection> XData { get; } = new DictionaryWithPredicate<string, DxfXDataApplicationItemCollection>((_key, value) => value != null);
        public IList<DxfCodePairGroup> ExtensionDataGroups { get; }
        private DxfEndBlock EndBlock
        {
            get { return _endBlockPointer.Item as DxfEndBlock; }
            set { _endBlockPointer.Item = value; }
        }

        public bool IsAnonymous
        {
            get { return DxfHelpers.GetFlag(Flags, 1); }
            set { DxfHelpers.SetFlag(value, ref Flags, 1); }
        }

        public bool HasAttributeDefinitions
        {
            get { return DxfHelpers.GetFlag(Flags, 2); }
            set { DxfHelpers.SetFlag(value, ref Flags, 2); }
        }

        public bool IsXref
        {
            get { return DxfHelpers.GetFlag(Flags, 4); }
            set { DxfHelpers.SetFlag(value, ref Flags, 4); }
        }

        public bool IsXrefOverlay
        {
            get { return DxfHelpers.GetFlag(Flags, 8); }
            set { DxfHelpers.SetFlag(value, ref Flags, 8); }
        }

        public bool IsExternallyDependent
        {
            get { return DxfHelpers.GetFlag(Flags, 16); }
            set { DxfHelpers.SetFlag(value, ref Flags, 16); }
        }

        public bool IsResolved
        {
            get { return DxfHelpers.GetFlag(Flags, 32); }
            set { DxfHelpers.SetFlag(value, ref Flags, 32); }
        }

        public bool IsReferencedExternally
        {
            get { return DxfHelpers.GetFlag(Flags, 64); }
            set { DxfHelpers.SetFlag(value, ref Flags, 64); }
        }

        public DxfBlock()
        {
            Layer = "0";
            BasePoint = DxfPoint.Origin;
            Entities = new ListNonNull<DxfEntity>();
            ExtensionDataGroups = new ListNonNull<DxfCodePairGroup>();
            EndBlock = new DxfEndBlock(this);
        }

        internal IEnumerable<DxfCodePair> GetValuePairs(DxfAcadVersion version, bool outputHandles)
        {
            var list = new List<DxfCodePair>();
            list.Add(new DxfCodePair(0, BlockText));
            if (outputHandles && version >= DxfAcadVersion.R13 && ((IDxfItemInternal)this).Handle.Value != 0)
            {
                list.Add(new DxfCodePair(5, DxfCommonConverters.HandleString(((IDxfItemInternal)this).Handle)));
            }

            if (version >= DxfAcadVersion.R14)
            {
                foreach (var group in ExtensionDataGroups)
                {
                    group.AddValuePairs(list, version, outputHandles);
                }
            }

            if (version >= DxfAcadVersion.R13)
            {
                if (((IDxfItemInternal)this).OwnerHandle.Value != 0)
                {
                    list.Add(new DxfCodePair(330, DxfCommonConverters.HandleString(((IDxfItemInternal)this).OwnerHandle)));
                }

                list.Add(new DxfCodePair(100, AcDbEntityText));
            }

            if (IsInPaperSpace)
            {
                list.Add(new DxfCodePair(67, DxfCommonConverters.BoolShort(IsInPaperSpace)));
            }

            list.Add(new DxfCodePair(8, Layer));
            if (version >= DxfAcadVersion.R13)
            {
                list.Add(new DxfCodePair(100, AcDbBlockBeginText));
            }

            list.Add(new DxfCodePair(2, Name));
            list.Add(new DxfCodePair(70, (short)Flags));
            list.Add(new DxfCodePair(10, BasePoint.X));
            list.Add(new DxfCodePair(20, BasePoint.Y));
            list.Add(new DxfCodePair(30, BasePoint.Z));
            if (version >= DxfAcadVersion.R12)
            {
                list.Add(new DxfCodePair(3, Name));
            }

            list.Add(new DxfCodePair(1, XrefName));

            if (!string.IsNullOrEmpty(Description))
            {
                list.Add(new DxfCodePair(4, Description));
            }

            // entities in blocks need handles for some applications
            list.AddRange(Entities.SelectMany(e => e.GetValuePairs(version, outputHandles)));

            list.AddRange(EndBlock.GetValuePairs(version, outputHandles));

            return list;
        }

        internal static DxfBlock FromBuffer(DxfCodePairBufferReader buffer)
        {
            if (!buffer.ItemsRemain)
            {
                return null;
            }

            var block = new DxfBlock();
            var readingBlockStart = true;
            var readingBlockEnd = false;
            var entities = new List<DxfEntity>();
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                if (DxfCodePair.IsSectionEnd(pair))
                {
                    // done reading blocks
                    buffer.Advance(); // swallow (0, ENDSEC)
                    break;
                }
                else if (IsBlockStart(pair))
                {
                    if (readingBlockStart)
                    {
                        // if another block is found, stop reading this one because some blocks don't specify (0, ENDBLK)
                        break;
                    }

                    break;
                }
                else if (IsBlockEnd(pair))
                {
                    if (!readingBlockStart) throw new DxfReadException("Unexpected block end", pair);
                    readingBlockStart = false;
                    readingBlockEnd = true;
                    buffer.Advance(); // swallow (0, ENDBLK)
                }
                else if (pair.Code == 0)
                {
                    // should be an entity
                    var entity = DxfEntity.FromBuffer(buffer);
                    if (entity != null)
                    {
                        // entity could be null if it's unsupported
                        entities.Add(entity);
                    }
                }
                else
                {
                    // read value pair
                    if (readingBlockStart)
                    {
                        buffer.Advance();
                        switch (pair.Code)
                        {
                            case 1:
                                block.XrefName = pair.StringValue;
                                break;
                            case 2:
                                block.Name = pair.StringValue;
                                break;
                            case 3:
                                break;
                            case 4:
                                block.Description = pair.StringValue;
                                break;
                            case 5:
                                block.Handle = DxfCommonConverters.HandleString(pair.StringValue);
                                break;
                            case 8:
                                block.Layer = pair.StringValue;
                                break;
                            case 10:
                                block.BasePoint = block.BasePoint.WithUpdatedX(pair.DoubleValue);
                                break;
                            case 20:
                                block.BasePoint = block.BasePoint.WithUpdatedY(pair.DoubleValue);
                                break;
                            case 30:
                                block.BasePoint = block.BasePoint.WithUpdatedZ(pair.DoubleValue);
                                break;
                            case 67:
                                block.IsInPaperSpace = DxfCommonConverters.BoolShort(pair.ShortValue);
                                break;
                            case 70:
                                block.Flags = pair.ShortValue;
                                break;
                            case 330:
                                ((IDxfItemInternal)block).OwnerHandle = DxfCommonConverters.HandleString(pair.StringValue);
                                break;
                            case DxfCodePairGroup.GroupCodeNumber:
                                var groupName = DxfCodePairGroup.GetGroupName(pair.StringValue);
                                block.ExtensionDataGroups.Add(DxfCodePairGroup.FromBuffer(buffer, groupName));
                                break;
                            case (int)DxfXDataType.ApplicationName:
                                DxfXData.PopulateFromBuffer(buffer, block.XData, pair.StringValue);
                                break;
                        }
                    }
                    else if (readingBlockEnd)
                    {
                        block.EndBlock.ApplyCodePairs(buffer);
                    }
                    else
                    {
                        throw new DxfReadException("Unexpected pair in block", pair);
                    }
                }
            }

            var collected = DxfEntitiesSection.GatherEntities(entities);
            foreach (var entity in collected)
            {
                block.Entities.Add(entity);
            }

            return block;
        }

        private static bool IsBlockStart(DxfCodePair pair)
        {
            return pair.Code == 0 && pair.StringValue == BlockText;
        }

        private static bool IsBlockEnd(DxfCodePair pair)
        {
            return pair.Code == 0 && pair.StringValue == EndBlockText;
        }
    }
}

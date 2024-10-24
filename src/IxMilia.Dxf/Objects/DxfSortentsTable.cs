namespace IxMilia.Dxf.Objects
{
    public partial class DxfSortentsTable
    {
        internal override DxfObject PopulateFromBuffer(DxfCodePairBufferReader buffer)
        {
            var isReadyForSortHandles = false;
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                if (pair.Code == 0)
                {
                    break;
                }

                while (this.TrySetExtensionData(pair, buffer))
                {
                    pair = buffer.Peek();
                }

                if (pair.Code == 0)
                {
                    break;
                }

                switch (pair.Code)
                {
                    case 5:
                        if (isReadyForSortHandles)
                        {
                            SortItemsPointers.Pointers.Add(new DxfPointer(DxfCommonConverters.HandleString(pair.StringValue)));
                        }
                        else
                        {
                            ((DxfObject)this).Handle = DxfCommonConverters.HandleString(pair.StringValue);
                            isReadyForSortHandles = true;
                        }
                        break;
                    case 100:
                        isReadyForSortHandles = true;
                        break;
                    case 330:
                        ((IDxfItemInternal)this).OwnerHandle = DxfCommonConverters.HandleString(pair.StringValue);
                        isReadyForSortHandles = true;
                        break;
                    case 331:
                        EntitiesPointers.Pointers.Add(new DxfPointer(DxfCommonConverters.HandleString(pair.StringValue)));
                        isReadyForSortHandles = true;
                        break;
                    default:
                        if (!base.TrySetPair(pair))
                        {
                            InternalExcessCodePairs.Add(pair);
                        }
                        break;
                }

                buffer.Advance();
            }

            return PostParse();
        }
    }
}

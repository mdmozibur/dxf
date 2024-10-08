// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System.Linq;
using System.Collections.Generic;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Sections;

namespace IxMilia.Dxf.Tables
{
    public partial class DxfAppIdTable : DxfTable
    {
        internal override DxfTableType TableType { get { return DxfTableType.AppId; } }

        public IList<DxfAppId> Items { get; private set; }

        protected override IEnumerable<DxfSymbolTableFlags> GetSymbolItems()
        {
            return Items.Cast<DxfSymbolTableFlags>();
        }

        public DxfAppIdTable()
        {
            Items = new ListNonNull<DxfAppId>();
            Normalize();
        }

        internal static DxfTable ReadFromBuffer(DxfCodePairBufferReader buffer)
        {
            var table = new DxfAppIdTable();
            table.Items.Clear();
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                buffer.Advance();
                if (DxfTablesSection.IsTableEnd(pair))
                {
                    break;
                }

                if (pair.Code == 0 && pair.StringValue == DxfTable.AppIdText)
                {
                    var item = DxfAppId.FromBuffer(buffer);
                    table.Items.Add(item);
                }
            }

            return table;
        }
    }
}

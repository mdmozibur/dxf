// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System.Linq;
using System.Collections.Generic;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Sections;

namespace IxMilia.Dxf.Tables
{
    public partial class DxfBlockRecordTable : DxfTable
    {
        internal override DxfTableType TableType { get { return DxfTableType.BlockRecord; } }

        public IList<DxfBlockRecord> Items { get; private set; }

        protected override IEnumerable<DxfSymbolTableFlags> GetSymbolItems()
        {
            return Items.Cast<DxfSymbolTableFlags>();
        }

        public DxfBlockRecordTable()
        {
            Items = new ListNonNull<DxfBlockRecord>();
            Normalize();
        }

        internal static DxfTable ReadFromBuffer(DxfCodePairBufferReader buffer)
        {
            var table = new DxfBlockRecordTable();
            table.Items.Clear();
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                buffer.Advance();
                if (DxfTablesSection.IsTableEnd(pair))
                {
                    break;
                }

                if (pair.Code == 0 && pair.StringValue == DxfTable.BlockRecordText)
                {
                    var item = DxfBlockRecord.FromBuffer(buffer);
                    table.Items.Add(item);
                }
            }

            return table;
        }
    }
}

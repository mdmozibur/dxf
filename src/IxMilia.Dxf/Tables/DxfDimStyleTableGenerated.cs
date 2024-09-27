// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System.Linq;
using System.Collections.Generic;
using IxMilia.Dxf.Collections;
using IxMilia.Dxf.Sections;

namespace IxMilia.Dxf.Tables
{
    public partial class DxfDimStyleTable : DxfTable
    {
        internal override DxfTableType TableType { get { return DxfTableType.DimStyle; } }
        internal override string TableClassName { get { return "AcDbDimStyleTable"; } }

        public IList<DxfDimStyle> Items { get; private set; }

        protected override IEnumerable<DxfSymbolTableFlags> GetSymbolItems()
        {
            return Items.Cast<DxfSymbolTableFlags>();
        }

        public DxfDimStyleTable()
        {
            Items = new ListNonNull<DxfDimStyle>();
            Normalize();
        }

        internal static DxfTable ReadFromBuffer(DxfCodePairBufferReader buffer)
        {
            var table = new DxfDimStyleTable();
            table.Items.Clear();
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                buffer.Advance();
                if (DxfTablesSection.IsTableEnd(pair))
                {
                    break;
                }

                if (pair.Code == 0 && pair.StringValue == DxfTable.DimStyleText)
                {
                    var item = DxfDimStyle.FromBuffer(buffer);
                    table.Items.Add(item);
                }
            }

            return table;
        }
    }
}
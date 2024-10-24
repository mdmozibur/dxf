namespace IxMilia.Dxf
{
    public interface IDxfItem
    {
        IDxfItem Owner { get; }
        DxfHandle Handle { get; }
    }
}

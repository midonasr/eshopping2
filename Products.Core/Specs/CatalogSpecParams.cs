namespace Products.Core.Specs;

public class CatalogSpecParams
{
    private const int MaxPageSize = 70;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public string? Sort { get; set; }
    public string? Search{ get; set; }

}
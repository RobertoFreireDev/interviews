namespace Application.Dtos.DataContracts.Request;

public class GetProductsRequest
{
    [Required]
    public string SearchTerm { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;

    [Required]
    [Range(1, 100)]
    public int PageSize { get; set; } = 10;
}

namespace ApplicationCore.Model.Response;

// Used for Pagination
public class PaginatedResultSet<T>
{
    public IEnumerable<T> Items { get; set; } // The list of items
    public int PageNumber { get; set; } // Current page number
    public int PageSize { get; set; } // Number of items per page
    public int TotalItems { get; set; } // Total number of items
    public int TotalPages => (int)System.Math.Ceiling((double)TotalItems / PageSize); // Total pages
    public bool HasPreviousPage => PageNumber > 1; // Check if there's a previous page
    public bool HasNextPage => PageNumber < TotalPages; // Check if there's a next page
}
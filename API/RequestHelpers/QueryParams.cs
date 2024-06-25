namespace API.RequestHelpers
{
    public class QueryParams : PaginationParams
    {
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
    }
}
using System.Text.Json;
using API.RequestHelpers;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationMetaData paginationMetaData)
        {
            var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationMetaData, options));
            response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
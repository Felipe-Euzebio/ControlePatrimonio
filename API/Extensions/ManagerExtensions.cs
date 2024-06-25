using API.Entities;

namespace API.Extensions
{
    public static class ManagerExtensions
    {
        public static IQueryable<Manager> Sort(this IQueryable<Manager> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(m => m.ManagerName);

            query = orderBy switch
            {
                "managerName" => query.OrderBy(m => m.ManagerName),
                "managerNameDesc" => query.OrderByDescending(m => m.ManagerName),
                "managerPhoneNumber" => query.OrderBy(m => m.ManagerPhoneNumber),
                "managerPhoneNumberDesc" => query.OrderByDescending(m => m.ManagerPhoneNumber),
                _ => query.OrderBy(m => m.ManagerName)
            };

            return query;
        }
    }
}
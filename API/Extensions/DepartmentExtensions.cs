using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Extensions
{
    public static class DepartmentExtensions
    {
        public static IQueryable<Department> Sort(this IQueryable<Department> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(d => d.DepartmentName);

            query = orderBy switch
            {
                "departmentName" => query.OrderBy(d => d.DepartmentName),
                "departmentNameDesc" => query.OrderByDescending(d => d.DepartmentName),
                _ => query.OrderBy(d => d.DepartmentId)
            };

            return query;
        }

        public static IQueryable<Department> Search(this IQueryable<Department> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(d => d.DepartmentName.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
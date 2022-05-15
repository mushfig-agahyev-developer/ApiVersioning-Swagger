using ApiProjectModul.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjectModul.Exteensions
{
    public static class QueryParametersExtensions
    {
        public static bool HasPrevious(this QueryParameters queryParameters)
        {
            return (queryParameters.Page > 1);
        }

        public static bool HasNext(this QueryParameters queryParameters, int totalCount)
        {
            return (queryParameters.Page < (int)GetTotalPages(queryParameters, totalCount));
        }

        public static double GetTotalPages(this QueryParameters queryParameters, int totalCount)
        {
            return Math.Ceiling(totalCount / (double)queryParameters.PageCount);
        }

        public static bool HasQuery(this QueryParameters queryParameters)
        {
            return !String.IsNullOrEmpty(queryParameters.Query);
        }

        public static bool IsDescending(this QueryParameters queryParameters)
        {
            if (!String.IsNullOrEmpty(queryParameters.OrderBy))
            { 
                var kkk = queryParameters.OrderBy.Split(' ').Last().ToLowerInvariant().StartsWith("desc");
                var kkk1 = queryParameters.OrderBy.Split(' ');
                var kkk2 = queryParameters.OrderBy.Split(' ').Last();
                var kkk3 = queryParameters.OrderBy.Split(' ').Last().ToLowerInvariant();
                var kkk4 = queryParameters.OrderBy.Split(' ').Last().ToLowerInvariant().StartsWith("desc");

                return queryParameters.OrderBy.Split(' ').Last().ToLowerInvariant().StartsWith("desc");
            }
            return false;
        }
    }
}

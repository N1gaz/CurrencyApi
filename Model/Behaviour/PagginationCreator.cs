using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Behaviour
{
    public static class PagginationCreator
    {
        public static List<Currency> GetPageEntities(this List<Currency> source, int pageNumber, int pageSize)
        {
            int minPageSize = (source.Count % pageSize) == 0 ? pageSize : (source.Count % pageSize);
            int lastPage = source.Count / pageSize - (minPageSize == pageSize ? 1 : 0) ;


            if (pageNumber < lastPage)
            {
                return source.GetRange(pageNumber * pageSize, pageSize);
            }
            else if (pageNumber == lastPage)
            {
                return source.GetRange(pageNumber * pageSize, minPageSize);
            }
            else
                throw new ArgumentException("Invalid page number");
            
        }
    }
}

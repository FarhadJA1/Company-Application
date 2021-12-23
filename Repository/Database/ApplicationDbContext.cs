using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Database
{
    public static class ApplicationDbContext<T>
    {
        public static List<T> database { get; }
        static ApplicationDbContext()
        {
            database = new List<T>();
        }

    }
}

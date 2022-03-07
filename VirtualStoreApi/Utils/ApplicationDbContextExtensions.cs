using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Context;

namespace VirtualStoreApi.Utils
{
    public static class ApplicationDbContextExtensions
    {
        public static void Reset(this ApplicationDbContext context)
        {
            if (context != null)
            {
                context.Database.EnsureCreated();
            }
        }
    }
}

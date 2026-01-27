using FN.Common.Common;

namespace FN.DataLayer.DataContext
{
    public static class ConnectionDataInitializer
    {
        public static void Initialize(ConnectionDataContext context, bool useInMemoryDatabase)
        {
            if (!useInMemoryDatabase)
            {
                context.Database.EnsureCreated();
            }            
        }
    }
}

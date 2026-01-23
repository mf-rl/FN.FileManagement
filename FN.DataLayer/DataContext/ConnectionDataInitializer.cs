using FN.Common.Common;

namespace FN.DataLayer.DataContext
{
    public static class ConnectionDataInitializer
    {
        public static void Initialize(ConnectionDataContext context)
        {
            if (StaticConfigs.GetConfig("UseInMemoryDatabase") != "true")
            {
                context.Database.EnsureCreated();
            }            
        }
    }
}

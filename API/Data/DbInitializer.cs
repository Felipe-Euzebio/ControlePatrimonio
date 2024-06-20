namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Managers.Any()) return;

            var managers = DbInitializerSeeds.GetManagers();

            context.Managers.AddRange(managers);

            context.SaveChanges();
        }
    }
}
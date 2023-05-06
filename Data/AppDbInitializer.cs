namespace CRUD_OPERATION_2.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceSope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceSope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Employee_table.Any())
                {

                }
            }
        }
    }
}

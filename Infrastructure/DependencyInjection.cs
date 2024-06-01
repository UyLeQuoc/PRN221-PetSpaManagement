using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services)
        {
            //Add Repositories, Services


            //Add UnitOfWork


            //Add CurrentTime


            return services;
        }
    }
}

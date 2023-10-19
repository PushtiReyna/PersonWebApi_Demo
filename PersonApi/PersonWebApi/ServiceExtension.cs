using BusinessLayer;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;

namespace PersonWebApi
{
    public static class ServiceExtensions
    {
        public static void DIScopes(this IServiceCollection services)
        {

            //interface
            services.AddScoped<IPerson, PersonImpl>();
            //bll
            services.AddScoped<PersonBLL>();

        }
    }
 }

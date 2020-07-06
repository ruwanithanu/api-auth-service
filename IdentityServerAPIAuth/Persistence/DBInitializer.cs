using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace IdentityServerAPIAuth.Persistence
{
    public class DBInitializer
    {
        public static void InitialiseIdentityServerDB(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                foreach (var client in IdentityServerConfig.GetClients())
                {
                    if (!context.Clients.Any(x => x.ClientId == client.ClientId))
                        context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();

                foreach (var resource in IdentityServerConfig.GetApis())
                {
                    if (!context.ApiResources.Any(x => x.Name == resource.Name))
                        context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }
    }
}

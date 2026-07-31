using CleanArchitecture.Application.Items;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection builder)
    {
        IncludeItemHandlers.Include(builder);
    }
}
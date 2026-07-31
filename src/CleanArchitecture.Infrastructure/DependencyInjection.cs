using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static void Configuration(this IServiceCollection builder, string connectionString)
    {
        builder.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        builder.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));
        builder.AddScoped<IUnitOfWork, UnitOfWork>();
    }


    public static void AddRepositories(this IServiceCollection builder)
    {
        builder.AddScoped<IItemRepository, ItemRepository>();
    }

    public static void AddReadGateways(this IServiceCollection builder)
    {
    }
}